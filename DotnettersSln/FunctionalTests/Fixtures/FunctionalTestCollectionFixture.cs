using Microsoft.AspNetCore.Mvc.Testing;
using Npgsql;
using Respawn;
using Respawn.Graph;

namespace FunctionalTests.Fixtures;

public class FunctionalTestCollectionFixture : WebApplicationFactory<Program>
{
    private readonly Checkpoint _checkpoint = new()
    {
        TablesToIgnore = new[] {
            new Table("schemaversions")
        },
        DbAdapter = DbAdapter.Postgres
    };

    public async Task ResetDbAsync()
    {
        var connectionString = "Host=localhost;Database=dotnetters;Username=postgres;Password=XXX";
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();
        await _checkpoint.Reset(connection);
        await connection.CloseAsync();
    }
}
