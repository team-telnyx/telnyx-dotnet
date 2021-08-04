using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.Porting.Orders
{
    public class PortingOrderCreateOptions : BaseOptions
    {
        /// <summary>
        /// The list of +E.164 formatted phone numbers.
        /// <para>Example: ["+13035550000","+13035550001","+13035550002"]</para>
        /// </summary>
        [JsonProperty("phone_numbers")]
        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}
