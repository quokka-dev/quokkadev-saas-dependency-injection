# QuokkaDev.Saas.DependencyInjection
Extensions for register QuokkaDev.Saas  in .NET dependency injection

## Usage
```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMultiTenancy()
            .WithResolutionStrategy<MyTenantResolutionStrategy>()
            .WithStore<MyTenantStore>()
            .WithService<MyTenantAccessService>();
    }
```

`services.AddMultiTenancy()` return a `TenantBuilder` that you can use for configuring various services. You can use one this overload://This is a new tenant, configure a new lifetimescope for it using our tenant sensitive configuration method

- With `services.AddMultiTenancy<TTenant, TKey>()` you can specify the type of your Tenant class and the type of the Id (please, note that you can specify the Id used for persistence scopes, not the identifier which always is a string)
- With `services.AddMultiTenancy<TKey>()` you use the base class `Tenant` for configuring the services but you can specify the type of the Id
- With `services.AddMultiTenancy()` you use the base class `Tenant` with an Id of type `int`. For many scenarios this default can be enough

## TenantBuilder
Once you call `services.AddMultiTenancy()` you get an instance of `TenantBuilder<T, TKey>` on which you can register your services. `TenantBuilder` has some base methods, other extensions methods can be availables if you add other QuokkaDev.Saas packages

### Configure resolution strategy

```csharp
// add MyTenantResolutionStrategy with a default Transient lifetime 
services.AddMultiTenancy().WithResolutionStrategy<MyTenantResolutionStrategy>()

// or you can set a custom lifetime
services.AddMultiTenancy().WithResolutionStrategy<MyTenantResolutionStrategy>(ServiceLifetime.Scoped)

// for development purposes you can pass an instance of your MyTenantResolutionStrategy. In this case it will be registered as a Singleton
services.AddMultiTenancy().WithResolutionStrategy<MyTenantResolutionStrategy>(myStrategyInstance)
```

### Configure store

```csharp
// add MyTenantStore with a default Transient lifetime 
services.AddMultiTenancy().WithStore<MyTenantStore>()

// or you can set a custom lifetime
services.AddMultiTenancy().WithStore<MyTenantStore>(ServiceLifetime.Scoped)

// for development purposes you can pass an instance of your MyTenantStore. In this case it will be registered as a Singleton
services.AddMultiTenancy().WithStore<MyTenantStore>(myStrategyInstance)
```

### Configure Tenant Access Service

```csharp
// add MyTenantAccessService with a default Transient lifetime 
services.AddMultiTenancy().WithService<MyTenantAccessService>()

// or you can set a custom lifetime
services.AddMultiTenancy().WithService<MyTenantAccessService>(ServiceLifetime.Scoped)

// for development purposes you can pass an instance of your MyTenantAccessService. In this case it will be registered as a Singleton
services.AddMultiTenancy().WithService<MyTenantAccessService>(myStrategyInstance)
```

### Configure Tenant Accessor

```csharp
// add MyTenantAccessor with a default Transient lifetime 
services.AddMultiTenancy().WithAccessor<MyTenantAccessor>()

// or you can set a custom lifetime
services.AddMultiTenancy().WithAccessor<MyTenantAccessor>(ServiceLifetime.Scoped)

// for development purposes you can pass an instance of your MyTenantAccessor. In this case it will be registered as a Singleton
services.AddMultiTenancy().WithAccessor<MyTenantAccessor>(myStrategyInstance)
```