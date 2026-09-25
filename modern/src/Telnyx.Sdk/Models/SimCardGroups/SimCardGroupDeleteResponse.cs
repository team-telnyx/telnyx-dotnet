using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups;

[JsonConverter(typeof(JsonModelConverter<SimCardGroupDeleteResponse, SimCardGroupDeleteResponseFromRaw>))]
public sealed record class SimCardGroupDeleteResponse : JsonModel
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

    public SimCardGroupDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGroupDeleteResponse (
        SimCardGroupDeleteResponse simCardGroupDeleteResponse
    ) : base(simCardGroupDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardGroupDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGroupDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGroupDeleteResponseFromRaw.FromRawUnchecked"/>
    public static SimCardGroupDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardGroupDeleteResponseFromRaw : IFromRawJson<SimCardGroupDeleteResponse>
{
    /// <inheritdoc/>
    public SimCardGroupDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGroupDeleteResponse.FromRawUnchecked(rawData);
}