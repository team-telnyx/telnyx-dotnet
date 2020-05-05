namespace Telnyx
{
    using System;
    using Newtonsoft.Json;

    public partial class ListConferenceResponse : TelnyxEntity
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
