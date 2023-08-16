namespace Telnyx.net.Entities.Wireless.SimCards
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;

    /// <summary>
    /// Sim Card record.
    /// </summary>
    public class SimCardRecord : TelnyxEntity, IHasId
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets RecordType.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; private set; }

        /// <summary>
        /// The current status of the SIM card. It will be one of the following: &lt;br/&gt; &lt;ul&gt;   &lt;li&gt;&lt;code&gt;activating&lt;/code&gt; - the card is being activated&lt;/li&gt;   &lt;li&gt;&lt;code&gt;active&lt;/code&gt; - the card is active and ready for use&lt;/li&gt;   &lt;li&gt;&lt;code&gt;inactivating&lt;/code&gt; - the card is being inactivated&lt;/li&gt;   &lt;li&gt;&lt;code&gt;inactive&lt;/code&gt; - the card has been inactivated and cannot be used&lt;/li&gt;   &lt;li&gt;&lt;code&gt;data_limit_exceeded&lt;/code&gt; - the card has exceeded its data consumption limit&lt;/li&gt; &lt;/ul&gt; Transitioning between the active and inactive states may take a period of time. 
        /// </summary>
        [JsonProperty("status")]
        public object Status { get; set; }

        /// <summary>
        /// The ICCID is the identifier of the specific SIM card/chip. Each SIM is internationally identified by its integrated circuit card identifier (ICCID). ICCIDs are stored in the SIM card&#x27;s memory and are also engraved or printed on the SIM card body during a process called personalization. 
        /// </summary>
        [JsonProperty("iccid")]
        public string Iccid { get; private set; }

        /// <summary>
        /// SIM cards are identified on their individual operator networks by a unique International Mobile Subscriber Identity (IMSI). &lt;br/&gt; Mobile network operators connect mobile phone calls and communicate with their market SIM cards using their IMSIs. The IMSI is stored in the Subscriber  Identity Module (SIM) inside the device and is sent by the device to the appropriate network. It is used to acquire the details of the device in the Home  Location Register (HLR) or the Visitor Location Register (VLR). 
        /// </summary>
        [JsonProperty("imsi")]
        public string Imsi { get; private set; }

        /// <summary>
        /// Mobile Station International Subscriber Directory Number (MSISDN) is a number used to identify a mobile phone number internationally. &lt;br/&gt; MSISDN is defined by the E.164 numbering plan. It includes a country code and a National Destination Code which identifies the subscriber&#x27;s operator. 
        /// </summary>
        [JsonProperty("msisdn")]
        public string Msisdn { get; private set; }

        /// <summary>
        /// The group SIMCardGroup identification. This attribute can be &lt;code&gt;null&lt;/code&gt; when it&#x27;s present in an associated resource.
        /// </summary>
        [JsonProperty("sim_card_group_id")]
        public Guid? SimCardGroupId { get; set; }

        /// <summary>
        /// Searchable tags associated with the SIM card.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }

        /// <summary>
        /// ISO 8601 formatted date-time indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; private set; }
    }
}
