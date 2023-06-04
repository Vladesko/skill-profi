using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Statements.Application.Common.Dependenies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
