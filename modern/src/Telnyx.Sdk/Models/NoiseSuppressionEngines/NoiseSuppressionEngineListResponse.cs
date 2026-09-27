using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NoiseSuppressionEngines;

[JsonConverter(typeof(JsonModelConverter<NoiseSuppressionEngineListResponse, NoiseSuppressionEngineListResponseFromRaw>))]
public sealed record class NoiseSuppressionEngineListResponse : JsonModel
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

    public NoiseSuppressionEngineListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoiseSuppressionEngineListResponse (
        NoiseSuppressionEngineListResponse noiseSuppressionEngineListResponse
    ) : base(noiseSuppressionEngineListResponse)
    {  }
    #pragma warning restore CS8618

    public NoiseSuppressionEngineListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NoiseSuppressionEngineListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NoiseSuppressionEngineListResponseFromRaw.FromRawUnchecked"/>
    public static NoiseSuppressionEngineListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public NoiseSuppressionEngineListResponse (IReadOnlyList<Data> data) : this(

    )
    { this.Data = data; }
}

class NoiseSuppressionEngineListResponseFromRaw : IFromRawJson<NoiseSuppressionEngineListResponse>
{
    /// <inheritdoc/>
    public NoiseSuppressionEngineListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NoiseSuppressionEngineListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A noise suppression engine available to the authenticated user.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Default attenuation level of the engine (0-100, in multiples of ten).
    /// </summary>
    public required long DefaultAttenuationLevel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "default_attenuation_level"
            );
        }
        init { this._rawData.Set("default_attenuation_level", value); }
    }

    /// <summary>
    /// Human-readable name of the engine.
    /// </summary>
    public required string Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "label"
            );
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// Machine-readable identifier of the engine, used when configuring noise suppression.
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DefaultAttenuationLevel;
        _ = this.Label;
        _ = this.Value;
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