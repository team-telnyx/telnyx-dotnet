namespace Telnyx
{
    using System;

    /// <summary>
    /// ITelnyxResponse.
    /// </summary>
    public interface ITelnyxResponse
    {
        /// <summary>
        /// Gets or sets responseJson.
        /// </summary>
        string ResponseJson { get; set; }

        /// <summary>
        /// Gets or sets objectJson.
        /// </summary>
        string ObjectJson { get; set; }

        /// <summary>
        /// Gets or sets requestId.
        /// </summary>
        string RequestId { get; set; }

        /// <summary>
        /// Gets or sets requestDate.
        /// </summary>
        DateTime RequestDate { get; set; }
    }
}
