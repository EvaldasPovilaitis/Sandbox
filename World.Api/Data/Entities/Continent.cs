namespace World.Data.Entities
{
    using System.Collections.Generic;

    public class Continent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Country> Countries { get; set; }
    }
}
