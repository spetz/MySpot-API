using Microsoft.Extensions.DependencyInjection;
using MySpot.Core.Shared.Time;
using MySpot.Core.Users.Entities;
using Xunit;

namespace MySpot.Tests;

public class ServiceCollectionTests
{
    [Fact]
    public void test()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddSingleton<Dummy>()
            .AddScoped<IClock, DateTimeClock>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        
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
    
    

    class Dummy
    {
        private readonly IClock _clock;

        public Dummy(IClock clock)
        {
            _clock = clock;
        }
        
        public Guid Id { get; } = Guid.NewGuid();
    }
}