using AFORO255.MS.TEST.Transaction.RabbitMQ.EventHandlers;
using AFORO255.MS.TEST.Transaction.RabbitMQ.Events;
using AFORO255.MS.TEST.Transaction.Repository;
using AFORO255.MS.TEST.Transaction.Service;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.AFORO255.Cross.RabbitMQ.RabbitMq;
using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Bus;

namespace AFORO255.MS.TEST.Transaction
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

            /*Start RabbitMQ*/
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            //Subscriptions
            services.AddTransient<TransactionEventHandler>();

            services.AddTransient<IEventHandler<TransactionCreatedEvent>, TransactionEventHandler>();
            /*End RabbitMQ*/

            services.AddScoped<IServiceTransaction, ServiceTransaction>();
            services.AddScoped<IRepositoryTransation, RepositoryTransation>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<TransactionCreatedEvent, TransactionEventHandler>();
        }
    }
}
