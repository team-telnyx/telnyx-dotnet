using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CredentialConnections;

/// <summary>
/// Controls when noise suppression is applied to calls. When set to 'inbound', noise
/// suppression is applied to incoming audio. When set to 'outbound', it's applied
/// to outgoing audio. When set to 'both', it's applied in both directions. When
/// set to 'disabled', noise suppression is turned off.
/// </summary>
[JsonConverter(typeof(ConnectionNoiseSuppressionConverter))]
public enum ConnectionNoiseSuppression
{
    Inbound, Outbound, Both, Disabled
}

sealed class ConnectionNoiseSuppressionConverter : JsonConverter<ConnectionNoiseSuppression>
{
    public override ConnectionNoiseSuppression Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>ConnectionNoiseSuppression.Inbound,
            "outbound"=>ConnectionNoiseSuppression.Outbound,
            "both"=>ConnectionNoiseSuppression.Both,
            "disabled"=>ConnectionNoiseSuppression.Disabled,
            _ =>(ConnectionNoiseSuppression)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConnectionNoiseSuppression value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConnectionNoiseSuppression.Inbound=>"inbound",
            ConnectionNoiseSuppression.Outbound=>"outbound",
            ConnectionNoiseSuppression.Both=>"both",
            ConnectionNoiseSuppression.Disabled=>"disabled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}