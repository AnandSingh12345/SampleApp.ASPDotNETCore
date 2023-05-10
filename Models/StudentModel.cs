using System.ComponentModel.DataAnnotations;

namespace SampleApp.ASPDotNETCore.Models
{
    public class StudentModel
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
    }
}
