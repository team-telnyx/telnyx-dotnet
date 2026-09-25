using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.NumberLookup;

[JsonConverter(typeof(JsonModelConverter<TelcoDataUsageRecord, TelcoDataUsageRecordFromRaw>))]
public sealed record class TelcoDataUsageRecord : JsonModel
{
    /// <summary>
    /// List of aggregations by lookup type
    /// </summary>
    public IReadOnlyList<TelcoDataAggregation>? Aggregations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TelcoDataAggregation>>(
                "aggregations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TelcoDataAggregation>?>(
                "aggregations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Record type identifier
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// User ID
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Aggregations ?? [])
        {
            item.Validate();
        }
        _ = this.RecordType;
        _ = this.UserID;
    }

    public TelcoDataUsageRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelcoDataUsageRecord (
        TelcoDataUsageRecord telcoDataUsageRecord
    ) : base(telcoDataUsageRecord)
    {  }
    #pragma warning restore CS8618

    public TelcoDataUsageRecord (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelcoDataUsageRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelcoDataUsageRecordFromRaw.FromRawUnchecked"/>
    public static TelcoDataUsageRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelcoDataUsageRecordFromRaw : IFromRawJson<TelcoDataUsageRecord>
{
    /// <inheritdoc/>
    public TelcoDataUsageRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelcoDataUsageRecord.FromRawUnchecked(rawData);
}