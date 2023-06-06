using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.NumberPortouts
{
    public class UpdateAListOfSupportingDocumentsOnAPortoutRequestOptions : BaseOptions
    {
        /// <summary>
        /// Provide a reason if rejecting the port out request
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
