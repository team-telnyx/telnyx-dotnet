using Newtonsoft.Json;

namespace Telnyx.net.Entities.ManagedAccounts
{
    public class AllocatableGlobalOutboundChannelResponse : TelnyxEntity
    {
        /// <summary>
        /// Integer value that indicates the number of allocatable global outbound channels 
        /// that should be allocated to the managed account. Must be 0 or more. 
        /// If the value is 0 then the account will have no usable channels and will not be able to perform outbound calling.
        /// </summary>
        [JsonProperty("channel_limit")]
        public int ChannelLimit { get; set; }

        /// <summary>
        /// The email of the managed account.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// The user ID of the managed account.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The user ID of the manager of the account.
        /// </summary>
        [JsonProperty("manager_account_id")]
        public string ManagerAccountId { get; set; }

        /// <summary>
        /// The name of the type of data in the response.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }
    }
}
