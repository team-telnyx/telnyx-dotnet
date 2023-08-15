namespace Telnyx.net.Services.HostedNumbers
{
    using Newtonsoft.Json;

    public class FileUploadOptions : BaseOptions
    {
        /// <summary>
        /// Must be the last month's bill with proof of ownership of all of the numbers in the order in PDF format.
        /// String in binary.
        /// </summary>
        [JsonProperty("bill")]
        public string Bill { get; set; }

        /// <summary>
        /// Must be a signed LOA for the numbers in the order in PDF format. 
        /// String in binary.
        /// </summary>
        [JsonProperty("loa")]
        public string Loa { get; set; }
    }
}
