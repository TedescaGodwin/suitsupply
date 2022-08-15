using Suit.Supply.Web.Endpoints.SalesEndpoints;

namespace Suit.Supply.Web.Endpoints.CompleteOrderEndpoints
{
    public class UpdateSalesResponse
    {
        public int Id { get; set; }
        public UpdateSalesResponse(SalesRecord sales)
        {
            Sales = sales;
        }
        public SalesRecord Sales { get; set; }
    }
}


