using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleChat.Data;
using SimpleChat.Models;
using SimpleChat.Services;

namespace SimpleChat.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ChatMessagesDBContext _context;

        public UserController(ChatMessagesDBContext context)
        {
            _context = context;
        }

        protected private List<User> Users { get; set; }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Users = await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: Login User
        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser(LoginRequest request)
        {
            var user = await _context.Users.FromSql($"select * from user where user_name={request.UserName}").FirstAsync();
            
            if (user == null)
            {
                return NotFound();
            }

            PasswordHasher passwordHasher = new();

            if (passwordHasher.Decrypt(request.Password, user.Password))
            {
                return Ok();
            } 
            
            return Unauthorized();

        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(ulong id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);

            var duplicateUser = await _context.Users.FromSql($"select * from user where user_name={user.UserName.ToLower()}").ToListAsync();
            if(duplicateUser.IsNullOrEmpty()) await _context.SaveChangesAsync();
            else return Conflict(new {Code = 409, Message = $"Username: {user.UserName.ToLower()} already in use." });

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        private bool UserExists(ulong id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
