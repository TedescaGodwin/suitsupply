using Suit.Supply.Core.SalesAggregate;
using Suit.Supply.Core.SalesAggregate.Models;
using Xunit;

namespace Suit.Supply.UnitTests.Core.SalesAggregate
{
    public class Order_AddItem
    {
        private SalesDetail _salesDetail =new();
   
        [Fact]
        public void AddsItemToItems()
        {
            var _testOrderItem = new OrderItem();

            _salesDetail.AddOrderItem(_testOrderItem);

            Assert.Contains(_testOrderItem, _salesDetail.OrderItems);
        }

        [Fact]
        public void ThrowsExceptionGivenNullItem()
        {
#nullable disable
            Action action = () => _salesDetail.AddOrderItem(null);
#nullable enable

            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("newOrderItem", ex.ParamName);
        }
    }

}

