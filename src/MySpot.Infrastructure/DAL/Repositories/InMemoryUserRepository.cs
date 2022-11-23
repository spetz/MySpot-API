using MySpot.Core.Users.Entities;
using MySpot.Core.Users.Repositories;
using MySpot.Core.Users.ValueObjects;

namespace MySpot.Infrastructure.DAL.Repositories;

public sealed class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> Users = new()
    {
        new User(Guid.Parse("00000000-0000-0000-0000-000000000001"), "user1@myspot.io", "secret", "John Doe", "user", "employee"),
        new User(Guid.Parse("00000000-0000-0000-0000-000000000002"), "user2@myspot.io", "secret", "Adam Smith", "user", "employee"),
        new User(Guid.Parse("00000000-0000-0000-0000-000000000003"), "user3@myspot.io", "secret", "Tom Jones", "user", "employee")
    };

    public Task<User> GetAsync(UserId id) => Task.FromResult(Users.SingleOrDefault(x => x.Id == id));

    public Task<User> GetAsync(Email email) => Task.FromResult(Users.SingleOrDefault(x => x.Email == email));

    public Task AddAsync(User user)
    {
        Users.Add(user);
        return Task.CompletedTask;
    }
}