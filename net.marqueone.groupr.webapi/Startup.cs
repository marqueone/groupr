using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using net.marqueone.groupr.shared.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace net.marqueone.groupr.webapi
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
            // services.AddDbContext<GrouprContext>(options =>
            //         options.UseMy(Configuration.GetConnectionString("DefaultConnection"),
            //         b => b.MigrationsAssembly("net.marqueone.childdata.api")));
            services.AddDbContext<GrouprContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), mySqlOptions => { 
                    mySqlOptions.ServerVersion(new ServerVersion(new Version(8, 0, 19), ServerType.MySql)); 
                    mySqlOptions.MigrationsAssembly("net.marqueone.groupr.webapi"); 
                })
            );
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Groupr API V1");
                });
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
