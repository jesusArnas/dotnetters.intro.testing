using WebApp.Database;
using WebApp.Database.Entities;
using WebApp.Models;

namespace WebApp.Repository;

public class UserRepository
{
    private readonly UsersContext _usersContext;

    public UserRepository(UsersContext usersContext)
    {
        _usersContext = usersContext;
    }

    internal async Task Save(User user)
    {
        await _usersContext.Users.AddAsync(new UserEntity { Name = user.Name, Password = user.Password! });
        await _usersContext.SaveChangesAsync();
    }
}
