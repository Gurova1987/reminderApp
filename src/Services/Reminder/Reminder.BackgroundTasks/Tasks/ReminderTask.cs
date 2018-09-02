using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EventBus.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Reminder.BackgroundTasks.Configuration;

namespace Reminder.BackgroundTasks.Tasks
{
    public class ReminderTask: BackgroundService
    {
        private readonly BackgroundTaskSettings _settings;
        private readonly IEventBus _eventBus;

        public ReminderTask(IOptions<BackgroundTaskSettings> settings,
            IEventBus eventBus)
        {
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.Register(() => //_logger.LogDebug($"#1 GracePeriodManagerService background task is stopping.")
                                          string.Empty.ToString());

            while (!stoppingToken.IsCancellationRequested)
            {
                DeliverReminders();

                await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
            }

            //_logger.LogDebug($"GracePeriodManagerService background task is stopping.");

            await Task.CompletedTask;
        }

        private IEnumerable<int> DeliverReminders()
        {
            IEnumerable<int> reminderIds = new List<int>();

            using (var conn = new SqlConnection(_settings.ConnectionString))
            {
                try
                {
                    conn.Open();
                    reminderIds = conn.Query<int>(
                        @"SELECT Id FROM [ordering].[orders] 
                            WHERE DATEDIFF(minute, [OrderDate], GETDATE()) >= @GracePeriodTime
                            AND [OrderStatusId] = 1",
                        new { GracePeriodTime = _settings.GracePeriodTime });
                }
                catch (SqlException exception)
                {
                   // _logger.LogCritical($"FATAL ERROR: Database connections could not be opened: {exception.Message}");
                }

            }

            return reminderIds;
        }
    }
}
