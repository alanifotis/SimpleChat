using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SimpleChat.Data;
using SimpleChat.Models;

namespace SimpleChat.Controllers
{


    [Route("api/users")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly ChatMessagesDBContext _dbContext;

        public UserController(ChatMessagesDBContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUserMessages(int userID)
        {

            return await _dbContext.Users.FromSql($"SELECT * FROM ChatMessages where UserId={userID}").ToListAsync();
        }
    }
}