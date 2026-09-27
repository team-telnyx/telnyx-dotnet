using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailMessages.Recipients;

[JsonConverter(typeof(JsonModelConverter<EmailRecipient, EmailRecipientFromRaw>))]
public sealed record class EmailRecipient : JsonModel
{
    /// <summary>
    /// Recipient UUID.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Recipient email address. Null for BCC recipients (redacted for privacy).
    /// </summary>
    public required string? Address {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address"
            );
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// Whether this recipient's delivery is billable (set on queue acceptance).
    /// </summary>
    public required bool Billable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "billable"
            );
        }
        init { this._rawData.Set("billable", value); }
    }

    public required ApiEnum<string, EmailRecipientKind> Kind {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailRecipientKind>>(
                "kind"
            );
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// Parent email message UUID.
    /// </summary>
    public required string MessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "message_id"
            );
        }
        init { this._rawData.Set("message_id", value); }
    }

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
    /// Current per-recipient delivery status.
    /// </summary>
    public required ApiEnum<string, EmailRecipientStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailRecipientStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public System::DateTimeOffset? DeliveredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "delivered_at"
            );
        }
        init { this._rawData.Set("delivered_at", value); }
    }

    public System::DateTimeOffset? FailedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "failed_at"
            );
        }
        init { this._rawData.Set("failed_at", value); }
    }

    public System::DateTimeOffset? SentAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "sent_at"
            );
        }
        init { this._rawData.Set("sent_at", value); }
    }

    /// <summary>
    /// SMTP response code when available (e.g. 550 for bounces).
    /// </summary>
    public long? SmtpCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "smtp_code"
            );
        }
        init { this._rawData.Set("smtp_code", value); }
    }

    /// <summary>
    /// SMTP response message when available.
    /// </summary>
    public string? SmtpResponse {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "smtp_response"
            );
        }
        init { this._rawData.Set("smtp_response", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Address;
        _ = this.Billable;
        this.Kind.Validate();
        _ = this.MessageID;
        this.RecordType.Validate();
        this.Status.Validate();
        _ = this.DeliveredAt;
        _ = this.FailedAt;
        _ = this.SentAt;
        _ = this.SmtpCode;
        _ = this.SmtpResponse;
    }

    public EmailRecipient ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailRecipient (EmailRecipient emailRecipient) : base(emailRecipient)
    {  }
    #pragma warning restore CS8618

    public EmailRecipient (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailRecipient (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailRecipientFromRaw.FromRawUnchecked"/>
    public static EmailRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailRecipientFromRaw : IFromRawJson<EmailRecipient>
{
    /// <inheritdoc/>
    public EmailRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailRecipient.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EmailRecipientKindConverter))]
public enum EmailRecipientKind
{
    To, Cc, Bcc
}sealed class EmailRecipientKindConverter : JsonConverter<EmailRecipientKind>
{
    public override EmailRecipientKind Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "to"=>EmailRecipientKind.To,
            "cc"=>EmailRecipientKind.Cc,
            "bcc"=>EmailRecipientKind.Bcc,
            _ =>(EmailRecipientKind)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailRecipientKind value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailRecipientKind.To=>"to",
            EmailRecipientKind.Cc=>"cc",
            EmailRecipientKind.Bcc=>"bcc",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailRecipient
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "email_recipient"=>RecordType.EmailRecipient, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailRecipient=>"email_recipient",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Current per-recipient delivery status.
/// </summary>
[JsonConverter(typeof(EmailRecipientStatusConverter))]
public enum EmailRecipientStatus
{
    Queued,
    Sending,
    Sent,
    Deferred,
    Delivered,
    Bounced,
    Failed,
    GwReject,
    Cancelled,
    InjectionTimeout,
    Expired
}sealed class EmailRecipientStatusConverter : JsonConverter<EmailRecipientStatus>
{
    public override EmailRecipientStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>EmailRecipientStatus.Queued,
            "sending"=>EmailRecipientStatus.Sending,
            "sent"=>EmailRecipientStatus.Sent,
            "deferred"=>EmailRecipientStatus.Deferred,
            "delivered"=>EmailRecipientStatus.Delivered,
            "bounced"=>EmailRecipientStatus.Bounced,
            "failed"=>EmailRecipientStatus.Failed,
            "gw_reject"=>EmailRecipientStatus.GwReject,
            "cancelled"=>EmailRecipientStatus.Cancelled,
            "injection_timeout"=>EmailRecipientStatus.InjectionTimeout,
            "expired"=>EmailRecipientStatus.Expired,
            _ =>(EmailRecipientStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailRecipientStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailRecipientStatus.Queued=>"queued",
            EmailRecipientStatus.Sending=>"sending",
            EmailRecipientStatus.Sent=>"sent",
            EmailRecipientStatus.Deferred=>"deferred",
            EmailRecipientStatus.Delivered=>"delivered",
            EmailRecipientStatus.Bounced=>"bounced",
            EmailRecipientStatus.Failed=>"failed",
            EmailRecipientStatus.GwReject=>"gw_reject",
            EmailRecipientStatus.Cancelled=>"cancelled",
            EmailRecipientStatus.InjectionTimeout=>"injection_timeout",
            EmailRecipientStatus.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}