using Suit.Supply.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace Suit.Supply.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));

        public static void AddServiceBus(this IServiceCollection services, string serviceBusConnectionString) =>
            services.AddAzureClients(builder =>
                builder.AddServiceBusClient(serviceBusConnectionString));
    }

}

