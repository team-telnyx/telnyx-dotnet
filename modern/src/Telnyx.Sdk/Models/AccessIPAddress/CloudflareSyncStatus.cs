using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AccessIPAddress;

/// <summary>
/// An enumeration.
/// </summary>
[JsonConverter(typeof(CloudflareSyncStatusConverter))]
public enum CloudflareSyncStatus
{
    Pending, Added
}

sealed class CloudflareSyncStatusConverter : JsonConverter<CloudflareSyncStatus>
{
    public override CloudflareSyncStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>CloudflareSyncStatus.Pending,
            "added"=>CloudflareSyncStatus.Added,
            _ =>(CloudflareSyncStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CloudflareSyncStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CloudflareSyncStatus.Pending=>"pending",
            CloudflareSyncStatus.Added=>"added",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}