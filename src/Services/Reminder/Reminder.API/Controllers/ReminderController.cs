using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reminder.API.Infrastructure;

namespace Reminder.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly ReminderContext _reminderContext;

        public ReminderController(ReminderContext context)
        {
            _reminderContext = context ?? throw new ArgumentNullException(nameof(context));

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateReminder([FromBody]Model.Reminder reminder)
        {
            var reminderNotification = new Model.Reminder
            {
                UserId = reminder.UserId,
                Message = reminder.Message,
                EmailTo = reminder.EmailTo,
                Date = reminder.Date
            };
            _reminderContext.Reminders.Add(reminderNotification);

            await _reminderContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = reminderNotification.Id }, null);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Model.Reminder), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _reminderContext.Reminders.SingleOrDefaultAsync(ci => ci.Id == id);

            if (item != null)
                return Ok(item);

            return NotFound();
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _reminderContext.Reminders.ToListAsync();
            return Ok(items);
        }
    }
}