using Suit.Supply.Core.SalesAggregate;
using Suit.Supply.Core.SalesAggregate.Models;
using Xunit;

namespace Suit.Supply.IntegrationTests.Data
{
    public class EntityFrameworkRepositoryDelete : BaseEntityFrameworkRepositoryTestFixture
    {
        [Fact]
        public async Task DeletesOrderItemAfterAddingIt()
        {
            // add a sale
            var repository = GetRepository();
            var sale = new SalesDetail();
            OrderItem orderItem = new();
                orderItem.UpdateOrder(3,4,6,7);
                sale.AddOrderItem(orderItem);
            await repository.AddAsync(sale);

            // delete the sale
            await repository.DeleteAsync(sale);

            Assert.DoesNotContain(await repository.ListAsync(), 
                sale => sale.OrderItems !=null);
        }
    }
}


