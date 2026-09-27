using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CredentialConnections;

/// <summary>
/// Enable use of SRTP for encryption. Cannot be set if the transport_portocol is TLS.
/// </summary>
[JsonConverter(typeof(EncryptedMediaConverter))]
public enum EncryptedMedia
{
    Srtp
}

sealed class EncryptedMediaConverter : JsonConverter<EncryptedMedia>
{
    public override EncryptedMedia Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "SRTP"=>EncryptedMedia.Srtp, _ =>(EncryptedMedia)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EncryptedMedia value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EncryptedMedia.Srtp=>"SRTP",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}