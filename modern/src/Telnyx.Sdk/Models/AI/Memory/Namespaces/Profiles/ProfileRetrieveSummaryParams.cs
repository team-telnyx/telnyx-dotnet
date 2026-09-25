using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

/// <summary>
/// The whole profile as one card, precomputed, with no query. Built for the start
/// of a session, where there is no question to ask yet.
///
/// <para>A summary is generated in the background. `is_stale` tells you newer memories
/// have arrived since it was written; that is ordinary and the card is still usable.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ProfileRetrieveSummaryParams : ParamsBase
{
    public required string Namespace { get; init; }

    public string? ProfileID { get; init; }

    public ProfileRetrieveSummaryParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveSummaryParams (
        ProfileRetrieveSummaryParams profileRetrieveSummaryParams
    ) : base(profileRetrieveSummaryParams)
    {
        this.Namespace = profileRetrieveSummaryParams.Namespace;
        this.ProfileID = profileRetrieveSummaryParams.ProfileID;
    }
    #pragma warning restore CS8618

    public ProfileRetrieveSummaryParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveSummaryParams (
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
    public static ProfileRetrieveSummaryParams FromRawUnchecked(
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

    public virtual bool Equals(ProfileRetrieveSummaryParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/memory/namespaces/{0}/profiles/{1}/summary",
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