using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Wireless.ESim.ActionPurchaseEsims
{
    public class ActionPurchaseEsim : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("status")]
        public Status SimStatus { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("type")]
        public string SimType { get; set; }

        [JsonProperty("iccid")]
        public string Iccid { get; set; }

        [JsonProperty("imsi")]
        public string Imsi { get; set; }

        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }

        [JsonProperty("sim_card_group_id")]
        public Guid? SimCardGroupId { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("data_limit")]
        public DataLimit SimDataLimit { get; set; }

        [JsonProperty("current_billing_period_consumed_data")]
        public CurrentBillingPeriodConsumedData ConsumedData { get; set; }

        [JsonProperty("actions_in_progress")]
        public bool ActionsInProgress { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("errors")]
        public Error[] Errors { get; set; }
    }

    public class DataLimit
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public class CurrentBillingPeriodConsumedData
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public class Status
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("source")]
        public Source ErrorSource { get; set; }

        [JsonProperty("meta")]
        public object Meta { get; set; }
    }

    public class Source
    {
        [JsonProperty("pointer")]
        public string Pointer { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

    }
}
