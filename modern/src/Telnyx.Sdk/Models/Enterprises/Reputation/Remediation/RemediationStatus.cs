using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Remediation;

/// <summary>
/// Customer-facing status of a remediation request.
/// </summary>
[JsonConverter(typeof(RemediationStatusConverter))]
public enum RemediationStatus
{
    Pending, InProgress, Completed, Failed, Cancelled
}

sealed class RemediationStatusConverter : JsonConverter<RemediationStatus>
{
    public override RemediationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>RemediationStatus.Pending,
            "in_progress"=>RemediationStatus.InProgress,
            "completed"=>RemediationStatus.Completed,
            "failed"=>RemediationStatus.Failed,
            "cancelled"=>RemediationStatus.Cancelled,
            _ =>(RemediationStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RemediationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RemediationStatus.Pending=>"pending",
            RemediationStatus.InProgress=>"in_progress",
            RemediationStatus.Completed=>"completed",
            RemediationStatus.Failed=>"failed",
            RemediationStatus.Cancelled=>"cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}