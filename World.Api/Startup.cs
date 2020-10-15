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
    using Microsoft.OData.Edm;
    using World.Api.Data;
    using System.Linq;

    internal class Startup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<WorldDbContext>(dbContextOptionsBuilder =>
                dbContextOptionsBuilder
                    .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=World;Integrated Security=True;")
                    .UseLoggerFactory(LoggerFactory.Create(loggingBuilder =>
                        loggingBuilder
                            .AddDebug()
                            .SetMinimumLevel(LogLevel.Information))));

            serviceCollection.AddAutoMapper(mapperConfigurationExpression =>
                {
                    mapperConfigurationExpression.CreateMap<World.Data.Entities.Continent, Models.Continent>();
                    mapperConfigurationExpression.CreateMap<World.Data.Entities.Country, Models.Country>()
                        .ForMember(c => c.Types, opt => opt.MapFrom(x => x.CountryTypes.Select(y => y.Type)));
                    mapperConfigurationExpression.CreateMap<World.Data.Entities.Type, Models.Type>();
                },
                typeof(Startup));


            serviceCollection.AddOData();
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostingEnvironment)
        {
            if (webHostingEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }

            applicationBuilder.UseHttpsRedirection();

            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(endpointRouteBuilder =>
            {
                endpointRouteBuilder.MapODataRoute("odata", "odata", getEdmModel(applicationBuilder)).Select().Expand().Count().Filter().MaxTop(4);
            });

            static IEdmModel getEdmModel(IApplicationBuilder applicationBuilder)
            {
                var oDataConventionBuilder = new ODataConventionModelBuilder(applicationBuilder.ApplicationServices);
                
                oDataConventionBuilder.EntitySet<Models.Continent>("Continents");
                oDataConventionBuilder.EntitySet<Models.Country>("Countries");
                oDataConventionBuilder.EntitySet<Models.Type>("Types");

                return oDataConventionBuilder.GetEdmModel();
            }
        }
    }
}
