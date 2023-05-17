using FluentAssertions;
using FunctionalTests.Fixtures;
using System.Net;

namespace FunctionalTests;

[Collection(nameof(FunctionalTestCollection))]
public class CreateUserShould
{
    private readonly FunctionalTestCollectionFixture _fixture;

    public CreateUserShould(FunctionalTestCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Test1()
    {
        using var client = _fixture.CreateClient();
        var response = await client.PostAsync(Api.Post.CreateUser, null);

        response.StatusCode.Should()
            .Be(HttpStatusCode.OK);
    }

    static class Api
    {
        public static class Post
        {
            public static string CreateUser => "users?name=b&password=passwordlargo";
        }
    }
}