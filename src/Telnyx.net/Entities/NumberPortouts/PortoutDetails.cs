namespace Telnyx.net.Entities.NumberPortouts
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Telnyx.net.Entities.Enum.NumberPortouts;
    using Telnyx.net.Services.PhoneNumbers.Orders.Comments;

    public class PortoutDetails : TelnyxEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether the number is already ported.
        /// </summary>
        [JsonProperty("already_ported")]
        public bool AlreadyPorted { get; set; }

        /// <summary>
        /// Gets or sets the name of the person authorizing the porting order.
        /// </summary>
        [JsonProperty("authorized_name")]
        public string AuthorizedName { get; set; }

        /// <summary>
        /// Gets or sets the carrier the number will be ported out to.
        /// </summary>
        [JsonProperty("carrier_name")]
        public string CarrierName { get; set; }

        /// <summary>
        /// Gets or sets the city or municipality of the billing address.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the portout was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the current carrier.
        /// </summary>
        [JsonProperty("current_carrier")]
        public string CurrentCarrier { get; set; }

        /// <summary>
        /// Gets or sets the person name or company name requesting the port.
        /// </summary>
        [JsonProperty("end_user_name")]
        public string EndUserName { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the FOC (Firm Order Commitment) date.
        /// </summary>
        [JsonProperty("foc_date")]
        public DateTime FocDate { get; set; }

        /// <summary>
        /// Gets or sets the UUID of the portout request.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the portout was inserted.
        /// </summary>
        [JsonProperty("inserted_at")]
        public DateTime InsertedAt { get; set; }

        /// <summary>
        /// Gets or sets the Local Service Request (LSR).
        /// </summary>
        [JsonProperty("lsr")]
        public List<string> Lsr { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers associated with this portout.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public List<string> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the port order number assigned by the carrier the number will be ported out to.
        /// </summary>
        [JsonProperty("pon")]
        public string Pon { get; set; }

        /// <summary>
        /// Gets or sets the reason why the order is being rejected by the user. If the order is authorized, this field can be left null.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the record type that identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// Gets or sets the requested FOC (Firm Order Commitment) date.
        /// </summary>
        [JsonProperty("requested_foc_date")]
        public DateTime RequestedFocDate { get; set; }

        /// <summary>
        /// Gets or sets the first line of the billing address (street address).
        /// </summary>
        [JsonProperty("service_address")]
        public string ServiceAddress { get; set; }

        /// <summary>
        /// Gets or sets the new service provider SPID (Service Provider Identifier).
        /// </summary>
        [JsonProperty("spid")]
        public string Spid { get; set; }

        /// <summary>
        /// Gets or sets the state, province, or similar of the billing address.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the status of the portout request.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PortoutStatus Status { get; set; }

        /// <summary>
        /// Gets or sets a key to reference this port out request when contacting Telnyx customer support.
        /// </summary>
        [JsonProperty("support_key")]
        public string SupportKey { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the portout was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the UUID that identifies the user (or organization) who requested the port out.
        /// </summary>
        [JsonProperty("user_id")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the UUID of the Telnyx partner providing network coverage.
        /// </summary>
        [JsonProperty("vendor")]
        public Guid Vendor { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the billing address.
        /// </summary>
        [JsonProperty("zip")]
        public string Zip { get; set; }
    }
}
