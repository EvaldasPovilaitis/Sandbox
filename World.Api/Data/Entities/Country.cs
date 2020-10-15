namespace World.Data.Entities
{
    using System.Collections.Generic;

    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ContinentId { get; set; }

        public Continent Continent { get; set; }

        public IEnumerable<CountryType> CountryTypes { get; set; }
    }
}
