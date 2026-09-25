using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(EmailDomainTypeConverter))]
public enum EmailDomainType
{
    Custom, Shared, SharedInbound
}

sealed class EmailDomainTypeConverter : JsonConverter<EmailDomainType>
{
    public override EmailDomainType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom"=>EmailDomainType.Custom,
            "shared"=>EmailDomainType.Shared,
            "shared_inbound"=>EmailDomainType.SharedInbound,
            _ =>(EmailDomainType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailDomainType.Custom=>"custom",
            EmailDomainType.Shared=>"shared",
            EmailDomainType.SharedInbound=>"shared_inbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}