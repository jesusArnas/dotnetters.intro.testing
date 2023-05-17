using Microsoft.AspNetCore.Mvc;
using WebApp.Database;
using WebApp.Features;
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
        var createUser = new CreateUser(_usersContext);

        var result = await createUser.Execute(name, password);

        if (!result.Item1)
        {
            return BadRequest();
        }

        return Ok();
    }
}