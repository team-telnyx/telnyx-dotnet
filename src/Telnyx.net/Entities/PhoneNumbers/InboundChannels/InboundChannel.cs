namespace Telnyx.net.Entities.PhoneNumbers.InboundChannels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class InboundChannel : TelnyxEntity
    {
        /// <summary>
        /// The current number of concurrent channels set for the account
        /// </summary>
        public int Channels { get; set; }
        /// <summary>
        /// Identifies the type of the response
        /// </summary>
        public string RecordType { get; set; }
    }
}
