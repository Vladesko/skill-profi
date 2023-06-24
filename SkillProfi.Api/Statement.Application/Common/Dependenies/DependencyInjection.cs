using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Statements.Application.Common.Behaviors;
using System.Reflection;

namespace Statements.Application.Common.Dependenies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(LogginBehavior<,>));

            return services;
        }
    }
}
