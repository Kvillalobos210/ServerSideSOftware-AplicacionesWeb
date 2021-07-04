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
    public class AccountController : ControllerBase
    {
        private readonly DbContextDhomeApp _context;

        public AccountController(DbContextDhomeApp context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<AccountModel>> GetAccounts()
        {
            var accountList = await _context.Account.ToListAsync();

            return accountList.Select(a => new AccountModel
            {
                AccountId = a.AccountId,
                Username = a.Username,
                Password = a.Password,
                UserType = a.UserType,
                Verify = a.Verify
            });
        }

        // GET: api/Account/GetAccountById/{id}
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAccountById([FromRoute] int id)
        {
            var account = await _context.Account.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(new AccountModel
            {
                AccountId = account.AccountId,
                Username = account.Username,
                Password = account.Password,
                UserType = account.UserType,
                Verify = account.Verify
            });
        }

        //Actualizar
        // PUT: api/Account/PutAccount
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutAccount([FromBody] PostAccountModel cmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (cmodel.AccountId <= 0)
                return BadRequest();

            var account = await _context.Account.FirstOrDefaultAsync(c => c.AccountId == cmodel.AccountId);

            if (account == null)
                return NotFound();
            account.Username = cmodel.Username;
            account.Password = cmodel.Password;
            account.UserType = cmodel.UserType;
            account.Verify = cmodel.Verify;

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
        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostAccount([FromBody] PostAccountModel cmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Account account = new Account
            {
                Username = cmodel.Username,
                Password = cmodel.Password,
                UserType = cmodel.UserType,
                Verify = cmodel.Verify
            };

            _context.Account.Add(account);

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

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int id) 
        {
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(account);

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
