using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Audio sampling rate.
/// </summary>
[JsonConverter(typeof(StreamBidirectionalSamplingRateConverter))]
public enum StreamBidirectionalSamplingRate
{
    Rate8000, Rate16000, Rate22050, Rate24000, Rate48000
}

sealed class StreamBidirectionalSamplingRateConverter : JsonConverter<StreamBidirectionalSamplingRate>
{
    public override StreamBidirectionalSamplingRate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            8000L=>StreamBidirectionalSamplingRate.Rate8000,
            16000L=>StreamBidirectionalSamplingRate.Rate16000,
            22050L=>StreamBidirectionalSamplingRate.Rate22050,
            24000L=>StreamBidirectionalSamplingRate.Rate24000,
            48000L=>StreamBidirectionalSamplingRate.Rate48000,
            _ =>(StreamBidirectionalSamplingRate)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamBidirectionalSamplingRate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StreamBidirectionalSamplingRate.Rate8000=>8000L,
            StreamBidirectionalSamplingRate.Rate16000=>16000L,
            StreamBidirectionalSamplingRate.Rate22050=>22050L,
            StreamBidirectionalSamplingRate.Rate24000=>24000L,
            StreamBidirectionalSamplingRate.Rate48000=>48000L,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}