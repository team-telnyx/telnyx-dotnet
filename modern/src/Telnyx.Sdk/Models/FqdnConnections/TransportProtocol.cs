using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.FqdnConnections;

/// <summary>
/// One of UDP, TLS, or TCP. Applies only to connections with IP authentication or
/// FQDN authentication.
/// </summary>
[JsonConverter(typeof(TransportProtocolConverter))]
public enum TransportProtocol
{
    Udp, Tcp, Tls
}

sealed class TransportProtocolConverter : JsonConverter<TransportProtocol>
{
    public override TransportProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UDP"=>TransportProtocol.Udp,
            "TCP"=>TransportProtocol.Tcp,
            "TLS"=>TransportProtocol.Tls,
            _ =>(TransportProtocol)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransportProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TransportProtocol.Udp=>"UDP",
            TransportProtocol.Tcp=>"TCP",
            TransportProtocol.Tls=>"TLS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}