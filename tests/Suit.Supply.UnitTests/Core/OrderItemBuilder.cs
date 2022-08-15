using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.UnitTests;

public class OrderItemBuilder
{
  private OrderItem _orderItem = new OrderItem();

  public OrderItemBuilder Id(int id)
  {
    _orderItem.Id = id;
    return this;
  }

  public OrderItemBuilder WithDefaultValues()
  {
        _orderItem = new OrderItem() { Id = 1 };

    return this;
  }

  public OrderItem Build() => _orderItem;
}

