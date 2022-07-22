﻿using MediatR;
using MediatRPattern.Command.PaymentService;
using MediatRPattern.Data;
using MediatRPattern.Models;
using MediatRPattern.PaymentManager;
using MediatRPattern.Query.PaymentService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MediatRPattern
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
            services.AddSingleton<Database>();

            services.AddTransient<IRequestHandler<PaymentManagerSetHandlerRequest<CashPaymentModel>, PaymentManagerSetHandlerResponse>,
                PaymentManagerSetHandler<CashPaymentModel>>();
            services.AddTransient<IRequestHandler<PaymentManagerSetHandlerRequest<CheckPaymentModel>, PaymentManagerSetHandlerResponse>,
                PaymentManagerSetHandler<CheckPaymentModel>>();
            services.AddTransient<IRequestHandler<PaymentManagerGetHandlerRequest<CashPaymentModel>, PaymentManagerGetHandlerResponse<CashPaymentModel>>,
                PaymentManagerGetHandler<CashPaymentModel>>();
            services.AddTransient<IRequestHandler<PaymentManagerGetHandlerRequest<CheckPaymentModel>, PaymentManagerGetHandlerResponse<CheckPaymentModel>>,
                PaymentManagerGetHandler<CheckPaymentModel>>();

            services.AddScoped(typeof(IPaymentManager<>), typeof(PaymentManager<>));
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
