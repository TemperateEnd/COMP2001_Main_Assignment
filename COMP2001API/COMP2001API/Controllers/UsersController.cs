using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2001API.Models;

namespace COMP2001API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataAccess _context;

        public UsersController(DataAccess context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersTable>>> GetUsersTables()
        {
            return await _context.UsersTables.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersTable>> GetUsersTable(int id)
        {
            var usersTable = await _context.UsersTables.FindAsync(id);

            if (usersTable == null)
            {
                return NotFound();
            }

            return usersTable;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersTable(int id, UsersTable usersTable)
        {
            if (id != usersTable.UserId)
            {
                return BadRequest();
            }

            _context.Entry(usersTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsersTable>> PostUsersTable(UsersTable usersTable)
        {
            _context.UsersTables.Add(usersTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersTable", new { id = usersTable.UserId }, usersTable);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersTable>> DeleteUsersTable(int id)
        {
            var usersTable = await _context.UsersTables.FindAsync(id);
            if (usersTable == null)
            {
                return NotFound();
            }

            _context.UsersTables.Remove(usersTable);
            await _context.SaveChangesAsync();

            return usersTable;
        }

        private bool UsersTableExists(int id)
        {
            return _context.UsersTables.Any(e => e.UserId == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<UsersTable>>> Delete (int UserID)
        {
            _context.Delete(UserID);

            return StatusCode(200);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<UsersTable>>> Post(UsersTable user)
        {
            string responseString;

            register(user, out responseString);
            
            if(responseString.Contains("200"))
            {
                return Ok(user);
            }

            else
            {
                return StatusCode(208);
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<IEnumerable<UsersTable>>> Put (UsersTable user)
        {
            _context.Update(user);

            return StatusCode(200);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UsersTable>>> Get(UsersTable user)
        {
            getValidation(user);

            if(getValidation(user) == true)
            {
                return Ok(user);
            }
           

            else
            {
                return StatusCode(208);
            }
        }

        public void register(UsersTable user, out string httpResponse)
        {
            _context.Register(user, out httpResponse);
        }

        public bool getValidation(UsersTable user)
        {
            return _context.Validate(user);

        }
    }
}
