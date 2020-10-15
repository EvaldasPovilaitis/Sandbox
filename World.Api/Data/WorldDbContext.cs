namespace World.Api.Data
{
    using Microsoft.EntityFrameworkCore;
    using World.Data.Entities;

    public class WorldDbContext : DbContext
    {
        public WorldDbContext(DbContextOptions<WorldDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryType>().HasKey(t => new { t.CountryId, t.TypeId });

            modelBuilder.Entity<CountryType>()
                .HasOne(countryType => countryType.Country)
                .WithMany(country => country.CountryTypes)
                .HasForeignKey(countryType => countryType.CountryId);

            modelBuilder.Entity<CountryType>()
                .HasOne(countryType => countryType.Type)
                .WithMany(type => type.CountryTypes)
                .HasForeignKey(countryType => countryType.TypeId);

            modelBuilder.Entity<Continent>().HasData(
                new[]
                {
                    new Continent
                    {
                        Id = 1,
                        Name = "Africa",
                    },
                    new Continent
                    {
                        Id = 2,
                        Name = "Antarctica"
                    },
                    new Continent
                    {
                        Id = 3,
                        Name = "Asia",
                    },
                    new Continent
                    {
                        Id = 4,
                        Name = "Australia",
                    },
                    new Continent
                    {
                        Id = 5,
                        Name = "Europe",
                    },
                    new Continent
                    {
                        Id = 6,
                        Name = "North America"
                    },
                    new Continent
                    {
                        Id = 7,
                        Name = "South America"
                    }
            });

            modelBuilder.Entity<Country>().HasData(
                new[]
                {
                    new Country { Id = 101, Name = "South Africa",  ContinentId = 1 },
                    new Country { Id = 102, Name = "Nigeria",       ContinentId = 1 },
                    new Country { Id = 103, Name = "Kenya",         ContinentId = 1 },
                    new Country { Id = 301, Name = "China",         ContinentId = 3 },
                    new Country { Id = 302, Name = "India",         ContinentId = 3 },
                    new Country { Id = 303, Name = "Japan",         ContinentId = 3 },
                    new Country { Id = 304, Name = "Indonesia",     ContinentId = 3 },
                    new Country { Id = 401, Name = "Australia",     ContinentId = 4 },
                    new Country { Id = 501, Name = "Estonia",       ContinentId = 5 },
                    new Country { Id = 502, Name = "Latvia",        ContinentId = 5 },
                    new Country { Id = 503, Name = "Lithuania",     ContinentId = 5 },
                    new Country { Id = 601, Name = "United States", ContinentId = 6 },
                    new Country { Id = 602, Name = "Canada",        ContinentId = 6 },
                    new Country { Id = 603, Name = "Mexico",        ContinentId = 6 },
                    new Country { Id = 701, Name = "Brazil",        ContinentId = 7 },
                    new Country { Id = 702, Name = "Chile",         ContinentId = 7 },
                    new Country { Id = 703, Name = "Argentina",     ContinentId = 7 },
                    new Country { Id = 704, Name = "Columbia",      ContinentId = 7 }
                });

            modelBuilder.Entity<Type>().HasData(
                new[]
                {
                    new Type { Id = 1, Name = "One of eight" },
                    new Type { Id = 2, Name = "Third world country" },
                    new Type { Id = 3, Name = "One of EU" }
                });

            modelBuilder.Entity<CountryType>().HasData(
                new[]
                {
                    new CountryType { CountryId = 101, TypeId = 1 },
                    new CountryType { CountryId = 101, TypeId = 2 },
                    new CountryType { CountryId = 101, TypeId = 3 },
                    new CountryType { CountryId = 102, TypeId = 1 },
                    new CountryType { CountryId = 103, TypeId = 2 },
                    new CountryType { CountryId = 301, TypeId = 3 },
                    new CountryType { CountryId = 302, TypeId = 1 },
                    new CountryType { CountryId = 303, TypeId = 2 }
                });
        }

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CountryType> CountryTypes { get; set; }

        public DbSet<Type> Types { get; set; }
    }
}
