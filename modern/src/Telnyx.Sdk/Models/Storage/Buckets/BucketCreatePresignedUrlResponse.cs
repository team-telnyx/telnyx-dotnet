using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Buckets;

[JsonConverter(typeof(JsonModelConverter<BucketCreatePresignedUrlResponse, BucketCreatePresignedUrlResponseFromRaw>))]
public sealed record class BucketCreatePresignedUrlResponse : JsonModel
{
    public Content? Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Content>(
                "content"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Content?.Validate(); }

    public BucketCreatePresignedUrlResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BucketCreatePresignedUrlResponse (
        BucketCreatePresignedUrlResponse bucketCreatePresignedUrlResponse
    ) : base(bucketCreatePresignedUrlResponse)
    {  }
    #pragma warning restore CS8618

    public BucketCreatePresignedUrlResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BucketCreatePresignedUrlResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BucketCreatePresignedUrlResponseFromRaw.FromRawUnchecked"/>
    public static BucketCreatePresignedUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BucketCreatePresignedUrlResponseFromRaw : IFromRawJson<BucketCreatePresignedUrlResponse>
{
    /// <inheritdoc/>
    public BucketCreatePresignedUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BucketCreatePresignedUrlResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Content, ContentFromRaw>))]
public sealed record class Content : JsonModel
{
    /// <summary>
    /// The token for the object
    /// </summary>
    public string? Token {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("token", value);
        }
    }

    /// <summary>
    /// The expiration time of the token
    /// </summary>
    public DateTimeOffset? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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
    /// The presigned URL for the object
    /// </summary>
    public string? PresignedUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "presigned_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("presigned_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.ExpiresAt;
        _ = this.PresignedUrl;
    }

    public Content ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Content (Content content) : base(content)
    {  }
    #pragma warning restore CS8618

    public Content (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Content (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ContentFromRaw.FromRawUnchecked"/>
    public static Content FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ContentFromRaw : IFromRawJson<Content>
{
    /// <inheritdoc/>
    public Content FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Content.FromRawUnchecked(rawData);
}