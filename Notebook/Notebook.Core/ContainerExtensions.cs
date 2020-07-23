using Notebook.Core.Services.Contracts;
using Notebook.Core.Repositories.Contracts;
using Notebook.Core.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Notebook.Core.Repositories.Implementations;

namespace Notebook.Core
{
    /// <summary>
    /// Extensions for service collection.
    /// </summary>
    public static class ContainerExtensions
    {
        /// <summary>
        /// Adds the database contracts and immplementatons to IoC container.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection UseDatabase(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IUnitOfWorkFactory<>), typeof(UnitOfWorkFactory<>));
            services.AddScoped(typeof(IDbContextFactory<>), typeof(DbContextFactory<>));

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }

        /// <summary>
        /// Adds the "unit of work" contracts and immplementatons to IoC container.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection UseUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IUnitOfWorkFactory<>), typeof(UnitOfWorkFactory<>));
            services.AddScoped(typeof(IDbContextFactory<>), typeof(DbContextFactory<>));

            return services;
        }

        /// <summary>
        /// Adds the business services contracts and immplementatons to IoC container.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection UseBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
