using Microsoft.AspNetCore;

namespace AzureDB;

public class Program
{
    public static void Main(string[] args)
    {
        IWebHost webHost = CreateWebHostBuilder(args).Build();
        webHost.Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost
            .CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                string environment =
                    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLowerInvariant() ??
                    "production";

                config.SetBasePath(context.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            })
            .UseStartup<Startup>();
}
