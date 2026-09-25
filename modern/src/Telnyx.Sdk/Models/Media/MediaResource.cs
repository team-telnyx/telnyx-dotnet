using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Media;

[JsonConverter(typeof(JsonModelConverter<MediaResource, MediaResourceFromRaw>))]
public sealed record class MediaResource : JsonModel
{
    /// <summary>
    /// Content type of the file
    /// </summary>
    public string? ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the media resource was created
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// ISO 8601 formatted date of when the media resource will expire and be deleted.
    /// </summary>
    public string? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "expires_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expires_at", value);
        }
    }

    /// <summary>
    /// Uniquely identifies a media resource.
    /// </summary>
    public string? MediaName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("media_name", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the media resource was last updated
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.ContentType;
        _ = this.CreatedAt;
        _ = this.ExpiresAt;
        _ = this.MediaName;
        _ = this.UpdatedAt;
    }

    public MediaResource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaResource (MediaResource mediaResource) : base(mediaResource)
    {  }
    #pragma warning restore CS8618

    public MediaResource (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaResource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MediaResourceFromRaw.FromRawUnchecked"/>
    public static MediaResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MediaResourceFromRaw : IFromRawJson<MediaResource>
{
    /// <inheritdoc/>
    public MediaResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MediaResource.FromRawUnchecked(rawData);
}