using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.TelnyxAgents;

[JsonConverter(typeof(JsonModelConverter<TelnyxAgentLinkResponse, TelnyxAgentLinkResponseFromRaw>))]
public sealed record class TelnyxAgentLinkResponse : JsonModel
{
    public required TelnyxAgentData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TelnyxAgentData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public TelnyxAgentLinkResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelnyxAgentLinkResponse (
        TelnyxAgentLinkResponse telnyxAgentLinkResponse
    ) : base(telnyxAgentLinkResponse)
    {  }
    #pragma warning restore CS8618

    public TelnyxAgentLinkResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelnyxAgentLinkResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelnyxAgentLinkResponseFromRaw.FromRawUnchecked"/>
    public static TelnyxAgentLinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TelnyxAgentLinkResponse (TelnyxAgentData data) : this()
    { this.Data = data; }
}

class TelnyxAgentLinkResponseFromRaw : IFromRawJson<TelnyxAgentLinkResponse>
{
    /// <inheritdoc/>
    public TelnyxAgentLinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelnyxAgentLinkResponse.FromRawUnchecked(rawData);
}