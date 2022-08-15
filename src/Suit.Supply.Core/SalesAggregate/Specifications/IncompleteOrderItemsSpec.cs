using Ardalis.Specification;
using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Core.SalesAggregate.Specifications
{
    public class IncompleteOrderItemsSpec : Specification<SalesDetail>
    {
        public IncompleteOrderItemsSpec()
        {
            Query.Where(item => !item.IsPaid);
        }
    }
}


