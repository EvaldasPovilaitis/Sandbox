namespace World.Api
{
    using AutoMapper;
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    using World.Api.Data;

    internal class Startup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<WorldDbContext>(dbContextOptionsBuilder =>
                dbContextOptionsBuilder
                    .UseLoggerFactory(LoggerFactory.Create(loggingBuilder => loggingBuilder.AddDebug().SetMinimumLevel(LogLevel.Information)))
                    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=World;Integrated Security=True;"));

            serviceCollection.AddAutoMapper(mapperConfigurationExpression =>
                {
                    mapperConfigurationExpression.CreateMap<World.Data.Entities.Continent, Models.Continent>();
                    mapperConfigurationExpression.CreateMap<World.Data.Entities.Country, Models.Country>();
                },
                typeof(Startup));


            serviceCollection.AddMvc(mvcOptions => mvcOptions.EnableEndpointRouting = false);
            serviceCollection.AddOData();
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostingEnvironment)
        {
            if (webHostingEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }

            applicationBuilder.UseHttpsRedirection();

            var oDataConventionBuilder = new ODataConventionModelBuilder(applicationBuilder.ApplicationServices);
            oDataConventionBuilder.EntitySet<Models.Continent>("Continents");
            oDataConventionBuilder.EntitySet<Models.Country>("Countries");

            applicationBuilder.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();

                routeBuilder.MapODataServiceRoute("ODataRoute", "odata", oDataConventionBuilder.GetEdmModel());

            });
        }
    }
}
