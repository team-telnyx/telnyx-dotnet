using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.NumberPortouts
{
    public class CreateCommentsForAPortoutRequestOptions : BaseOptions
    {
        /// <summary>
        /// Comment to post on this portout request
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
