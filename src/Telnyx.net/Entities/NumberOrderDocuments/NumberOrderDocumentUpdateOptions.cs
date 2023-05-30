using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.NumberOrderDocuments
{
    public class NumberOrderDocumentUpdateOptions : BaseOptions
    {
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("requirements_id")]
        public string RequirementsId { get; set; }
    }
}
