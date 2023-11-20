using Luden.Application.Interfaces;
using Luden.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Luden.Application
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IRpgService, RpgService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IRpgSystemService, RpgSystemService>();
            services.AddScoped<ICharacterSkillService, CharacterSkillService>();
            services.AddScoped<ISkillService, SkillService>();
        }
    }
}