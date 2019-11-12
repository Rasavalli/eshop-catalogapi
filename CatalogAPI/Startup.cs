using CatalogAPI.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogAPI
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
            services.AddScoped<CatalogContext>();
            services.AddCors(c =>
            {
                //c.AddDefaultPolicy(x =>
                //{
                //    x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                //});
                //Named Policy
                //c.AddPolicy("AllowPartners", x => {
                //    x.WithOrigins("http://microsoft.com", "http://synergetics.com")
                //    .WithMethods("GET", "POST").AllowAnyHeader();
                //});
                c.AddPolicy("AllowAll", x =>
                {
                    x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title="CatalogAPI",
                    Description ="Catalog Management API Methods for Eshop App",
                    Version="1.0",
                    Contact= new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name="Rasavalli",
                        Email="rasavallid@hexaware.com",
                        Url =""
                    }
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API");
                config.RoutePrefix = "";
            });
            app.UseMvc();
        }
    }
}
