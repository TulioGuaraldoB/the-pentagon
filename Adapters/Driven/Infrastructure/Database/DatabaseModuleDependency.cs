using Adapters.Driven.Infrastructure.Database.Context;
using Adapters.Driven.Infrastructure.Database.Repositories;
using Core.Domain.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace Adapters.Driven.Infrastructure.Database
{
    public static class DatabaseModuleDependency
    {
        public static void AddDatabaseModule(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<ISquadRepository, SquadRepository>();
        }
    }
}