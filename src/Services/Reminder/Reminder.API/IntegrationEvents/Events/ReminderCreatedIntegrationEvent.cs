using EventBus;

namespace Reminder.API.IntegrationEvents.Events
{
    public class ReminderCreatedIntegrationEvent : IntegrationEvent
    {
        public int ReminderId { get; }

        public ReminderCreatedIntegrationEvent(int reminderId)
        {
            ReminderId = reminderId;
        }
    }
}
