namespace Telnyx
{
    using System;

    /// <summary>
    /// TelnyxResponse.
    /// </summary>
    public class TelnyxResponse
    {
        /// <summary>
        /// Gets or sets responseJson.
        /// </summary>
        public string ResponseJson { get; set; }

        /// <summary>
        /// Gets or sets objectJson.
        /// </summary>
        public string ObjectJson { get; set; }

        /// <summary>
        /// Gets or sets requestId.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets requestDate.
        /// </summary>
        public DateTime RequestDate { get; set; }

        public string Url { get; set; }
    }
}
