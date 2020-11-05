using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAPI.project.Models;
using MyAPI.project.Repositories;

namespace MyAPI.project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        // GET: api/Employees
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllemployees()
        {
            try
            {
                var emp = await employeeRepository.GetAllEmployees();
                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Employees/5
        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var emp = await employeeRepository.GetEmployeeById(id);
                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var empId = await employeeRepository.AddEmployeeAsync(emp);
                    if (empId > 0)
                    {
                        return Ok(empId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int? Id)
        {
            int result = 0;

            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await employeeRepository.DeleteEmployee(Id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeRepository.UpdateEmployee(emp);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
