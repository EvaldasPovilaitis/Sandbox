namespace World.Data.Entities
{
    using System.Collections.Generic;

    public class Type
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CountryType> CountryTypes { get; set; }
    }
}
