using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Data;
using Microsoft.OpenApi.Models;


namespace TripTracker.BackService
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

            //services.AddTransient<Models.Repository>();
            services.AddControllers();
            services.AddMvc(/*options => options.EnableEndpointRouting = false*/);
            
           services.AddDbContext<TripContext>(options => options.UseSqlite("Data Source=JeffsTrips.db"));
           services.AddDbContext<DesktopComputerContext>(options => options.UseSqlite("Data Source=CCPHDesktopComputers.db"));


            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc
                ("v1", new OpenApiInfo 
                    { 
                        Version = "v1" , 
                        Title = "Trip Tracker", 
                        Description = "none", 
                        Contact = new OpenApiContact() 
                        { 
                            Name = "Dotnet Details",
                            Email = "jessie.reyna@live.com"
                           
                        } 
                    }
                );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            


            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Trip Tracker v1"));

            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseMvc NOT originally here 

           // app.UseMvc( );
            TripContext.SeedData(app.ApplicationServices); //Added 
            DesktopComputerContext.SeedData(app.ApplicationServices);

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
