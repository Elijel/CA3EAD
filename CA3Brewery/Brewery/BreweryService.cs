using Newtonsoft.Json;
using System.Text.Json;

namespace CA3Brewery.Brewery
{
    public class BreweryService : IBreweryService
    {
        private readonly HttpClient _httpClient;
        const string _baseUrl = "https://api.openbrewerydb.org/";
        const string _breweryEndpoint = "/breweries";

        public BreweryService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<BreweryItem>> GetBrewery()
        {
            ConfigureHttpClient();

            var response = await _httpClient.GetAsync(_breweryEndpoint);
            response.EnsureSuccessStatusCode();

            var string_ = await response.Content.ReadAsStringAsync();

            var dto = JsonConvert.DeserializeObject<List<BreweryDto>>(string_);

            return dto.Select(n => new BreweryItem
            {
                id = n.id,
                name = n.name
            }).ToList();

        }
        private void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }
    }
}
