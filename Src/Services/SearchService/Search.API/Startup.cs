using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SearchService.API.Data;
using SearchService.API.Repositories;
using SearchService.API.Repositories.Interfaces;
using SearchService.API.Services;
using SearchService.API.Services.Interfaces;
using SearchService.API.Settings;

namespace SearchService.API
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

            services.AddControllers();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.Configure<SearchDatabaseSettings>(Configuration.GetSection("DatabaseSettings"));

            services.AddSingleton<ISearchDatabaseSettings>(s => 
                s.GetRequiredService<IOptions<SearchDatabaseSettings>>().Value);

            services.AddScoped<ISearchContext, SearchContext>();
            services.AddScoped<ISearchRepository, SearchRepository>();

            services.AddHttpClient<IFlightService,FlightService>(h =>
            {
                h.BaseAddress = new Uri(Configuration["ApiSettings:FlightUrl"]);
            });

            services.AddHttpClient<IHotelService,HotelService>(h =>
            {
                h.BaseAddress = new Uri(Configuration["ApiSettings:HotelUrl"]);
            });

            services.AddScoped<ISearchService, Services.SearchService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Search.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Search.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
