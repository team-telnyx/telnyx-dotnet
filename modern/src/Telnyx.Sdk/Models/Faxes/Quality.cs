using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Faxes;

/// <summary>
/// The quality of the fax. The `ultra` settings provides the highest quality available,
/// but also present longer fax processing times. `ultra_light` is best suited for
/// images, wihle `ultra_dark` is best suited for text.
/// </summary>
[JsonConverter(typeof(QualityConverter))]
public enum Quality
{
    Normal, High, VeryHigh, UltraLight, UltraDark
}

sealed class QualityConverter : JsonConverter<Quality>
{
    public override Quality Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal"=>Quality.Normal,
            "high"=>Quality.High,
            "very_high"=>Quality.VeryHigh,
            "ultra_light"=>Quality.UltraLight,
            "ultra_dark"=>Quality.UltraDark,
            _ =>(Quality)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Quality value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Quality.Normal=>"normal",
            Quality.High=>"high",
            Quality.VeryHigh=>"very_high",
            Quality.UltraLight=>"ultra_light",
            Quality.UltraDark=>"ultra_dark",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}