using Ardalis.HttpClientTestExtensions;
using Suit.Supply.Web;
using Suit.Supply.Web.Endpoints.SalesEndpoints;
using Xunit;

namespace Suit.Supply.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class SalesList : IClassFixture<SalesWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public SalesList(SalesWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsOneSale()
  {
    //var result = await _client.GetAndDeserialize<SalesListResponse>("/Sales");
        //Assert.Single(result.Sales);
        //Assert.Contains(result.Sales, i => i.Details == new AlterationDetailsRecord
        //(
        //    SeedData.TestSales1.AlterationDetails.SleeveRight,
        //    SeedData.TestSales1.AlterationDetails.SleeveLeft,
        //    SeedData.TestSales1.AlterationDetails.TrouserRight,
        //    SeedData.TestSales1.AlterationDetails.TrouserLeft
        //));

    }
    
  }
