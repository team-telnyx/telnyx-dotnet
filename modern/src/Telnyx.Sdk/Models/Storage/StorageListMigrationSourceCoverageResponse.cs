using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Usage = Telnyx.Sdk.Models.Storage.Buckets.Usage;

namespace Telnyx.Sdk.Models.Storage;

[JsonConverter(typeof(JsonModelConverter<StorageListMigrationSourceCoverageResponse, StorageListMigrationSourceCoverageResponseFromRaw>))]
public sealed record class StorageListMigrationSourceCoverageResponse : JsonModel
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

    public Usage::PaginationMetaSimple? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Usage::PaginationMetaSimple>(
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

    public StorageListMigrationSourceCoverageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StorageListMigrationSourceCoverageResponse (
        StorageListMigrationSourceCoverageResponse storageListMigrationSourceCoverageResponse
    ) : base(storageListMigrationSourceCoverageResponse)
    {  }
    #pragma warning restore CS8618

    public StorageListMigrationSourceCoverageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StorageListMigrationSourceCoverageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StorageListMigrationSourceCoverageResponseFromRaw.FromRawUnchecked"/>
    public static StorageListMigrationSourceCoverageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StorageListMigrationSourceCoverageResponseFromRaw : IFromRawJson<StorageListMigrationSourceCoverageResponse>
{
    /// <inheritdoc/>
    public StorageListMigrationSourceCoverageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StorageListMigrationSourceCoverageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Cloud provider from which to migrate data.
    /// </summary>
    public ApiEnum<string, Provider>? Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Provider>>(
                "provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <summary>
    /// Provider region from which to migrate data.
    /// </summary>
    public string? SourceRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "source_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source_region", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Provider?.Validate();
        _ = this.SourceRegion;
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
}/// <summary>
/// Cloud provider from which to migrate data.
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Aws
}sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "aws"=>Provider.Aws, _ =>(Provider)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Provider value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Provider.Aws=>"aws",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}