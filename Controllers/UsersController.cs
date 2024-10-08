using Microsoft.AspNetCore.Mvc;
using SecondDbProject.Context;
using SecondDbProject.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SecondDbProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MySecondDbContext _context;

        public UsersController(MySecondDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
