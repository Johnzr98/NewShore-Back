using BusinessLayer;
using BusinessLayer.Common;
using DataLayer;
using DataLayer.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text;
using NewShore.Api.Filters;

namespace NewShore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IBaseRepository BaseRepository { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opciones =>
            {
                opciones.Filters.Add(typeof(FiltroDeExepcion));
            }).AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            services.AddSingleton(new BaseRepository(Configuration["Api"]));
            services.AddSingleton(new BaseFlights());
            services.AddTransient<IBaseFlights, BaseFlights>();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api NewShore",
                    Description = "api for consult flights",
                });
            });

            string[] allowedOrigins = Configuration["AppConfig:ALLOWEDORIGINS"].Split('|');

            services.AddCors(opciones =>
            {
                opciones.AddDefaultPolicy(builder =>
                {
                    builder
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials()
                   .WithOrigins(allowedOrigins);
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
