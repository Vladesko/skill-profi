using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Statements.Application.Interfaces;

namespace Statements.Persistance.Dependencies
{
    public static class DependencyInjection
    {
        /// <summary>
        /// This method add context for database
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["DbConnection"];
            services.AddDbContext<StatementDbContext>(options => 
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IStatementDbContext>(provider => provider.GetService<StatementDbContext>());
            return services;
        }
    }
}
