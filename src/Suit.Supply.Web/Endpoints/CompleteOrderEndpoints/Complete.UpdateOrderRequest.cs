using Suit.Supply.Core.SalesAggregate.Models;
using System.ComponentModel.DataAnnotations;

namespace Suit.Supply.Web.Endpoints.CompleteOrderEndpoints
{
    public class UpdateSalesRequest
    {
        public const string Route = "/Complete";
        [Required]
        public int SalesId { get; set; }
        public bool IsCompleted { get; set; }

    }
}


