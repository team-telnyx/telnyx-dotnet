using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants.Tests;

[JsonConverter(typeof(TelnyxConversationChannelConverter))]
public enum TelnyxConversationChannel
{
    PhoneCall, WebCall, SmsChat, WebChat
}

sealed class TelnyxConversationChannelConverter : JsonConverter<TelnyxConversationChannel>
{
    public override TelnyxConversationChannel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phone_call"=>TelnyxConversationChannel.PhoneCall,
            "web_call"=>TelnyxConversationChannel.WebCall,
            "sms_chat"=>TelnyxConversationChannel.SmsChat,
            "web_chat"=>TelnyxConversationChannel.WebChat,
            _ =>(TelnyxConversationChannel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TelnyxConversationChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TelnyxConversationChannel.PhoneCall=>"phone_call",
            TelnyxConversationChannel.WebCall=>"web_call",
            TelnyxConversationChannel.SmsChat=>"sms_chat",
            TelnyxConversationChannel.WebChat=>"web_chat",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}