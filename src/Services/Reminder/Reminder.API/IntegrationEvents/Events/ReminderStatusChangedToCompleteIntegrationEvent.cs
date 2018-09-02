namespace Reminder.API.IntegrationEvents.Events
{
    public class ReminderStatusChangedToCompleteIntegrationEventHandler
    {
        public int ReminderId { get; }

        public ReminderStatusChangedToCompleteIntegrationEventHandler(int reminderId)
        {
            ReminderId = reminderId;
        }
    }
}
