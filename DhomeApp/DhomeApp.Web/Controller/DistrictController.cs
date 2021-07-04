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
    public class DistrictController : ControllerBase
    {
        private readonly DbContextDhomeApp _context;

        public DistrictController(DbContextDhomeApp context)
        {
            _context = context;
        }

        // GET: api/District
        [HttpGet]
        public async Task<IEnumerable<DistrictModel>> GetDistrict()
        {
            var districtList = await _context.District.ToListAsync();

            return districtList.Select(d => new DistrictModel
            {
                DistrictId = d.DistrictId,
                DistrictName = d.DistrictName,
                CityId = d.CityId
            });
        }

        // GET: api/District/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetDistrictById(int id)
        {
            var district = await _context.District.FindAsync(id);

            if (district == null)
            {
                return NotFound();
            }

            return Ok(new DistrictModel
            {
                DistrictId = district.DistrictId,
                DistrictName = district.DistrictName,
                CityId = district.CityId
            });
        }

        // PUT: api/District/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutDistrict([FromBody] DistrictModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.DistrictId <= 0)
            {
                return BadRequest();
            }

            var district = await _context.District.FirstOrDefaultAsync(d => d.DistrictId == model.DistrictId);

            if (district == null)
            {
                return NotFound();
            }

            district.DistrictName = model.DistrictName;
            district.CityId = model.CityId;

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

        // POST: api/District
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDistrict([FromBody] DistrictModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            District district = new District
            {
                DistrictName=model.DistrictName,
                CityId=model.CityId
            };

            _context.District.Add(district);

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

        // DELETE: api/District/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict([FromRoute]int id)
        {
            var district = await _context.District.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            _context.District.Remove(district);

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
