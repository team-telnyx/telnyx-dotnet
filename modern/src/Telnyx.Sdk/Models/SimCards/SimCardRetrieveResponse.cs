using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards;

[JsonConverter(typeof(JsonModelConverter<SimCardRetrieveResponse, SimCardRetrieveResponseFromRaw>))]
public sealed record class SimCardRetrieveResponse : JsonModel
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

    public SimCardRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardRetrieveResponse (
        SimCardRetrieveResponse simCardRetrieveResponse
    ) : base(simCardRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SimCardRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardRetrieveResponseFromRaw : IFromRawJson<SimCardRetrieveResponse>
{
    /// <inheritdoc/>
    public SimCardRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardRetrieveResponse.FromRawUnchecked(rawData);
}