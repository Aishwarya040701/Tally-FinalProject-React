using System.ComponentModel.DataAnnotations;

namespace EmployeeEFCore.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
       
        public string Name { get; set; }
    
        public string Band { get; set; }
        
        public string Role { get; set; }
      
        public string Designation { get; set; }
      
        public string Responsibilities { get; set; }
    }
}
