namespace TelnyxTests
{
    using Xunit;

    [CollectionDefinition("telnyx-mock tests")]
    public class TelnyxMockTestCollection :
        ICollectionFixture<MockHttpClientFixture>,
        ICollectionFixture<TelnyxMockFixture>
    {
        // This class has no code, and is never created. Its purpose is simply to be the place to
        // apply [CollectionDefinition] and all the ICollectionFixture<> interfaces.
    }
}
