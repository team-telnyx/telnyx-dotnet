using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.NumberPortouts;

namespace Telnyx.net.Services.NumberPortouts
{
    public class CreateAListOfSupportingDocumentsOnAPortoutRequestOptions : BaseOptions
    {
        /// <summary>
        /// List of supporting documents parameters.
        /// </summary>
        [JsonProperty("documents")]
        public List<SupportingDocument> Documents { get; set; }
    }
}
