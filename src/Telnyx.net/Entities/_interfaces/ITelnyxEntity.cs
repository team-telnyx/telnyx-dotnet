namespace Telnyx
{
    /// <summary>
    /// Interface that identifies all entities returned by Telnyx.
    /// </summary>
    public interface ITelnyxEntity
    {
        /// <summary>
        /// Gets or sets telnyx Response.
        /// </summary>
        TelnyxResponse TelnyxResponse { get; set; }
    }
}
