using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.Porting.Orders
{
    public class PortingOrderListOptions : ListOptions
    {
        public PortingOrderListOptions()
            : base(1, 20)
        {
        }

        /// <summary>
        /// Include the first 50 phone number objects in the results.
        /// </summary>
        [JsonProperty("include_phone_numbers")]
        public bool IncludePhoneNumbers { get; set; } = true;

        [JsonProperty("filter[status]")]
        public Status Status { get; set; }

        /// <summary>
        /// Filter results by user reference.
        /// <para>Example: "123Abc"</para>
        /// </summary>
        [JsonProperty("filter[customer_reference]")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// Filter results by old service provider.
        /// <para>Example: "Telnyx". </para>
        /// </summary>
        [JsonProperty("filter[phone_numbers][carrier_name]")]
        public string OldServiceProvider { get; set; }

        /// <summary>
        /// A port can be either 'full' or 'partial'. When type is 'full' the other attributes should be omitted.
        /// <para>Example: "full"</para>
        /// <para>Options: ["full", "partial"]</para>
        /// </summary>
        [JsonProperty("filter[misc][type]")]
        public string MiscType { get; set; }

        /// <summary>
        /// Filter results by person or company name.
        /// </summary>
        [JsonProperty("filter[end_user][admin][entity_name]")]
        public string EndUserAdminName { get; set; }

        /// <summary>
        /// Filter results by authorized person.
        /// </summary>
        [JsonProperty("filter[end_user][admin][auth_person_name]")]
        public string EndUserAuthorizedPersonName { get; set; }

        /// <summary>
        /// Filter results by fast port eligible.
        /// </summary>
        [JsonProperty("filter[activation_settings][fast_port_eligible]")]
        public bool FastPortableEligible { get; set; }

        /// <summary>
        /// Filter results by foc date later than this value.
        /// </summary>
        [JsonProperty("filter[activation_settings][foc_datetime_requested][gt]")]
        public DateTime? GreaterThanFocDate { get; set; }

        /// <summary>
        /// Filter results by foc date earlier than this value.
        /// </summary>
        [JsonProperty("filter[activation_settings][foc_datetime_requested][lt]")]
        public DateTime? LessThanFocDate { get; set; }

        /// <summary>
        /// Specifies the sort order for results. If not given, results are sorted by created_at in descending order.
        /// <para>>Example: "created_at"</para
        /// <para>Options: ["created_at", "-created_at", "activation_settings.foc_datetime_requested", "-activation_settings.foc_datetime_requested"]
        /// </para>
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }

    }

    public class Status
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("details")]
        public IEnumerable<string> Details { get; set; }

        //TODO: Convert to enum for UX.
        /// <summary>
        /// Current status of porting order.
        /// <para>Example: "ported"</para>
        /// <para>Options: ["draft","in-process","submitted","exception","foc-date-confirmed","ported","canceled","cancel-pending"]</para>
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
