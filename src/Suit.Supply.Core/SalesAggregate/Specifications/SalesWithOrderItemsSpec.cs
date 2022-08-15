using Ardalis.Specification;
using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Core.SalesAggregate.Specifications
{
    public class SalesWithOrderItemsSpec : Specification<SalesDetail>, ISingleResultSpecification
    {
        public SalesWithOrderItemsSpec()
        {
            Query
                .Where(sales => sales.Id != 0)
                .Include(sales => sales.OrderItems);
        }
    }
}


