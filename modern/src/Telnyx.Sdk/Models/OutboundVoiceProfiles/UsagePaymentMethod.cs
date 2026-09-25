using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

/// <summary>
/// Setting for how costs for outbound profile are calculated.
/// </summary>
[JsonConverter(typeof(UsagePaymentMethodConverter))]
public enum UsagePaymentMethod
{
    RateDeck
}

sealed class UsagePaymentMethodConverter : JsonConverter<UsagePaymentMethod>
{
    public override UsagePaymentMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rate-deck"=>UsagePaymentMethod.RateDeck,
            _ =>(UsagePaymentMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsagePaymentMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UsagePaymentMethod.RateDeck=>"rate-deck",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}