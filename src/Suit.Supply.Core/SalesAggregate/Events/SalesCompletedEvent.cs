using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.SharedKernel;

namespace Suit.Supply.Core.SalesAggregate.Events
{

    public class SalesCompletedEvent : DomainEventBase
    {
        public SalesDetail CompletedSale { get; set; }

        public SalesCompletedEvent(SalesDetail completedSale)
        {
            CompletedSale = completedSale;
        }
    }
}
