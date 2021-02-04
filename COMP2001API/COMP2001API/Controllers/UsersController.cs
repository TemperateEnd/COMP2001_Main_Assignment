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
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly DataAccess _context;

        public UsersController(DataAccess context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(UsersTable user)
        {

            bool p1 = getValidation(user);

            if (p1)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(208);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UsersTable user)
        {
            _context.Update(user);

            return StatusCode(200);
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Post(UsersTable user)
        {
            string Responce;
            
            register(user, out Responce);

            if (Responce.Contains("200"))
            {
                return Ok(user);
            }
            else
            {
                return StatusCode(208);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _context.Delete(id);
            return StatusCode(200);
        }

        [NonAction]
        public void register(UsersTable user, out string httpResponse)
        {
            _context.Register(user, out httpResponse);
        }

        public bool getValidation(UsersTable user)
        {
            return _context.Validate(user);
        }

        private bool UserExists(int id)
        {
            return _context.UsersTables.Any(e => e.UserId == id);
        }

    }
}
