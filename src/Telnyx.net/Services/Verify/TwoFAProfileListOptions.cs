using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.Verify
{
    public class TwoFAProfileListOptions : ListOptions
    {
        public TwoFAProfileListOptions()
            : base(25, 1)
        {

        }
        /// <summary>
        /// Optional filter for profile names.
        /// </summary>
        [JsonProperty("filter[name]")]
        public string Filter { get; set; }
    }
}
