namespace Reminder.API.IntegrationEvents.EventHandling
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
