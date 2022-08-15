using Suit.Supply.Infrastructure.Data;
using Suit.Supply.SharedKernel.Interfaces;
using Suit.Supply.Core.SalesAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;


namespace Suit.Supply.IntegrationTests.Data
{
    public abstract class BaseEntityFrameworkRepositoryTestFixture
    {
        protected AppDbContext _dbContext;

        protected BaseEntityFrameworkRepositoryTestFixture()
        {
            var options = CreateNewContextOptions();
            var mockEventDispatcher = new Mock<IDomainEventDispatcher>();

            _dbContext = new AppDbContext(options, mockEventDispatcher.Object);
        }

        protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("suitsupply")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected EntityFrameworkRepository<SalesDetail> GetRepository()
        {
            return new EntityFrameworkRepository<SalesDetail>(_dbContext);
        }
    }

}

