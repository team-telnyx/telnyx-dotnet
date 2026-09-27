using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// An enumeration.
/// </summary>
[JsonConverter(typeof(AltBusinessIDTypeConverter))]
public enum AltBusinessIDType
{
    None, Duns, Giin, Lei
}

sealed class AltBusinessIDTypeConverter : JsonConverter<AltBusinessIDType>
{
    public override AltBusinessIDType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NONE"=>AltBusinessIDType.None,
            "DUNS"=>AltBusinessIDType.Duns,
            "GIIN"=>AltBusinessIDType.Giin,
            "LEI"=>AltBusinessIDType.Lei,
            _ =>(AltBusinessIDType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AltBusinessIDType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AltBusinessIDType.None=>"NONE",
            AltBusinessIDType.Duns=>"DUNS",
            AltBusinessIDType.Giin=>"GIIN",
            AltBusinessIDType.Lei=>"LEI",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}