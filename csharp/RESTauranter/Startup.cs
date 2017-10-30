using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;

namespace RESTauranter
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration Configuration;
            services.AddConfiguration(out Configuration);

            // if (Configuration["Database:Type"] == "SQLite")
            // {
            //     services.AddDbContext<aspnetContext>(x => x.UseSqlite(Configuration["Database:ConnectionString"]));
            // }
            // else if (Configuration["Database:Type"] == "MySQL")
            // {
            //     services.AddDbContext<aspnetContext>(x => x.UseMySql(Configuration["Database:ConnectionString"]));
            // }

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession(x => x.IdleTimeout = TimeSpan.FromMinutes(20));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Warning, true);
            app.UseDeveloperExceptionPage();
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
