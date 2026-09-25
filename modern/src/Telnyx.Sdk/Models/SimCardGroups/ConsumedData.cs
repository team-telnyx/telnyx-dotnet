using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups;

/// <summary>
/// Represents the amount of data consumed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConsumedData, ConsumedDataFromRaw>))]
public sealed record class ConsumedData : JsonModel
{
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Unit;
    }

    public ConsumedData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumedData (ConsumedData consumedData) : base(consumedData)
    {  }
    #pragma warning restore CS8618

    public ConsumedData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumedData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConsumedDataFromRaw.FromRawUnchecked"/>
    public static ConsumedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConsumedDataFromRaw : IFromRawJson<ConsumedData>
{
    /// <inheritdoc/>
    public ConsumedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConsumedData.FromRawUnchecked(rawData);
}