using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.InexplicitNumberOrders;

[JsonConverter(typeof(JsonModelConverter<InexplicitNumberOrderCreateResponse, InexplicitNumberOrderCreateResponseFromRaw>))]
public sealed record class InexplicitNumberOrderCreateResponse : JsonModel
{
    public InexplicitNumberOrderResponse? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InexplicitNumberOrderResponse>(
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

    public InexplicitNumberOrderCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InexplicitNumberOrderCreateResponse (
        InexplicitNumberOrderCreateResponse inexplicitNumberOrderCreateResponse
    ) : base(inexplicitNumberOrderCreateResponse)
    {  }
    #pragma warning restore CS8618

    public InexplicitNumberOrderCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InexplicitNumberOrderCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InexplicitNumberOrderCreateResponseFromRaw.FromRawUnchecked"/>
    public static InexplicitNumberOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InexplicitNumberOrderCreateResponseFromRaw : IFromRawJson<InexplicitNumberOrderCreateResponse>
{
    /// <inheritdoc/>
    public InexplicitNumberOrderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InexplicitNumberOrderCreateResponse.FromRawUnchecked(rawData);
}