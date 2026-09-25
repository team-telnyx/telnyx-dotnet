using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// Business entity classification
/// </summary>
[JsonConverter(typeof(MessagingTollFreeVerificationEntityTypeConverter))]
public enum MessagingTollFreeVerificationEntityType
{
    SoleProprietor, PrivateProfit, PublicProfit, NonProfit, Government
}

sealed class MessagingTollFreeVerificationEntityTypeConverter : JsonConverter<MessagingTollFreeVerificationEntityType>
{
    public override MessagingTollFreeVerificationEntityType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SOLE_PROPRIETOR"=>MessagingTollFreeVerificationEntityType.SoleProprietor,
            "PRIVATE_PROFIT"=>MessagingTollFreeVerificationEntityType.PrivateProfit,
            "PUBLIC_PROFIT"=>MessagingTollFreeVerificationEntityType.PublicProfit,
            "NON_PROFIT"=>MessagingTollFreeVerificationEntityType.NonProfit,
            "GOVERNMENT"=>MessagingTollFreeVerificationEntityType.Government,
            _ =>(MessagingTollFreeVerificationEntityType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingTollFreeVerificationEntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingTollFreeVerificationEntityType.SoleProprietor=>"SOLE_PROPRIETOR",
            MessagingTollFreeVerificationEntityType.PrivateProfit=>"PRIVATE_PROFIT",
            MessagingTollFreeVerificationEntityType.PublicProfit=>"PUBLIC_PROFIT",
            MessagingTollFreeVerificationEntityType.NonProfit=>"NON_PROFIT",
            MessagingTollFreeVerificationEntityType.Government=>"GOVERNMENT",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}