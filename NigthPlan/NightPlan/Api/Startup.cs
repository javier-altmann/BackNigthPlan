using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Services;
using DAL.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
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
             services.AddMvc(); 
             services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        });

            var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,"ApiNightPlan.xml");
            services.AddSwaggerGen(c=>{
                c.IncludeXmlComments(filePath);
            });

            var connection = Configuration.GetConnectionString("NigthPlanMysql");      
           
            services.AddDbContext<nightPlanContext>(options => options.UseMySql(connection));
            services.AddScoped<IGruposService, GruposService>();
            services.AddScoped<IEstablecimientosService, EstablecimientosService>();
            services.AddScoped<IUsuariosService, UsuariosService>();
            services.AddScoped<IRecomendadosService, RecomendacionesService>();
            services.AddScoped<IPreferenciasService, PreferenciasService>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
                });
            }

            app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
