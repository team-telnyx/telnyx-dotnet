using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.Connections.Options
{
    public class ConnectionListOptions : ListOptions
    {
        /// <summary>
        /// If present, connections with connection_name containing the given value will be returned. Matching is not case-sensitive. Requires at least three characters
        /// </summary>
        [JsonProperty("filter[connection_name][contains]")]
        public string ConnectionNameContains { get; set; } = null;
        /// <summary>
        /// Identifies the associated outbound voice profile.
        /// </summary>
        [JsonProperty("filter[outbound_voice_profile_id]")]
        public string OutBoundVoiceProfileId { get; set; }
        /// <summary>
        /// Specifies the sort order for results. By default sorting direction is ascending. To have the results sorterd in descending order use values with DESC in the name.
        /// </summary>
        [JsonProperty("sort")]
        public ConnectionSortEnum Sort { get; set; } = ConnectionSortEnum.CreatedAtDESC;
    }
    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    /// <value>Type of the resource.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ConnectionSortEnum
    {
        [EnumMember(Value = "enabled")]
        Enabled = 0,

        [EnumMember(Value = "-enabled")]
        EnabledDESC = 1,
        [EnumMember(Value = "created_at")]
        CreatedAt = 2,

        [EnumMember(Value = "-created_at")]
        CreatedAtDESC = 3,

        [EnumMember(Value = "name")]
        Name = 4,

        [EnumMember(Value = "-name")]
        NameDESC = 5,

        [EnumMember(Value = "service_plan")]
        ServicePlan = 6,

        [EnumMember(Value = "-service_plan")]
        ServicePlanDESC = 7,
        [EnumMember(Value = "traffic_type")]
        TrafficType = 8,

        [EnumMember(Value = "-traffic_type")]
        TrafficTypeDESC = 9,
        [EnumMember(Value = "usage_payment_method")]
        UsagePaymentMethod = 10,

        [EnumMember(Value = "-usage_payment_method")]
        UsagePaymentMethodDESC = 11,
    }

}
