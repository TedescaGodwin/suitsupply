using Ardalis.Specification;
using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Core.SalesAggregate.Specifications
{
    public class IncompleteOrderItemsSearchSpec : Specification<SalesDetail>
    {
        public IncompleteOrderItemsSearchSpec()
        {
            Query
                .Where(SalesDetail => !SalesDetail.IsPaid);
        }
    }
}


