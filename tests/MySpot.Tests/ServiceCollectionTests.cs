using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MySpot.Tests;

public class ServiceCollectionTests
{
    [Fact]
    public void test()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddSingleton<IEnumerable<IDummy>>(new IDummy[]
            {
                new Dummy(),
                new Dummy2(),
                new Dummy3()
            });

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var dummy = serviceProvider.GetService<IEnumerable<IDummy>>();
        
        // HTTP REQUEST 1
        using (var scope = serviceProvider.CreateScope())
        {
            var dummy1 = scope.ServiceProvider.GetService<Dummy>();
            var dummy2 = scope.ServiceProvider.GetService<Dummy>();
            Assert.Same(dummy1, dummy2);
        }
        
        // HTTP REQUEST 2
        using (var scope = serviceProvider.CreateScope())
        {
            var dummy1 = scope.ServiceProvider.GetService<Dummy>();
            var dummy2 = scope.ServiceProvider.GetService<Dummy>();
            Assert.Same(dummy1, dummy2);
        }
    }

    interface IDummy
    {
        Guid Id { get; }
    }

    class Dummy : IDummy
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
    
    class Dummy2 : IDummy
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
    
    class Dummy3 : IDummy
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}