using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        //private readonly IEventBus _eventBus;

        public ReminderTask(IOptions<BackgroundTaskSettings> settings)
        {
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            //_eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
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
                        @"SELECT Id FROM [Reminders] 
                            WHERE DATEDIFF(minute, [Date], GETDATE()) >= @PeriodTime
                            AND [IsComplete] != 1 OR [IsComplete] IS NULL",
                        new {PeriodTime = _settings.PeriodTime});

                    // TODO: Here resides the logic to send the emails
                    const string sqlInsert = "INSERT INTO DeliveredReminders (ReminderId, DeliveredDate) Values (@ReminderId, @DeliveredDate);";
                    const string sqlUpdate = "UPDATE Reminders SET IsComplete = 1 WHERE Id = @Id;";
                    var affectedRows = reminderIds.Select(x => new {ReminderId = x, DeliveredDate = DateTime.Now});
                    var updatedRows = reminderIds.Select(x => new {Id = x});
                    conn.Execute(sqlInsert, affectedRows);
                    conn.Execute(sqlUpdate, updatedRows);
                }
                catch (SqlException exception)
                {
                    var temp = string.Empty;
                    // _logger.LogCritical($"FATAL ERROR: Database connections could not be opened: {exception.Message}");
                }

            }

            return reminderIds;
        }
    }
}
