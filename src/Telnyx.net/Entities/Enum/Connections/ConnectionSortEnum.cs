using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Entities.Enum.Connections
{
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
