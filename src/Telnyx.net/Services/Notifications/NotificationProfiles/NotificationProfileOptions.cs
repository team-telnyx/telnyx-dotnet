using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.Notifications.NotificationProfiles
{
    public class NotificationProfileOptions : BaseOptions
    {
        /// <summary>
        /// A human readable name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
