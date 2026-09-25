using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Messaging;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.NumberLookup;

[JsonConverter(typeof(JsonModelConverter<NumberLookupListPageResponse, NumberLookupListPageResponseFromRaw>))]
public sealed record class NumberLookupListPageResponse : JsonModel
{
    public IReadOnlyList<TelcoDataUsageReportResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TelcoDataUsageReportResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TelcoDataUsageReportResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public StandardPaginationMetaFfba4faa88? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StandardPaginationMetaFfba4faa88>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public NumberLookupListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberLookupListPageResponse (
        NumberLookupListPageResponse numberLookupListPageResponse
    ) : base(numberLookupListPageResponse)
    {  }
    #pragma warning restore CS8618

    public NumberLookupListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberLookupListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberLookupListPageResponseFromRaw.FromRawUnchecked"/>
    public static NumberLookupListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberLookupListPageResponseFromRaw : IFromRawJson<NumberLookupListPageResponse>
{
    /// <inheritdoc/>
    public NumberLookupListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberLookupListPageResponse.FromRawUnchecked(rawData);
}