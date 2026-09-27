using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardOrders;

[JsonConverter(typeof(JsonModelConverter<SimCardOrderCreateResponse, SimCardOrderCreateResponseFromRaw>))]
public sealed record class SimCardOrderCreateResponse : JsonModel
{
    public SimCardOrder? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardOrder>(
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

    public SimCardOrderCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardOrderCreateResponse (
        SimCardOrderCreateResponse simCardOrderCreateResponse
    ) : base(simCardOrderCreateResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardOrderCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardOrderCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardOrderCreateResponseFromRaw.FromRawUnchecked"/>
    public static SimCardOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardOrderCreateResponseFromRaw : IFromRawJson<SimCardOrderCreateResponse>
{
    /// <inheritdoc/>
    public SimCardOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardOrderCreateResponse.FromRawUnchecked(rawData);
}