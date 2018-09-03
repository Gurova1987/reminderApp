using System;

namespace Reminder.API.Model
{
    public class Reminder
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }

        public string EmailTo { get; set; }

        public DateTime? Date { get; set; }
    }
}
