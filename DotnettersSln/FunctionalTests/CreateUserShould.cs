using FluentAssertions;
using FunctionalTests.Fixtures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using WebApp.Database;

namespace FunctionalTests;

[Collection(nameof(FunctionalTestCollection))]
public class CreateUserShould : IAsyncLifetime
{
    private readonly FunctionalTestCollectionFixture _fixture;

    public CreateUserShould(FunctionalTestCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    public async Task InitializeAsync()
    {
        await _fixture.ResetDbAsync();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    [Fact]
    public async Task Test1()
    {
        using var client = _fixture.CreateClient();
        var response = await client.PostAsync(Api.Post.CreateUser, null);

        response.StatusCode.Should()
            .Be(HttpStatusCode.OK);

        using var scope = _fixture.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<UsersContext>();

        var existingUser = await dbContext
            .Users
            .Where(user => user.Name == "testuser")
            .SingleAsync();
        existingUser.Should().NotBeNull();
    }

    static class Api
    {
        public static class Post
        {
            public static string CreateUser => "users?name=testuser&password=passwordlargo";
        }
    }
}