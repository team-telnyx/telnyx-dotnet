using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Notifications.NotificationSettings
{
    public class Parameter
    {
        /// <summary>
        /// The name of the parameter.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The value of the parameter.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
