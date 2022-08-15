using Suit.Supply.Core.SalesAggregate.Models;
using System.ComponentModel.DataAnnotations;

namespace Suit.Supply.Web.Endpoints.PaymentEndpoints
{
    public class UpdatePaymentRequest
    {
        public const string Route = "/Payment";
        [Required]
        public int SalesId { get; set; }
        public bool IsPaid { get; set; }
    }
}


