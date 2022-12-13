using Newtonsoft.Json;

namespace CA3Brewery.Brewery
{
    public interface IBreweryService
    {
        Task<List<BreweryItem>> GetBrewery();
        Task<BreweryItem> GetRandomBrewery();
        Task<BreweryItem> GetBreweryDetails(string id);
        Task<List<BreweryItem>> SearchBreweries(string query);
        Task<List<BreweryItem>> GetBreweriesPaginated(int page);
    }
}
