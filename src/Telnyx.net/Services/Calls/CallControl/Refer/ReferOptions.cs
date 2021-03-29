﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Services.Calls.CallControl.Refer
{
    public class ReferOptions : BaseOptions
    {
        /// <summary>
        /// Use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Use this field to avoid duplicate commands. Telnyx will ignore commands with the same `command_id`
        /// </summary>
        [JsonProperty("command_id")]
        public string CommandId { get; set; }

        /// <summary>
        /// The SIP URI to which the call will be referred to.
        /// <para>Example: "sip:username@sip.non-telnyx-address.com".</para>
        /// </summary>
        [JsonProperty("sip_address")]
        public string SIPAddress { get; set; }

        /// <summary>
        /// Custom headers to be added to the SIP invite.
        /// </summary>
        [JsonProperty("custom_headers")]
        public IEnumerable<CustomHeaders> CustomHeaders { get; set; }

        /// <summary>
        /// SIP Authentication password used for SIP challenges.
        /// </summary>
        public string SIPAuthPassword { get; set; }

        /// <summary>
        /// SIP Authentication username used for SIP challenges.
        /// </summary>
        public string SIPAuthUserName { get; set; }
    }

    public class CustomHeaders
    {
        /// <summary>
        /// The name of the header value to add.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the header.
        /// </summary>
        public string Value { get; set; }
    }

}
