using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DhomeApp.Data;
using DhomeApp.Entity;
using DhomeApp.Web.Models;

namespace DhomeApp.Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DbContextDhomeApp _context;

        public CustomersController(DbContextDhomeApp context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        {
            var customerList = await _context.Customer.ToListAsync();

            return customerList.Select(c => new CustomerModel
            {

                CustomerId = c.CustomerId,
                Firstname = c.Firstname,
                Lastname = c.Lastname,
                Dni = c.Dni,
                DistrictId=c.DistrictId
            });
        }

        // GET: api/Customers/GetCustomerById/{id}
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(new CustomerModel
            {
                CustomerId = customer.CustomerId,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Dni = customer.Dni,
                DistrictId = customer.DistrictId
            });
        }

        //Actualizar
        // PUT: api/Customers/PutCustomer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutCustomer([FromBody] PostCustomerModel cmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (cmodel.CustomerId <= 0)
                return BadRequest();

            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.CustomerId == cmodel.CustomerId);

            if (customer == null)
                return NotFound();
            customer.Firstname = cmodel.Firstname;
            customer.Lastname = cmodel.Lastname;
            customer.Dni = cmodel.Dni;
            customer.Email = cmodel.Email;
            customer.Cellphone = cmodel.Cellphone;
            customer.IdAccount = cmodel.IdAccount;
            customer.DistrictId = cmodel.DistrictId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        //Crear
        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] PostCustomerModel cmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = new Customer
            {
                Firstname = cmodel.Firstname,
                Lastname = cmodel.Lastname,
                Dni = cmodel.Dni,
                Email = cmodel.Email,
                Cellphone = cmodel.Cellphone,
                IdAccount = cmodel.IdAccount,
                DistrictId=cmodel.DistrictId
            };

            _context.Customer.Add(customer);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }
    }
}