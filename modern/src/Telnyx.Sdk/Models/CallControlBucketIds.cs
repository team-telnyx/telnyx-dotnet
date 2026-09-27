using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<CallControlBucketIds, CallControlBucketIdsFromRaw>))]
public sealed record class CallControlBucketIds : JsonModel
{
    public required IReadOnlyList<string> BucketIds {
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
        _ = this.BucketIds;
        _ = this.MaxNumResults;
    }

    public CallControlBucketIds ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlBucketIds (
        CallControlBucketIds callControlBucketIds
    ) : base(callControlBucketIds)
    {  }
    #pragma warning restore CS8618

    public CallControlBucketIds (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlBucketIds (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlBucketIdsFromRaw.FromRawUnchecked"/>
    public static CallControlBucketIds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public CallControlBucketIds (IReadOnlyList<string> bucketIds) : this()
    { this.BucketIds = bucketIds; }
}

class CallControlBucketIdsFromRaw : IFromRawJson<CallControlBucketIds>
{
    /// <inheritdoc/>
    public CallControlBucketIds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlBucketIds.FromRawUnchecked(rawData);
}