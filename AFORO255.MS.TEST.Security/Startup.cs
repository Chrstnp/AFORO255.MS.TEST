using AFORO255.MS.TEST.Security.Repository;
using AFORO255.MS.TEST.Security.Repository.Data;
using AFORO255.MS.TEST.Security.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AFORO255.MS.TEST.Security
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //Start - Database
            services.AddDbContext<ContextDatabase>(
            options =>
            {
                options.UseSqlServer(Configuration["cnsql"]);
            });
            services.AddScoped<IContextDatabase, ContextDatabase>();
            //End - Database

            services.AddScoped<IServiceAccess, ServiceAccess>();
            services.AddScoped<IRepositoryAccess, RepositoryAccess>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
