using Microsoft.AspNetCore.Components;

namespace CA3Brewery.Brewery
{
    public class BreweryItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string brewery_type { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string website_url { get; set; }
    }
}
