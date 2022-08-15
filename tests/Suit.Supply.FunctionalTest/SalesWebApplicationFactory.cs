using Suit.Supply.Infrastructure.Data;
using Suit.Supply.UnitTests;
using Suit.Supply.Web;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Suit.Supply.FunctionalTests
{
    public class SalesWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = builder.Build();
            host.Start();

            var serviceProvider = host.Services;

            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();

                var logger = scopedServices
                    .GetRequiredService<ILogger<SalesWebApplicationFactory<TStartup>>>();

                // Ensure the database is created.
                db.Database.EnsureCreated();

                try
                {
                    SeedData.PopulateTestData(db);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the " +
                                        "database with test messages. Error: {exceptionMessage}", ex.Message);
                }
            }

            return host;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
            d => d.ServiceType ==
                typeof(DbContextOptions<AppDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    string inMemoryCollectionName = Guid.NewGuid().ToString();

                    services.AddDbContext<AppDbContext>(options =>
        {
                      options.UseInMemoryDatabase(inMemoryCollectionName);
                  });

                    services.AddScoped<IMediator, NoOpMediator>();
                });
        }
    }
}
