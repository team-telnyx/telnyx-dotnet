using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PronunciationDicts;

/// <summary>
/// Create a new pronunciation dictionary for the authenticated organization. Each
/// dictionary contains a list of items that control how specific words are spoken.
/// Items can be alias type (text replacement) or phoneme type (IPA pronunciation notation).
///
/// <para>As an alternative to providing items directly as JSON, you can upload a
/// dictionary file (PLS/XML or plain text format, max 1MB) using multipart/form-data.
/// PLS files use the standard W3C Pronunciation Lexicon Specification XML format.
/// Text files use a line-based format: `word=alias` for aliases, `word:/phoneme/`
/// for IPA phonemes.</para>
///
/// <para>Limits: - Maximum 50 dictionaries per organization - Maximum 100 items per
/// dictionary - Text: max 200 characters - Alias/phoneme value: max 500 characters
/// - File upload: max 1MB (1,048,576 bytes)</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PronunciationDictCreateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// List of pronunciation items (alias or phoneme type). At least one item is required.
    /// </summary>
    public required IReadOnlyList<PronunciationDictItem> Items {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<PronunciationDictItem>>(
                "items"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<PronunciationDictItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Human-readable name. Must be unique within the organization.
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public PronunciationDictCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PronunciationDictCreateParams (
        PronunciationDictCreateParams pronunciationDictCreateParams
    ) : base(pronunciationDictCreateParams)
    { this._rawBodyData = new(pronunciationDictCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public PronunciationDictCreateParams (
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
    PronunciationDictCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PronunciationDictCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, MultipartJsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PronunciationDictCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/pronunciation_dicts"
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