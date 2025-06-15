using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PetSupportInfra.Persistence.Repositories.Base;
using PetSupportInfra.Persistence.Context;
using Microsoft.Extensions.Configuration;
using PetSupportInfra.Persistence.Repositories.Adoption;
using PetSupportInfra.Persistence.Repositories.Base.Interfaces;
using PetSupportInfra.Persistence.Repositories.LostPet;
using PetSupportInfra.Persistence.Repositories.Rescue;

namespace PetSupportInfra.DependencyInjection;

public static class InfrastructureServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<MongoDbContext>();

        services.AddScoped(typeof(IBaseCommandRepository<>), typeof(BaseCommandRepository<>));
        services.AddScoped(typeof(IBaseQueryRepository<>), typeof(BaseQueryRepository<>));

        services.AddScoped<AdoptionCommandRepository>();
        services.AddScoped<AdoptionQueryRepository>();

        services.AddScoped<LostPetCommandRepository>();
        services.AddScoped<LostPetQueryRepository>();

        services.AddScoped<RescueCommandRepository>();
        services.AddScoped<RescueQueryRepository>();

        return services;
    }
}