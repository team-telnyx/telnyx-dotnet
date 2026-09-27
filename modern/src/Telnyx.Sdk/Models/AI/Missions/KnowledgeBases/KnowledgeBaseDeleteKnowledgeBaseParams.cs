using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.KnowledgeBases;

/// <summary>
/// Detaches the specified knowledge base from the mission so its content is no longer
/// available to agents in subsequent runs.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class KnowledgeBaseDeleteKnowledgeBaseParams : ParamsBase
{
    public required string MissionID { get; init; }

    public string? KnowledgeBaseID { get; init; }

    public KnowledgeBaseDeleteKnowledgeBaseParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public KnowledgeBaseDeleteKnowledgeBaseParams (
        KnowledgeBaseDeleteKnowledgeBaseParams knowledgeBaseDeleteKnowledgeBaseParams
    ) : base(knowledgeBaseDeleteKnowledgeBaseParams)
    {
        this.MissionID = knowledgeBaseDeleteKnowledgeBaseParams.MissionID;
        this.KnowledgeBaseID = knowledgeBaseDeleteKnowledgeBaseParams.KnowledgeBaseID;
    }
    #pragma warning restore CS8618

    public KnowledgeBaseDeleteKnowledgeBaseParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    KnowledgeBaseDeleteKnowledgeBaseParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string missionID,
        string knowledgeBaseID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.MissionID = missionID;
        this.KnowledgeBaseID = knowledgeBaseID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static KnowledgeBaseDeleteKnowledgeBaseParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string missionID,
        string knowledgeBaseID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            missionID,
            knowledgeBaseID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["MissionID"] = JsonSerializer.SerializeToElement(this.MissionID),
        ["KnowledgeBaseID"] = JsonSerializer.SerializeToElement(this.KnowledgeBaseID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(KnowledgeBaseDeleteKnowledgeBaseParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.MissionID.Equals(other.MissionID)&&(this.KnowledgeBaseID?.Equals(other.KnowledgeBaseID) ?? other.KnowledgeBaseID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/missions/{0}/knowledge-bases/{1}",
            EncodePathSegment(this.MissionID),
            EncodePathSegment(this.KnowledgeBaseID))
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