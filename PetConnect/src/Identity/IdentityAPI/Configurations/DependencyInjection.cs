using Microsoft.Extensions.DependencyInjection;
using IdentityCore.Domain;
using IdentityCore.Register.Services;
using IdentityCore.Register.DTOs;
using IdentityCore.Domain.Entities;
using IdentityCore.Interfaces;
using IdentityCore.Register.Interfaces;
using IdentityInfra.Repositories;
using IdentityCore.Login.DTOS;
using IdentityCore.Login.Interfaces;
using IdentityCore.Login.Services;

namespace IdentityAPI.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityDependencies(this IServiceCollection services)
        {
            // Generic Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            // Services
            services.AddScoped<ILoginService<LoginDto>, LoginService>();
            services.AddScoped<IRegistrationService<UserRegisterDto>, UserService>();
            services.AddScoped<IRegistrationService<ProtectorRegisterDto>, ProtectorService>();
            services.AddScoped<IRegistrationService<OngRegisterDto>, OngService>();

            return services;
        }
    }
}
