namespace Telnyx.net.Entities.Enum.Connections
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    /// <value>Type of the resource.</value>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ConnectionSort
    {
        [EnumMember(Value = "enabled")]
        Enabled = 0,

        [EnumMember(Value = "-enabled")]
        EnabledDESC = 1,

        [EnumMember(Value = "created_at")]
        CreatedAt = 2,

        [EnumMember(Value = "-created_at")]
        CreatedAtDESC = 3,

        [EnumMember(Value = "connection_name")]
        ConnectionName = 4,

        [EnumMember(Value = "-connection_name")]
        ConnectionNameDESC = 5,

        [EnumMember(Value = "name")]
        Name = 6,

        [EnumMember(Value = "-name")]
        NameDESC = 7,

        [EnumMember(Value = "service_plan")]
        ServicePlan = 8,

        [EnumMember(Value = "-service_plan")]
        ServicePlanDESC = 9,

        [EnumMember(Value = "traffic_type")]
        TrafficType = 10,

        [EnumMember(Value = "-traffic_type")]
        TrafficTypeDESC = 11,

        [EnumMember(Value = "usage_payment_method")]
        UsagePaymentMethod = 12,

        [EnumMember(Value = "-usage_payment_method")]
        UsagePaymentMethodDESC = 13,

        [EnumMember(Value = "active")]
        Active = 14,

        [EnumMember(Value = "-active")]
        ActiveDESC = 15,
    }
}
