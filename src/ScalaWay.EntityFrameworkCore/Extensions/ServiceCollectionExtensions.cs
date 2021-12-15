using Microsoft.Extensions.DependencyInjection;
using ScalaWay.Domain.Abstractions.Entities;
using ScalaWay.Domain.Abstractions.Repositories;
using ScalaWay.EntityFrameworkCore.Dependencies;
using System.Reflection;

namespace ScalaWay.EntityFrameworkCore.Extensions
{
    /// <summary>
    /// https://github.com/thangchung/clean-architecture-dotnet/blob/main/src/N8T.Infrastructure.EfCore/Extensions.cs
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Find any concrete implementation of EntityTypeConfiguration inside target assembly and register
        /// them in the services container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IServiceCollection AddEntityTypeConfiguration(
            this IServiceCollection services,
            Assembly assembly)
        {
            var types = assembly.DefinedTypes.Where(t => !t.IsGenericTypeDefinition
                && !t.IsAbstract
                && typeof(EntityTypeConfigurationDependency).IsAssignableFrom(t));

            foreach (var type in types)
            {
                services.AddSingleton(typeof(EntityTypeConfigurationDependency), type);
            }
            return services;
        }
    }
}