
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BestRoute.Core.Services;
using BestRoute.Core.Services.Impl;
using BestRoute.Core.Repository;
using BestRoute.Core.Repository.Impl;
using BestRoute.Core.Business;
using BestRoute.Core.Business.Impl.Algorithms;

namespace BestRoute.OutputApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // config DI
            services.AddSingleton<IRouteRepository, RouteRepository>();
            services.AddSingleton<IAirportRepository, AirportRepository>();
            services.AddSingleton<IShortestPathFinder, Dijkstra>();
            services.AddSingleton<IBestRouteServices, BestRouteService>();

            services.AddControllers();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
