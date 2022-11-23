using MySpot.Core.Users.ValueObjects;

namespace MySpot.Core.Users.Entities;

public class User
{
    public UserId Id { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public FullName FullName { get; private set; }
    public string Role { get; private set; }
    public string JobTitle { get; private set; }

    private User()
    {
    }

    public User(UserId id, Email email, Username username, Password password, FullName fullName, string role = "user",
        string jobTitle = "employee")
    {
        Id = id;
        Email = email;
        Password = password;
        FullName = fullName;
        Role = role;
        JobTitle = jobTitle;
    }
}