using CA3Brewery.Brewery;
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

        public string Error { get; private set; }

        public BreweryService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(_baseUrl);

            _httpClient = httpClient;
        }

        public async Task<List<BreweryItem>> GetBrewery(int page)
        {
            var response = await _httpClient.GetAsync($"{_breweryEndpoint}?page={page}&per_page=36");
            response.EnsureSuccessStatusCode();

            var string_ = await response.Content.ReadAsStringAsync();

            var dto = JsonConvert.DeserializeObject<List<BreweryDto>>(string_);

            return dto.Select(x => x.ToBreweryItem()).ToList();
        }
        public async Task<BreweryItem> GetRandomBrewery()
        {
            // Make a request to the /breweries endpoint to get a list of all breweries
            var response = await _httpClient.GetAsync("/breweries?per_page=50");
            response.EnsureSuccessStatusCode();

            var string_ = await response.Content.ReadAsStringAsync();

            // Deserialize the response into a list of BreweryDto objects
            var dtoList = JsonConvert.DeserializeObject<List<BreweryDto>>(string_);

            // Select a random brewery from the list
            // Select a random brewery from the list
            var random = new Random();
            var randomIndex = random.Next(0, dtoList.Count);
            var dto = dtoList[randomIndex];

            // Convert the BreweryDto object to a BreweryItem object and return it
            return dto.ToBreweryItem();
        }


        public async Task<BreweryItem> GetBreweryDetails(string id)
        {
            var response = await _httpClient.GetAsync($"{_breweryEndpoint}/{id}");
            response.EnsureSuccessStatusCode();

            var string_ = await response.Content.ReadAsStringAsync();

            var dto = JsonConvert.DeserializeObject<BreweryDto>(string_);

            return dto.ToBreweryItem();
        }


        public async Task<List<BreweryItem>> SearchBreweries(string query)
        {
            var response = await _httpClient.GetAsync($"/breweries/search?query={query}");
            response.EnsureSuccessStatusCode();

            var string_ = await response.Content.ReadAsStringAsync();

            var dto = JsonConvert.DeserializeObject<List<BreweryDto>>(string_);

            if (dto.Count == 0)
            {
                Error = $"No breweries found for search query '{query}'";
                return new List<BreweryItem>();
            }

            return dto.Select(x => x.ToBreweryItem()).ToList();
        }

    }

}