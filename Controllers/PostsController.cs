using Microsoft.AspNetCore.Mvc;
using SecondDbProject.Context;
using SecondDbProject.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SecondDbProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly MySecondDbContext _context;    

        public PostController(MySecondDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddPost([FromBody] Post post)
        {
            if (post == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Posts.Add(post);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }
        [HttpGet("{id}")]
        public ActionResult<Post> GetPostById(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return post;
        }
    }
}
