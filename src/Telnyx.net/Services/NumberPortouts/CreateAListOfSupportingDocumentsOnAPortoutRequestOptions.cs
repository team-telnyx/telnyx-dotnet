namespace Telnyx.net.Services.NumberPortouts
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.NumberPortouts;

    public class CreateAListOfSupportingDocumentsOnAPortoutRequestOptions : BaseOptions
    {
        /// <summary>
        /// List of supporting documents parameters.
        /// </summary>
        [JsonProperty("documents")]
        public List<SupportingDocument> Documents { get; set; }
    }
}
