using System.Threading.Tasks;
using EventBus;

namespace Reminder.API.IntegrationEvents
{
    public interface IReminderIntegrationEventService
    {
        Task SaveEventAndReminderContextChangesAsync(IntegrationEvent evt);
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
