using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SubNumberOrders;

[JsonConverter(typeof(JsonModelConverter<SubNumberOrderUpdateResponse, SubNumberOrderUpdateResponseFromRaw>))]
public sealed record class SubNumberOrderUpdateResponse : JsonModel
{
    public NumbersSubNumberOrder? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumbersSubNumberOrder>(
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

    public SubNumberOrderUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderUpdateResponse (
        SubNumberOrderUpdateResponse subNumberOrderUpdateResponse
    ) : base(subNumberOrderUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public SubNumberOrderUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SubNumberOrderUpdateResponseFromRaw.FromRawUnchecked"/>
    public static SubNumberOrderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SubNumberOrderUpdateResponseFromRaw : IFromRawJson<SubNumberOrderUpdateResponse>
{
    /// <inheritdoc/>
    public SubNumberOrderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SubNumberOrderUpdateResponse.FromRawUnchecked(rawData);
}