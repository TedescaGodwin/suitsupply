using Suit.Supply.Core.SalesAggregate;
using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.Core.SalesAggregate.Specifications;
using Xunit;

namespace Suit.Supply.UnitTests.Core.Specifications
{
    public class IncompleteItemsSpecificationConstructor
    {
        [Fact]
        public void FilterCollectionToOnlyReturnItemsWithPaidFalse()
        {
            var item1 = new SalesDetail();
            var item2 = new SalesDetail(); 
            var item3 = new SalesDetail(); 
            List<SalesDetail> sales = new List<SalesDetail>();
                sales.Add(item1);
                sales.Add(item2);
                sales.Add(item3);

            item3.MarkOrderAsPaid();

            var spec = new IncompleteOrderItemsSpec();

            var filteredList = spec.Evaluate(sales);

            Assert.Contains(item1, filteredList);
            Assert.Contains(item2, filteredList);
            Assert.DoesNotContain(item3, filteredList);
        }
    }

}

