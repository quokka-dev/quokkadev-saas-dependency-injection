using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using QuokkaDev.Saas.Abstractions;
using System;
using Xunit;

namespace QuokkaDev.Saas.DependencyInjection.Tests
{
    public class ServiceCollectionExtensionsUnitTest
    {
        public ServiceCollectionExtensionsUnitTest()
        {
        }

        [Fact(DisplayName = "AddMultiTenancy return right builder")]
        public void AddMultiTenancy_Return_Right_Builder()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();

            // Act
            var b1 = services.AddMultiTenancy<CustomTenant, Guid>();
            var b2 = services.AddMultiTenancy<Guid>();
            var b3 = services.AddMultiTenancy();

            // Assert
            b1.Should().NotBeNull();
            b1.Should().BeOfType<TenantBuilder<CustomTenant, Guid>>();

            b2.Should().NotBeNull();
            b2.Should().BeOfType<TenantBuilder<Tenant<Guid>, Guid>>();

            b3.Should().NotBeNull();
            b3.Should().BeOfType<TenantBuilder<Tenant<int>, int>>();
        }
    }
}
