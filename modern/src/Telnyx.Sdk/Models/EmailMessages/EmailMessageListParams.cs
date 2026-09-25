using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailMessages;

/// <summary>
/// Lists messages sorted newest first by `created_at desc, id desc`. Tags and metadata
/// filters compose with cursor pagination. The legacy `/v2/emails` GET route is
/// a backward-compatible alias for this operation.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailMessageListParams : ParamsBase
{
    /// <summary>
    /// Metadata containment filter, supplied as a JSON object or comma-separated
    /// `key=value` pairs. All supplied key/value pairs must be contained in the message
    /// metadata. An empty value or empty JSON object omits the filter. Malformed
    /// values, valid non-object JSON, pairs without `=`, empty keys, and non-string/nested
    /// query shapes return HTTP 400.
    /// </summary>
    public string? FilterMetadata {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[metadata]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[metadata]", value);
        }
    }

    /// <summary>
    /// Comma-separated tags. Each segment is trimmed, and messages having at least
    /// one supplied tag are returned; matching is exact and case-sensitive after
    /// trimming. Because commas delimit values and surrounding whitespace is removed,
    /// this filter cannot represent stored tags containing literal commas or leading/trailing
    /// whitespace. An empty value omits the filter. Empty segments and non-string/nested
    /// query shapes return HTTP 400.
    /// </summary>
    public string? FilterTags {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[tags]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[tags]", value);
        }
    }

    /// <summary>
    /// Opaque URL-safe Base64 cursor returned by a previous list response.
    /// </summary>
    public string? PageCursor {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "page_cursor"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page_cursor", value);
        }
    }

    /// <summary>
    /// Number of results to return. Defaults to 25; maximum is 100. Invalid values
    /// are clamped to the valid range.
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    public EmailMessageListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessageListParams (
        EmailMessageListParams emailMessageListParams
    ) : base(emailMessageListParams)
    {  }
    #pragma warning restore CS8618

    public EmailMessageListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailMessageListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailMessageListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EmailMessageListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/email_messages"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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