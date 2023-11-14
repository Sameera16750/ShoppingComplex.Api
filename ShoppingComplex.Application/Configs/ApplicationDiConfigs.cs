﻿using Microsoft.Extensions.DependencyInjection;
using ShoppingComplex.Application.Services.Implementations;
using ShoppingComplex.Application.Services.Interfaces;

namespace ShoppingComplex.Application.Configs
{
    // this class used for register all dependency injection related to Application layer
    public static class ApplicationDiConfigs
    {
        // Registering Dependency injections to services
        public static IServiceCollection AddApplicationDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<IUserService, IUserServiceImpl>();
            return services;
        }
    }
}