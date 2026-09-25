using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

[JsonConverter(typeof(TaskStatusConverter))]
public enum TaskStatus
{
    Pending, Starting, Running, Completed, Failed
}

sealed class TaskStatusConverter : JsonConverter<TaskStatus>
{
    public override TaskStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>TaskStatus.Pending,
            "starting"=>TaskStatus.Starting,
            "running"=>TaskStatus.Running,
            "completed"=>TaskStatus.Completed,
            "failed"=>TaskStatus.Failed,
            _ =>(TaskStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, TaskStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TaskStatus.Pending=>"pending",
            TaskStatus.Starting=>"starting",
            TaskStatus.Running=>"running",
            TaskStatus.Completed=>"completed",
            TaskStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}