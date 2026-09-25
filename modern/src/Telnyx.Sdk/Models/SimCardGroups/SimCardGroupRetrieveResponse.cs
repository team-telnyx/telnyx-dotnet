using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups;

[JsonConverter(typeof(JsonModelConverter<SimCardGroupRetrieveResponse, SimCardGroupRetrieveResponseFromRaw>))]
public sealed record class SimCardGroupRetrieveResponse : JsonModel
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

    public SimCardGroupRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGroupRetrieveResponse (
        SimCardGroupRetrieveResponse simCardGroupRetrieveResponse
    ) : base(simCardGroupRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardGroupRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGroupRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGroupRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SimCardGroupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardGroupRetrieveResponseFromRaw : IFromRawJson<SimCardGroupRetrieveResponse>
{
    /// <inheritdoc/>
    public SimCardGroupRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGroupRetrieveResponse.FromRawUnchecked(rawData);
}