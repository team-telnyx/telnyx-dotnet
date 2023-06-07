using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Services.PhoneNumbers.Orders.Comments;

namespace Telnyx.net.Services.Documents
{
    public class DocumentCreateOptions : BaseOptions
    {
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("file")]
        public string File { get; set; }
    }
}
