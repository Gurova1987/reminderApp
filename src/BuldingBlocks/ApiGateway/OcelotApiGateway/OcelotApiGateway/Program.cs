using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace OcelotApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(
                    ic => ic.AddJsonFile("configuration.json", optional: false, reloadOnChange: true))
                .ConfigureAppConfiguration(
                    ic => ic.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true))
                .UseUrls("http://localhost:9000")
                .UseStartup<Startup>();
    }
}
