﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.Verify
{
    public class TwoFaProfileOptions : BaseOptions
    {
        /// <summary>
        /// Enables RCS messaging for the 2FA profile.
        /// Default: false
        /// </summary>
        [JsonProperty("rcs_enabled")]
        public bool RcsEnabled { get; set; }
        /// <summary>
        /// Enables SMS text messaging for the 2FA profile
        /// Default: false
        /// </summary>
        [JsonProperty("msg_enabled")]
        public bool MsgEnabled { get; set; }
        /// <summary>
        /// Optionally sets a messaging text template when sending the verification code. Uses `{code}` to template in the actual verification code.
        /// Example: Hello, this is the Acme Inc verification code you requested: {code}."
        /// </summary>
        [JsonProperty("msg_template")]
        public string MsgTemplate { get; set; }
        /// <summary>
        /// For every request that is initiated via this 2FA Profile, this sets the number of seconds before a verification request code expires. Once the verification request expires, the user cannot use the code to verify their identity.
        /// Example: 300
        /// </summary>
        [JsonProperty("default_timeout_secs")]
        public long? DefaultTimeoutSecs { get; set; }
        /// <summary>
        /// The human readable label for the 2FA profile.
        /// Example: "Test Profile"
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
