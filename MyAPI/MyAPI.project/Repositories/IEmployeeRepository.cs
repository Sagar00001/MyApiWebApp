using MyAPI.project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.project.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int? Id);

        Task<int> AddEmployeeAsync(Employee emp);

        Task<int> DeleteEmployee(int? Id);

        Task UpdateEmployee(Employee emp);
    }
}
