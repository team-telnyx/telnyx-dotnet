using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.CustomerServiceRecords
{
    public class UpsertCustomerServiceRecord : BaseOptions
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        [JsonProperty("additional_data")]
        public AdditionalData AdditionalData { get; set; }
    }
    public class AdditionalData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("authorized_person_name")]
        public string AuthorizedPersonName { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("customer_code")]
        public string CustomerCode { get; set; }

        [JsonProperty("address_line_1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("billing_phone_number")]
        public string BillingPhoneNumber { get; set; }
    }
}
