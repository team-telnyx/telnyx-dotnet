namespace Telnyx.net.Entities.Calls.CallControl.ClientState
{
    using Newtonsoft.Json;

    public class ClientStateOption : BaseOptions
    {
        /// <summary>
        /// Use this field to add state to every subsequent webhook. It must be a valid Base-64 encoded string.
        /// </summary>
        [JsonProperty("client_state")]
        public string ClientStates { get; set; }
    }
}
