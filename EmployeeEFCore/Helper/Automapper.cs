using AutoMapper;
using EmployeeEFCore.DTO;
using EmployeeEFCore.Models;

namespace EmployeeEFCore.Helper
{
    public class Automapper:Profile
    {

        public Automapper()
        {
            CreateMap<Employee, EmployeeDTO>();
               


            CreateMap<EmployeeDTO, Employee>();
                
        }

    
    }
}
