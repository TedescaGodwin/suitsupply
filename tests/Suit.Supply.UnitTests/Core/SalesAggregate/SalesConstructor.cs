using Suit.Supply.Core.SalesAggregate.Models;
using Xunit;

namespace Suit.Supply.UnitTests.Core.SalesAggregate;

public class SalesConstructor
{
  //private readonly AlterationDetails _testDetails = new();
  //private readonly OrderStatus _testStatus = OrderStatus.Paid;
  private SalesDetail? _testSalesDetail;

  private SalesDetail CreateSales()
  {
    return new SalesDetail();
  }

  //[Fact]
  //public void InitializesSalesDetail()
  //{
  //      _testSalesDetail = CreateSales();

  //  Assert.Equal(_testSalesDetail.AlterationDetails, _testSalesDetail.AlterationDetails);
  //}

  //[Fact]
  //public void InitializesAlterationStatus()
  //{
  //      _testSalesDetail = CreateSales();

  //  Assert.Equal(_testStatus.Value, _testSalesDetail);
  //}

  [Fact]
  public void InitializesTaskListToEmptyList()
  {
        _testSalesDetail = CreateSales();

    Assert.NotNull(_testSalesDetail.OrderItems);
  }

  //[Fact]
  //public void InitializesStatusToInProgress()
  //{
  //      _testSalesDetail = CreateSales();

  //  Assert.Equal(OrderStatus.Paid, _testSalesDetail.OrderStatus.Value);
  //}
}
