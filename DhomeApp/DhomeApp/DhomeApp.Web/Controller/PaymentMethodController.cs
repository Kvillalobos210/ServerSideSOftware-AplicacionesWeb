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
    public class PaymentMethodController : ControllerBase
    {
        private readonly DbContextDhomeApp _context;

        public PaymentMethodController(DbContextDhomeApp context)
        {
            _context = context;
        }

        // GET: api/PaymentMethod
        [HttpGet]
        public async Task<IEnumerable<PaymentMethodModel>> GetPaymentMethod()
        {
            var paymentMethodList = await _context.PaymentMethod.ToListAsync();
            return paymentMethodList.Select(p => new PaymentMethodModel
            {
                PaymentMethodId = p.PaymentMethodId,
                PaymentMethodName=p.PaymentMethodName
            });
        }

        // GET: api/PaymentMethod/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPaymentMethodById(int id)
        {
            var paymentMethod = await _context.PaymentMethod.FindAsync(id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            return Ok(new PaymentMethodModel
            {
                PaymentMethodId = paymentMethod.PaymentMethodId,
                PaymentMethodName = paymentMethod.PaymentMethodName
            });
        }

        // PUT: api/PaymentMethod/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutPaymentMethod([FromBody] PaymentMethodModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.PaymentMethodId <= 0)
            {
                return BadRequest();
            }
            var paymentMethod = await _context.PaymentMethod.FirstOrDefaultAsync(p => p.PaymentMethodId == model.PaymentMethodId);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            paymentMethod.PaymentMethodName = model.PaymentMethodName;

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

        // POST: api/PaymentMethod
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPaymentMethod([FromBody] PaymentMethodModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PaymentMethod paymentMethod = new PaymentMethod
            {
                PaymentMethodName=model.PaymentMethodName
            };

            _context.PaymentMethod.Add(paymentMethod);
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

        // DELETE: api/PaymentMethod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            var paymentMethod = await _context.PaymentMethod.FindAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            _context.PaymentMethod.Remove(paymentMethod);
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
