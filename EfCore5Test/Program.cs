using EfCore5Test.Db;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace EfCore5Test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var myDbContext = services.GetService<MyDbContext>();
                    await myDbContext.Database.MigrateAsync();

                    if (!await myDbContext.MyCoolModels.AnyAsync())
                    {
                        myDbContext.MyCoolModels.Add(new MyCoolModel()
                        {
                            SomeText = "Hello World",
                            Id = new MyCoolKey() { FirstId = 1, SecondId = 1 }
                        });
                        await myDbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred migrating the DB.");
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
