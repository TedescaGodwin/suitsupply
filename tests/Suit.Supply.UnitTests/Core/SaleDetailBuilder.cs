using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.UnitTests.Core
{
    public class SaleDetailBuilder
    {
        private SalesDetail _salesDetail = new();

        public SaleDetailBuilder WithDefaultValues()
        {
             OrderItem _orderItem = new() { Id = 0 };
            _salesDetail = new SalesDetail()
            {
                Id =1,
            };
            _orderItem.UpdateOrder(0, 0, 1, 2 );
            _salesDetail.AddOrderItem(_orderItem);
            return this;
        }

        public SalesDetail Build() => _salesDetail;
    }
}
