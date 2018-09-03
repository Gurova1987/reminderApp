using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Reminder.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:9001")
                .UseKestrel()
                .UseHealthChecks("/hc")
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
