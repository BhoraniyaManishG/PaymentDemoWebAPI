using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using PaymentDemoService.Services;
using PaymentDemoService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentDemoRepository.Abstraction;
using PaymentDemoService.IPaymentGateways;
using PaymentDemoService.PaymentGateways;
using PaymentDemoRepository.Repositories;
using PaymentDemoRepository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace PaymentDemoAPI.Util
{
    public static class RegisterDependency
    {
        public static IServiceCollection RegisterDI(IServiceCollection services)
        {
            services.AddScoped<DbContext, PaymentDemoModels.Models.PaymentContext>();

            services.AddScoped<IPaymentProcess, PaymentProcess>();
            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddScoped<IPaymentGateway, PremiumPaymentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPaymentInfoRepo, PaymentInfoRepo>();
            services.AddScoped<IPaymentStatusInfoRepo, PaymentStatusInfoRepo>();


            services.AddAutoMapper(typeof(AutomapperProfile));


            return services;
        }
    }
}
