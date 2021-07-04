using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DhomeApp.Data;
using DhomeApp.Entity;

namespace DhomeApp.Web.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DbContextDhomeApp _context;

        public CityController(DbContextDhomeApp context)
        {
            _context = context;
        }

        // GET: api/City
        [HttpGet]
        public async Task<IEnumerable<CityModel>> GetCity()
        {
            var cityList = await _context.City.ToListAsync();

            return cityList.Select(b => new CityModel
            {
                CityId=b.CityId,
                CityName=b.CityName
            });
        }

        // GET: api/City/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCityById([FromRoute] int id)
        {
            var city = await _context.City.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(new CityModel
            {
                CityId=city.CityId,
                CityName=city.CityName
            });
        }

        // PUT: api/City/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutCity([FromBody] CityModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.CityId <= 0)
            {
                return BadRequest();
            }
            var city = await _context.City.FirstOrDefaultAsync(b => b.CityId == model.CityId);

            if (city == null)
            {
                return NotFound();
            }

            city.CityName = model.CityName;
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

        // POST: api/City
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCity([FromBody] CityModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            City city = new City
            {
                CityName = model.CityName
            };
            _context.City.Add(city);
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

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity([FromRoute] int id)
        {
            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.City.Remove(city);
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
