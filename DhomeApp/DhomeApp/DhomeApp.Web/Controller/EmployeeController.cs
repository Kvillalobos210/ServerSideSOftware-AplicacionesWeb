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
    public class EmployeeController : ControllerBase
    {
        private readonly DbContextDhomeApp _context;

        public EmployeeController(DbContextDhomeApp context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<IEnumerable<EmployeeModel>> GetEmployee()  
        {
            var employeeList = await _context.Employee.ToListAsync();

            return employeeList.Select(e => new EmployeeModel
            {
                EmployeeId = e.EmployeeId,
                Firstname = e.Firstname,
                Lastname = e.Lastname,
                Dni = e.Dni,
                Cellphone = e.Cellphone,
                Description = e.Description,
                SpecialtyId=e.SpecialtyId,
                DistrictId=e.DistrictId
            });
        }

        // GET: api/Employee/GetEmployeeById/{id}
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(new EmployeeModel
            {
                EmployeeId = employee.EmployeeId,
                Firstname = employee.Firstname,
                Lastname = employee.Lastname,
                Dni = employee.Dni,
                Cellphone = employee.Cellphone,
                Description = employee.Description,
                SpecialtyId=employee.SpecialtyId,
                DistrictId=employee.DistrictId
            });
        }

        //Actualizar
        // PUT: api/Employee/PutEmployee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutEmployee([FromBody] PostEmployeeModel cmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (cmodel.EmployeeId <= 0)
                return BadRequest();

            var employee = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeId == cmodel.EmployeeId);

            if (employee == null)
                return NotFound();
            employee.Firstname = cmodel.Firstname;
            employee.Lastname = cmodel.Lastname;
            employee.Dni = cmodel.Dni;
            employee.Email = cmodel.Email;
            employee.Description = cmodel.Description;
            employee.Cellphone = cmodel.Cellphone;
            employee.IdAccount = cmodel.IdAccount;
            employee.SpecialtyId = cmodel.SpecialtyId;
            employee.DistrictId = cmodel.DistrictId;

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
        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] PostEmployeeModel cmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Employee employee = new Employee
            {
                Firstname = cmodel.Firstname,
                Lastname = cmodel.Lastname,
                Dni = cmodel.Dni,
                Email = cmodel.Email,
                Description = cmodel.Description,
                Cellphone = cmodel.Cellphone,
                IdAccount = cmodel.IdAccount,
                SpecialtyId=cmodel.SpecialtyId,
                DistrictId=cmodel.DistrictId
            };

            _context.Employee.Add(employee);

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

        // DELETE: api/Employee/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);

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