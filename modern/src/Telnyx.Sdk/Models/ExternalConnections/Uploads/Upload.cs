using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ExternalConnections.Uploads;

[JsonConverter(typeof(JsonModelConverter<Upload, UploadFromRaw>))]
public sealed record class Upload : JsonModel
{
    public IReadOnlyList<ApiEnum<string, AvailableUsage>>? AvailableUsages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, AvailableUsage>>>(
                "available_usages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, AvailableUsage>>?>(
                "available_usages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A code returned by Microsoft Teams if there is an error with the upload process.
    /// </summary>
    public string? ErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_code", value);
        }
    }

    /// <summary>
    /// A message set if there is an error with the upload process.
    /// </summary>
    public string? ErrorMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_message", value);
        }
    }

    public string? LocationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "location_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location_id", value);
        }
    }

    /// <summary>
    /// Represents the status of the upload on Microsoft Teams.
    /// </summary>
    public ApiEnum<string, UploadStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UploadStatus>>(
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

    public string? TenantID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tenant_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tenant_id", value);
        }
    }

    /// <summary>
    /// Uniquely identifies the resource.
    /// </summary>
    public string? TicketID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ticket_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ticket_id", value);
        }
    }

    public IReadOnlyList<TnUploadEntry>? TnUploadEntries {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TnUploadEntry>>(
                "tn_upload_entries"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TnUploadEntry>?>(
                "tn_upload_entries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AvailableUsages ?? [])
        {
            item.Validate();
        }
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.LocationID;
        this.Status?.Validate();
        _ = this.TenantID;
        _ = this.TicketID;
        foreach (var item in this.TnUploadEntries ?? [])
        {
            item.Validate();
        }
    }

    public Upload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Upload (Upload upload) : base(upload)
    {  }
    #pragma warning restore CS8618

    public Upload (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Upload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UploadFromRaw.FromRawUnchecked"/>
    public static Upload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UploadFromRaw : IFromRawJson<Upload>
{
    /// <inheritdoc/>
    public Upload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Upload.FromRawUnchecked(rawData);
}

/// <summary>
/// Available usages for the numbers in the upload on Microsoft Teams.
/// </summary>
[JsonConverter(typeof(AvailableUsageConverter))]
public enum AvailableUsage
{
    CallingUserAssignment, FirstPartyAppAssignment
}sealed class AvailableUsageConverter : JsonConverter<AvailableUsage>
{
    public override AvailableUsage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "calling_user_assignment"=>AvailableUsage.CallingUserAssignment,
            "first_party_app_assignment"=>AvailableUsage.FirstPartyAppAssignment,
            _ =>(AvailableUsage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AvailableUsage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AvailableUsage.CallingUserAssignment=>"calling_user_assignment",
            AvailableUsage.FirstPartyAppAssignment=>"first_party_app_assignment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Represents the status of the upload on Microsoft Teams.
/// </summary>
[JsonConverter(typeof(UploadStatusConverter))]
public enum UploadStatus
{
    PendingUpload, Pending, InProgress, PartialSuccess, Success, Error
}sealed class UploadStatusConverter : JsonConverter<UploadStatus>
{
    public override UploadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_upload"=>UploadStatus.PendingUpload,
            "pending"=>UploadStatus.Pending,
            "in_progress"=>UploadStatus.InProgress,
            "partial_success"=>UploadStatus.PartialSuccess,
            "success"=>UploadStatus.Success,
            "error"=>UploadStatus.Error,
            _ =>(UploadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, UploadStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UploadStatus.PendingUpload=>"pending_upload",
            UploadStatus.Pending=>"pending",
            UploadStatus.InProgress=>"in_progress",
            UploadStatus.PartialSuccess=>"partial_success",
            UploadStatus.Success=>"success",
            UploadStatus.Error=>"error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}