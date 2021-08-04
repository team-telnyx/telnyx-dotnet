using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Entities.Enum.Porting.Orders;

namespace Telnyx.net.Entities.Porting.Orders
{
    public class PortOrder : TelnyxEntity
    {
        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Unique id of porting order.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Identifies the old service provider.
        /// </summary>
        [JsonProperty("old_service_provider_ocn")]
        public string OldServiceProviderOcn { get; set; }

        /// <summary>
        /// Count of phone numbers associated with this porting order.
        /// </summary>
        [JsonProperty("porting_phone_numbers_count")]
        public long PortingPhoneNumbersCount { get; set; }

        /// <summary>
        /// Identifies the type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public RecordType? RecordType { get; set; }

        /// <summary>
        /// Porting order status.
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }

        /// <summary>
        /// A key to reference this porting order when contacting Telnyx customer support.
        /// </summary>
        [JsonProperty("support_key")]
        public string SupportKey { get; set; }

        /// <summary>
        /// ISO 8601 formatted date indicating when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// A customer-specified reference number for customer bookkeeping purposes.
        /// </summary>
        [JsonProperty("user_reference")]

        public string UserReference { get; set; }
        [JsonProperty("activation_settings")]
        public ActivationSettings ActivationSettings { get; set; }

        [JsonProperty("documents")]
        public Documents Documents { get; set; }

        [JsonProperty("end_user")]
        public EndUser EndUser { get; set; }

        [JsonProperty("misc")]
        public Misc Misc { get; set; }

        [JsonProperty("phone_number_configuration")]
        public PhoneNumberConfiguration PhoneNumberConfiguration { get; set; }

        [JsonProperty("user_feedback")]
        public UserFeedback UserFeedback { get; set; }

        /// <summary>
        /// URL to webhook for updates.
        /// </summary>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
    }

    public class ActivationSettings
    {
        [JsonProperty("activation_status")]
        public ActivationStatus? ActivationStatus { get; set; }

        [JsonProperty("fast_port_eligible")]
        public bool FastPortEligible { get; set; }

        [JsonProperty("foc_datetime_actual")]
        public DateTimeOffset? FocDatetimeActual { get; set; }

        [JsonProperty("foc_datetime_requested")]
        public DateTimeOffset? FocDatetimeRequested { get; set; }
    }

    public class Documents
    {
        /// <summary>
        /// Identifies the Invoice document.
        /// </summary>
        [JsonProperty("invoice")]
        public Guid? Invoice { get; set; }

        /// <summary>
        /// Identifies the loa document.
        /// </summary>
        [JsonProperty("loa")]
        public Guid? Loa { get; set; }
    }

    public class EndUser
    {
        [JsonProperty("admin")]
        public Admin Admin { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Admin
    {
        /// <summary>
        /// The authorized person's account number with the current service providers.
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Name of person authorizing the porting order.
        /// </summary>
        [JsonProperty("auth_person_name")]
        public string AuthPersonName { get; set; }

        /// <summary>
        /// Billing phone number associated with these phone numbers.
        /// </summary>
        [JsonProperty("billing_phone_number")]
        public long BillingPhoneNumber { get; set; }

        /// <summary>
        /// European business identification number. Applicable only in the European Union.
        /// </summary>
        [JsonProperty("business_identifier")]
        public string BusinessIdentifier { get; set; }

        /// <summary>
        /// Person Name or Company name requesting the port.
        /// </summary>
        [JsonProperty("entity_name")]
        public string EntityName { get; set; }

        /// <summary>
        /// PIN/passcode possibly required by the old service provider for extra verification.
        /// </summary>
        [JsonProperty("pin_passcode")]
        public int PinPasscode { get; set; }

        /// <summary>
        /// European tax identification number. Applicable only in the European Union.
        /// </summary>
        [JsonProperty("tax_identifier")]
        public string TaxIdentifier { get; set; }
    }

    public class Location
    {
        /// <summary>
        /// State, province, or similar of billing address.
        /// </summary>
        [JsonProperty("administrative_area")]
        public string AdministrativeArea { get; set; }

        /// <summary>
        /// ISO3166-1 alpha-2 country code of billing address.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Second line of billing address.
        /// </summary>
        [JsonProperty("extended_address")]
        public string ExtendedAddress { get; set; }

        /// <summary>
        /// City or municipality of billing address.
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// Postal Code of billing address.
        /// </summary>
        [JsonProperty("postal_code")]
        public long PostalCode { get; set; }

        /// <summary>
        /// First line of billing address.
        /// </summary>
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }
    }

    public class Misc
    {
        /// <summary>
        /// New billing phone number for the remaining numbers. Used in case the current billing phone number is being ported to Telnyx. This will be set on your account with your current service provider and should be one of the numbers remaining on that account.
        /// </summary>
        [JsonProperty("new_billing_phone_number")]
        public string NewBillingPhoneNumber { get; set; }

        /// <summary>
        /// Remaining numbers can be either kept with their current service provider or disconnected. 'new_billing_telephone_number' is required when 'remaining_numbers_action' is 'keep'.
        /// <para>Options: ["keep","disconnect"]
        /// </para>
        /// </summary>
        [JsonProperty("remaining_numbers_action")]
        public string RemainingNumbersAction { get; set; }

        /// <summary>
        /// A port can be either 'full' or 'partial'. When type is 'full' the other attributes should be omitted.
        /// <para>Options: ["full", "partial"]</para>
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class PhoneNumberConfiguration
    {
        /// <summary>
        /// identifies the connection to set on the numbers when ported.
        /// </summary>
        [JsonProperty("connection_id")]
        public Guid? ConnectionId { get; set; }

        /// <summary>
        /// identifies the emergency address to set on the numbers when ported.
        /// </summary>
        [JsonProperty("emergency_address_id")]
        public Guid? EmergencyAddressId { get; set; }

        /// <summary>
        /// identifies the messaging profile to set on the numbers when ported.
        /// </summary>
        [JsonProperty("messaging_profile_id")]
        public Guid? MessagingProfileId { get; set; }

        /// <summary>
        /// Tags to search by.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }

    public class Status
    {
        /// <summary>
        /// A list of 0 or more details about this porting order's status.
        /// </summary>
        [JsonProperty("details")]
        public List<string> Details { get; set; }

        /// <summary>
        /// The current status of the porting order.
        /// <para>Options: ["draft","in-process","submitted","exception","foc-date-confirmed","ported","canceled","cancel-pending"]</para>
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class UserFeedback
    {
        /// <summary>
        /// A comment related to the customer rating.
        /// </summary>
        [JsonProperty("user_comment")]
        public string UserComment { get; set; }

        /// <summary>
        /// Once an order is ported, cancellation is requested or the request is canceled, the user may rate their experience
        /// </summary>
        [JsonProperty("user_rating")]
        public int UserRating { get; set; }
    }
}
