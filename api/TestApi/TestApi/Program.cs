using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using TestApi.Data;

namespace TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host  = CreateWebHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(config => config.ClearProviders())
                .ConfigureAppConfiguration((context, config) =>
                {
                    var builtConfig = config.Build();
                    var vault = builtConfig["KeyVault:Vault"];
                    if (!string.IsNullOrEmpty(vault))
                    {
                        config.AddAzureKeyVault(
                            $"https://{builtConfig["KeyVault:Vault"]}.vault.azure.net/",
                           builtConfig["KeyVault:ClientId"],
                           builtConfig["KeyVault:ClientSecret"]);
                    }
                });

        private static void CreateDbIfNotExists(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SysdocContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}