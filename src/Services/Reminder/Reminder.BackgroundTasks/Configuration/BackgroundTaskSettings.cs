using System;

namespace Reminder.BackgroundTasks.Configuration
{
    public class BackgroundTaskSettings
    {
        public string ConnectionString { get; set; }

        public string EventBusConnection { get; set; }

        public int PeriodTime { get; set; }

        public int CheckUpdateTime { get; set; }
    }
}
