using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using WebApp.Database;
using WebApp.Database.Entities;
using WebApp.Features;

namespace UnitTests;

public class CreateUserShould
{
    [Fact]
    public async Task ReturnExpectedError_GivenInvalidPassword()
    {
        var usersContextMock = new Mock<UsersContext>();

        var createUser = new CreateUser(usersContextMock.Object);

        var result = await createUser.Execute("name", "name");

        result.Item1.Should().BeFalse();
    }

    [Fact]
    public async Task ReturnSuccess_GivenValidPassword()
    {
        var usersContextMock = new Mock<UsersContext>();
        usersContextMock
            .Setup(mock => mock.Users)
            .ReturnsDbSet(new List<UserEntity>());

        var createUser = new CreateUser(usersContextMock.Object);

        var result = await createUser.Execute("name", "valid password");

        result.Item1.Should().BeTrue();
    }

}
