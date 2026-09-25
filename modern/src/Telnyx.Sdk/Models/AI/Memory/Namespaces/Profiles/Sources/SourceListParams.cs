using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Sources;

/// <summary>
/// Everything a profile has stored and extracts memories from: each ingested session,
/// and each remembered fact, which has no session. Content is not listed; read one
/// source for it. A source whose ingest is still queued is not here yet. Re-ingesting
/// a session moves it to the front, so a listing paged while sessions are written
/// can repeat or miss one at a page boundary. A `session_id` narrows the listing
/// to the source that session was stored as: one source or none, and none -- an
/// empty page, not a 404 -- for a session never ingested, still queued, or another profile's.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SourceListParams : ParamsBase
{
    public required string Namespace { get; init; }

    public string? ProfileID { get; init; }

    /// <summary>
    /// The page to return, counting from 1. Bounded in depth: (page[number] - 1)
    /// * page[size] may be at most 10000.
    /// </summary>
    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    /// <summary>
    /// How many results a page holds.
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    /// <summary>
    /// An ingested session, by the `session_id` it was ingested with. Narrows the
    /// request to the source that session was stored as.
    /// </summary>
    public string? SessionID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "session_id"
            );
        }
        init { this._rawQueryData.Set("session_id", value); }
    }

    public SourceListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SourceListParams (SourceListParams sourceListParams) : base(
        sourceListParams
    )
    {
        this.Namespace = sourceListParams.Namespace;
        this.ProfileID = sourceListParams.ProfileID;
    }
    #pragma warning restore CS8618

    public SourceListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SourceListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string namespace_,
        string profileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.Namespace = namespace_;
        this.ProfileID = profileID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SourceListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string namespace_,
        string profileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            namespace_,
            profileID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["Namespace"] = JsonSerializer.SerializeToElement(this.Namespace),
        ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SourceListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.Namespace.Equals(other.Namespace)&&(this.ProfileID?.Equals(other.ProfileID) ?? other.ProfileID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/memory/namespaces/{0}/profiles/{1}/sources",
            this.Namespace,
            this.ProfileID)
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