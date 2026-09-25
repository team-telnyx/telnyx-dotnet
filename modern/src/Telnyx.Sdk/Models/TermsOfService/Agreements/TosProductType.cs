using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.TermsOfService.Agreements;

/// <summary>
/// Telnyx product the Terms of Service apply to.
/// </summary>
[JsonConverter(typeof(TosProductTypeConverter))]
public enum TosProductType
{
    BrandedCalling, NumberReputation
}

sealed class TosProductTypeConverter : JsonConverter<TosProductType>
{
    public override TosProductType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "branded_calling"=>TosProductType.BrandedCalling,
            "number_reputation"=>TosProductType.NumberReputation,
            _ =>(TosProductType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TosProductType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TosProductType.BrandedCalling=>"branded_calling",
            TosProductType.NumberReputation=>"number_reputation",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}