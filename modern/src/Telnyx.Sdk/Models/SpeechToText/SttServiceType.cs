using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SpeechToText;

/// <summary>
/// Service surface a model is available on. `ai_assistant` is the STT surface configured
/// via Call Control voice-assistant transcription; it covers both live-streaming
/// and non-streaming/batch models (matching the `TranscriptionConfig.model` enum
/// on `call-control` voice assistants).
/// </summary>
[JsonConverter(typeof(SttServiceTypeConverter))]
public enum SttServiceType
{
    Streaming, FileBased, InCall, AIAssistant
}

sealed class SttServiceTypeConverter : JsonConverter<SttServiceType>
{
    public override SttServiceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "streaming"=>SttServiceType.Streaming,
            "file_based"=>SttServiceType.FileBased,
            "in_call"=>SttServiceType.InCall,
            "ai_assistant"=>SttServiceType.AIAssistant,
            _ =>(SttServiceType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SttServiceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SttServiceType.Streaming=>"streaming",
            SttServiceType.FileBased=>"file_based",
            SttServiceType.InCall=>"in_call",
            SttServiceType.AIAssistant=>"ai_assistant",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}