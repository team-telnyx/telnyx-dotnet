namespace Telnyx.net.Entities.PortingOrders
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ActivationSettings
    {
        [JsonProperty("activation_status")]
        public string ActivationStatus { get; set; }

        [JsonProperty("fast_port_eligible")]
        public bool FastPortEligible { get; set; }

        [JsonProperty("foc_datetime_actual")]
        public DateTime FocDatetimeActual { get; set; }

        [JsonProperty("foc_datetime_requested")]
        public DateTime FocDatetimeRequested { get; set; }
    }

    public class Admin
    {
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("auth_person_name")]
        public string AuthPersonName { get; set; }

        [JsonProperty("billing_phone_number")]
        public long BillingPhoneNumber { get; set; }

        [JsonProperty("business_identifier")]
        public string BusinessIdentifier { get; set; }

        [JsonProperty("entity_name")]
        public string EntityName { get; set; }

        [JsonProperty("pin_passcode")]
        public int PinPasscode { get; set; }

        [JsonProperty("tax_identifier")]
        public string TaxIdentifier { get; set; }
    }

    public class PortingOrder : TelnyxEntity
    {
        [JsonProperty("activation_settings")]
        public ActivationSettings ActivationSettings { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("documents")]
        public Documents Documents { get; set; }

        [JsonProperty("end_user")]
        public EndUser EndUser { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("misc")]
        public Misc Misc { get; set; }

        [JsonProperty("old_service_provider_ocn")]
        public string OldServiceProviderOcn { get; set; }

        [JsonProperty("parent_support_key")]
        public string ParentSupportKey { get; set; }

        [JsonProperty("phone_number_configuration")]
        public PhoneNumberConfiguration PhoneNumberConfiguration { get; set; }

        [JsonProperty("phone_number_type")]
        public string PhoneNumberType { get; set; }

        [JsonProperty("porting_phone_numbers_count")]
        public int PortingPhoneNumbersCount { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("requirements")]
        public List<Requirement> Requirements { get; set; }

        [JsonProperty("requirements_met")]
        public bool RequirementsMet { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("support_key")]
        public string SupportKey { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("user_feedback")]
        public UserFeedback UserFeedback { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
    }

    public class Detail
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Documents
    {
        [JsonProperty("invoice")]
        public string Invoice { get; set; }

        [JsonProperty("loa")]
        public string Loa { get; set; }
    }

    public class EndUser
    {
        [JsonProperty("admin")]
        public Admin Admin { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonProperty("administrative_area")]
        public string AdministrativeArea { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("extended_address")]
        public string ExtendedAddress { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }
    }

    public class Misc
    {
        [JsonProperty("new_billing_phone_number")]
        public string NewBillingPhoneNumber { get; set; }

        [JsonProperty("remaining_numbers_action")]
        public string RemainingNumbersAction { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class PhoneNumberConfiguration
    {
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("emergency_address_id")]
        public string EmergencyAddressId { get; set; }

        [JsonProperty("messaging_profile_id")]
        public string MessagingProfileId { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }

    public class Requirement
    {
        [JsonProperty("field_type")]
        public string FieldType { get; set; }

        [JsonProperty("field_value")]
        public string FieldValue { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("requirement_type_id")]
        public string RequirementTypeId { get; set; }
    }

    public class Status
    {
        [JsonProperty("details")]
        public List<Detail> Details { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class UserFeedback
    {
        [JsonProperty("user_comment")]
        public string UserComment { get; set; }

        [JsonProperty("user_rating")]
        public int UserRating { get; set; }
    }
}
