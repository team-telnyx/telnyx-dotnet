using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Storage.Buckets.Usage;

[JsonConverter(typeof(JsonModelConverter<UsageGetApiUsageResponse, UsageGetApiUsageResponseFromRaw>))]
public sealed record class UsageGetApiUsageResponse : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public UsageGetApiUsageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageGetApiUsageResponse (
        UsageGetApiUsageResponse usageGetApiUsageResponse
    ) : base(usageGetApiUsageResponse)
    {  }
    #pragma warning restore CS8618

    public UsageGetApiUsageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageGetApiUsageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UsageGetApiUsageResponseFromRaw.FromRawUnchecked"/>
    public static UsageGetApiUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UsageGetApiUsageResponseFromRaw : IFromRawJson<UsageGetApiUsageResponse>
{
    /// <inheritdoc/>
    public UsageGetApiUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UsageGetApiUsageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public IReadOnlyList<Category>? Categories {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Category>>(
                "categories"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Category>?>(
                "categories",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The time the usage was recorded
    /// </summary>
    public System::DateTimeOffset? Timestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    public Total? Total {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Total>(
                "total"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Categories ?? [])
        {
            item.Validate();
        }
        _ = this.Timestamp;
        this.Total?.Validate();
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
}[JsonConverter(typeof(JsonModelConverter<Category, CategoryFromRaw>))]
public sealed record class Category : JsonModel
{
    /// <summary>
    /// The number of bytes received
    /// </summary>
    public long? BytesReceived {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "bytes_received"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bytes_received", value);
        }
    }

    /// <summary>
    /// The number of bytes sent
    /// </summary>
    public long? BytesSent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "bytes_sent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bytes_sent", value);
        }
    }

    /// <summary>
    /// The category of the bucket operation
    /// </summary>
    public ApiEnum<string, CategoryCategory>? CategoryValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CategoryCategory>>(
                "category"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    /// <summary>
    /// The number of operations
    /// </summary>
    public long? Ops {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "ops"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ops", value);
        }
    }

    /// <summary>
    /// The number of successful operations
    /// </summary>
    public long? SuccessfulOps {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "successful_ops"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("successful_ops", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BytesReceived;
        _ = this.BytesSent;
        this.CategoryValue?.Validate();
        _ = this.Ops;
        _ = this.SuccessfulOps;
    }

    public Category ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Category (Category category) : base(category)
    {  }
    #pragma warning restore CS8618

    public Category (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Category (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CategoryFromRaw.FromRawUnchecked"/>
    public static Category FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CategoryFromRaw : IFromRawJson<Category>
{
    /// <inheritdoc/>
    public Category FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Category.FromRawUnchecked(rawData);
}/// <summary>
/// The category of the bucket operation
/// </summary>
[JsonConverter(typeof(CategoryCategoryConverter))]
public enum CategoryCategory
{
    ListBucket,
    ListBuckets,
    GetBucketLocation,
    CreateBucket,
    StatBucket,
    GetBucketVersioning,
    SetBucketVersioning,
    GetObj,
    PutObj,
    DeleteObj
}sealed class CategoryCategoryConverter : JsonConverter<CategoryCategory>
{
    public override CategoryCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list_bucket"=>CategoryCategory.ListBucket,
            "list_buckets"=>CategoryCategory.ListBuckets,
            "get-bucket_location"=>CategoryCategory.GetBucketLocation,
            "create_bucket"=>CategoryCategory.CreateBucket,
            "stat_bucket"=>CategoryCategory.StatBucket,
            "get_bucket_versioning"=>CategoryCategory.GetBucketVersioning,
            "set_bucket_versioning"=>CategoryCategory.SetBucketVersioning,
            "get_obj"=>CategoryCategory.GetObj,
            "put_obj"=>CategoryCategory.PutObj,
            "delete_obj"=>CategoryCategory.DeleteObj,
            _ =>(CategoryCategory)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CategoryCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CategoryCategory.ListBucket=>"list_bucket",
            CategoryCategory.ListBuckets=>"list_buckets",
            CategoryCategory.GetBucketLocation=>"get-bucket_location",
            CategoryCategory.CreateBucket=>"create_bucket",
            CategoryCategory.StatBucket=>"stat_bucket",
            CategoryCategory.GetBucketVersioning=>"get_bucket_versioning",
            CategoryCategory.SetBucketVersioning=>"set_bucket_versioning",
            CategoryCategory.GetObj=>"get_obj",
            CategoryCategory.PutObj=>"put_obj",
            CategoryCategory.DeleteObj=>"delete_obj",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Total, TotalFromRaw>))]
public sealed record class Total : JsonModel
{
    /// <summary>
    /// The number of bytes received
    /// </summary>
    public long? BytesReceived {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "bytes_received"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bytes_received", value);
        }
    }

    /// <summary>
    /// The number of bytes sent
    /// </summary>
    public long? BytesSent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "bytes_sent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bytes_sent", value);
        }
    }

    /// <summary>
    /// The number of operations
    /// </summary>
    public long? Ops {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "ops"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ops", value);
        }
    }

    /// <summary>
    /// The number of successful operations
    /// </summary>
    public long? SuccessfulOps {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "successful_ops"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("successful_ops", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BytesReceived;
        _ = this.BytesSent;
        _ = this.Ops;
        _ = this.SuccessfulOps;
    }

    public Total ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Total (Total total) : base(total)
    {  }
    #pragma warning restore CS8618

    public Total (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Total (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TotalFromRaw.FromRawUnchecked"/>
    public static Total FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TotalFromRaw : IFromRawJson<Total>
{
    /// <inheritdoc/>
    public Total FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Total.FromRawUnchecked(rawData);
}