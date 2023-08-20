using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers 
{
    [ApiController]
    [Route("api/[controller]")] // Corrected route
    public class UserController : ControllerBase
    {
        private readonly DataContext _db;
        
        public UserController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _db.Users.ToListAsync();

            return Ok(users); // Returning HTTP 200 OK with the users
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _db.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(); // Returning HTTP 404 Not Found
            }

            return Ok(user); // Returning HTTP 200 OK with the user
        }
    }
}
