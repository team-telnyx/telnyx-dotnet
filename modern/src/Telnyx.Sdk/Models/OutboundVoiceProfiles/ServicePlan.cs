using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

/// <summary>
/// Indicates the coverage of the termination regions.
/// </summary>
[JsonConverter(typeof(ServicePlanConverter))]
public enum ServicePlan
{
    Global
}

sealed class ServicePlanConverter : JsonConverter<ServicePlan>
{
    public override ServicePlan Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "global"=>ServicePlan.Global, _ =>(ServicePlan)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, ServicePlan value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ServicePlan.Global=>"global",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}