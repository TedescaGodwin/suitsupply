using Suit.Supply.Core.SalesAggregate.Models;
using System.ComponentModel.DataAnnotations;

namespace Suit.Supply.Web.Endpoints.SalesEndpoints{
  public class CreateSalesRequest
  {
    public const string Route = "/Sales";

    [Required]
    public decimal SleeveRight { get; set; }
    [Required]
    public decimal SleeveLeft { get; set; }
    [Required]
    public decimal TrouserRight { get; set; }
    [Required]
    public decimal TrouserLeft { get; set; }
}
}


