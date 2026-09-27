using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Seti;

[JsonConverter(typeof(JsonModelConverter<SetiRetrieveBlackBoxTestResultsResponse, SetiRetrieveBlackBoxTestResultsResponseFromRaw>))]
public sealed record class SetiRetrieveBlackBoxTestResultsResponse : JsonModel
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

    public SetiRetrieveBlackBoxTestResultsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetiRetrieveBlackBoxTestResultsResponse (
        SetiRetrieveBlackBoxTestResultsResponse setiRetrieveBlackBoxTestResultsResponse
    ) : base(setiRetrieveBlackBoxTestResultsResponse)
    {  }
    #pragma warning restore CS8618

    public SetiRetrieveBlackBoxTestResultsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SetiRetrieveBlackBoxTestResultsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SetiRetrieveBlackBoxTestResultsResponseFromRaw.FromRawUnchecked"/>
    public static SetiRetrieveBlackBoxTestResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SetiRetrieveBlackBoxTestResultsResponseFromRaw : IFromRawJson<SetiRetrieveBlackBoxTestResultsResponse>
{
    /// <inheritdoc/>
    public SetiRetrieveBlackBoxTestResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SetiRetrieveBlackBoxTestResultsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public IReadOnlyList<BlackBoxTest>? BlackBoxTests {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BlackBoxTest>>(
                "black_box_tests"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<BlackBoxTest>?>(
                "black_box_tests",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The product associated with the black box test group.
    /// </summary>
    public string? Product {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "product"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product", value);
        }
    }

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
        foreach (var item in this.BlackBoxTests ?? [])
        {
            item.Validate();
        }
        _ = this.Product;
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
}[JsonConverter(typeof(JsonModelConverter<BlackBoxTest, BlackBoxTestFromRaw>))]
public sealed record class BlackBoxTest : JsonModel
{
    /// <summary>
    /// The name of the black box test.
    /// </summary>
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

    /// <summary>
    /// The average result of the black box test over the last hour.
    /// </summary>
    public double? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("result", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.RecordType;
        _ = this.Result;
    }

    public BlackBoxTest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlackBoxTest (BlackBoxTest blackBoxTest) : base(blackBoxTest)
    {  }
    #pragma warning restore CS8618

    public BlackBoxTest (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BlackBoxTest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BlackBoxTestFromRaw.FromRawUnchecked"/>
    public static BlackBoxTest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class BlackBoxTestFromRaw : IFromRawJson<BlackBoxTest>
{
    /// <inheritdoc/>
    public BlackBoxTest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BlackBoxTest.FromRawUnchecked(rawData);
}