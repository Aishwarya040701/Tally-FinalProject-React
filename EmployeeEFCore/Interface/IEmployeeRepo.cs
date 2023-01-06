using EmployeeEFCore.DTO;
using EmployeeEFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeEFCore.Interface
{
    public interface IEmployeeRepo
    {
      //Declaring Methods
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        Employee PostEmployee(Employee employee);
        Employee PutEmployee(Employee employee);
        bool DeleteEmployee(int id);

        bool checkId(int id);
        

        void Save();


    }
}
