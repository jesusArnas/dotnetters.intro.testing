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
    [InlineData("password is valid", "")]

    public void ReturnExpectedResultForGivenPassword(string? password, string expectedMessage)
    {
        var result = sut.Validate(password);

        result.Should().Be(expectedMessage);
    }
}