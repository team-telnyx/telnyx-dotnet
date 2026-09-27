using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Authentication method used when connecting to the external LLM endpoint.
/// </summary>
[JsonConverter(typeof(AuthenticationMethodConverter))]
public enum AuthenticationMethod
{
    Token, Certificate
}

sealed class AuthenticationMethodConverter : JsonConverter<AuthenticationMethod>
{
    public override AuthenticationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "token"=>AuthenticationMethod.Token,
            "certificate"=>AuthenticationMethod.Certificate,
            _ =>(AuthenticationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AuthenticationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AuthenticationMethod.Token=>"token",
            AuthenticationMethod.Certificate=>"certificate",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}