using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Actions.Purchase;

[JsonConverter(typeof(JsonModelConverter<PurchaseCreateResponse, PurchaseCreateResponseFromRaw>))]
public sealed record class PurchaseCreateResponse : JsonModel
{
    /// <summary>
    /// Successfully registered SIM cards.
    /// </summary>
    public IReadOnlyList<SimpleSimCard>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimpleSimCard>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SimpleSimCard>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<WirelessErrorC5290d5308>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WirelessErrorC5290d5308>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WirelessErrorC5290d5308>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Errors ?? [])
        {
            item.Validate();
        }
    }

    public PurchaseCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PurchaseCreateResponse (
        PurchaseCreateResponse purchaseCreateResponse
    ) : base(purchaseCreateResponse)
    {  }
    #pragma warning restore CS8618

    public PurchaseCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PurchaseCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PurchaseCreateResponseFromRaw.FromRawUnchecked"/>
    public static PurchaseCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PurchaseCreateResponseFromRaw : IFromRawJson<PurchaseCreateResponse>
{
    /// <inheritdoc/>
    public PurchaseCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PurchaseCreateResponse.FromRawUnchecked(rawData);
}