namespace Telnyx.net.Services.NumberPortouts
{
    using Newtonsoft.Json;

    public class UpdateAListOfSupportingDocumentsOnAPortoutRequestOptions : BaseOptions
    {
        /// <summary>
        /// Provide a reason if rejecting the port out request.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
