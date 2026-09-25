using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Missions.Runs.TelnyxAgents;

[JsonConverter(typeof(JsonModelConverter<TelnyxAgentListResponse, TelnyxAgentListResponseFromRaw>))]
public sealed record class TelnyxAgentListResponse : JsonModel
{
    public required IReadOnlyList<TelnyxAgentData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TelnyxAgentData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<TelnyxAgentData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public TelnyxAgentListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelnyxAgentListResponse (
        TelnyxAgentListResponse telnyxAgentListResponse
    ) : base(telnyxAgentListResponse)
    {  }
    #pragma warning restore CS8618

    public TelnyxAgentListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelnyxAgentListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelnyxAgentListResponseFromRaw.FromRawUnchecked"/>
    public static TelnyxAgentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TelnyxAgentListResponse (IReadOnlyList<TelnyxAgentData> data) : this(

    )
    { this.Data = data; }
}

class TelnyxAgentListResponseFromRaw : IFromRawJson<TelnyxAgentListResponse>
{
    /// <inheritdoc/>
    public TelnyxAgentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelnyxAgentListResponse.FromRawUnchecked(rawData);
}