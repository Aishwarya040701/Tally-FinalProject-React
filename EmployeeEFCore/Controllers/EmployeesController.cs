using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeEFCore.Models;
using EmployeeEFCore.DTO;
using EmployeeEFCore.Helper;
using AutoMapper;
using EmployeeEFCore.Interface;

namespace EmployeeEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
  
        private readonly IEmployeeRepo _repo;

        //Using dependency injection
        public EmployeesController(IEmployeeRepo repo)
        {
         
            _repo = repo;

        }



        //Get method which return Status code 200(OK) with Employee list
        //if fetched Successfully else return Status code 400(BadRequest)
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try 
            {
                var result = _repo.GetEmployees().ToList();
                return Ok(result);
            }
            catch(Exception ex)
            
            {
                return BadRequest(ex);
            }

            
        }


        //GetById method which return Status code 200(OK) with Employee details
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            try
            {
                if (_repo.checkId(id))
                {
                    var result = _repo.GetEmployeeById(id);
                    return Ok(result);

                }
                return NotFound("Id does not Exists");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }

        //Post method which return Status code 200(OK) with Employee details
        //if Added Successfully else return Status code 400(BadRequest) 
        [HttpPost]
        public async Task<ActionResult> PostEmployee(Employee employee)
        {
            try
            {
                var result = _repo.PostEmployee(employee);
              
                    return Ok(result);
                
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //Put method which return Status code 200(OK) with Employee details
        //if updated Successfully else return Status code 400(BadRequest)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            try
            {
                if (_repo.checkId(id))
                {

                    var result = _repo.PutEmployee(employee);
                    return Ok(result);
                }
                return NotFound("Id does not Exists");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }


        //Delete method which return Status code 200(OK) with Employee details
        //if Deleted Successfully else return Status code 400(BadRequest)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
               

                if (_repo.checkId(id))
                {
                    var result = _repo.DeleteEmployee(id);
                    return Ok(result);
                }
                return NotFound("Id does not Exists");


            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }


        }




    }
}
