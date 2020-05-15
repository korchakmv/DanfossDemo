using System.Reflection;
using DanfossHomeTrackingService.Application.Homes.Handlers;
using DanfossHomeTrackingService.Domain;
using DanfossHomeTrackingService.Persistance.Ef;
using DanfossHomeTrackingService.Query.Ef.Homes;
using DanfossHomeTrackingService.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DanfossHomeTrackingService.WebApi
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

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "Danfoss Smart Home Tracking", Version = "v1"});
            });
            
            services.AddDbContext<DanfossDbContext>(
                builder => builder.UseInMemoryDatabase("Danfoss"));

            services.AddMediatR(
                Assembly.GetAssembly(typeof(GetAllQueryHandler)),
                Assembly.GetAssembly(typeof(CreateHomeRequestHandler)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Danfoss Smart Home Tracking");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            using (var serviceScope = app.ApplicationServices.CreateScope())
                AddTestData(serviceScope.ServiceProvider.GetService<DanfossDbContext>());
        }
        
        private void AddTestData(DanfossDbContext db)
        {
            var home = new Home("Address 1");

            var sensors = new[]
            {
                new Sensor("Sensor1", SensorType.Water, home)
            };

            foreach (var sensor in sensors) 
                home.AddSensor(sensor);

            db.Homes.Add(home);
            db.SaveChanges();
        }
    }
}