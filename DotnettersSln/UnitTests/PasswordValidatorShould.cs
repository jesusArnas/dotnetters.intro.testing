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

    [Fact]
    public void ReturnExpectedError_WhenPasswordIsNull()
    {
        string? passwordNull = null;
        var result = sut.Validate(passwordNull);

        result.Should().Be("Password can not be null");
    }

    [Fact]
    public void ReturnExpectedError_WhenPasswordIsEmpty()
    {
        string? passwordEmpty = string.Empty;
        var result = sut.Validate(passwordEmpty);

        result.Should().Be("Password can not be empty");
    }

    [Fact]
    public void ReturnExpectedError_WhenPasswordIsTooShort()
    {
        string? passwordShort = "short";
        var result = sut.Validate(passwordShort);

        result.Should().Be("Password length can not be less than 8");
    }

    [Fact]
    public void NoReturnError_WhenPasswordMatchesAllRequirements()
    {
        string? passwordValid = "password is valid";
        var result = sut.Validate(passwordValid);

        result.Should().BeEmpty();
    }
}