using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum.NumberPortouts;

namespace Telnyx.net.Entities.NumberPortouts
{
    public class SupportingDocument
    {
        /// <summary>
        /// Identifies the associated document.
        /// </summary>
        [JsonProperty("document_id")]
        public string DocumentId { get; set; }

        /// <summary>
        /// Identifies the type of the document.
        /// </summary>
        [JsonProperty("type")]
        public DocumentType Type { get; set; }
    }
}
