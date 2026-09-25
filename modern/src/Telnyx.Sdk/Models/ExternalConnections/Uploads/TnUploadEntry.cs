using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ExternalConnections.Uploads;

[JsonConverter(typeof(JsonModelConverter<TnUploadEntry, TnUploadEntryFromRaw>))]
public sealed record class TnUploadEntry : JsonModel
{
    /// <summary>
    /// Identifies the civic address assigned to the phone number entry.
    /// </summary>
    public string? CivicAddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "civic_address_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("civic_address_id", value);
        }
    }

    /// <summary>
    /// A code returned by Microsoft Teams if there is an error with the phone number
    /// entry upload.
    /// </summary>
    public ApiEnum<string, ErrorCode>? ErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ErrorCode>>(
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
    /// A message returned by Microsoft Teams if there is an error with the upload process.
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

    /// <summary>
    /// Represents the status of the phone number entry upload on Telnyx.
    /// </summary>
    public ApiEnum<string, InternalStatus>? InternalStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InternalStatus>>(
                "internal_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("internal_status", value);
        }
    }

    /// <summary>
    /// Identifies the location assigned to the phone number entry.
    /// </summary>
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
    /// Uniquely identifies the resource.
    /// </summary>
    public string? NumberID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "number_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_id", value);
        }
    }

    /// <summary>
    /// Phone number in E164 format.
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

    /// <summary>
    /// Represents the status of the phone number entry upload on Microsoft Teams.
    /// </summary>
    public ApiEnum<string, TnUploadEntryStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TnUploadEntryStatus>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CivicAddressID;
        this.ErrorCode?.Validate();
        _ = this.ErrorMessage;
        this.InternalStatus?.Validate();
        _ = this.LocationID;
        _ = this.NumberID;
        _ = this.PhoneNumber;
        this.Status?.Validate();
    }

    public TnUploadEntry ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TnUploadEntry (TnUploadEntry tnUploadEntry) : base(tnUploadEntry)
    {  }
    #pragma warning restore CS8618

    public TnUploadEntry (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TnUploadEntry (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TnUploadEntryFromRaw.FromRawUnchecked"/>
    public static TnUploadEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TnUploadEntryFromRaw : IFromRawJson<TnUploadEntry>
{
    /// <inheritdoc/>
    public TnUploadEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TnUploadEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// A code returned by Microsoft Teams if there is an error with the phone number
/// entry upload.
/// </summary>
[JsonConverter(typeof(ErrorCodeConverter))]
public enum ErrorCode
{
    InternalError,
    UnableToRetrieveDefaultLocation,
    UnknownCountryCode,
    UnableToRetrieveLocation,
    UnableToRetrievePartnerInfo,
    UnableToMatchGeographyEntry
}sealed class ErrorCodeConverter : JsonConverter<ErrorCode>
{
    public override ErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal_error"=>ErrorCode.InternalError,
            "unable_to_retrieve_default_location"=>ErrorCode.UnableToRetrieveDefaultLocation,
            "unknown_country_code"=>ErrorCode.UnknownCountryCode,
            "unable_to_retrieve_location"=>ErrorCode.UnableToRetrieveLocation,
            "unable_to_retrieve_partner_info"=>ErrorCode.UnableToRetrievePartnerInfo,
            "unable_to_match_geography_entry"=>ErrorCode.UnableToMatchGeographyEntry,
            _ =>(ErrorCode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ErrorCode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ErrorCode.InternalError=>"internal_error",
            ErrorCode.UnableToRetrieveDefaultLocation=>"unable_to_retrieve_default_location",
            ErrorCode.UnknownCountryCode=>"unknown_country_code",
            ErrorCode.UnableToRetrieveLocation=>"unable_to_retrieve_location",
            ErrorCode.UnableToRetrievePartnerInfo=>"unable_to_retrieve_partner_info",
            ErrorCode.UnableToMatchGeographyEntry=>"unable_to_match_geography_entry",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Represents the status of the phone number entry upload on Telnyx.
/// </summary>
[JsonConverter(typeof(InternalStatusConverter))]
public enum InternalStatus
{
    PendingAssignment,
    InProgress,
    AllInternalJobsCompleted,
    ReleaseRequested,
    ReleaseCompleted,
    Error
}sealed class InternalStatusConverter : JsonConverter<InternalStatus>
{
    public override InternalStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_assignment"=>InternalStatus.PendingAssignment,
            "in_progress"=>InternalStatus.InProgress,
            "all_internal_jobs_completed"=>InternalStatus.AllInternalJobsCompleted,
            "release_requested"=>InternalStatus.ReleaseRequested,
            "release_completed"=>InternalStatus.ReleaseCompleted,
            "error"=>InternalStatus.Error,
            _ =>(InternalStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InternalStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InternalStatus.PendingAssignment=>"pending_assignment",
            InternalStatus.InProgress=>"in_progress",
            InternalStatus.AllInternalJobsCompleted=>"all_internal_jobs_completed",
            InternalStatus.ReleaseRequested=>"release_requested",
            InternalStatus.ReleaseCompleted=>"release_completed",
            InternalStatus.Error=>"error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Represents the status of the phone number entry upload on Microsoft Teams.
/// </summary>
[JsonConverter(typeof(TnUploadEntryStatusConverter))]
public enum TnUploadEntryStatus
{
    PendingUpload, Pending, InProgress, Success, Error
}sealed class TnUploadEntryStatusConverter : JsonConverter<TnUploadEntryStatus>
{
    public override TnUploadEntryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_upload"=>TnUploadEntryStatus.PendingUpload,
            "pending"=>TnUploadEntryStatus.Pending,
            "in_progress"=>TnUploadEntryStatus.InProgress,
            "success"=>TnUploadEntryStatus.Success,
            "error"=>TnUploadEntryStatus.Error,
            _ =>(TnUploadEntryStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TnUploadEntryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TnUploadEntryStatus.PendingUpload=>"pending_upload",
            TnUploadEntryStatus.Pending=>"pending",
            TnUploadEntryStatus.InProgress=>"in_progress",
            TnUploadEntryStatus.Success=>"success",
            TnUploadEntryStatus.Error=>"error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}