using Suit.Supply.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.Core.SalesAggregate;

namespace Suit.Supply.Web;

public static class SeedData
{
    public static readonly SalesDetail TestSales1 = new();
    public static readonly OrderItem OrderItem1 = new();

  public static void Initialize(IServiceProvider serviceProvider)
  {
        using var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);
        if (dbContext.OrderItems.Any())
        {
            return;   // DB has been seeded
        }

        PopulateTestData(dbContext);
    }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.SalesDetail)
    {
      dbContext.Remove(item);
    }
    foreach (var item in dbContext.SalesDetail)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    TestSales1.AddOrderItem(OrderItem1);
    dbContext.SalesDetail.Add(TestSales1);

    dbContext.SaveChanges();
  }
}
