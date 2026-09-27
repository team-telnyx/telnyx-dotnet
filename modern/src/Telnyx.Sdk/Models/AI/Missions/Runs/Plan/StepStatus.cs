using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Plan;

[JsonConverter(typeof(StepStatusConverter))]
public enum StepStatus
{
    Pending, InProgress, Completed, Skipped, Failed
}

sealed class StepStatusConverter : JsonConverter<StepStatus>
{
    public override StepStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>StepStatus.Pending,
            "in_progress"=>StepStatus.InProgress,
            "completed"=>StepStatus.Completed,
            "skipped"=>StepStatus.Skipped,
            "failed"=>StepStatus.Failed,
            _ =>(StepStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, StepStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StepStatus.Pending=>"pending",
            StepStatus.InProgress=>"in_progress",
            StepStatus.Completed=>"completed",
            StepStatus.Skipped=>"skipped",
            StepStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}