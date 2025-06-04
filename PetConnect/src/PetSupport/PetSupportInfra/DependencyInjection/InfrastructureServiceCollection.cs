using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PetSupportInfra.Persistence.Repositories.Base;
using PetSupportInfra.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetSupportInfra.Persistence.Context;
using Microsoft.Extensions.Configuration;
using PetSupportInfra.Persistence.Repositories.Adoption;

namespace PetSupportInfra.DependencyInjection;

public static class InfrastructureServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<MongoDbContext>();
        services.AddSingleton<IMongoClient>(sp =>
        {
            var settings = MongoClientSettings.FromConnectionString(configuration.GetConnectionString("MongoConnection"));
            return new MongoClient(settings);
        });

        // Repositórios base
        services.AddScoped(typeof(IBaseQueryRepository<>), typeof(IQueryRepository<>));


        services.AddScoped<AdoptionCommandRepository>();
        services.AddScoped<RescueRepository>();
        services.AddScoped<LostPetRepository>();

        return services;
    }
}