using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CredentialConnections;

/// <summary>
/// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that DTMF
/// digits sent to Telnyx will be accepted in all formats.
/// </summary>
[JsonConverter(typeof(DtmfTypeConverter))]
public enum DtmfType
{
    Rfc2833, Inband, SipInfo
}

sealed class DtmfTypeConverter : JsonConverter<DtmfType>
{
    public override DtmfType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RFC 2833"=>DtmfType.Rfc2833,
            "Inband"=>DtmfType.Inband,
            "SIP INFO"=>DtmfType.SipInfo,
            _ =>(DtmfType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DtmfType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DtmfType.Rfc2833=>"RFC 2833",
            DtmfType.Inband=>"Inband",
            DtmfType.SipInfo=>"SIP INFO",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}