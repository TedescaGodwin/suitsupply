using Suit.Supply.Web;
using Xunit;

namespace Suit.Supply.FunctionalTests.ControllerViews
{
    [Collection("Sequential")]
    public class HomeControllerIndex : IClassFixture<SalesWebApplicationFactory<WebMarker>>
    {
        private readonly HttpClient _client;

        public HomeControllerIndex(SalesWebApplicationFactory<WebMarker> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsViewWithCorrectMessage()
        {
            HttpResponseMessage response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Contains("Suit.Supply.Web", stringResponse);
        }
    }

}

