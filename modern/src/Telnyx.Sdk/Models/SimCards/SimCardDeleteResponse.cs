using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards;

[JsonConverter(typeof(JsonModelConverter<SimCardDeleteResponse, SimCardDeleteResponseFromRaw>))]
public sealed record class SimCardDeleteResponse : JsonModel
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

    public SimCardDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDeleteResponse (
        SimCardDeleteResponse simCardDeleteResponse
    ) : base(simCardDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardDeleteResponseFromRaw.FromRawUnchecked"/>
    public static SimCardDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardDeleteResponseFromRaw : IFromRawJson<SimCardDeleteResponse>
{
    /// <inheritdoc/>
    public SimCardDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardDeleteResponse.FromRawUnchecked(rawData);
}