namespace World.Api.Controllers
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.OData;
    using World.Api.Data;

    public class CountriesController : ODataController
    {
        private readonly WorldDbContext worldDbContext;
        private readonly IMapper mapper;

        public CountriesController(WorldDbContext worldDbContext, IMapper mapper)
        {
            this.worldDbContext = worldDbContext ?? throw new System.ArgumentNullException(nameof(worldDbContext));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        [EnableQuery]
        public IQueryable<Models.Country> Get() =>
            this.worldDbContext.Countries
                .AsQueryable()
                .ProjectTo<Models.Country>(this.mapper.ConfigurationProvider);

    }
}