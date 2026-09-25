using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Buckets.Usage;

[JsonConverter(typeof(JsonModelConverter<UsageGetBucketUsageResponse, UsageGetBucketUsageResponseFromRaw>))]
public sealed record class UsageGetBucketUsageResponse : JsonModel
{
    public IReadOnlyList<UsageGetBucketUsageResponseData>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UsageGetBucketUsageResponseData>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<UsageGetBucketUsageResponseData>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMetaSimple? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMetaSimple>(
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

    public UsageGetBucketUsageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageGetBucketUsageResponse (
        UsageGetBucketUsageResponse usageGetBucketUsageResponse
    ) : base(usageGetBucketUsageResponse)
    {  }
    #pragma warning restore CS8618

    public UsageGetBucketUsageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageGetBucketUsageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UsageGetBucketUsageResponseFromRaw.FromRawUnchecked"/>
    public static UsageGetBucketUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UsageGetBucketUsageResponseFromRaw : IFromRawJson<UsageGetBucketUsageResponse>
{
    /// <inheritdoc/>
    public UsageGetBucketUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UsageGetBucketUsageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UsageGetBucketUsageResponseData, UsageGetBucketUsageResponseDataFromRaw>))]
public sealed record class UsageGetBucketUsageResponseData : JsonModel
{
    /// <summary>
    /// The number of objects in the bucket
    /// </summary>
    public long? NumObjects {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "num_objects"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("num_objects", value);
        }
    }

    /// <summary>
    /// The size of the bucket in bytes
    /// </summary>
    public long? Size {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("size", value);
        }
    }

    /// <summary>
    /// The size of the bucket in kilobytes
    /// </summary>
    public long? SizeKB {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "size_kb"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("size_kb", value);
        }
    }

    /// <summary>
    /// The time the snapshot was taken
    /// </summary>
    public DateTimeOffset? Timestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "timestamp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NumObjects;
        _ = this.Size;
        _ = this.SizeKB;
        _ = this.Timestamp;
    }

    public UsageGetBucketUsageResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageGetBucketUsageResponseData (
        UsageGetBucketUsageResponseData usageGetBucketUsageResponseData
    ) : base(usageGetBucketUsageResponseData)
    {  }
    #pragma warning restore CS8618

    public UsageGetBucketUsageResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageGetBucketUsageResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UsageGetBucketUsageResponseDataFromRaw.FromRawUnchecked"/>
    public static UsageGetBucketUsageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UsageGetBucketUsageResponseDataFromRaw : IFromRawJson<UsageGetBucketUsageResponseData>
{
    /// <inheritdoc/>
    public UsageGetBucketUsageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UsageGetBucketUsageResponseData.FromRawUnchecked(rawData);
}