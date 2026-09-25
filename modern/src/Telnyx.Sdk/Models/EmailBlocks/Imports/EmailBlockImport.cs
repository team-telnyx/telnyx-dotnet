using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailBlocks.Imports;

/// <summary>
/// Import job. Schema fields hidden: `account_id`, `csv_content`, `block_ttl_days`.
/// Nullable fields use the omit-nullable pattern.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailBlockImport, EmailBlockImportFromRaw>))]
public sealed record class EmailBlockImport : JsonModel
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

    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// View-only.
    /// </summary>
    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Data-row count at upload.
    /// </summary>
    public required long Total {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total"
            );
        }
        init { this._rawData.Set("total", value); }
    }

    public required System::DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Omitted until terminal success.
    /// </summary>
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
    /// Only when `status == completed`.
    /// </summary>
    public long? CreatedCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "created_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_count", value);
        }
    }

    /// <summary>
    /// Rows that passed CSV parsing but failed suppression creation. This is the
    /// creation-failure subset of `skipped_count`; parser-rejected rows equal `skipped_count
    /// - error_count`. Only when `status == completed`.
    /// </summary>
    public long? ErrorCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "error_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_count", value);
        }
    }

    /// <summary>
    /// `{row_number: reason}`; only rendered when non-empty.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "errors",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Only when `status == completed`.
    /// </summary>
    public long? ExistingCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "existing_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("existing_count", value);
        }
    }

    /// <summary>
    /// Only on terminal failure.
    /// </summary>
    public string? FailureReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failure_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failure_reason", value);
        }
    }

    /// <summary>
    /// Only when `status == completed`.
    /// </summary>
    public long? ProcessedRows {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "processed_rows"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("processed_rows", value);
        }
    }

    /// <summary>
    /// Omitted when nil.
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
    /// Only when `status == completed`.
    /// </summary>
    public long? SkippedCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "skipped_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("skipped_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.RecordType.Validate();
        this.Status.Validate();
        _ = this.Total;
        _ = this.UpdatedAt;
        _ = this.CompletedAt;
        _ = this.CreatedCount;
        _ = this.ErrorCount;
        _ = this.Errors;
        _ = this.ExistingCount;
        _ = this.FailureReason;
        _ = this.ProcessedRows;
        this.Provider?.Validate();
        _ = this.SkippedCount;
    }

    public EmailBlockImport ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlockImport (EmailBlockImport emailBlockImport) : base(
        emailBlockImport
    )
    {  }
    #pragma warning restore CS8618

    public EmailBlockImport (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlockImport (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailBlockImportFromRaw.FromRawUnchecked"/>
    public static EmailBlockImport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailBlockImportFromRaw : IFromRawJson<EmailBlockImport>
{
    /// <inheritdoc/>
    public EmailBlockImport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailBlockImport.FromRawUnchecked(rawData);
}

/// <summary>
/// View-only.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailBlockImport
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_block_import"=>RecordType.EmailBlockImport,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailBlockImport=>"email_block_import",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Processing, Completed, Failed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>Status.Pending,
            "processing"=>Status.Processing,
            "completed"=>Status.Completed,
            "failed"=>Status.Failed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Processing=>"processing",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Omitted when nil.
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Sendgrid, Mailgun, Ses, Generic
}sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sendgrid"=>Provider.Sendgrid,
            "mailgun"=>Provider.Mailgun,
            "ses"=>Provider.Ses,
            "generic"=>Provider.Generic,
            _ =>(Provider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Provider value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Provider.Sendgrid=>"sendgrid",
            Provider.Mailgun=>"mailgun",
            Provider.Ses=>"ses",
            Provider.Generic=>"generic",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}