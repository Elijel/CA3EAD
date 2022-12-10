using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

namespace CA3Brewery.Brewery
{
    public class BreweryService : IBreweryService
    {
        private readonly HttpClient _httpClient;
        const string _baseUrl = "https://api.openbrewerydb.org";
        const string _breweryEndpoint = "/breweries";

        public BreweryService(HttpClient httpClient)
        {
            // Set the base address of the HttpClient in the constructor, so that it is only called once
            httpClient.BaseAddress = new Uri(_baseUrl);

            _httpClient = httpClient;
        }

        public async Task<List<BreweryItem>> GetBrewery()
        {
            var response = await _httpClient.GetAsync(_breweryEndpoint);
            response.EnsureSuccessStatusCode();

            var string_ = await response.Content.ReadAsStringAsync();

            var dto = JsonConvert.DeserializeObject<List<BreweryDto>>(string_);

            return dto.Select(x => x.ToBreweryItem()).ToList();
        }

        public async Task<BreweryItem> GetBreweryDetails(string id)
        {
            var response = await _httpClient.GetAsync($"{_breweryEndpoint}/{id}");
            response.EnsureSuccessStatusCode();

            var string_ = await response.Content.ReadAsStringAsync();

            var dto = JsonConvert.DeserializeObject<BreweryDto>(string_);

            return dto.ToBreweryItem();
        }
    }

}
