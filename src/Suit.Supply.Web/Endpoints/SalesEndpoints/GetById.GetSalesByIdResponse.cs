
namespace Suit.Supply.Web.Endpoints.SalesEndpoints{

  public class GetSalesByIdResponse
  {
    public GetSalesByIdResponse(int id)
    {
      Id = id;
    }

    public int Id { get; set; }
    public bool IsPaid { get; set; }
    public List<OrderItemRecord> OrderItems { get; set; } = new();
  }
}


