using FluentAssertions;
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

    public void ReturnExpectedError_GivenInvalidPassword(string? invalidPassword, string expectedMessage)
    {
        var result = sut.Validate(invalidPassword);

        result.Should().Be(expectedMessage);
    }

    [Fact]
    public void NoReturnError_WhenPasswordMatchesAllRequirements()
    {
        string? passwordValid = "password is valid";
        var result = sut.Validate(passwordValid);

        result.Should().BeEmpty();
    }
}