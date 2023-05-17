namespace FunctionalTests.Fixtures;

[CollectionDefinition(nameof(FunctionalTestCollection))]
public sealed class FunctionalTestCollection : ICollectionFixture<FunctionalTestCollectionFixture>
{
}
