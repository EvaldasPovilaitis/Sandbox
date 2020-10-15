namespace World.Data.Entities
{
    public class CountryType
    {
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int TypeId { get; set; }

        public Type Type { get; set; }
    }
}