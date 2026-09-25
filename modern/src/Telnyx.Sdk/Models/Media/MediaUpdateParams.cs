using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Media;

/// <summary>
/// Updates the specified stored media file and returns the updated resource.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MediaUpdateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? MediaName { get; init; }

    /// <summary>
    /// The URL where the media to be stored in Telnyx network is currently hosted.
    /// The maximum allowed size is 20 MB.
    /// </summary>
    public string? MediaUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "media_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("media_url", value);
        }
    }

    /// <summary>
    /// The number of seconds after which the media resource will be deleted, defaults
    /// to 2 days. The maximum allowed vale is 630720000, which translates to 20 years.
    /// </summary>
    public long? TtlSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "ttl_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ttl_secs", value);
        }
    }

    public MediaUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaUpdateParams (MediaUpdateParams mediaUpdateParams) : base(
        mediaUpdateParams
    )
    {
        this.MediaName = mediaUpdateParams.MediaName;

        this._rawBodyData = new(mediaUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public MediaUpdateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData,
        string mediaName
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.MediaName = mediaName;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MediaUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData,
        string mediaName
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            mediaName
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, MultipartJsonElement>(

    )
    {
        ["MediaName"] = JsonSerializer.SerializeToElement(this.MediaName),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(MediaUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.MediaName?.Equals(other.MediaName) ?? other.MediaName == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/media/{0}",
            this.MediaName)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    { return MultipartJsonSerializer.Serialize(RawBodyData) ; }

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