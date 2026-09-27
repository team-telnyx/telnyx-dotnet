using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Missions.Runs;

[JsonConverter(typeof(RunStatusConverter))]
public enum RunStatus
{
    Pending, Running, Paused, Succeeded, Failed, Cancelled
}

sealed class RunStatusConverter : JsonConverter<RunStatus>
{
    public override RunStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>RunStatus.Pending,
            "running"=>RunStatus.Running,
            "paused"=>RunStatus.Paused,
            "succeeded"=>RunStatus.Succeeded,
            "failed"=>RunStatus.Failed,
            "cancelled"=>RunStatus.Cancelled,
            _ =>(RunStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RunStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RunStatus.Pending=>"pending",
            RunStatus.Running=>"running",
            RunStatus.Paused=>"paused",
            RunStatus.Succeeded=>"succeeded",
            RunStatus.Failed=>"failed",
            RunStatus.Cancelled=>"cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}