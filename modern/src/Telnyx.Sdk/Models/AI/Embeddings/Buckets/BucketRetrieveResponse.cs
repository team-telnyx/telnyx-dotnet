using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Embeddings.Buckets;

[JsonConverter(typeof(JsonModelConverter<BucketRetrieveResponse, BucketRetrieveResponseFromRaw>))]
public sealed record class BucketRetrieveResponse : JsonModel
{
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

    public BucketRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BucketRetrieveResponse (
        BucketRetrieveResponse bucketRetrieveResponse
    ) : base(bucketRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public BucketRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BucketRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BucketRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BucketRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BucketRetrieveResponse (IReadOnlyList<Data> data) : this()
    { this.Data = data; }
}

class BucketRetrieveResponseFromRaw : IFromRawJson<BucketRetrieveResponse>
{
    /// <inheritdoc/>
    public BucketRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BucketRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string Filename {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "filename"
            );
        }
        init { this._rawData.Set("filename", value); }
    }

    public required string Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public string? ErrorReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_reason", value);
        }
    }

    public DateTimeOffset? LastEmbeddedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "last_embedded_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_embedded_at", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Filename;
        _ = this.Status;
        _ = this.ErrorReason;
        _ = this.LastEmbeddedAt;
        _ = this.UpdatedAt;
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
}