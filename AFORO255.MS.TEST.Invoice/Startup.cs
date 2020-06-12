using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.Invoice.Repository;
using AFORO255.MS.TEST.Invoice.Repository.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AFORO255.MS.TEST.Invoice
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
                 options.UseNpgsql(Configuration["cnpostgres"]);

             });
            services.AddScoped<IContextDatabase, ContextDatabase>();
            //End - Database

            services.AddScoped<IRepositoryInvoice, RepositoryInvoice>();

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
