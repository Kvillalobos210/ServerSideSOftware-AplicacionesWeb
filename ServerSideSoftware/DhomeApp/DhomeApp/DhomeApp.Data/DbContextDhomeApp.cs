using Microsoft.EntityFrameworkCore;
using DhomeApp.Data.Mapping;
using DhomeApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhomeApp.Data
{
    public class DbContextDhomeApp : DbContext
    {
        public DbContextDhomeApp(DbContextOptions<DbContextDhomeApp> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            base.OnModelCreating(modelBuilder);*/
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());

        }

    }
}
