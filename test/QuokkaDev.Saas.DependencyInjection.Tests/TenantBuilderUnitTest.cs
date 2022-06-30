using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QuokkaDev.Saas.Abstractions;
using System.Linq;
using Xunit;

namespace QuokkaDev.Saas.DependencyInjection.Tests;

public class TenantBuilderUnitTest
{
    [Fact(DisplayName = "WithResolutionstrategy should register correct type")]
    public void WithResolutionstrategy_Should_Register_Correct_Type()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        TenantBuilder<Tenant<int>, int> tenantBuilder = new(services);

        // Act
        tenantBuilder.WithResolutionStrategy<MockResolutionStrategy>(ServiceLifetime.Singleton);
        var strategy = services.FirstOrDefault(sd => sd.ServiceType == typeof(ITenantResolutionStrategy));
        // Assert
        strategy.Should().NotBeNull();
        strategy?.ImplementationType.Should().NotBeNull();
        strategy?.ImplementationType.Should().Be(typeof(MockResolutionStrategy));
        strategy?.Lifetime.Should().Be(ServiceLifetime.Singleton);
        strategy?.ImplementationInstance.Should().BeNull();
    }

    [Fact(DisplayName = "WithResolutionstrategy should register correct instance")]
    public void WithResolutionstrategy_Should_Register_Correct_Instance()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        TenantBuilder<Tenant<int>, int> tenantBuilder = new(services);
        MockResolutionStrategy strategyInstance = new();

        // Act
        tenantBuilder.WithResolutionStrategy<MockResolutionStrategy>(strategyInstance);
        var strategy = services.FirstOrDefault(sd => sd.ServiceType == typeof(ITenantResolutionStrategy));
        // Assert
        strategy.Should().NotBeNull();
        strategy?.Lifetime.Should().Be(ServiceLifetime.Singleton);
        strategy?.ImplementationInstance.Should().NotBeNull();
        strategy?.ImplementationInstance.Should().BeSameAs(strategyInstance);
    }

    [Fact(DisplayName = "WithStore should register correct type")]
    public void WithStore_Should_Register_Correct_Type()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        TenantBuilder<Tenant<int>, int> tenantBuilder = new(services);

        // Act
        tenantBuilder.WithStore<MockStore>(ServiceLifetime.Singleton);
        var store = services.FirstOrDefault(sd => sd.ServiceType == typeof(ITenantStore<Tenant<int>, int>));
        // Assert
        store.Should().NotBeNull();
        store?.ImplementationType.Should().NotBeNull();
        store?.ImplementationType.Should().Be(typeof(MockStore));
        store?.Lifetime.Should().Be(ServiceLifetime.Singleton);
        store?.ImplementationInstance.Should().BeNull();
    }

    [Fact(DisplayName = "WithStore should register correct instance")]
    public void WithStore_Should_Register_Correct_Instance()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        TenantBuilder<Tenant<int>, int> tenantBuilder = new(services);
        MockStore storeInstance = new();

        // Act
        tenantBuilder.WithStore<MockStore>(storeInstance);
        var store = services.FirstOrDefault(sd => sd.ServiceType == typeof(ITenantStore<Tenant<int>, int>));
        // Assert
        store.Should().NotBeNull();
        store?.Lifetime.Should().Be(ServiceLifetime.Singleton);
        store?.ImplementationInstance.Should().NotBeNull();
        store?.ImplementationInstance.Should().BeSameAs(storeInstance);
    }

    [Fact(DisplayName = "WithService should register correct type")]
    public void WithService_Should_Register_Correct_Type()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        TenantBuilder<Tenant<int>, int> tenantBuilder = new(services);

        // Act
        tenantBuilder.WithService<MockService>(ServiceLifetime.Singleton);
        var service = services.FirstOrDefault(sd => sd.ServiceType == typeof(ITenantAccessService<Tenant<int>, int>));
        // Assert
        service.Should().NotBeNull();
        service?.ImplementationType.Should().NotBeNull();
        service?.ImplementationType.Should().Be(typeof(MockService));
        service?.Lifetime.Should().Be(ServiceLifetime.Singleton);
        service?.ImplementationInstance.Should().BeNull();
    }

    [Fact(DisplayName = "WithService should register correct instance")]
    public void WithService_Should_Register_Correct_Instance()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        TenantBuilder<Tenant<int>, int> tenantBuilder = new(services);
        MockService serviceInstance = new();

        // Act
        tenantBuilder.WithService<MockService>(serviceInstance);
        var service = services.FirstOrDefault(sd => sd.ServiceType == typeof(ITenantAccessService<Tenant<int>, int>));
        // Assert
        service.Should().NotBeNull();
        service?.Lifetime.Should().Be(ServiceLifetime.Singleton);
        service?.ImplementationInstance.Should().NotBeNull();
        service?.ImplementationInstance.Should().BeSameAs(serviceInstance);
    }
}