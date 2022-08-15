using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.SharedKernel;

namespace Suit.Supply.Core.SalesAggregate.Events
{
    public class SalesOrderPaidEvent : DomainEventBase
    {
        public SalesDetail SalesDetail { get; set; }

        public SalesOrderPaidEvent(SalesDetail salesDetail)
        {
            SalesDetail = salesDetail;
        }
    }
}
