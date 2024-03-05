namespace Telnyx.net.Entities.ManagedAccounts
{
    using Newtonsoft.Json;

    public class AllocatableGlobalOutboundChannel : TelnyxEntity
    {
        [JsonProperty("managed_account_allow_custom_pricing")]
        public bool ManagedAccountAllowCustomPricing { get; set; }

        [JsonProperty("allocatable_global_outbound_channels")]
        public int AllocatableGlobalOutboundChannels { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("total_global_channels_allocated")]
        public int TotalGlobalChannelsAllocated { get; set; }
    }

}
