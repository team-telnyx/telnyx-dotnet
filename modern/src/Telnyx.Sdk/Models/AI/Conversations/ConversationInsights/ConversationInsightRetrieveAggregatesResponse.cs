using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations.ConversationInsights;

/// <summary>
/// Aggregated conversation insight counts grouped by the specified fields. Each
/// item in `data` contains the grouped field values and a `record_count` indicating
/// how many conversation insights match that combination.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConversationInsightRetrieveAggregatesResponse, ConversationInsightRetrieveAggregatesResponseFromRaw>))]
public sealed record class ConversationInsightRetrieveAggregatesResponse : JsonModel
{
    /// <summary>
    /// Aggregation result rows. Each row contains the grouped field values and a `record_count`.
    /// </summary>
    public required IReadOnlyList<Data> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Data>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public ConversationInsightRetrieveAggregatesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationInsightRetrieveAggregatesResponse (
        ConversationInsightRetrieveAggregatesResponse conversationInsightRetrieveAggregatesResponse
    ) : base(conversationInsightRetrieveAggregatesResponse)
    {  }
    #pragma warning restore CS8618

    public ConversationInsightRetrieveAggregatesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationInsightRetrieveAggregatesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationInsightRetrieveAggregatesResponseFromRaw.FromRawUnchecked"/>
    public static ConversationInsightRetrieveAggregatesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConversationInsightRetrieveAggregatesResponse (
        IReadOnlyList<Data> data
    ) : this()
    { this.Data = data; }
}

class ConversationInsightRetrieveAggregatesResponseFromRaw : IFromRawJson<ConversationInsightRetrieveAggregatesResponse>
{
    /// <inheritdoc/>
    public ConversationInsightRetrieveAggregatesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationInsightRetrieveAggregatesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An aggregation row. Contains the grouped field values (keyed by the group_by
/// field names) and a `record_count` integer. For example, when grouping by `score`,
/// each row has a `score` value and a `record_count` of conversations with that score.
/// When also splitting by `metadata.assistant_version_id`, each row includes both
/// `score` and `metadata.assistant_version_id` plus their combined `record_count`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Number of conversation insights that match this combination of grouped field values.
    /// </summary>
    public required long RecordCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "record_count"
            );
        }
        init { this._rawData.Set("record_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.RecordCount; }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Data (long recordCount) : this()
    { this.RecordCount = recordCount; }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}