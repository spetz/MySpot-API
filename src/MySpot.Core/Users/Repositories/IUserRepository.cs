using MySpot.Core.Users.Entities;
using MySpot.Core.Users.ValueObjects;

namespace MySpot.Core.Users.Repositories;

public interface IUserRepository
{
    Task<User> GetAsync(UserId id);
    Task<User> GetAsync(Email email);
    Task AddAsync(User user);
}