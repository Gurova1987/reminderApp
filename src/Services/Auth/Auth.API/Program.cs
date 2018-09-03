using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Auth.API
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
                    ic => ic.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true))
                .UseKestrel()
                .UseHealthChecks("/hc")
                .UseIISIntegration()
                .UseUrls("http://localhost:9002")
                .UseStartup<Startup>();
    }
}
