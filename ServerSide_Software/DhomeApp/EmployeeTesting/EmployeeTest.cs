using DhomeApp.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTesting
{
    [TestFixture]
    public class EmployeeTest
    {
        [Test]
        public void Employeefirstname()
        {
            Employee employee = new();
            employee.Firstname = "Alonso";
            Assert.IsNotNull(employee.Firstname);
        }
        [Test]
        public void Employeelastname()
        {
            Employee employee = new();
            employee.Lastname = "Mendez";
            Assert.IsNotNull(employee.Lastname);
        }
        [Test]
        public void Employeedni()
        {
            Employee employee = new();
            employee.Dni = "74896532";
            Assert.IsNotNull(employee.Dni);
        }
        [Test]
        public void Employeeemail()
        {
            Employee employee = new();
            employee.Email = "Alez14@hotmail.com";
            Assert.IsNotNull(employee.Email);
        }
        /*
        [Test]
        public void Employeepassword()
        {
            Employee employee = new();
            employee.Password = "almendez";
            Assert.IsNotNull(employee.Password);
        }
        [Test]
        public void Employeecity()
        {
            Employee employee = new();
            employee.City = "Lima";
            Assert.IsNotNull(employee.City);
        }
        [Test]
        */
        public void Employeedescription()
        {
            Employee employee = new();
            employee.Description = "Trabajos en Sodimac";
            Assert.IsNotNull(employee.Description);
        }
    }
}
