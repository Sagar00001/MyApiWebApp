using MyAPI.project.Data;
using MyAPI.project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.project.Repositories
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork()
        {

        }

        private DatabaseContext context = new DatabaseContext();
        public static EmployeeRepository employeeRepository { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }
        
    }
}
