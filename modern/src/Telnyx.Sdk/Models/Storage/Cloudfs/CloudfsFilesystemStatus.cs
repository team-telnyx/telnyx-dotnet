using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Storage.Cloudfs;

/// <summary>
/// Lifecycle status of the filesystem. `ready` means it is fully provisioned and
/// usable. `needs_format` means the storage bucket and metadata database were provisioned
/// but the filesystem has not yet been formatted — run `juicefs format` with the
/// filesystem's `meta_url` before mounting. `failed` means the last lifecycle action
/// failed — see the filesystem's `error` message. `deleted` appears only in the delete
/// response: deleted filesystems are excluded from list results and return a `404`
/// on retrieval.
/// </summary>
[JsonConverter(typeof(CloudfsFilesystemStatusConverter))]
public enum CloudfsFilesystemStatus
{
    Provisioning, Ready, NeedsFormat, Deleting, Failed, Deleted
}

sealed class CloudfsFilesystemStatusConverter : JsonConverter<CloudfsFilesystemStatus>
{
    public override CloudfsFilesystemStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "provisioning"=>CloudfsFilesystemStatus.Provisioning,
            "ready"=>CloudfsFilesystemStatus.Ready,
            "needs_format"=>CloudfsFilesystemStatus.NeedsFormat,
            "deleting"=>CloudfsFilesystemStatus.Deleting,
            "failed"=>CloudfsFilesystemStatus.Failed,
            "deleted"=>CloudfsFilesystemStatus.Deleted,
            _ =>(CloudfsFilesystemStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CloudfsFilesystemStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CloudfsFilesystemStatus.Provisioning=>"provisioning",
            CloudfsFilesystemStatus.Ready=>"ready",
            CloudfsFilesystemStatus.NeedsFormat=>"needs_format",
            CloudfsFilesystemStatus.Deleting=>"deleting",
            CloudfsFilesystemStatus.Failed=>"failed",
            CloudfsFilesystemStatus.Deleted=>"deleted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}