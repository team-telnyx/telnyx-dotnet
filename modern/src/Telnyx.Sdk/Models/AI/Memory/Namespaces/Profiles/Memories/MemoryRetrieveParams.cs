using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Memories;

/// <summary>
/// One memory by its id, as `recall` and the listing return it, together with what
/// it came from. A fact names its `source_id`: read it with `GET .../sources/{source_id}`
/// to see what was stored. A memory derived from other memories names them in `derived_from`
/// instead; read each of those to reach its source.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MemoryRetrieveParams : ParamsBase
{
    public required string Namespace { get; init; }

    public required string ProfileID { get; init; }

    public string? MemoryID { get; init; }

    public MemoryRetrieveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryRetrieveParams (
        MemoryRetrieveParams memoryRetrieveParams
    ) : base(memoryRetrieveParams)
    {
        this.Namespace = memoryRetrieveParams.Namespace;
        this.ProfileID = memoryRetrieveParams.ProfileID;
        this.MemoryID = memoryRetrieveParams.MemoryID;
    }
    #pragma warning restore CS8618

    public MemoryRetrieveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryRetrieveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string namespace_,
        string profileID,
        string memoryID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.Namespace = namespace_;
        this.ProfileID = profileID;
        this.MemoryID = memoryID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MemoryRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string namespace_,
        string profileID,
        string memoryID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            namespace_,
            profileID,
            memoryID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["Namespace"] = JsonSerializer.SerializeToElement(this.Namespace),
        ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
        ["MemoryID"] = JsonSerializer.SerializeToElement(this.MemoryID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(MemoryRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.Namespace.Equals(other.Namespace)&&this.ProfileID.Equals(other.ProfileID)&&(this.MemoryID?.Equals(other.MemoryID) ?? other.MemoryID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/memory/namespaces/{0}/profiles/{1}/memories/{2}",
            EncodePathSegment(this.Namespace),
            EncodePathSegment(this.ProfileID),
            EncodePathSegment(this.MemoryID))
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