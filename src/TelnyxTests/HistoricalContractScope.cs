namespace TelnyxTests
{
    using System;
    using Telnyx;

    /// <summary>Opt one test into the hash-pinned 2023 compatibility contract.</summary>
    public sealed class HistoricalContractScope : IDisposable
    {
        private readonly string originalBase = TelnyxConfiguration.GetApiBase();

        public HistoricalContractScope()
        {
            TelnyxConfiguration.SetApiBase("http://127.0.0.1:4013");
        }

        public void Dispose()
        {
            TelnyxConfiguration.SetApiBase(this.originalBase);
        }
    }
}
