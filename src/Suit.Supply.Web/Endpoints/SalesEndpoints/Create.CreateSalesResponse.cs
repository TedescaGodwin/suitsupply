using Suit.Supply.Web.ApiModels;

namespace Suit.Supply.Web.Endpoints.SalesEndpoints{
  public class CreateSalesResponse
  {
    public CreateSalesResponse(int id, List<OrderItemDTO> orderItems)
    {
      Id = id;
      OrderItems = orderItems;
    }
    public int Id { get; set; }
    public bool IsPaid { get; set; }
    public List<OrderItemDTO> OrderItems { get; set; }
    }
}


