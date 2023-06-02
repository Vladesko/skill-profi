using AutoMapper;
using Statements.Application.Interfaces;
using System.Reflection;

namespace Statements.Application.Common
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            ApplyMappingsFromAssembly(assembly);
        }
        /// <summary>
        /// Scans the assembly and looks for any types that implement the IMapWith interface
        /// </summary>
        /// <param name="assembly"></param>
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(type => type.GetInterfaces().
               Any(intr => intr.IsGenericType && intr.GetGenericTypeDefinition() == typeof(IMapWith<>))).
               ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
