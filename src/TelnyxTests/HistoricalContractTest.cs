namespace TelnyxTests
{
    using System;
    using Telnyx;
    using Xunit;

    /// <summary>
    /// Explicit compatibility coverage for the archived 2023 API contract.
    /// This is not evidence that these operations exist in the current API.
    /// The CI bootstrap verifies the archived spec's immutable digest.
    /// </summary>
    [Trait("Contract", "historical-1d97a787b3c88edce00428076ec0c236392a3f18")]
    public class HistoricalContractTest : BaseTelnyxTest, IDisposable
    {
        private readonly string originalBase;

        public HistoricalContractTest(MockHttpClientFixture fixture)
            : base(fixture)
        {
            this.originalBase = TelnyxConfiguration.GetApiBase();
            TelnyxConfiguration.SetApiBase("http://127.0.0.1:4013");
        }

        public void Dispose()
        {
            TelnyxConfiguration.SetApiBase(this.originalBase);
        }
    }
}
