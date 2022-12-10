namespace CA3Brewery.Brewery
{
    public class BreweryDto
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

        public BreweryItem ToBreweryItem()
        {
            return new BreweryItem
            {
                id = this.id,
                name = this.name,
                brewery_type = this.brewery_type,
                street = this.street,
                city = this.city,
                state = this.state,
                postal_code = this.postal_code,
                country = this.country,
                phone = this.phone,
                website_url = this.website_url
            };
        }

    }
}



