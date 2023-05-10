using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.ASPDotNETCore.Models
{    
    public interface IStudentRepository
    {
        string AddStudent(StudentModel employee);
    }
}
