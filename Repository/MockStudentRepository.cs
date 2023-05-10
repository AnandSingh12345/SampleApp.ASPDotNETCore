using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.ASPDotNETCore.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<StudentModel> _studentList;

        public MockStudentRepository()
        {
        }

        
        public string AddStudent(StudentModel student)
        {
            try
            {
                var filePath = @"SampleData.json";
                //var filePath = "@" + new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("File")["FileName"];
                var jsonData = System.IO.File.ReadAllText(filePath);
                // De-serialize to object or create new list
                var strStudentList = JsonConvert.DeserializeObject<List<StudentModel>>(jsonData) ?? new List<StudentModel>();

                // Add any new employees
                strStudentList.Add(new StudentModel()
                {
                    firstName = student.firstName,
                    lastName = student.lastName
                });

                // Update json data string
                jsonData = JsonConvert.SerializeObject(strStudentList);
                System.IO.File.WriteAllText(filePath, jsonData);
                return "Ok";
            }
            catch(System.Exception ex)
            {
               return ex.Message;
            }           
}
    }
}
