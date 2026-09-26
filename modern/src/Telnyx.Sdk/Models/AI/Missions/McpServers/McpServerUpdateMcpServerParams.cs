using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.McpServers;

/// <summary>
/// Replaces the configuration of the specified MCP server on this mission.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class McpServerUpdateMcpServerParams : ParamsBase
{
    public required string MissionID { get; init; }

    public string? McpServerID { get; init; }

    public McpServerUpdateMcpServerParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpServerUpdateMcpServerParams (
        McpServerUpdateMcpServerParams mcpServerUpdateMcpServerParams
    ) : base(mcpServerUpdateMcpServerParams)
    {
        this.MissionID = mcpServerUpdateMcpServerParams.MissionID;
        this.McpServerID = mcpServerUpdateMcpServerParams.McpServerID;
    }
    #pragma warning restore CS8618

    public McpServerUpdateMcpServerParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    McpServerUpdateMcpServerParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string missionID,
        string mcpServerID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.MissionID = missionID;
        this.McpServerID = mcpServerID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static McpServerUpdateMcpServerParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string missionID,
        string mcpServerID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            missionID,
            mcpServerID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["MissionID"] = JsonSerializer.SerializeToElement(this.MissionID),
        ["McpServerID"] = JsonSerializer.SerializeToElement(this.McpServerID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(McpServerUpdateMcpServerParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.MissionID.Equals(other.MissionID)&&(this.McpServerID?.Equals(other.McpServerID) ?? other.McpServerID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/missions/{0}/mcp-servers/{1}",
            EncodePathSegment(this.MissionID),
            EncodePathSegment(this.McpServerID))
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