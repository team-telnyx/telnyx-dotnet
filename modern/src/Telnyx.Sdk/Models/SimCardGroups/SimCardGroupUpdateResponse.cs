using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups;

[JsonConverter(typeof(JsonModelConverter<SimCardGroupUpdateResponse, SimCardGroupUpdateResponseFromRaw>))]
public sealed record class SimCardGroupUpdateResponse : JsonModel
{
    public SimCardGroup? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardGroup>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public SimCardGroupUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGroupUpdateResponse (
        SimCardGroupUpdateResponse simCardGroupUpdateResponse
    ) : base(simCardGroupUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardGroupUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGroupUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGroupUpdateResponseFromRaw.FromRawUnchecked"/>
    public static SimCardGroupUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardGroupUpdateResponseFromRaw : IFromRawJson<SimCardGroupUpdateResponse>
{
    /// <inheritdoc/>
    public SimCardGroupUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGroupUpdateResponse.FromRawUnchecked(rawData);
}