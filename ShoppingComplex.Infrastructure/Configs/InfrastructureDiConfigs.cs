using Microsoft.Extensions.DependencyInjection;
using ShoppingComplex.Infrastructure.Repositories.Implementations;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Infrastructure.Configs
{
    // this class used for register all dependency injection related to Infrastructure layer
    public static class InfrastructureDiConfigs
    {
        // Registering Dependency injections to services
        public static IServiceCollection AddInfrastructureDependencyGroup(
            this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, IUserRepoImpl>();
            services.AddScoped<IFloorRepo, FloorRepoImpl>();
            services.AddScoped<ISpaceRepo, SpaceRepoImpl>();
            services.AddScoped<IStoreCategoryRepo, StoreCategoryRepoImpl>();
            services.AddScoped<IStoreOwnerRepo, StoreOwnerRepoImpl>();
            return services;
        }
    }
}