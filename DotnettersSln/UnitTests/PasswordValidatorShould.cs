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
    [MemberData(nameof(Data))]

    public void ReturnExpectedError_GivenInvalidPassword(User user, string expectedMessage)
    {
        var result = sut.Validate(user);

        result.Should().Be(expectedMessage);
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new User("name", null), "Password can not be null" },
            new object[] { new User("name", ""), "Password can not be empty" },
            new object[] { new User("name", "short"), "Password length can not be less than 8" },
            new object[] { new User("john deere", "john deere"), "Password can not be equal to user name" },
        };

    [Fact]
    public void NoReturnError_WhenPasswordMatchesAllRequirements()
    {
        var user = new User("name", "password is valid");
        var result = sut.Validate(user);

        result.Should().BeEmpty();
    }
}