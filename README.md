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