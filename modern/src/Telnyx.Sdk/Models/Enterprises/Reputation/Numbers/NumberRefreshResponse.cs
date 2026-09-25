using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Numbers;

[JsonConverter(typeof(JsonModelConverter<NumberRefreshResponse, NumberRefreshResponseFromRaw>))]
public sealed record class NumberRefreshResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public NumberRefreshResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberRefreshResponse (
        NumberRefreshResponse numberRefreshResponse
    ) : base(numberRefreshResponse)
    {  }
    #pragma warning restore CS8618

    public NumberRefreshResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberRefreshResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberRefreshResponseFromRaw.FromRawUnchecked"/>
    public static NumberRefreshResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public NumberRefreshResponse (Data data) : this()
    { this.Data = data; }
}

class NumberRefreshResponseFromRaw : IFromRawJson<NumberRefreshResponse>
{
    /// <inheritdoc/>
    public NumberRefreshResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberRefreshResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Per-number outcome of the refresh.
    /// </summary>
    public required IReadOnlyList<Result> Results {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Result>>(
                "results"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Result>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long TotalFailed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_failed"
            );
        }
        init { this._rawData.Set("total_failed", value); }
    }

    public required long TotalRequested {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_requested"
            );
        }
        init { this._rawData.Set("total_requested", value); }
    }

    public required long TotalSuccessful {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_successful"
            );
        }
        init { this._rawData.Set("total_successful", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
        _ = this.TotalFailed;
        _ = this.TotalRequested;
        _ = this.TotalSuccessful;
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
}[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public required bool Success {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "success"
            );
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// `null` when `success` is `true`; carries an error message otherwise.
    /// </summary>
    public string? Error {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error"
            );
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        _ = this.Success;
        _ = this.Error;
    }

    public Result ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result (Result result) : base(result)
    {  }
    #pragma warning restore CS8618

    public Result (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Result (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Result.FromRawUnchecked(rawData);
}