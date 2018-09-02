using EventBus;

namespace Reminder.BackgroundTasks.IntegrationEvents
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
