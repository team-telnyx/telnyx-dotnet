using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Embeddings.Buckets;

[JsonConverter(typeof(JsonModelConverter<BucketListResponse, BucketListResponseFromRaw>))]
public sealed record class BucketListResponse : JsonModel
{
    public required BucketListResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BucketListResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public BucketListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BucketListResponse (BucketListResponse bucketListResponse) : base(
        bucketListResponse
    )
    {  }
    #pragma warning restore CS8618

    public BucketListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BucketListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BucketListResponseFromRaw.FromRawUnchecked"/>
    public static BucketListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BucketListResponse (BucketListResponseData data) : this()
    { this.Data = data; }
}

class BucketListResponseFromRaw : IFromRawJson<BucketListResponse>
{
    /// <inheritdoc/>
    public BucketListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BucketListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BucketListResponseData, BucketListResponseDataFromRaw>))]
public sealed record class BucketListResponseData : JsonModel
{
    public required IReadOnlyList<string> Buckets {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "buckets"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "buckets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Buckets; }

    public BucketListResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BucketListResponseData (
        BucketListResponseData bucketListResponseData
    ) : base(bucketListResponseData)
    {  }
    #pragma warning restore CS8618

    public BucketListResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BucketListResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BucketListResponseDataFromRaw.FromRawUnchecked"/>
    public static BucketListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BucketListResponseData (IReadOnlyList<string> buckets) : this()
    { this.Buckets = buckets; }
}class BucketListResponseDataFromRaw : IFromRawJson<BucketListResponseData>
{
    /// <inheritdoc/>
    public BucketListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BucketListResponseData.FromRawUnchecked(rawData);
}