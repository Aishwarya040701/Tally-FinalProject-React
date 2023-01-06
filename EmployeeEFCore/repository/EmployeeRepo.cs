using AutoMapper;
using EmployeeEFCore.DTO;
using EmployeeEFCore.Interface;
using EmployeeEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EmployeeEFCore.repository
{

    //Inherits the Interface IEmployeerepo and Implement Methods
    public class EmployeeRepo : IEmployeeRepo
   
    {
       private readonly EmployeeDBContext _context;
       

        //Using dependency injection
        public EmployeeRepo(EmployeeDBContext context)
        {
            _context = context;
       

        }


        //Get method which return Employee list
        public IEnumerable<Employee> GetEmployees()
        {
            IEnumerable<Employee> employee =  _context.Employees.ToList();
     
            return employee;
           
        }


        //GetById method with parameter id return Employee details of particular Employee
        public Employee GetEmployeeById(int id)
        {
            var employee=_context.Employees.FirstOrDefault(u=>u.EmployeeId==id);
           
          
            return employee;
            
           
        }




        //Post method with parameter employee adds new employee and return Employee details of new Employee
        public Employee PostEmployee(Employee employee)
        {
            
           
                _context.Employees.Add(employee);

           
                Save();
                return employee;
          


        }

        //Put method with parameter employee updates new employee and return the same Employee details 
        public Employee PutEmployee(Employee employee)
        {
          
      
            _context.Employees.Update(employee);
          
                Save();
                return employee;
        }

        // Delete method with  parameter id deletes employee and return true if deleted successfully
        public bool DeleteEmployee(int id)
        {
            var employee= _context.Employees.FirstOrDefault(u=>u.EmployeeId==id);
           
           
                _context.Employees.Remove(employee);
                Save();
                return true;
          
        }

        //checkId method with parameter id, checks the id and return true if id is present
        public bool checkId(int id)
        {
            return _context.Employees.Any(u => u.EmployeeId == id);
        }


        //Save method saves the changes
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
