using Microsoft.Extensions.DependencyInjection;
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService, UserServiceImpl>();
            services.AddScoped<IFloorService, FloorServiceImpl>();
            services.AddScoped<ISpaceService, SpaceServiceImpl>();
            services.AddScoped<IStoreCategoryService, StoreCategoryServiceImpl>();
            services.AddScoped<IStoreOwnerService, StoreOwnerServiceImpl>();
            services.AddScoped<IStoreService, StoreServiceImpl>();
            services.AddScoped<IContractorService, ContractorServiceImpl>();
            return services;
        }
    }
}