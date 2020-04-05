namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// CallControlDialCreateOptions
    /// </summary>
    public class CallControlDialOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("audio_url")]
        public string AudioUrl { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("timeout_secs")]
        public int TimeoutSecs { get; set; }

        /// <summary>
        /// Gets or sets the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("time_limit_secs")]
        public int TimeLimitSecs { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the call control id of the call you want to bridge with.
        /// </summary>
        [JsonProperty("answering_machine_detection")]
        public bool AnsweringMachineDetection { get; set; }

        ///// <summary>
        ///// Custom headers to be added to the SIP INVITE
        ///// </summary>
        // [JsonProperty("custom_headers")]
        // public Dictionary<string, string> CustomHeaders { get; set; }

        /// <summary>
        /// Gets or sets use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientState { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("command_id")]
        public Guid CommandId { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("link_to")]
        public string LinkTo { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("sip_auth_username")]
        public string SipAuthUsername { get; set; }

        /// <summary>
        /// Gets or sets use this field to avoid duplicate commands. Telnyx will ignore commands with the same "command_id".
        /// </summary>
        /// <value>Example: "891510ac-f3e4-11e8-af5b-de00688a4901"</value>
        [JsonProperty("sip_auth_password")]
        public string SipAuthPassword { get; set; }
    }

    // public class List<T1, T2>
    // {
    //    public List<T2> List1 = new List<T2>();
    //    public List<string> Abc
    //    {
    //        get
    //        {
    //            for (int i = 0; i < this.length; i++)
    //            {
    //                if()
    //                return $"{this.list1[i]} : {this.list2[i]}";
    //            }
    //        }
    //        set { this.expand = value; }
    //    }
    //    public void Add(T1 s1, T2 s2)
    //    {
    //        this
    //        this.list2.Add(s2);
    //        this.length++;
    //    }
    // }
}