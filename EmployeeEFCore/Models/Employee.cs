using System.ComponentModel.DataAnnotations;

namespace EmployeeEFCore.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Band { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string Responsibilities { get; set; }


    }
}
