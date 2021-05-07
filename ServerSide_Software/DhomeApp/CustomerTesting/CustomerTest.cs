using DhomeApp.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTesting
{
    [TestFixture]
    public class CustomerTest
    {
        [Test]
        public void Customerfirstname()
        {
            Customer customer = new();

            customer.Firstname = "Valeria";

            Assert.IsNotNull(customer.Firstname);
        }

        [Test]
        public void Customerlastname()
        {
            Customer customer = new();
            customer.Lastname = "Curichimba";

            Assert.IsNotNull(customer.Lastname);
        }
        [Test]
        public void Customerdni()
        {
            Customer customer = new();
            customer.Dni = "08054789";

            Assert.IsNotNull(customer.Dni);
        }
        [Test]
        public void Customeremail()
        {
            Customer customer = new();
            customer.Email = "vale@gmail.com";

            Assert.IsNotNull(customer.Email);
        }
        /*
        [Test]
        public void Customerpassword()
        {
            Customer customer = new();
            customer.Password = "ValeVilla";

            Assert.IsNotNull(customer.Password);
        }
        [Test]
        public void Customercity()
        {
            Customer customer = new();
            customer.City = "Lima";

            Assert.IsNotNull(customer.City);
        }*/
    }
}
