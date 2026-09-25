using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.TelnyxAgents;

/// <summary>
/// Unlinks the specified Telnyx agent from the run so it no longer participates in
/// execution. The run itself and its history are unaffected.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TelnyxAgentUnlinkParams : ParamsBase
{
    public required string MissionID { get; init; }

    public required string RunID { get; init; }

    public string? TelnyxAgentID { get; init; }

    public TelnyxAgentUnlinkParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelnyxAgentUnlinkParams (
        TelnyxAgentUnlinkParams telnyxAgentUnlinkParams
    ) : base(telnyxAgentUnlinkParams)
    {
        this.MissionID = telnyxAgentUnlinkParams.MissionID;
        this.RunID = telnyxAgentUnlinkParams.RunID;
        this.TelnyxAgentID = telnyxAgentUnlinkParams.TelnyxAgentID;
    }
    #pragma warning restore CS8618

    public TelnyxAgentUnlinkParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelnyxAgentUnlinkParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string missionID,
        string runID,
        string telnyxAgentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.MissionID = missionID;
        this.RunID = runID;
        this.TelnyxAgentID = telnyxAgentID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TelnyxAgentUnlinkParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string missionID,
        string runID,
        string telnyxAgentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            missionID,
            runID,
            telnyxAgentID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["MissionID"] = JsonSerializer.SerializeToElement(this.MissionID),
        ["RunID"] = JsonSerializer.SerializeToElement(this.RunID),
        ["TelnyxAgentID"] = JsonSerializer.SerializeToElement(this.TelnyxAgentID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(TelnyxAgentUnlinkParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.MissionID.Equals(other.MissionID)&&this.RunID.Equals(other.RunID)&&(this.TelnyxAgentID?.Equals(other.TelnyxAgentID) ?? other.TelnyxAgentID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/missions/{0}/runs/{1}/telnyx-agents/{2}",
            this.MissionID,
            this.RunID,
            this.TelnyxAgentID)
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