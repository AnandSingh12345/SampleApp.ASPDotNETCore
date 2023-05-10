using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SampleApp.ASPDotNETCore.Models;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;

namespace SampleApp.ASPDotNETCore.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IStudentRepository _studentRepository;

        public HomeController(ILogger<HomeController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateStudent()
        {
            return View();
        }        

        [HttpPost]
        public async Task<IActionResult> AddDetails([FromBody] StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter required fields");
            }
            else
            {
                try
                {
                    string strResult = _studentRepository.AddStudent(student);  
                    if(strResult == "Ok")
                    {
                        return this.Ok();
                    }
                    else
                    {
                        _logger.LogInformation($"Error generated");
                        return this.BadRequest();
                    }
                }
                catch(System.Exception ex)
                {
                    _logger.LogInformation($"Error generated");
                    return this.BadRequest();
                }                
            }
        }
    }
}
