using Ardalis.HttpClientTestExtensions;
using Suit.Supply.Web;
using Suit.Supply.Web.Endpoints.SalesEndpoints;
using Xunit;

namespace Suit.Supply.FunctionalTests.ApiEndpoints
{
    [Collection("Sequential")]
    public class SalesGetById : IClassFixture<SalesWebApplicationFactory<WebMarker>>
    {
        private readonly HttpClient _client;

        public SalesGetById(SalesWebApplicationFactory<WebMarker> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsSeedSalesGivenId1()
        {
            var result = await _client.GetAndDeserialize<GetSalesByIdResponse>(GetSalesByIdRequest.BuildRoute(1));

            //Assert.Equal(Guid.NewGuid, result.Id);
            //Assert.Equal(SeedData.TestSales1.IsPaid, result.IsPaid);
            Assert.Equal(3, result.OrderItems.Count);
        }

        [Fact]
        public async Task ReturnsNotFoundGivenId0()
        {
            string route = GetSalesByIdRequest.BuildRoute(0);
            _ = await _client.GetAndEnsureNotFound(route);
        }
    }
}


