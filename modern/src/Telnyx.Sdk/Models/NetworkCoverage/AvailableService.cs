using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NetworkCoverage;

[JsonConverter(typeof(AvailableServiceConverter))]
public enum AvailableService
{
    CloudVpn, PrivateWirelessGateway, VirtualCrossConnect
}

sealed class AvailableServiceConverter : JsonConverter<AvailableService>
{
    public override AvailableService Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cloud_vpn"=>AvailableService.CloudVpn,
            "private_wireless_gateway"=>AvailableService.PrivateWirelessGateway,
            "virtual_cross_connect"=>AvailableService.VirtualCrossConnect,
            _ =>(AvailableService)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AvailableService value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AvailableService.CloudVpn=>"cloud_vpn",
            AvailableService.PrivateWirelessGateway=>"private_wireless_gateway",
            AvailableService.VirtualCrossConnect=>"virtual_cross_connect",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}