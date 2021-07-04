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
    public class SpecialtyController : ControllerBase
    {
        private readonly DbContextDhomeApp _context;

        public SpecialtyController(DbContextDhomeApp context)
        {
            _context = context;
        }

        // GET: api/Specialty
        [HttpGet]
        public async Task<IEnumerable<SpecialtyModel>> GetSpecialty()
        {
            var specialtyList = await _context.Specialty.ToListAsync();
            return specialtyList.Select(s => new SpecialtyModel
            {
                SpecialtyId=s.SpecialtyId,
                SpecialtyName=s.SpecialtyName
            });
        }

        // GET: api/Specialty/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSpecialtyById([FromRoute] int id)
        {
            var specialty = await _context.Specialty.FindAsync(id);

            if (specialty == null)
            {
                return NotFound();
            }

            return Ok(new SpecialtyModel
            {
                SpecialtyId=specialty.SpecialtyId,
                SpecialtyName=specialty.SpecialtyName
            });
        }

        // PUT: api/Specialty/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutSpecialty([FromBody] SpecialtyModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.SpecialtyId <=0)
            {
                return BadRequest();
            }

            var specialty = await _context.Specialty.FirstOrDefaultAsync(s => s.SpecialtyId == model.SpecialtyId);
            if (specialty==null)
            {
                return NotFound();
            }
            specialty.SpecialtyName = model.SpecialtyName;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
            return Ok();
        }

        // POST: api/Specialty
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostSpecialty([FromBody] SpecialtyModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Specialty specialty = new Specialty
            {
                SpecialtyName=model.SpecialtyName
            };

            _context.Specialty.Add(specialty);
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

        // DELETE: api/Specialty/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialty(int id)
        {
            var specialty = await _context.Specialty.FindAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }

            _context.Specialty.Remove(specialty);
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
