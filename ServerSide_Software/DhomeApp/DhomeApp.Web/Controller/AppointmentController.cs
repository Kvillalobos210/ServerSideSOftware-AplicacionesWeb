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
    public class AppointmentController : ControllerBase
    {
        private readonly DbContextDhomeApp _context;

        public AppointmentController(DbContextDhomeApp context)
        {
            _context = context;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<IEnumerable<AppointmentModel>> GetAppointment()
        {
            var appointmentList = await _context.Appointment.ToListAsync();

            return appointmentList.Select(a => new AppointmentModel
            {
                AppointmentId = a.AppointmentId,
                CustomerId = a.CustomerId,
                EmployeeId = a.EmployeeId,
                Description = a.Description,
                AppointmentDate = a.AppointmentDate,
                Address = a.Address,
                IdPaymentMethod = a.IdPaymentMethod
            });
        }

        // GET: api/Appointment/GetAppointmentById/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAppointmentById([FromRoute] int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(new AppointmentModel
            {
                AppointmentId = appointment.AppointmentId,
                CustomerId = appointment.CustomerId,
                EmployeeId = appointment.EmployeeId,
                Description = appointment.Description,
                AppointmentDate = appointment.AppointmentDate,
                Address = appointment.Address,
                IdPaymentMethod = appointment.IdPaymentMethod
            });
        }

        // PUT: api/Appointment/PutAppointment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutAppointment([FromBody] PostAppointmentModel amodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (amodel.AppointmentId <= 0)
                return BadRequest();

            var appointment = await _context.Appointment.FirstOrDefaultAsync(a => a.AppointmentId == amodel.AppointmentId);

            if (appointment == null)
                return NotFound();

            appointment.CustomerId = amodel.CustomerId;
            appointment.EmployeeId = amodel.EmployeeId;
            appointment.Description = amodel.Description;
            appointment.AppointmentDate = amodel.AppointmentDate;
            appointment.Address = amodel.Address;
            appointment.Valorization = amodel.Valorization;
            appointment.Status = amodel.Status;
            appointment.IdPaymentMethod = amodel.IdPaymentMethod;

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

        // POST: api/Appointment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostAppointment([FromBody] PostAppointmentModel amodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Appointment appointment = new Appointment
            {
                CustomerId = amodel.CustomerId,
                EmployeeId = amodel.EmployeeId,
                Description = amodel.Description,
                AppointmentDate = amodel.AppointmentDate,
                Address = amodel.Address,
                Valorization=amodel.Valorization,
                Status = amodel.Status,
                IdPaymentMethod = amodel.IdPaymentMethod
            };


            _context.Appointment.Add(appointment);

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

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointment.Remove(appointment);
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
