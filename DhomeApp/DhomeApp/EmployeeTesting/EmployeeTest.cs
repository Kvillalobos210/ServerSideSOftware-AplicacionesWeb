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

        public void Employeedescription()
        {
            Employee employee = new();
            employee.Description = "Trabajos en Sodimac";
            Assert.IsNotNull(employee.Description);
        }
    }
}
