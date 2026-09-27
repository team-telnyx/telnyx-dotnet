using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

[JsonConverter(typeof(ConversationChannelTypeConverter))]
public enum ConversationChannelType
{
    PhoneCall, SmsChat
}

sealed class ConversationChannelTypeConverter : JsonConverter<ConversationChannelType>
{
    public override ConversationChannelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phone_call"=>ConversationChannelType.PhoneCall,
            "sms_chat"=>ConversationChannelType.SmsChat,
            _ =>(ConversationChannelType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversationChannelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConversationChannelType.PhoneCall=>"phone_call",
            ConversationChannelType.SmsChat=>"sms_chat",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}