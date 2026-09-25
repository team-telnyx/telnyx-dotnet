using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Chat;

[JsonConverter(typeof(JsonModelConverter<BucketIds, BucketIdsFromRaw>))]
public sealed record class BucketIds : JsonModel
{
    /// <summary>
    /// List of [embedded storage buckets](https://developers.telnyx.com/api-reference/embeddings/embed-documents)
    /// to use for retrieval-augmented generation.
    /// </summary>
    public required IReadOnlyList<string> BucketIdsValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "bucket_ids"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "bucket_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The maximum number of results to retrieve as context for the language model.
    /// </summary>
    public long? MaxNumResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_num_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_num_results", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BucketIdsValue;
        _ = this.MaxNumResults;
    }

    public BucketIds ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BucketIds (BucketIds bucketIds) : base(bucketIds)
    {  }
    #pragma warning restore CS8618

    public BucketIds (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BucketIds (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BucketIdsFromRaw.FromRawUnchecked"/>
    public static BucketIds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BucketIds (IReadOnlyList<string> bucketIdsValue) : this()
    { this.BucketIdsValue = bucketIdsValue; }
}

class BucketIdsFromRaw : IFromRawJson<BucketIds>
{
    /// <inheritdoc/>
    public BucketIds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BucketIds.FromRawUnchecked(rawData);
}