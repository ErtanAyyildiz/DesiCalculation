using Enoca.Business.Abstracts;
using Enoca.Business.Concretes;
using Enoca.Business.Validators;
using Enoca.Entity.Modals;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.IoC
{
    public static class ModuleInjector
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            //services.AddTransient<IValidator<Project>, ProjectValidator>();

            services.AddScoped<ICarrierService, CarrierManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<ICarrierConfigurationService, CarrierConfigurationManager>();

            services.AddScoped<IValidator<Order>, OrderValidator>();
            services.AddScoped<IValidator<Carrier>, CarriersValidator>();
            services.AddScoped<IValidator<CarrierConfiguration>, CarrierConfigurationValidator>();

            return services;
        }
    }
}
