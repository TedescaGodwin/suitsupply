using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Suit.Supply.Core.SalesAggregate;
using Suit.Supply.Core.SalesAggregate.Models;
using Xunit;

namespace Suit.Supply.IntegrationTests.Data;

public class EntityFrameworkRepositoryUpdate : BaseEntityFrameworkRepositoryTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a Sales
    var repository = GetRepository();
    AlterationDetails initialDetails = new()
    {
        SleeveLeft = 1, SleeveRight = 5, TrouserLeft = 3, TrouserRight = 4,
    };

    var orderItem = new OrderItem();
   
    var sales = new SalesDetail();
        sales.AddOrderItem(orderItem);

    await repository.AddAsync(sales);

    // detach the item so we get a different instance
    _dbContext.Entry(sales).State = EntityState.Detached;

    // fetch the item and update its sales description
    var newSale = (await repository.ListAsync())
        .FirstOrDefault(sales => sales.OrderItems.Select(x=> x.SleeveRight).Contains(initialDetails.SleeveRight));
    if (newSale == null)
    {
      Assert.NotNull(newSale);
      return;
    }
        orderItem.UpdateOrder(1,8,90,5);

        Assert.NotSame(sales, newSale);

        // Update the item
        await repository.UpdateAsync(newSale);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
            .FirstOrDefault(sales => sales.OrderItems
            .Select(x => x.SleeveRight).Contains(1));

    Assert.NotNull(updatedItem);
    Assert.NotEqual(newSale.OrderItems.Count(), updatedItem?.OrderItems.Count());
    //Assert.Equal(newSale.AlterationStatus, updatedItem?.AlterationStatus);
    Assert.Equal(newSale.Id, updatedItem?.Id);
  }
}
