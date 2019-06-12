using BazarSapiens.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BazarSapiens
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var strCon = Configuration.GetConnectionString("BazarSQLiteConnection");
            if (Env.IsDevelopment())
            {
                strCon = string.Format(strCon, Env.ContentRootPath);
            }

            services.AddDbContext<BazarContext>(options =>
                options.UseSqlite(strCon));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
