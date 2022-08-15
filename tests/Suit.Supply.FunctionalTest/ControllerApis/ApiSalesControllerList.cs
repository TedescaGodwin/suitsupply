using Ardalis.HttpClientTestExtensions;
using Suit.Supply.Web;
using Suit.Supply.Web.ApiModels;
using Xunit;

namespace Suit.Supply.FunctionalTests.ControllerApis;

[Collection("Sequential")]
public class CustomerCreate : IClassFixture<SalesWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public CustomerCreate(SalesWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsOneCustomer()
  {
    var result = await _client.GetAndDeserialize<IEnumerable<SalesDTO>>("/api/customers");

    Assert.Single(result);
    //Assert.Contains(result, i => i.Details== AlterationDetailsDTO.FromAlterationDetails(SeedData.TestSales1.AlterationDetails));
  }
}
