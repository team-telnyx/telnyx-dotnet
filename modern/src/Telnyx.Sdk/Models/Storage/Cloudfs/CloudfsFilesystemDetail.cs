using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Cloudfs;

/// <summary>
/// A CloudFS filesystem as returned by get, update, and delete. `meta_url` omits
/// the credential and there is no `meta_token` field — the token is only returned
/// by create and rotate-meta-token.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CloudfsFilesystemDetail, CloudfsFilesystemDetailFromRaw>))]
public sealed record class CloudfsFilesystemDetail : JsonModel
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

    /// <summary>
    /// Explanation of the most recent failed lifecycle action. Present only when
    /// the filesystem is in a `failed` state.
    /// </summary>
    public string? Error {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// PostgreSQL connection URL for the filesystem's metadata database, without
    /// the credential. Combine it with your stored metadata token, or issue a new
    /// token with rotate-meta-token.
    /// </summary>
    public string? MetaUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "meta_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta_url", value);
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
        _ = this.Error;
        _ = this.MetaUrl;
        _ = this.Name;
        _ = this.RecordType;
        _ = this.Region;
        _ = this.S3Bucket;
        _ = this.S3Endpoint;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public CloudfsFilesystemDetail ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudfsFilesystemDetail (
        CloudfsFilesystemDetail cloudfsFilesystemDetail
    ) : base(cloudfsFilesystemDetail)
    {  }
    #pragma warning restore CS8618

    public CloudfsFilesystemDetail (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudfsFilesystemDetail (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CloudfsFilesystemDetailFromRaw.FromRawUnchecked"/>
    public static CloudfsFilesystemDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CloudfsFilesystemDetailFromRaw : IFromRawJson<CloudfsFilesystemDetail>
{
    /// <inheritdoc/>
    public CloudfsFilesystemDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CloudfsFilesystemDetail.FromRawUnchecked(rawData);
}