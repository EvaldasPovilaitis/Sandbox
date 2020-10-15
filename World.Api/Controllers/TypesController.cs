namespace World.Api.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.OData;
    using World.Api.Data;

    public class TypesController : ODataController
    {
        private readonly WorldDbContext worldDbContext;
        private readonly IMapper mapper;

        public TypesController(WorldDbContext worldDbContext, IMapper mapper)
        {
            this.worldDbContext = worldDbContext ?? throw new ArgumentNullException(nameof(worldDbContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [EnableQuery]
        public IQueryable<Models.Type> Get() =>
            this.worldDbContext.Types
                .ProjectTo<Models.Type>(this.mapper.ConfigurationProvider);
    }
}