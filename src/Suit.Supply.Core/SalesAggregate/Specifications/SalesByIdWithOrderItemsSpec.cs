using Ardalis.Specification;
using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Core.SalesAggregate.Specifications
{
    public class SalesByIdWithOrderItemsSpec : Specification<SalesDetail>, ISingleResultSpecification
    {
        public SalesByIdWithOrderItemsSpec(int salesId)
        {
            Query
                .Where(sales => sales.Id == salesId)
                .Include(sales => sales.OrderItems);
        }
    }

}


