using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.CustomerServiceRecords
{
    public class CustomerServiceRecord : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("result")]
        public CustomerServiceResult Result { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class CustomerServiceResult
    {
        [JsonProperty("carrier_name")]
        public string CarrierName { get; set; }

        [JsonProperty("associated_phone_numbers")]
        public string[] AssociatedPhoneNumbers { get; set; }

        [JsonProperty("admin")]
        public CustomerServiceAdmin Admin { get; set; }

        [JsonProperty("address")]
        public CustomerServiceAddress Address { get; set; }
    }

    public class CustomerServiceAddress
    {
        [JsonProperty("administrative_area")]
        public string AdministrativeArea { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        [JsonProperty("full_address")]
        public string FullAddress { get; set; }
    }

    public class CustomerServiceAdmin
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("billing_phone_number")]
        public string BillingPhoneNumber { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("authorized_person_name")]
        public string AuthorizedPersonName { get; set; }
    }
}
