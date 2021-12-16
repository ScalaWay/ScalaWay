using Lucius.Data.Abstractions.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScalaWay.EntityFrameworkCore.Uow;
using ScalaWay.Utils.Extentions;

namespace ScalaWay.EntityFrameworkCore.Extensions
{
    /// <summary>
    /// Extension methods for setting up unit of work related services in an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class UnitOfWorkServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the unit of work for a given context as a service in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TContext">The type of the db context.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained.</returns>
        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.Replace<IUnitOfWork<TContext>, UnitOfWork<TContext>>(ServiceLifetime.Scoped);
            return services;
        }
    }
}