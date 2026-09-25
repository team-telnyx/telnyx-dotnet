using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups;

[JsonConverter(typeof(JsonModelConverter<SimCardGroupCreateResponse, SimCardGroupCreateResponseFromRaw>))]
public sealed record class SimCardGroupCreateResponse : JsonModel
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

    public SimCardGroupCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGroupCreateResponse (
        SimCardGroupCreateResponse simCardGroupCreateResponse
    ) : base(simCardGroupCreateResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardGroupCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGroupCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGroupCreateResponseFromRaw.FromRawUnchecked"/>
    public static SimCardGroupCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardGroupCreateResponseFromRaw : IFromRawJson<SimCardGroupCreateResponse>
{
    /// <inheritdoc/>
    public SimCardGroupCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGroupCreateResponse.FromRawUnchecked(rawData);
}