using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingProfileMetrics;

/// <summary>
/// The time frame for metrics aggregation.
/// </summary>
[JsonConverter(typeof(MessagingMetricsTimeFrameConverter))]
public enum MessagingMetricsTimeFrame
{
    TimeFrame1H,
    TimeFrame3H,
    TimeFrame24H,
    TimeFrame3D,
    TimeFrame7D,
    TimeFrame30D
}

sealed class MessagingMetricsTimeFrameConverter : JsonConverter<MessagingMetricsTimeFrame>
{
    public override MessagingMetricsTimeFrame Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1h"=>MessagingMetricsTimeFrame.TimeFrame1H,
            "3h"=>MessagingMetricsTimeFrame.TimeFrame3H,
            "24h"=>MessagingMetricsTimeFrame.TimeFrame24H,
            "3d"=>MessagingMetricsTimeFrame.TimeFrame3D,
            "7d"=>MessagingMetricsTimeFrame.TimeFrame7D,
            "30d"=>MessagingMetricsTimeFrame.TimeFrame30D,
            _ =>(MessagingMetricsTimeFrame)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingMetricsTimeFrame value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingMetricsTimeFrame.TimeFrame1H=>"1h",
            MessagingMetricsTimeFrame.TimeFrame3H=>"3h",
            MessagingMetricsTimeFrame.TimeFrame24H=>"24h",
            MessagingMetricsTimeFrame.TimeFrame3D=>"3d",
            MessagingMetricsTimeFrame.TimeFrame7D=>"7d",
            MessagingMetricsTimeFrame.TimeFrame30D=>"30d",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}