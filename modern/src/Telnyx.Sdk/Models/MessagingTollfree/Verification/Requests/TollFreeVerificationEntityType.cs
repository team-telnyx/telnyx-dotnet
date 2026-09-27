using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// Business entity classification
/// </summary>
[JsonConverter(typeof(TollFreeVerificationEntityTypeConverter))]
public enum TollFreeVerificationEntityType
{
    SoleProprietor, PrivateProfit, PublicProfit, NonProfit, Government
}

sealed class TollFreeVerificationEntityTypeConverter : JsonConverter<TollFreeVerificationEntityType>
{
    public override TollFreeVerificationEntityType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SOLE_PROPRIETOR"=>TollFreeVerificationEntityType.SoleProprietor,
            "PRIVATE_PROFIT"=>TollFreeVerificationEntityType.PrivateProfit,
            "PUBLIC_PROFIT"=>TollFreeVerificationEntityType.PublicProfit,
            "NON_PROFIT"=>TollFreeVerificationEntityType.NonProfit,
            "GOVERNMENT"=>TollFreeVerificationEntityType.Government,
            _ =>(TollFreeVerificationEntityType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TollFreeVerificationEntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TollFreeVerificationEntityType.SoleProprietor=>"SOLE_PROPRIETOR",
            TollFreeVerificationEntityType.PrivateProfit=>"PRIVATE_PROFIT",
            TollFreeVerificationEntityType.PublicProfit=>"PUBLIC_PROFIT",
            TollFreeVerificationEntityType.NonProfit=>"NON_PROFIT",
            TollFreeVerificationEntityType.Government=>"GOVERNMENT",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}