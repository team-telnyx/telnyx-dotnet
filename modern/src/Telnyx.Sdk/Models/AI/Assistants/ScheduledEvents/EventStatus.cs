using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

[JsonConverter(typeof(EventStatusConverter))]
public enum EventStatus
{
    Pending, InProgress, Completed, Failed
}

sealed class EventStatusConverter : JsonConverter<EventStatus>
{
    public override EventStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>EventStatus.Pending,
            "in_progress"=>EventStatus.InProgress,
            "completed"=>EventStatus.Completed,
            "failed"=>EventStatus.Failed,
            _ =>(EventStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, EventStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EventStatus.Pending=>"pending",
            EventStatus.InProgress=>"in_progress",
            EventStatus.Completed=>"completed",
            EventStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}