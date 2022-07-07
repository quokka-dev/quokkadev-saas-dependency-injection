using Microsoft.Extensions.DependencyInjection;
using QuokkaDev.Saas.Abstractions;

namespace QuokkaDev.Saas.DependencyInjection
{
    /// <summary>
    /// Configure tenant services
    /// </summary>
    public class TenantBuilder<T, TKey> where T : Tenant<TKey>
    {
        public readonly IServiceCollection Services;

        public TenantBuilder(IServiceCollection services)
        {
            Services = services;
        }

        /// <summary>
        /// Register the tenant strategy implementation
        /// </summary>
        /// <typeparam name="TStrategy">Type of the strategy</typeparam>
        /// <param name="lifetime">Lifetime for the strategy. Default value is transient</param>
        /// <returns>The tenant builder for chaining methods</returns>
        public TenantBuilder<T, TKey> WithResolutionStrategy<TStrategy>(ServiceLifetime lifetime = ServiceLifetime.Transient) where TStrategy : class, ITenantResolutionStrategy
        {
            Services.Add(ServiceDescriptor.Describe(typeof(ITenantResolutionStrategy), typeof(TStrategy), lifetime));
            return this;
        }

        /// <summary>
        /// Register the tenant strategy implementation
        /// </summary>
        /// <typeparam name="TStrategy">Type of the strategy</typeparam>
        /// <param name="strategyInstance">The strategy instance. The strategy will be registered as singleton</param>
        /// <returns>The tenant builder for chaining methods</returns>
        public TenantBuilder<T, TKey> WithResolutionStrategy<TStrategy>(TStrategy strategyInstance) where TStrategy : class, ITenantResolutionStrategy
        {
            Services.AddSingleton<ITenantResolutionStrategy>(strategyInstance);
            return this;
        }

        /// <summary>
        /// Register the tenant store implementation
        /// </summary>
        /// <typeparam name="TStore">Type of the store</typeparam>
        /// <param name="storeInstance">the store instance. The store will be registered as singleton</param>
        /// <returns>The tenant builder for chaining methods</returns>
        public TenantBuilder<T, TKey> WithStore<TStore>(ServiceLifetime lifetime = ServiceLifetime.Transient) where TStore : class, ITenantStore<T, TKey>
        {
            Services.Add(ServiceDescriptor.Describe(typeof(ITenantStore<T, TKey>), typeof(TStore), lifetime));
            return this;
        }

        /// <summary>
        /// Register the tenant store implementation
        /// </summary>
        /// <typeparam name="TStore">Type of the store</typeparam>
        /// <param name="storeInstance">the store instance. The store will be registered as singleton</param>
        /// <returns>The tenant builder for chaining methods</returns>
        public TenantBuilder<T, TKey> WithStore<TStore>(TStore storeInstance) where TStore : class, ITenantStore<T, TKey>
        {
            Services.AddSingleton<ITenantStore<T, TKey>>(storeInstance);
            return this;
        }

        /// <summary>
        /// Register the tenant access service implementation
        /// </summary>
        /// <typeparam name="TService">Type of tenant access service</typeparam>
        /// <param name="lifetime">Lifetime for the service. Default value is transient</param>
        /// <returns>The tenant builder for chaining methods</returns>
        public TenantBuilder<T, TKey> WithService<TService>(ServiceLifetime lifetime = ServiceLifetime.Transient) where TService : class, ITenantAccessService<T, TKey>
        {
            Services.Add(ServiceDescriptor.Describe(typeof(ITenantAccessService<T, TKey>), typeof(TService), lifetime));
            return this;
        }

        /// <summary>
        /// Register the tenant access service implementation
        /// </summary>
        /// <typeparam name="TService">Type of tenant access service</typeparam>
        /// <param name="serviceInstance">the service instance. The service will be registered as singleton</param>
        /// <returns>The tenant builder for chaining methods</returns>
        public TenantBuilder<T, TKey> WithService<TService>(TService serviceInstance) where TService : class, ITenantAccessService<T, TKey>
        {
            Services.AddSingleton<ITenantAccessService<T, TKey>>(serviceInstance);
            return this;
        }

        /// <summary>
        /// Register the tenant accessor implementation
        /// </summary>
        /// <typeparam name="TService">Type of tenant accessor</typeparam>
        /// <param name="lifetime">Lifetime for the service. Default value is scoped</param>
        /// <returns>The tenant builder for chaining methods</returns>
        public TenantBuilder<T, TKey> WithAccessor<TAccessor>(ServiceLifetime lifetime = ServiceLifetime.Scoped) where TAccessor : class, ITenantAccessor<T, TKey>
        {
            Services.Add(ServiceDescriptor.Describe(typeof(ITenantAccessor<T, TKey>), typeof(TAccessor), lifetime));
            return this;
        }

        /// <summary>
        /// Register the tenant accessor implementation
        /// </summary>
        /// <typeparam name="TService">Type of tenant accessor</typeparam>
        /// <param name="serviceInstance">the accessor instance. The service will be registered as singleton</param>
        /// <returns>The tenant builder for chaining methods</returns>
        public TenantBuilder<T, TKey> WithAccessor<TAccessor>(TAccessor serviceInstance) where TAccessor : class, ITenantAccessor<T, TKey>
        {
            Services.AddSingleton<ITenantAccessor<T, TKey>>(serviceInstance);
            return this;
        }
    }
}
