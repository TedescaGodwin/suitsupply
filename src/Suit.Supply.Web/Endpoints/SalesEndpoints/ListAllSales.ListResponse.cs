namespace Suit.Supply.Web.Endpoints.SalesEndpoints{

  public class ListResponse
  {
    public ListResponse(List<SalesRecord> salesRecord)
    {
            SalesRecord = salesRecord;
    }
    public List<SalesRecord> SalesRecord { get; set; }
  }
}


