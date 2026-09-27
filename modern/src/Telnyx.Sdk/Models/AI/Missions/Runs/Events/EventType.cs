using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Events;

[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    StatusChange,
    StepStarted,
    StepCompleted,
    StepFailed,
    ToolCall,
    ToolResult,
    Message,
    Error,
    Custom
}

sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "status_change"=>EventType.StatusChange,
            "step_started"=>EventType.StepStarted,
            "step_completed"=>EventType.StepCompleted,
            "step_failed"=>EventType.StepFailed,
            "tool_call"=>EventType.ToolCall,
            "tool_result"=>EventType.ToolResult,
            "message"=>EventType.Message,
            "error"=>EventType.Error,
            "custom"=>EventType.Custom,
            _ =>(EventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, EventType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EventType.StatusChange=>"status_change",
            EventType.StepStarted=>"step_started",
            EventType.StepCompleted=>"step_completed",
            EventType.StepFailed=>"step_failed",
            EventType.ToolCall=>"tool_call",
            EventType.ToolResult=>"tool_result",
            EventType.Message=>"message",
            EventType.Error=>"error",
            EventType.Custom=>"custom",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}