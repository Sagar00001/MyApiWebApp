using Microsoft.EntityFrameworkCore;
using MyAPI.project.Data;
using MyAPI.project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.project.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DatabaseContext db;

        public EmployeeRepository(DatabaseContext _db)
        {
            this.db = _db;
        }
        public async Task<int> AddEmployeeAsync(Employee emp)
        {
            if (db != null)
            {
                await db.employees.AddAsync(emp);
                await db.SaveChangesAsync();
                return emp.ID;
            }
            return 0;
        }

        public async Task<int> DeleteEmployee(int? Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the employee for specific employee id
                var emp = await db.employees.FirstOrDefaultAsync(x => x.ID == Id);
                if (emp != null)
                {
                    //Delete that employee
                    db.employees.Remove(emp);
                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            if (db != null)
            {
                return await db.employees.ToListAsync();
            }
            return null;
        }

        public async Task<Employee> GetEmployeeById(int? Id)
        {
            if (db != null)
            {
                return await db.employees.FirstOrDefaultAsync(x => x.ID == Id);
            }
            return null;
        }

        public async Task UpdateEmployee(Employee emp)
        {
            if (db != null)
            {
                //Delete that employee
                db.employees.Update(emp);
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
