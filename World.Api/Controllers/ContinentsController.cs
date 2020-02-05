namespace World.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using World.Api.Data;

    public class ContinentsController : ODataController
    {
        private readonly WorldDbContext worldDbContext;
        private readonly IMapper mapper;

        public ContinentsController(WorldDbContext worldDbContext, IMapper mapper)
        {
            this.worldDbContext = worldDbContext ?? throw new ArgumentNullException(nameof(worldDbContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [EnableQuery]
        public IQueryable<Models.Continent> Get() =>
            this.worldDbContext.Continents
                .AsQueryable()
                .ProjectTo<Models.Continent>(this.mapper.ConfigurationProvider);
    }
}