using gradtest.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace gradtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> getALL()
        {
            var x = await _context.users.ToListAsync();
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> get(int id)
        {
            var x = await _context.users.Where(a => a.Id == id).ToListAsync();
            return Ok(x);
        }

        [HttpPost]
        public async Task<IActionResult> pushUser(UserDto x)
        {
            User y = new User { Name = x.Name, Password = x.password };
            await _context.users.AddAsync(y);
            _context.SaveChanges();
            return Ok(y);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            User user = await _context.users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound("مش موجود يا صاحبي");
            _context.users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateUser(int id,[FromBody]UserDto x)
        {
            User user= await _context.users.FirstOrDefaultAsync(a => a.Id == id);
            if (user == null) return NotFound("ميتين امه مش موجود");
            user.Name = x.Name;
            user.Password = x.password;
            _context.SaveChanges();
            return Ok(user);
        }
        
    }
}
