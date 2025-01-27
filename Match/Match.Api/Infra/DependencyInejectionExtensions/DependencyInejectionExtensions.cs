using Match.Domain.Core;
using Match.Infrastructure.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using System.Xml.Linq;

namespace Match.Api.Infra.DependencyInejectionExtensions
{
    public static class DependencyInejectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assemblies = new[]
            {
                Assembly.Load("Match.Application"),
                Assembly.Load("Match.Infrastructure"),
                Assembly.Load("Match.Domain")
            };

            foreach (var assembly in assemblies)
            {
                RegisterByPrefix(services, assembly, "IAplic", "Aplic");
                RegisterByPrefix(services, assembly, "IServ", "Serv");
                RegisterByPrefix(services, assembly, "IRep", "Rep");  
            }
        }

        private static void RegisterByPrefix(IServiceCollection services, Assembly assembly, string interfacePrefix, string classPrefix)
        {

            var types = assembly.GetTypes()
                .Where(t => t.IsClass
                && !t.IsAbstract
                && t.Name.StartsWith(classPrefix)
                && !t.Name.EndsWith("RepCore`1")
                && !t.Name.EndsWith("ServCore`1"))
                .ToList();

            foreach (var type in types)
            {

                var interfaceType = type.GetInterfaces()
                .FirstOrDefault(i => i.Name.StartsWith(interfacePrefix));

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, type);
                }


            }
        }
    }
}
