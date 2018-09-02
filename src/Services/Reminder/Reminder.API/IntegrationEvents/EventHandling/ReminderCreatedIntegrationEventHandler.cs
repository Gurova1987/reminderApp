using System.Threading.Tasks;
using EventBus.Abstractions;
using Reminder.API.IntegrationEvents.Events;

namespace Reminder.API.IntegrationEvents.EventHandling
{
    public class ReminderCreatedIntegrationEventHandler : IIntegrationEventHandler<ReminderCreatedIntegrationEvent>
    {
        private readonly IReminderIntegrationEventService _reminderIntegrationEventService;

        public ReminderCreatedIntegrationEventHandler(IReminderIntegrationEventService reminderIntegrationEventService)
        {
            _reminderIntegrationEventService = reminderIntegrationEventService;
        }

        public async Task Handle(ReminderCreatedIntegrationEvent command)
        {
            var createdIntegrationEvent =  new ReminderCreatedIntegrationEvent(command.ReminderId);

            await _reminderIntegrationEventService.SaveEventAndReminderContextChangesAsync(createdIntegrationEvent);
            await _reminderIntegrationEventService.PublishThroughEventBusAsync(createdIntegrationEvent);
        }
    }
}
