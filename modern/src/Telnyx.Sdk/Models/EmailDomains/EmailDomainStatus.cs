using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(EmailDomainStatusConverter))]
public enum EmailDomainStatus
{
    Pending, Verifying, Verified, Failed, Degraded, Suspended
}

sealed class EmailDomainStatusConverter : JsonConverter<EmailDomainStatus>
{
    public override EmailDomainStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>EmailDomainStatus.Pending,
            "verifying"=>EmailDomainStatus.Verifying,
            "verified"=>EmailDomainStatus.Verified,
            "failed"=>EmailDomainStatus.Failed,
            "degraded"=>EmailDomainStatus.Degraded,
            "suspended"=>EmailDomainStatus.Suspended,
            _ =>(EmailDomainStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailDomainStatus.Pending=>"pending",
            EmailDomainStatus.Verifying=>"verifying",
            EmailDomainStatus.Verified=>"verified",
            EmailDomainStatus.Failed=>"failed",
            EmailDomainStatus.Degraded=>"degraded",
            EmailDomainStatus.Suspended=>"suspended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}