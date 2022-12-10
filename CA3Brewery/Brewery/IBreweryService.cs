using Newtonsoft.Json;

namespace CA3Brewery.Brewery
{
    public interface IBreweryService
    {
        Task<List<BreweryItem>> GetBrewery();
        Task<BreweryItem> GetBreweryDetails(string id);
    }
}
