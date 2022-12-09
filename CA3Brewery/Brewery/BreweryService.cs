using System.Text.Json;

namespace CA3Brewery.Brewery
{
    public class BreweryService : IBreweryService
    {
        private readonly HttpClient _httpClient;
        const string _baseUrl = "https://brianiswu-open-brewery-db-v1.p.rapidapi.com/";
        const string _breweryEndpoint = "/breweries";
        const string _host = "brianiswu-open-brewery-db-v1.p.rapidapi.com";
        const string _key = "517635a361mshca0e856c0d2b273p11a73djsnc7fd99ee4164";

        public BreweryService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<BreweryItem>> GetBrewery()
        {
            ConfigureHttpClient();

            var response = await _httpClient.GetAsync(_breweryEndpoint);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            var dto = await JsonSerializer.DeserializeAsync<BreweryDto>(stream);

            return dto.Property1.Select(n => new BreweryItem
            {
                id = n.id,
                name = n.name,
            }).ToList();
        }
        private void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _host);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _key);
        }
    }
}
