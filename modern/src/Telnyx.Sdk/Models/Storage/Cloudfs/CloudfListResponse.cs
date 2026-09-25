using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Cloudfs;

/// <summary>
/// A CloudFS filesystem as returned in list results. Connection details (`meta_url`,
/// `meta_token`) are omitted — retrieve the filesystem by ID for its redacted `meta_url`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CloudfListResponse, CloudfListResponseFromRaw>))]
public sealed record class CloudfListResponse : JsonModel
{
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <summary>
    /// Name of the bucket that stores this filesystem's data. Created during provisioning.
    /// </summary>
    public string? S3Bucket {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "s3_bucket"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("s3_bucket", value);
        }
    }

    /// <summary>
    /// URL of the Telnyx Cloud Storage endpoint backing this filesystem.
    /// </summary>
    public string? S3Endpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "s3_endpoint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("s3_endpoint", value);
        }
    }

    /// <summary>
    /// Lifecycle status of the filesystem. `ready` means it is fully provisioned
    /// and usable. `needs_format` means the storage bucket and metadata database
    /// were provisioned but the filesystem has not yet been formatted — run `juicefs
    /// format` with the filesystem's `meta_url` before mounting. `failed` means the
    /// last lifecycle action failed — see the filesystem's `error` message. `deleted`
    /// appears only in the delete response: deleted filesystems are excluded from
    /// list results and return a `404` on retrieval.
    /// </summary>
    public ApiEnum<string, CloudfsFilesystemStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CloudfsFilesystemStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.RecordType;
        _ = this.Region;
        _ = this.S3Bucket;
        _ = this.S3Endpoint;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public CloudfListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudfListResponse (CloudfListResponse cloudfListResponse) : base(
        cloudfListResponse
    )
    {  }
    #pragma warning restore CS8618

    public CloudfListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudfListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CloudfListResponseFromRaw.FromRawUnchecked"/>
    public static CloudfListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CloudfListResponseFromRaw : IFromRawJson<CloudfListResponse>
{
    /// <inheritdoc/>
    public CloudfListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CloudfListResponse.FromRawUnchecked(rawData);
}