using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Web.ApiModels;

public class OrderItemDTO
{
  public int Id { get; set; }
   [Required]
    public decimal SleeveRight { get; set; }
    [Required]
    public decimal SleeveLeft { get; set; }
    [Required]
    public decimal TrouserRight { get; set; }
    [Required]
    public decimal TrouserLeft { get; set; }
    public static OrderItemDTO FromOrderItem(OrderItem item)
  {
    item = Guard.Against.Null(item, nameof(item));

        return new OrderItemDTO()
        {
            Id = item.Id,
            TrouserRight = item.TrouserRight,
            TrouserLeft = item.TrouserLeft,
            SleeveRight = item.SleeveRight,
            SleeveLeft = item.SleeveLeft,

    };
  }

    public static List<OrderItemDTO> FromOrderItems(List<OrderItem> items)
    {
        items = Guard.Against.Null(items, nameof(items));
        var newOrderItems = new List<OrderItemDTO>();
        items.ForEach(item =>
        {
            newOrderItems.Add(new OrderItemDTO()
            {
                Id = item.Id,
                TrouserRight = item.TrouserRight,
                TrouserLeft = item.TrouserLeft,
                SleeveRight = item.SleeveRight,
                SleeveLeft = item.SleeveLeft,
            });
        });

        return newOrderItems;
    }
}
