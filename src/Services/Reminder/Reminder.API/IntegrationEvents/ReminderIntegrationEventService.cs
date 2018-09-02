using System;
using System.Threading.Tasks;
using EventBus;
using EventBus.Abstractions;
using Reminder.API.Infrastructure;

namespace Reminder.API.IntegrationEvents
{
    public class ReminderIntegrationEventService : IReminderIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        private readonly ReminderContext _reminderContext;

        public ReminderIntegrationEventService(IEventBus eventBus, ReminderContext reminderContext)
        {
            _reminderContext = reminderContext ?? throw new ArgumentNullException(nameof(reminderContext));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        //public async Task SaveEventAndReminderContextChangesAsync(IntegrationEvent evt)
        //{
        //    _eventBus.Publish(evt);

        //    await _eventLogService.MarkEventAsPublishedAsync(evt);
        //}

        //public async Task SaveEventAndReminderContextChangesAsync(IntegrationEvent evt)
        //{
        //    //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
        //    //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
        //    await ResilientTransaction.New(_catalogContext)
        //        .ExecuteAsync(async () => {
        //            // Achieving atomicity between original catalog database operation and the IntegrationEventLog thanks to a local transaction
        //            await _reminderContext.SaveChangesAsync();
        //            await _eventLogService.SaveEventAsync(evt, _reminderContext.Database.CurrentTransaction.GetDbTransaction());
        //        });
        //}
        public Task SaveEventAndReminderContextChangesAsync(IntegrationEvent evt)
        {
            throw new NotImplementedException();
        }

        public Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            throw new NotImplementedException();
        }
    }
}
