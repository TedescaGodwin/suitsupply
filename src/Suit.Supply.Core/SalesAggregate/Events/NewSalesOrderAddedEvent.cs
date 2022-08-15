using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.SharedKernel;

namespace Suit.Supply.Core.SalesAggregate.Events
{
    public class NewSalesOrderAddedEvent : DomainEventBase
    {
        public SalesDetail SalesDetail { get; set; }

        public NewSalesOrderAddedEvent(SalesDetail salesDetails)
        {
            SalesDetail = salesDetails;
        }
    }
}


