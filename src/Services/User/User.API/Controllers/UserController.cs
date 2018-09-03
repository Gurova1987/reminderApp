using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.API.Infrastructure;

namespace User.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UserController(UserContext context)
        {
            _userContext = context ?? throw new ArgumentNullException(nameof(context));

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateReminder([FromBody]Models.User user)
        {
            var newUser = new Models.User
            {
                Username = user.Username,
                Email = user.Email
            };
            _userContext.Users.Add(newUser);

            await _userContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, null);
        }
        
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Models.User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var user = await _userContext.Users.SingleOrDefaultAsync(ci => ci.Id == id);

            if (user != null)
                return Ok(user);

            return NotFound();
        }
        
        [HttpGet]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _userContext.Users.ToListAsync();
            return Ok(items);
        }
    }
}