using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Missions;

[JsonConverter(typeof(ExecutionModeConverter))]
public enum ExecutionMode
{
    External, Managed
}

sealed class ExecutionModeConverter : JsonConverter<ExecutionMode>
{
    public override ExecutionMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "external"=>ExecutionMode.External,
            "managed"=>ExecutionMode.Managed,
            _ =>(ExecutionMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExecutionMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ExecutionMode.External=>"external",
            ExecutionMode.Managed=>"managed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}