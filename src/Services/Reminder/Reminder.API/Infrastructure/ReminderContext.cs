using Microsoft.EntityFrameworkCore;

namespace Reminder.API.Infrastructure
{
    public class ReminderContext: DbContext
    {
        public ReminderContext(DbContextOptions<ReminderContext> options) : base(options)
        {
        }
        public DbSet<Model.Reminder> Reminders { get; set; }
    }
}
