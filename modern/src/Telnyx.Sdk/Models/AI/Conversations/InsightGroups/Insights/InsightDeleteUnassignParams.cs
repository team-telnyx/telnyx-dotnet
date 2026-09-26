using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations.InsightGroups.Insights;

/// <summary>
/// Removes the specified insight template from the specified group. The insight template
/// itself is not deleted.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InsightDeleteUnassignParams : ParamsBase
{
    public required string GroupID { get; init; }

    public string? InsightID { get; init; }

    public InsightDeleteUnassignParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightDeleteUnassignParams (
        InsightDeleteUnassignParams insightDeleteUnassignParams
    ) : base(insightDeleteUnassignParams)
    {
        this.GroupID = insightDeleteUnassignParams.GroupID;
        this.InsightID = insightDeleteUnassignParams.InsightID;
    }
    #pragma warning restore CS8618

    public InsightDeleteUnassignParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightDeleteUnassignParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string groupID,
        string insightID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.GroupID = groupID;
        this.InsightID = insightID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InsightDeleteUnassignParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string groupID,
        string insightID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            groupID,
            insightID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["GroupID"] = JsonSerializer.SerializeToElement(this.GroupID),
        ["InsightID"] = JsonSerializer.SerializeToElement(this.InsightID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(InsightDeleteUnassignParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.GroupID.Equals(other.GroupID)&&(this.InsightID?.Equals(other.InsightID) ?? other.InsightID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/conversations/insight-groups/{0}/insights/{1}/unassign",
            EncodePathSegment(this.GroupID),
            EncodePathSegment(this.InsightID))
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