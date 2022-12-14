using System;
using System.Threading.Tasks;
using CA3Brewery.Brewery;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CA3Brewery.Tests
{
    [TestClass]
    public class BreweryServiceTests
    {
        private BreweryService _breweryService;
        private HttpClient _httpClient;

        [TestInitialize]
        public void Initialize()
        {
            // Create a new HttpClient for making HTTP requests
            _httpClient = new HttpClient();

            // Create a new instance of the BreweryService using the HttpClient
            _breweryService = new BreweryService(_httpClient);
        }

        [TestMethod]
        public async Task SearchBreweries_ReturnsBreweriesForQuery()
        {
            var query = "Brewery";

            var result = await _breweryService.SearchBreweries(query);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.Any(b => b.Name.Contains(query, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
