using Microsoft.Extensions.DependencyInjection;
using QuokkaDev.Saas.Abstractions;

namespace QuokkaDev.Saas.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the services for a custom tenant of a specific key type
        /// </summary>
        /// <typeparam name="T">Type of tenant class</typeparam>
        /// <typeparam name="TKey">Type of tenant id</typeparam>
        /// <param name="services">The service collection</param>
        /// <returns>The service collection for chaining methods</returns>
        public static TenantBuilder<T, TKey> AddMultiTenancy<T, TKey>(this IServiceCollection services) where T : Tenant<TKey> => new(services);

        /// <summary>
        /// Add the services for Tenant class of a specific key type
        /// </summary>
        /// <typeparam name="TKey">Type of tenant id</typeparam>
        /// <param name="services">The service collection</param>
        /// <returns>The service collection for chaining methods</returns>
        public static TenantBuilder<Tenant<TKey>, TKey> AddMultiTenancy<TKey>(this IServiceCollection services) => new(services);

        /// <summary>
        /// Add the services for Tenant<int> class
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <returns>The service collection for chaining methods</returns>
        public static TenantBuilder<Tenant<int>, int> AddMultiTenancy(this IServiceCollection services) => new(services);
    }
}
