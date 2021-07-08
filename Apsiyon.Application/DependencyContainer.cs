using Apsiyon.Application.Interfaces;
using Apsiyon.Application.Profiles;
using Apsiyon.Application.Services;
using Apsiyon.Domain.Interfaces;
using Apsiyon.Domain.Models;
using Apsiyon.Infrastructure;
using Apsiyon.Infrastructure.Context;
using Apsiyon.Infrastructure.Repositories;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterApsiyon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApsiyonDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"))
            .UseLazyLoadingProxies());

            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApsiyonDbContext>();

            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<IFlatRepository, FlatRepository>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            //services.AddHttpClient<ICreditCardService, CreditCardService>(options =>
            //{
            //    options.BaseAddress = new Uri(configuration["CreditCard:Url"]);
            //});

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.AddProfile(new FlatProfile());
                cfg.AddProfile(new ApartmentProfile());
                cfg.AddProfile(new SubscriptionProfile());
                cfg.AddProfile(new SubscriptionProfile());
                cfg.AddProfile(new UserProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
