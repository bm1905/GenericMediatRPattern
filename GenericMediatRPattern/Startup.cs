using System.Collections.Generic;
using GenericMediatRPattern.Data;
using GenericMediatRPattern.Models;
using GenericMediatRPattern.PaymentManager;
using GenericMediatRPattern.PaymentService.Command;
using GenericMediatRPattern.PaymentService.Query;
using GenericMediatRPattern.PluginHandler;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GenericMediatRPattern
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(PluginFactory).Assembly);

            services.AddSingleton<Database>();
            services.AddTransient<IRequestHandler<PaymentManagerSetHandlerRequest<CashPaymentModel>, PaymentManagerSetHandlerResponse>,
                PaymentManagerSetHandler<CashPaymentModel>>();
            services.AddTransient<IRequestHandler<PaymentManagerSetHandlerRequest<CheckPaymentModel>, PaymentManagerSetHandlerResponse>,
                PaymentManagerSetHandler<CheckPaymentModel>>();
            services.AddTransient<IRequestHandler<PaymentManagerGetHandlerRequest<CashPaymentModel>, PaymentManagerGetHandlerResponse<CashPaymentModel>>,
                PaymentManagerGetHandler<CashPaymentModel>>();
            services.AddTransient<IRequestHandler<PaymentManagerGetHandlerRequest<CheckPaymentModel>, PaymentManagerGetHandlerResponse<CheckPaymentModel>>,
                PaymentManagerGetHandler<CheckPaymentModel>>();
            services.AddTransient<IRequestHandler<PaymentManagerGetAllHandlerRequest<CashPaymentModel>, List<PaymentManagerGetHandlerResponse<CashPaymentModel>>>,
                PaymentManagerGetAllHandler<CashPaymentModel>>();
            services.AddTransient<IRequestHandler<PaymentManagerGetAllHandlerRequest<CheckPaymentModel>, List<PaymentManagerGetHandlerResponse<CheckPaymentModel>>>,
                PaymentManagerGetAllHandler<CheckPaymentModel>>();
            services.AddScoped(typeof(IPaymentManager<>), typeof(PaymentManager<>));
            services.AddSingleton(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var pluginFactory = new PluginFactory(configuration);
                pluginFactory.Initialize();
                return pluginFactory;
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
