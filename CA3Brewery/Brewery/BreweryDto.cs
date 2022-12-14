namespace CA3Brewery.Brewery
{
    public class BreweryDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Brewery_type { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Postal_code { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Website_url { get; set; }

        public BreweryItem ToBreweryItem()
        {
            return new BreweryItem
            {
                Id = this.Id,
                Name = this.Name,
                Brewery_type = this.Brewery_type,
                Street = this.Street,
                City = this.City,
                State = this.State,
                Postal_code = this.Postal_code,
                Country = this.Country,
                Phone = this.Phone,
                Website_url = this.Website_url
            };
        }

    }
}



