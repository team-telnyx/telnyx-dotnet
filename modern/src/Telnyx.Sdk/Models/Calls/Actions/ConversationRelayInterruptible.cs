using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Controls when caller input can interrupt assistant speech. `any` allows speech
/// or DTMF interruptions; `none` disables interruptions; `speech` allows speech
/// only; `dtmf` allows DTMF only.
/// </summary>
[JsonConverter(typeof(ConversationRelayInterruptibleConverter))]
public enum ConversationRelayInterruptible
{
    None, Any, Speech, Dtmf
}

sealed class ConversationRelayInterruptibleConverter : JsonConverter<ConversationRelayInterruptible>
{
    public override ConversationRelayInterruptible Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none"=>ConversationRelayInterruptible.None,
            "any"=>ConversationRelayInterruptible.Any,
            "speech"=>ConversationRelayInterruptible.Speech,
            "dtmf"=>ConversationRelayInterruptible.Dtmf,
            _ =>(ConversationRelayInterruptible)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversationRelayInterruptible value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConversationRelayInterruptible.None=>"none",
            ConversationRelayInterruptible.Any=>"any",
            ConversationRelayInterruptible.Speech=>"speech",
            ConversationRelayInterruptible.Dtmf=>"dtmf",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}