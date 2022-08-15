using Suit.Supply.Core.SalesAggregate;
using Suit.Supply.Core.SalesAggregate.Models;
using Xunit;

namespace Suit.Supply.IntegrationTests.Data
{
    public class EntityFrameworkRepositoryAdd : BaseEntityFrameworkRepositoryTestFixture
    {
        [Fact]
        public async Task AddSaleAndSetsId()
        {

            var repository = GetRepository();
            var sales = new SalesDetail();

            await repository.AddAsync(sales);

            var newSale = (await repository.ListAsync())
                            .FirstOrDefault();
            Assert.NotNull(newSale);
            Assert.True(newSale?.Id != 0);
        }
    }
}


