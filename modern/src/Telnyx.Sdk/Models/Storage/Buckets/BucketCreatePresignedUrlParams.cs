using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Buckets;

/// <summary>
/// Returns a timed and authenticated URL to download (GET) or upload (PUT) an object.
/// This is the equivalent to AWS S3’s “presigned” URL. Please note that Telnyx performs
/// authentication differently from AWS S3 and you MUST NOT use the presign method
/// of AWS s3api CLI or SDK to generate the presigned URL.
///
/// <para>Refer to: https://developers.telnyx.com/docs/cloud-storage/presigned-urls</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BucketCreatePresignedUrlParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public required string BucketName { get; init; }

    public string? ObjectName { get; init; }

    public Body? Body {
        get {
            return WrappedJsonSerializer.GetNullableClass<Body>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public BucketCreatePresignedUrlParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BucketCreatePresignedUrlParams (
        BucketCreatePresignedUrlParams bucketCreatePresignedUrlParams
    ) : base(bucketCreatePresignedUrlParams)
    {
        this.BucketName = bucketCreatePresignedUrlParams.BucketName;
        this.ObjectName = bucketCreatePresignedUrlParams.ObjectName;

        this.RawBodyData = bucketCreatePresignedUrlParams.RawBodyData;
    }
    #pragma warning restore CS8618

    public BucketCreatePresignedUrlParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BucketCreatePresignedUrlParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string bucketName,
        string objectName
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.BucketName = bucketName;
        this.ObjectName = objectName;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BucketCreatePresignedUrlParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string bucketName,
        string objectName
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            bucketName,
            objectName
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["BucketName"] = JsonSerializer.SerializeToElement(this.BucketName),
        ["ObjectName"] = JsonSerializer.SerializeToElement(this.ObjectName),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(BucketCreatePresignedUrlParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.BucketName.Equals(other.BucketName)&&(this.ObjectName?.Equals(other.ObjectName) ?? other.ObjectName == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this.RawBodyData.Equals(
            other.RawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/storage/buckets/{0}/{1}/presigned_url",
            this.BucketName,
            this.ObjectName)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

[JsonConverter(typeof(JsonModelConverter<Body, BodyFromRaw>))]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// The time to live of the token in seconds
    /// </summary>
    public long? Ttl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "ttl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ttl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Ttl; }

    public Body ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Body (Body body) : base(body)
    {  }
    #pragma warning restore CS8618

    public Body (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Body (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BodyFromRaw.FromRawUnchecked"/>
    public static Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BodyFromRaw : IFromRawJson<Body>
{
    /// <inheritdoc/>
    public Body FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Body.FromRawUnchecked(rawData);
}