using Core.Application.Services;
using Core.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<ISquadService, SquadService>();
        }
    }
}