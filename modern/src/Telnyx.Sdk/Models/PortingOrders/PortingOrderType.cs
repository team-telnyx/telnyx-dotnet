using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders;

/// <summary>
/// A port can be either 'full' or 'partial'. When type is 'full' the other attributes
/// should be omitted.
/// </summary>
[JsonConverter(typeof(PortingOrderTypeConverter))]
public enum PortingOrderType
{
    Full, Partial
}

sealed class PortingOrderTypeConverter : JsonConverter<PortingOrderType>
{
    public override PortingOrderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "full"=>PortingOrderType.Full,
            "partial"=>PortingOrderType.Partial,
            _ =>(PortingOrderType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingOrderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingOrderType.Full=>"full",
            PortingOrderType.Partial=>"partial",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}