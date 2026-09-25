using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir.VerifyEmail;

/// <summary>
/// Verification state for a DIR's authorizer email.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailVerificationStatus, EmailVerificationStatusFromRaw>))]
public sealed record class EmailVerificationStatus : JsonModel
{
    /// <summary>
    /// Whether the DIR's authorizer email has been confirmed.
    /// </summary>
    public required bool EmailVerified {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "email_verified"
            );
        }
        init { this._rawData.Set("email_verified", value); }
    }

    /// <summary>
    /// Always `email_verification`.
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

    /// <summary>
    /// `sent` after a code is emailed; `verified` after a successful confirm; `unverified`
    /// when no verification is in progress.
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

    /// <summary>
    /// When the outstanding code stops being accepted. Null when no verification
    /// is in progress.
    /// </summary>
    public System::DateTimeOffset? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "expires_at"
            );
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// How many more codes may be requested for this DIR today. Null when the daily
    /// cap does not apply.
    /// </summary>
    public long? SendsRemainingToday {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "sends_remaining_today"
            );
        }
        init { this._rawData.Set("sends_remaining_today", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EmailVerified;
        this.RecordType.Validate();
        this.Status.Validate();
        _ = this.ExpiresAt;
        _ = this.SendsRemainingToday;
    }

    public EmailVerificationStatus ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailVerificationStatus (
        EmailVerificationStatus emailVerificationStatus
    ) : base(emailVerificationStatus)
    {  }
    #pragma warning restore CS8618

    public EmailVerificationStatus (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailVerificationStatus (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailVerificationStatusFromRaw.FromRawUnchecked"/>
    public static EmailVerificationStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailVerificationStatusFromRaw : IFromRawJson<EmailVerificationStatus>
{
    /// <inheritdoc/>
    public EmailVerificationStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailVerificationStatus.FromRawUnchecked(rawData);
}

/// <summary>
/// Always `email_verification`.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailVerification
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
            "email_verification"=>RecordType.EmailVerification,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailVerification=>"email_verification",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// `sent` after a code is emailed; `verified` after a successful confirm; `unverified`
/// when no verification is in progress.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Sent, Verified, Unverified
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
            "sent"=>Status.Sent,
            "verified"=>Status.Verified,
            "unverified"=>Status.Unverified,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Sent=>"sent",
            Status.Verified=>"verified",
            Status.Unverified=>"unverified",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}