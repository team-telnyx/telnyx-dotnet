using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NumberReservations;

[JsonConverter(typeof(JsonModelConverter<ReservedPhoneNumber, ReservedPhoneNumberFromRaw>))]
public sealed record class ReservedPhoneNumber : JsonModel
{
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
    /// An ISO 8901 datetime string denoting when the individual number reservation
    /// was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// Errors the reservation could happen upon
    /// </summary>
    public string? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("errors", value);
        }
    }

    /// <summary>
    /// An ISO 8901 datetime string for when the individual number reservation is
    /// going to expire
    /// </summary>
    public System::DateTimeOffset? ExpiredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "expired_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expired_at", value);
        }
    }

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
    /// The status of the phone number's reservation.
    /// </summary>
    public ApiEnum<string, ReservedPhoneNumberStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ReservedPhoneNumberStatus>>(
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

    /// <summary>
    /// An ISO 8901 datetime string for when the the individual number reservation
    /// was updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
        _ = this.Errors;
        _ = this.ExpiredAt;
        _ = this.PhoneNumber;
        _ = this.RecordType;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public ReservedPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReservedPhoneNumber (ReservedPhoneNumber reservedPhoneNumber) : base(
        reservedPhoneNumber
    )
    {  }
    #pragma warning restore CS8618

    public ReservedPhoneNumber (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReservedPhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReservedPhoneNumberFromRaw.FromRawUnchecked"/>
    public static ReservedPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReservedPhoneNumberFromRaw : IFromRawJson<ReservedPhoneNumber>
{
    /// <inheritdoc/>
    public ReservedPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReservedPhoneNumber.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the phone number's reservation.
/// </summary>
[JsonConverter(typeof(ReservedPhoneNumberStatusConverter))]
public enum ReservedPhoneNumberStatus
{
    Pending, Success, Failure
}sealed class ReservedPhoneNumberStatusConverter : JsonConverter<ReservedPhoneNumberStatus>
{
    public override ReservedPhoneNumberStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>ReservedPhoneNumberStatus.Pending,
            "success"=>ReservedPhoneNumberStatus.Success,
            "failure"=>ReservedPhoneNumberStatus.Failure,
            _ =>(ReservedPhoneNumberStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReservedPhoneNumberStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ReservedPhoneNumberStatus.Pending=>"pending",
            ReservedPhoneNumberStatus.Success=>"success",
            ReservedPhoneNumberStatus.Failure=>"failure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}