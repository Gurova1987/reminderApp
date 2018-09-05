using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace User.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:9006")
                .UseKestrel()
                .UseHealthChecks("/hc")
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
