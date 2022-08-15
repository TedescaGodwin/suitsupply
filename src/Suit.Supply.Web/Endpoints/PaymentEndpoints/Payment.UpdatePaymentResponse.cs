using Suit.Supply.Web.Endpoints.SalesEndpoints;

namespace Suit.Supply.Web.Endpoints.PaymentEndpoints
{
    public class UpdatePaymentResponse
    {
        public UpdatePaymentResponse(SalesRecord sales)
        {
            Sales = sales;
        }
        public SalesRecord Sales { get; set; }
    }
}


