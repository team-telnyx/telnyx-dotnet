namespace Telnyx.net.Entities.VerifyAPI
{
    using Newtonsoft.Json;

    public class VerifyCode : VerifyBase
    {
        /// <summary>
        /// Identifies if the verification code has been accepted or rejected.
        /// <para>Options: ["accepted","rejected"].</para>
        /// </summary>
        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }
    }
}
