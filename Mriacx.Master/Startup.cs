using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mriacx.Entity.CommonEntity;
using Mriacx.Master.Extensions;

namespace Mriacx.Master
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

            #region Add HttpContent
            services.AddHttpContextAccessor();
            #endregion

            #region Add AllService
            services.Configure<AssemblyOption>(Configuration.GetSection("assembly")).AddServices();
            #endregion

            #region Add Cors
            services.AddCors(options => options.AddPolicy("cors", builder => builder.AllowAnyOrigin().AllowAnyMethod().WithHeaders("Accept", "Content-Type", "Origin", "Authorization", "Referer", "User-Agent").AllowAnyHeader()));
            #endregion

            #region Add DbContext

            #endregion
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("cors");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
