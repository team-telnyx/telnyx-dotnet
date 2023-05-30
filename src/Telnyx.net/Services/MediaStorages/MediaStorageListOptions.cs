using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.MediaStorages
{
    public class MediaStorageListOptions : ListOptions
    {
        /// <summary>
        /// Filters files by given content types
        /// </summary>
        [JsonProperty("filter[content_type][]")]
        public string ContentType { get; set; }
    }
}
