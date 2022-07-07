using QuokkaDev.Saas.Abstractions;
using System;
using System.Threading.Tasks;

namespace QuokkaDev.Saas.DependencyInjection.Tests
{
    public class CustomTenant : Tenant<Guid>
    {
        public CustomTenant(Guid id, string identifier) : base(id, identifier)
        {
        }
    }

    public class MockResolutionStrategy : ITenantResolutionStrategy
    {
        public string GetTenantIdentifier()
        {
            return "my-tenant-identifier";
        }

        public Task<string> GetTenantIdentifierAsync()
        {
            return Task.FromResult("my-tenant-identifier");
        }
    }

    public class MockStore : ITenantStore<Tenant<int>, int>
    {
        public Tenant<int> GetTenant(string identifier)
        {
            return new(1, "my-tenant-identifier");
        }

        public Task<Tenant<int>> GetTenantAsync(string identifier)
        {
            return Task.FromResult(GetTenant(""));
        }
    }

    public class MockService : ITenantAccessService<Tenant<int>, int>
    {
        public Tenant<int> GetTenant()
        {
            return new(1, "my-tenant-identifier");
        }

        public Task<Tenant<int>> GetTenantAsync()
        {
            return Task.FromResult(GetTenant());
        }
    }

    public class MockAccessor : ITenantAccessor<Tenant<int>, int>
    {
        public Tenant<int>? Tenant => new(1, "my-tenant-identifier");
    }
}
