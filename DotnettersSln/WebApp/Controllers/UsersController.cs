using Microsoft.AspNetCore.Mvc;
using WebApp.Database;
using WebApp.Models;
using WebApp.PasswordValidator;
using WebApp.Repository;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersContext _usersContext;

    public UsersController(UsersContext usersContext)
    {
        _usersContext = usersContext;
    }

    [HttpPost(Name = "CreateUser")]
    public async Task<IActionResult> Create(string name, string password)
    {
        var user = new User(name, password);

        var passwordValidator = new PasswordValidatorImpl();
        var result = passwordValidator.Validate(user);

        if (!string.IsNullOrEmpty(result))
        {
            return BadRequest();
        }

        var userRepository = new UserRepository(_usersContext);
        await userRepository.Save(user);

        return Ok();
    }
}