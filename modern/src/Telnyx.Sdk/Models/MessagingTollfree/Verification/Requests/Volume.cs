using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// Message Volume Enums
/// </summary>
[JsonConverter(typeof(VolumeConverter))]
public enum Volume
{
    V10,
    V100,
    V1000,
    V10000,
    V100000,
    V250000,
    V500000,
    V750000,
    V1000000,
    V5000000,
    V10000000Plus
}

sealed class VolumeConverter : JsonConverter<Volume>
{
    public override Volume Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "10"=>Volume.V10,
            "100"=>Volume.V100,
            "1,000"=>Volume.V1000,
            "10,000"=>Volume.V10000,
            "100,000"=>Volume.V100000,
            "250,000"=>Volume.V250000,
            "500,000"=>Volume.V500000,
            "750,000"=>Volume.V750000,
            "1,000,000"=>Volume.V1000000,
            "5,000,000"=>Volume.V5000000,
            "10,000,000+"=>Volume.V10000000Plus,
            _ =>(Volume)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Volume value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Volume.V10=>"10",
            Volume.V100=>"100",
            Volume.V1000=>"1,000",
            Volume.V10000=>"10,000",
            Volume.V100000=>"100,000",
            Volume.V250000=>"250,000",
            Volume.V500000=>"500,000",
            Volume.V750000=>"750,000",
            Volume.V1000000=>"1,000,000",
            Volume.V5000000=>"5,000,000",
            Volume.V10000000Plus=>"10,000,000+",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}