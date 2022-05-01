using Microsoft.Extensions.DependencyInjection;
using PracticeWebApi.Common;
using System;
using System.Linq;

namespace PracticeWebApi.Configurations
{
    public static class DependencyConfig
    {
        private static Func<Type, bool> IsTargetType = (t) => 
            t.IsVisible && 
            t.IsClass && 
            !t.IsAbstract && 
            t.GetInterface(nameof(IDependencyConfigurer)) is not null;

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetName().Name.StartsWith("PracticeWebApi"));
            foreach (var assembly in assemblies)
            {
                var targets = assembly.GetTypes().ToList().Where(t => IsTargetType(t));
                
                foreach (var target in targets)
                {
                    var type = Activator.CreateInstance(target) as IDependencyConfigurer;
                    type.Configure(services);
                }
            }
        }
    }
}
