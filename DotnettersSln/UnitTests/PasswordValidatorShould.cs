using FluentAssertions;
using WebApp.Models;
using WebApp.PasswordValidator;

namespace UnitTests;

public class PasswordValidatorShould
{
    private readonly PasswordValidator sut;

    public PasswordValidatorShould()
    {
        sut = new();
    }

    [Theory]
    [InlineData(null, "Password can not be null")]
    [InlineData("", "Password can not be empty")]
    [InlineData("short", "Password length can not be less than 8")]
    [InlineData("john deere", "Password can not be equal to user name")]

    public void ReturnExpectedError_GivenInvalidPassword(string? invalidPassword, string expectedMessage)
    {
        var user = new User("john deere", invalidPassword);
        var result = sut.Validate(user);

        result.Should().Be(expectedMessage);
    }

    [Fact]
    public void NoReturnError_WhenPasswordMatchesAllRequirements()
    {
        var user = new User("name", "password is valid");
        var result = sut.Validate(user);

        result.Should().BeEmpty();
    }
}