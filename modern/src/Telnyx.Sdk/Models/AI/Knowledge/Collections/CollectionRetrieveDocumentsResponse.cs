using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Knowledge.Collections;

[JsonConverter(typeof(JsonModelConverter<CollectionRetrieveDocumentsResponse, CollectionRetrieveDocumentsResponseFromRaw>))]
public sealed record class CollectionRetrieveDocumentsResponse : JsonModel
{
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Meta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>(
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

    public CollectionRetrieveDocumentsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionRetrieveDocumentsResponse (
        CollectionRetrieveDocumentsResponse collectionRetrieveDocumentsResponse
    ) : base(collectionRetrieveDocumentsResponse)
    {  }
    #pragma warning restore CS8618

    public CollectionRetrieveDocumentsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionRetrieveDocumentsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CollectionRetrieveDocumentsResponseFromRaw.FromRawUnchecked"/>
    public static CollectionRetrieveDocumentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CollectionRetrieveDocumentsResponseFromRaw : IFromRawJson<CollectionRetrieveDocumentsResponse>
{
    /// <inheritdoc/>
    public CollectionRetrieveDocumentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CollectionRetrieveDocumentsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public long? ChunkIndex {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "chunk_index"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("chunk_index", value);
        }
    }

    public long? ChunkTotal {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "chunk_total"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("chunk_total", value);
        }
    }

    public DateTimeOffset? IngestedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "ingested_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ingested_at", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_id", value);
        }
    }

    public DateTimeOffset? RecordCreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "record_created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_created_at", value);
        }
    }

    public string? RecordID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_id", value);
        }
    }

    /// <summary>
    /// The source record kind this chunk came from (e.g. `voice`, `meeting_bot`, `message`).
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

    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <summary>
    /// Relevance score (higher = more relevant) for ranked search. `0.0` for plain
    /// catalog listings (when `query` is omitted).
    /// </summary>
    public float? Score {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "score"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

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
        _ = this.ID;
        _ = this.ChunkIndex;
        _ = this.ChunkTotal;
        _ = this.IngestedAt;
        _ = this.Metadata;
        _ = this.OrganizationID;
        _ = this.RecordCreatedAt;
        _ = this.RecordID;
        _ = this.RecordType;
        _ = this.Region;
        _ = this.Score;
        _ = this.Text;
        _ = this.UserID;
    }

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
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public string? CollectionSlug {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "collection_slug"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("collection_slug", value);
        }
    }

    public long? PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_number", value);
        }
    }

    public long? PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    public string? RetrievalType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "retrieval_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("retrieval_type", value);
        }
    }

    public IReadOnlyList<string>? SearchedSources {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "searched_sources"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "searched_sources",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? TopK {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "top_k"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("top_k", value);
        }
    }

    public long? TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_pages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_pages", value);
        }
    }

    public long? TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_results", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CollectionSlug;
        _ = this.PageNumber;
        _ = this.PageSize;
        _ = this.RetrievalType;
        _ = this.SearchedSources;
        _ = this.TopK;
        _ = this.TotalPages;
        _ = this.TotalResults;
    }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}