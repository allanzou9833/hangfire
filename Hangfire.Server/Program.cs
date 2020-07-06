using Hangfire.MySql;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Hangfire.Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            var configuration = builder.Build();

            GlobalConfiguration.Configuration.UseStorage(
                    new MySqlStorage(
                        configuration.GetConnectionString("HangfireConnection"),
                        new MySqlStorageOptions()
                    ));

            var hostBuilder = new HostBuilder()
                // Add configuration, logging, ...
                .ConfigureServices((hostContext, services) =>
                {
                    // Add your services with depedency injection.
                });

            using (var server = new BackgroundJobServer(new BackgroundJobServerOptions()
            {
                WorkerCount = 1
            }))
            {
                await hostBuilder.RunConsoleAsync();
            }
        }
    }
}
