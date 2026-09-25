using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberAssignmentByProfileRetrieveStatusResponse, PhoneNumberAssignmentByProfileRetrieveStatusResponseFromRaw>))]
public sealed record class PhoneNumberAssignmentByProfileRetrieveStatusResponse : JsonModel
{
    /// <summary>
    /// An enumeration.
    /// </summary>
    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string TaskID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "taskId"
            );
        }
        init { this._rawData.Set("taskId", value); }
    }

    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "createdAt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updatedAt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.TaskID;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public PhoneNumberAssignmentByProfileRetrieveStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberAssignmentByProfileRetrieveStatusResponse (
        PhoneNumberAssignmentByProfileRetrieveStatusResponse phoneNumberAssignmentByProfileRetrieveStatusResponse
    ) : base(phoneNumberAssignmentByProfileRetrieveStatusResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberAssignmentByProfileRetrieveStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberAssignmentByProfileRetrieveStatusResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberAssignmentByProfileRetrieveStatusResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberAssignmentByProfileRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberAssignmentByProfileRetrieveStatusResponseFromRaw : IFromRawJson<PhoneNumberAssignmentByProfileRetrieveStatusResponse>
{
    /// <inheritdoc/>
    public PhoneNumberAssignmentByProfileRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberAssignmentByProfileRetrieveStatusResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An enumeration.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
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
}