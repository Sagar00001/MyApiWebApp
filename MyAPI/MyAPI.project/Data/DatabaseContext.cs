using Microsoft.EntityFrameworkCore;
using MyAPI.project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.project.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Designation> designations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Name")
                    .IsUnicode(false);
                entity.Property(e => e.Designation).HasColumnName("Designation");
                entity.Property(e => e.Joining_Date).HasColumnName("Joining_Date");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.Desg_ID).HasColumnName("Desg_ID");
                entity.Property(e => e.Desg_Name)
                    .IsRequired()
                    .HasColumnName("Desg_Name")
                    .IsUnicode(false);              
            });
        }
    }
}
