using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(ObservabilityStatusConverter))]
public enum ObservabilityStatus
{
    Enabled, Disabled
}

sealed class ObservabilityStatusConverter : JsonConverter<ObservabilityStatus>
{
    public override ObservabilityStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled"=>ObservabilityStatus.Enabled,
            "disabled"=>ObservabilityStatus.Disabled,
            _ =>(ObservabilityStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ObservabilityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ObservabilityStatus.Enabled=>"enabled",
            ObservabilityStatus.Disabled=>"disabled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}