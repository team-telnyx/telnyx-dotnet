using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Verifications;

[JsonConverter(typeof(JsonModelConverter<Verification, VerificationFromRaw>))]
public sealed record class Verification : JsonModel
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
    /// Send a self-generated numeric code to the end-user
    /// </summary>
    public string? CustomCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "custom_code"
            );
        }
        init { this._rawData.Set("custom_code", value); }
    }

    /// <summary>
    /// +E164 formatted phone number.
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
    /// The possible verification record types.
    /// </summary>
    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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
    /// The possible statuses of the verification request.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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
    /// This is the number of seconds before the code of the request is expired.
    /// Once this request has expired, the code will no longer verify the user. Note:
    /// this will override the `default_verification_timeout_secs` on the Verify profile.
    /// </summary>
    public long? TimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timeout_secs", value);
        }
    }

    /// <summary>
    /// The possible types of verification.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.Verifications.Type>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.Verifications.Type>>(
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

    /// <summary>
    /// The identifier of the associated Verify profile.
    /// </summary>
    public string? VerifyProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "verify_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verify_profile_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CustomCode;
        _ = this.PhoneNumber;
        this.RecordType?.Validate();
        this.Status?.Validate();
        _ = this.TimeoutSecs;
        this.Type?.Validate();
        _ = this.UpdatedAt;
        _ = this.VerifyProfileID;
    }

    public Verification ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Verification (Verification verification) : base(verification)
    {  }
    #pragma warning restore CS8618

    public Verification (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Verification (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerificationFromRaw.FromRawUnchecked"/>
    public static Verification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerificationFromRaw : IFromRawJson<Verification>
{
    /// <inheritdoc/>
    public Verification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Verification.FromRawUnchecked(rawData);
}

/// <summary>
/// The possible verification record types.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Verification
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "verification"=>RecordType.Verification, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Verification=>"verification",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The possible statuses of the verification request.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Accepted, Invalid, Expired, Error
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
            "accepted"=>Status.Accepted,
            "invalid"=>Status.Invalid,
            "expired"=>Status.Expired,
            "error"=>Status.Error,
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
            Status.Accepted=>"accepted",
            Status.Invalid=>"invalid",
            Status.Expired=>"expired",
            Status.Error=>"error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The possible types of verification.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Sms, Call, Flashcall, Whatsapp
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.Verifications.Type>
{
    public override global::Telnyx.Sdk.Models.Verifications.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms"=>global::Telnyx.Sdk.Models.Verifications.Type.Sms,
            "call"=>global::Telnyx.Sdk.Models.Verifications.Type.Call,
            "flashcall"=>global::Telnyx.Sdk.Models.Verifications.Type.Flashcall,
            "whatsapp"=>global::Telnyx.Sdk.Models.Verifications.Type.Whatsapp,
            _ =>(global::Telnyx.Sdk.Models.Verifications.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Verifications.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Verifications.Type.Sms=>"sms",
            global::Telnyx.Sdk.Models.Verifications.Type.Call=>"call",
            global::Telnyx.Sdk.Models.Verifications.Type.Flashcall=>"flashcall",
            global::Telnyx.Sdk.Models.Verifications.Type.Whatsapp=>"whatsapp",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}