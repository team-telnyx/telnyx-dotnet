using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.Plan;

/// <summary>
/// Returns the details of a single plan step within a run's plan, including its status.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PlanGetStepDetailsParams : ParamsBase
{
    public required string MissionID { get; init; }

    public required string RunID { get; init; }

    public string? StepID { get; init; }

    public PlanGetStepDetailsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanGetStepDetailsParams (
        PlanGetStepDetailsParams planGetStepDetailsParams
    ) : base(planGetStepDetailsParams)
    {
        this.MissionID = planGetStepDetailsParams.MissionID;
        this.RunID = planGetStepDetailsParams.RunID;
        this.StepID = planGetStepDetailsParams.StepID;
    }
    #pragma warning restore CS8618

    public PlanGetStepDetailsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanGetStepDetailsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string missionID,
        string runID,
        string stepID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.MissionID = missionID;
        this.RunID = runID;
        this.StepID = stepID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PlanGetStepDetailsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string missionID,
        string runID,
        string stepID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            missionID,
            runID,
            stepID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["MissionID"] = JsonSerializer.SerializeToElement(this.MissionID),
        ["RunID"] = JsonSerializer.SerializeToElement(this.RunID),
        ["StepID"] = JsonSerializer.SerializeToElement(this.StepID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PlanGetStepDetailsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.MissionID.Equals(other.MissionID)&&this.RunID.Equals(other.RunID)&&(this.StepID?.Equals(other.StepID) ?? other.StepID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/missions/{0}/runs/{1}/plan/steps/{2}",
            EncodePathSegment(this.MissionID),
            EncodePathSegment(this.RunID),
            EncodePathSegment(this.StepID))
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