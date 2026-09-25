using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumberBlocks.Jobs;

[JsonConverter(typeof(JsonModelConverter<Job, JobFromRaw>))]
public sealed record class Job : JsonModel
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
    /// Indicates the completion status of the background operation.
    /// </summary>
    public ApiEnum<string, JobStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, JobStatus>>(
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
    public ApiEnum<string, JobType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, JobType>>(
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
        _ = this.RecordType;
        this.Status?.Validate();
        foreach (var item in this.SuccessfulOperations ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public Job ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Job (Job job) : base(job)
    {  }
    #pragma warning restore CS8618

    public Job (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Job (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="JobFromRaw.FromRawUnchecked"/>
    public static Job FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class JobFromRaw : IFromRawJson<Job>
{
    /// <inheritdoc/>
    public Job FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Job.FromRawUnchecked(rawData);
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

    public IReadOnlyList<JobError>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JobError>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<JobError>?>(
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
/// Indicates the completion status of the background operation.
/// </summary>
[JsonConverter(typeof(JobStatusConverter))]
public enum JobStatus
{
    Pending, InProgress, Completed, Failed
}sealed class JobStatusConverter : JsonConverter<JobStatus>
{
    public override JobStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>JobStatus.Pending,
            "in_progress"=>JobStatus.InProgress,
            "completed"=>JobStatus.Completed,
            "failed"=>JobStatus.Failed,
            _ =>(JobStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, JobStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            JobStatus.Pending=>"pending",
            JobStatus.InProgress=>"in_progress",
            JobStatus.Completed=>"completed",
            JobStatus.Failed=>"failed",
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
[JsonConverter(typeof(JobTypeConverter))]
public enum JobType
{
    DeletePhoneNumberBlock
}sealed class JobTypeConverter : JsonConverter<JobType>
{
    public override JobType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delete_phone_number_block"=>JobType.DeletePhoneNumberBlock,
            _ =>(JobType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, JobType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            JobType.DeletePhoneNumberBlock=>"delete_phone_number_block",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}