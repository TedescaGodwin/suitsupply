using Ardalis.Specification;
using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Core.SalesAggregate.Specifications
{
    public class CompleteOrderItemsSearchSpec : Specification<SalesDetail>
    {
        public CompleteOrderItemsSearchSpec()
        {
            Query
                .Where(SalesDetail => SalesDetail.IsPaid 
                    && SalesDetail.OrderStatus == OrderStatus.Done);
        }
    }
}


