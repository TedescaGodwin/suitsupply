
namespace Suit.Supply.Web.Endpoints.SalesEndpoints{
public class GetSalesByIdRequest
  {
    public const string Route = "/Sales/{SalesId:int}";
    public static string BuildRoute(int salesId) => Route.Replace("{SalesId:int}", salesId.ToString());

    public int SalesId { get; set; }
  }

}

