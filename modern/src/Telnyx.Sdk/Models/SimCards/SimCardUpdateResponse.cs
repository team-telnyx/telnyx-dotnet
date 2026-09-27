using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards;

[JsonConverter(typeof(JsonModelConverter<SimCardUpdateResponse, SimCardUpdateResponseFromRaw>))]
public sealed record class SimCardUpdateResponse : JsonModel
{
    public SimCard? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCard>(
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

    public SimCardUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardUpdateResponse (
        SimCardUpdateResponse simCardUpdateResponse
    ) : base(simCardUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardUpdateResponseFromRaw.FromRawUnchecked"/>
    public static SimCardUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardUpdateResponseFromRaw : IFromRawJson<SimCardUpdateResponse>
{
    /// <inheritdoc/>
    public SimCardUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardUpdateResponse.FromRawUnchecked(rawData);
}