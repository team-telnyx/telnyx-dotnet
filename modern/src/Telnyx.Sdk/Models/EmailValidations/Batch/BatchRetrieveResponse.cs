using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailValidations.Batch;

[JsonConverter(typeof(JsonModelConverter<BatchRetrieveResponse, BatchRetrieveResponseFromRaw>))]
public sealed record class BatchRetrieveResponse : JsonModel
{
    /// <summary>
    /// Shape returned by the GET endpoint. Does not include duplicates_removed.
    /// </summary>
    public required BatchRetrieveResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BatchRetrieveResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public BatchRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchRetrieveResponse (
        BatchRetrieveResponse batchRetrieveResponse
    ) : base(batchRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public BatchRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BatchRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BatchRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BatchRetrieveResponse (BatchRetrieveResponseData data) : this()
    { this.Data = data; }
}

class BatchRetrieveResponseFromRaw : IFromRawJson<BatchRetrieveResponse>
{
    /// <inheritdoc/>
    public BatchRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BatchRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Shape returned by the GET endpoint. Does not include duplicates_removed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchRetrieveResponseData, BatchRetrieveResponseDataFromRaw>))]
public sealed record class BatchRetrieveResponseData : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, BatchRetrieveResponseDataRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchRetrieveResponseDataRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    public required ApiEnum<string, EmailValidationBatchStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailValidationBatchStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required long Total {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total"
            );
        }
        init { this._rawData.Set("total", value); }
    }

    public System::DateTimeOffset? CompletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "completed_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("completed_at", value);
        }
    }

    /// <summary>
    /// Map keyed by original email address. Present only when the batch is completed.
    /// </summary>
    public IReadOnlyDictionary<string, ResultsItem>? Results {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, ResultsItem>>(
                "results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, ResultsItem>?>(
                "results",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.RecordType.Validate();
        this.Status.Validate();
        _ = this.Total;
        _ = this.CompletedAt;
        if (this.Results != null)
        {
            foreach (var item in this.Results.Values)
            {
                item.Validate();
            }
        }
        _ = this.WebhookUrl;
    }

    public BatchRetrieveResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchRetrieveResponseData (
        BatchRetrieveResponseData batchRetrieveResponseData
    ) : base(batchRetrieveResponseData)
    {  }
    #pragma warning restore CS8618

    public BatchRetrieveResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchRetrieveResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BatchRetrieveResponseDataFromRaw.FromRawUnchecked"/>
    public static BatchRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class BatchRetrieveResponseDataFromRaw : IFromRawJson<BatchRetrieveResponseData>
{
    /// <inheritdoc/>
    public BatchRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BatchRetrieveResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(BatchRetrieveResponseDataRecordTypeConverter))]
public enum BatchRetrieveResponseDataRecordType
{
    EmailValidationBatch
}sealed class BatchRetrieveResponseDataRecordTypeConverter : JsonConverter<BatchRetrieveResponseDataRecordType>
{
    public override BatchRetrieveResponseDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_validation_batch"=>BatchRetrieveResponseDataRecordType.EmailValidationBatch,
            _ =>(BatchRetrieveResponseDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchRetrieveResponseDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BatchRetrieveResponseDataRecordType.EmailValidationBatch=>"email_validation_batch",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<ResultsItem, ResultsItemFromRaw>))]
public sealed record class ResultsItem : JsonModel
{
    public required EmailValidationChecks Checks {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailValidationChecks>(
                "checks"
            );
        }
        init { this._rawData.Set("checks", value); }
    }

    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    public required float RiskScore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "risk_score"
            );
        }
        init { this._rawData.Set("risk_score", value); }
    }

    public required bool Valid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "valid"
            );
        }
        init { this._rawData.Set("valid", value); }
    }

    /// <summary>
    /// Suggested correction for typo. Omitted when nil.
    /// </summary>
    public string? DidYouMean {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "did_you_mean"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("did_you_mean", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Checks.Validate();
        _ = this.Email;
        _ = this.RiskScore;
        _ = this.Valid;
        _ = this.DidYouMean;
    }

    public ResultsItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResultsItem (ResultsItem resultsItem) : base(resultsItem)
    {  }
    #pragma warning restore CS8618

    public ResultsItem (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultsItem (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResultsItemFromRaw.FromRawUnchecked"/>
    public static ResultsItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResultsItemFromRaw : IFromRawJson<ResultsItem>
{
    /// <inheritdoc/>
    public ResultsItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ResultsItem.FromRawUnchecked(rawData);
}