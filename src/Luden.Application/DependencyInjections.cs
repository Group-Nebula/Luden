using Microsoft.Extensions.DependencyInjection;
using Luden.Application.Interfaces;
using Luden.Application.Services;

namespace Luden.Application
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}