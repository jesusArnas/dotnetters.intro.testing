using WebApp.Database;
using WebApp.Models;
using WebApp.PasswordValidator;
using WebApp.Repository;

namespace WebApp.Features;

public class CreateUser
{
    private readonly UsersContext _usersContext;

    public CreateUser(UsersContext usersContext)
    {
        _usersContext = usersContext;
    }

    public async Task<(bool, string?)> Execute(string name, string password)
    {
        var user = new User(name, password);

        var passwordValidator = new PasswordValidatorImpl();
        var result = passwordValidator.Validate(user);

        if (!string.IsNullOrEmpty(result))
        {
            return (false, result);
        }

        var userRepository = new UserRepository(_usersContext);
        await userRepository.Save(user);

        return (true, null);
    }
}
