using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// A paginated response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RequestRetrieveStatusHistoryResponse, RequestRetrieveStatusHistoryResponseFromRaw>))]
public sealed record class RequestRetrieveStatusHistoryResponse : JsonModel
{
    /// <summary>
    /// The records yielded by this request
    /// </summary>
    public required IReadOnlyList<Record> Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Record>>(
                "records"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Record>>(
                "records",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The total amount of records for these query parameters
    /// </summary>
    public required long TotalRecords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_records"
            );
        }
        init { this._rawData.Set("total_records", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Records)
        {
            item.Validate();
        }
        _ = this.TotalRecords;
    }

    public RequestRetrieveStatusHistoryResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestRetrieveStatusHistoryResponse (
        RequestRetrieveStatusHistoryResponse requestRetrieveStatusHistoryResponse
    ) : base(requestRetrieveStatusHistoryResponse)
    {  }
    #pragma warning restore CS8618

    public RequestRetrieveStatusHistoryResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestRetrieveStatusHistoryResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequestRetrieveStatusHistoryResponseFromRaw.FromRawUnchecked"/>
    public static RequestRetrieveStatusHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RequestRetrieveStatusHistoryResponseFromRaw : IFromRawJson<RequestRetrieveStatusHistoryResponse>
{
    /// <inheritdoc/>
    public RequestRetrieveStatusHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequestRetrieveStatusHistoryResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A single entry in the verification request status history
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Record, RecordFromRaw>))]
public sealed record class Record : JsonModel
{
    /// <summary>
    /// The timestamp at which this status change occurred
    /// </summary>
    public required DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "updatedAt"
            );
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// Tollfree verification status
    /// </summary>
    public required ApiEnum<string, TfVerificationStatus> VerificationStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TfVerificationStatus>>(
                "verificationStatus"
            );
        }
        init { this._rawData.Set("verificationStatus", value); }
    }

    /// <summary>
    /// An explanation of why this request has its current status.
    /// </summary>
    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UpdatedAt;
        this.VerificationStatus.Validate();
        _ = this.Reason;
    }

    public Record ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Record (Record record) : base(record)
    {  }
    #pragma warning restore CS8618

    public Record (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Record (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordFromRaw.FromRawUnchecked"/>
    public static Record FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RecordFromRaw : IFromRawJson<Record>
{
    /// <inheritdoc/>
    public Record FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Record.FromRawUnchecked(rawData);
}