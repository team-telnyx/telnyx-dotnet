using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPHealthCheckTypes;

[JsonConverter(typeof(JsonModelConverter<GlobalIPHealthCheckTypeListResponse, GlobalIPHealthCheckTypeListResponseFromRaw>))]
public sealed record class GlobalIPHealthCheckTypeListResponse : JsonModel
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

    public GlobalIPHealthCheckTypeListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPHealthCheckTypeListResponse (
        GlobalIPHealthCheckTypeListResponse globalIPHealthCheckTypeListResponse
    ) : base(globalIPHealthCheckTypeListResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPHealthCheckTypeListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPHealthCheckTypeListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPHealthCheckTypeListResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPHealthCheckTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPHealthCheckTypeListResponseFromRaw : IFromRawJson<GlobalIPHealthCheckTypeListResponse>
{
    /// <inheritdoc/>
    public GlobalIPHealthCheckTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPHealthCheckTypeListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Global IP Health check params.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? HealthCheckParams {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "health_check_params"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "health_check_params",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Global IP Health check type.
    /// </summary>
    public string? HealthCheckType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "health_check_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("health_check_type", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HealthCheckParams;
        _ = this.HealthCheckType;
        _ = this.RecordType;
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