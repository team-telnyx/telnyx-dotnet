using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Compute.Funcs;

[JsonConverter(typeof(JsonModelConverter<FuncRetrieveMetricAggregatesPageResponse, FuncRetrieveMetricAggregatesPageResponseFromRaw>))]
public sealed record class FuncRetrieveMetricAggregatesPageResponse : JsonModel
{
    public IReadOnlyList<FuncRetrieveMetricAggregatesResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FuncRetrieveMetricAggregatesResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FuncRetrieveMetricAggregatesResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public FunctionsObservabilityPaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionsObservabilityPaginationMeta>(
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

    public FuncRetrieveMetricAggregatesPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncRetrieveMetricAggregatesPageResponse (
        FuncRetrieveMetricAggregatesPageResponse funcRetrieveMetricAggregatesPageResponse
    ) : base(funcRetrieveMetricAggregatesPageResponse)
    {  }
    #pragma warning restore CS8618

    public FuncRetrieveMetricAggregatesPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncRetrieveMetricAggregatesPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncRetrieveMetricAggregatesPageResponseFromRaw.FromRawUnchecked"/>
    public static FuncRetrieveMetricAggregatesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FuncRetrieveMetricAggregatesPageResponseFromRaw : IFromRawJson<FuncRetrieveMetricAggregatesPageResponse>
{
    /// <inheritdoc/>
    public FuncRetrieveMetricAggregatesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncRetrieveMetricAggregatesPageResponse.FromRawUnchecked(rawData);
}