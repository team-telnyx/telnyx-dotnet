using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Jobs = Telnyx.Sdk.Models.PhoneNumberBlocks.Jobs;

namespace Telnyx.Sdk.Models.PhoneNumbers.Jobs;

[JsonConverter(typeof(JsonModelConverter<PhoneNumbersJob, PhoneNumbersJobFromRaw>))]
public sealed record class PhoneNumbersJob : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the estimated time of completion of
    /// the background job.
    /// </summary>
    public System::DateTimeOffset? Etc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "etc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("etc", value);
        }
    }

    public IReadOnlyList<FailedOperation>? FailedOperations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FailedOperation>>(
                "failed_operations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FailedOperation>?>(
                "failed_operations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<PendingOperation>? PendingOperations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PendingOperation>>(
                "pending_operations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PendingOperation>?>(
                "pending_operations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<PhoneNumbersJobPhoneNumber>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PhoneNumbersJobPhoneNumber>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PhoneNumbersJobPhoneNumber>?>(
                "phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    /// <summary>
    /// Indicates the completion status of the background update.
    /// </summary>
    public ApiEnum<string, PhoneNumbersJobStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumbersJobStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public IReadOnlyList<SuccessfulOperation>? SuccessfulOperations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SuccessfulOperation>>(
                "successful_operations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SuccessfulOperation>?>(
                "successful_operations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Identifies the type of the background job.
    /// </summary>
    public ApiEnum<string, PhoneNumbersJobType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumbersJobType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Etc;
        foreach (var item in this.FailedOperations ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PendingOperations ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PhoneNumbers ?? [])
        {
            item.Validate();
        }
        _ = this.RecordType;
        this.Status?.Validate();
        foreach (var item in this.SuccessfulOperations ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public PhoneNumbersJob ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumbersJob (PhoneNumbersJob phoneNumbersJob) : base(
        phoneNumbersJob
    )
    {  }
    #pragma warning restore CS8618

    public PhoneNumbersJob (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumbersJob (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumbersJobFromRaw.FromRawUnchecked"/>
    public static PhoneNumbersJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumbersJobFromRaw : IFromRawJson<PhoneNumbersJob>
{
    /// <inheritdoc/>
    public PhoneNumbersJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumbersJob.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FailedOperation, FailedOperationFromRaw>))]
public sealed record class FailedOperation : JsonModel
{
    /// <summary>
    /// The phone number's ID
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

    public IReadOnlyList<Jobs::JobError>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Jobs::JobError>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Jobs::JobError>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The phone number in e164 format.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Errors ?? [])
        {
            item.Validate();
        }
        _ = this.PhoneNumber;
    }

    public FailedOperation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FailedOperation (FailedOperation failedOperation) : base(
        failedOperation
    )
    {  }
    #pragma warning restore CS8618

    public FailedOperation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FailedOperation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FailedOperationFromRaw.FromRawUnchecked"/>
    public static FailedOperation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FailedOperationFromRaw : IFromRawJson<FailedOperation>
{
    /// <inheritdoc/>
    public FailedOperation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FailedOperation.FromRawUnchecked(rawData);
}/// <summary>
/// The phone numbers pending confirmation on update results. Entries in this list
/// are transient, and will be moved to either successful_operations or failed_operations
/// once the processing is done.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PendingOperation, PendingOperationFromRaw>))]
public sealed record class PendingOperation : JsonModel
{
    /// <summary>
    /// The phone number's ID
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

    /// <summary>
    /// The phone number in e164 format.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.PhoneNumber;
    }

    public PendingOperation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PendingOperation (PendingOperation pendingOperation) : base(
        pendingOperation
    )
    {  }
    #pragma warning restore CS8618

    public PendingOperation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PendingOperation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PendingOperationFromRaw.FromRawUnchecked"/>
    public static PendingOperation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PendingOperationFromRaw : IFromRawJson<PendingOperation>
{
    /// <inheritdoc/>
    public PendingOperation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PendingOperation.FromRawUnchecked(rawData);
}/// <summary>
/// Indicates the completion status of the background update.
/// </summary>
[JsonConverter(typeof(PhoneNumbersJobStatusConverter))]
public enum PhoneNumbersJobStatus
{
    Pending, InProgress, Completed, Failed, Expired
}sealed class PhoneNumbersJobStatusConverter : JsonConverter<PhoneNumbersJobStatus>
{
    public override PhoneNumbersJobStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>PhoneNumbersJobStatus.Pending,
            "in_progress"=>PhoneNumbersJobStatus.InProgress,
            "completed"=>PhoneNumbersJobStatus.Completed,
            "failed"=>PhoneNumbersJobStatus.Failed,
            "expired"=>PhoneNumbersJobStatus.Expired,
            _ =>(PhoneNumbersJobStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumbersJobStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumbersJobStatus.Pending=>"pending",
            PhoneNumbersJobStatus.InProgress=>"in_progress",
            PhoneNumbersJobStatus.Completed=>"completed",
            PhoneNumbersJobStatus.Failed=>"failed",
            PhoneNumbersJobStatus.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The phone numbers successfully updated.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SuccessfulOperation, SuccessfulOperationFromRaw>))]
public sealed record class SuccessfulOperation : JsonModel
{
    /// <summary>
    /// The phone number's ID
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

    /// <summary>
    /// The phone number in e164 format.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.PhoneNumber;
    }

    public SuccessfulOperation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SuccessfulOperation (SuccessfulOperation successfulOperation) : base(
        successfulOperation
    )
    {  }
    #pragma warning restore CS8618

    public SuccessfulOperation (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SuccessfulOperation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SuccessfulOperationFromRaw.FromRawUnchecked"/>
    public static SuccessfulOperation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SuccessfulOperationFromRaw : IFromRawJson<SuccessfulOperation>
{
    /// <inheritdoc/>
    public SuccessfulOperation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SuccessfulOperation.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the background job.
/// </summary>
[JsonConverter(typeof(PhoneNumbersJobTypeConverter))]
public enum PhoneNumbersJobType
{
    UpdateEmergencySettings, DeletePhoneNumbers, UpdatePhoneNumbers
}sealed class PhoneNumbersJobTypeConverter : JsonConverter<PhoneNumbersJobType>
{
    public override PhoneNumbersJobType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "update_emergency_settings"=>PhoneNumbersJobType.UpdateEmergencySettings,
            "delete_phone_numbers"=>PhoneNumbersJobType.DeletePhoneNumbers,
            "update_phone_numbers"=>PhoneNumbersJobType.UpdatePhoneNumbers,
            _ =>(PhoneNumbersJobType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumbersJobType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumbersJobType.UpdateEmergencySettings=>"update_emergency_settings",
            PhoneNumbersJobType.DeletePhoneNumbers=>"delete_phone_numbers",
            PhoneNumbersJobType.UpdatePhoneNumbers=>"update_phone_numbers",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}