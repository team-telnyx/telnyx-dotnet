using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageCancelScheduledResponse, MessageCancelScheduledResponseFromRaw>))]
public sealed record class MessageCancelScheduledResponse : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
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

    public IReadOnlyList<MessageCancelScheduledResponseCc>? Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessageCancelScheduledResponseCc>>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessageCancelScheduledResponseCc>?>(
                "cc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the message was finalized.
    /// </summary>
    public System::DateTimeOffset? CompletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "completed_at"
            );
        }
        init { this._rawData.Set("completed_at", value); }
    }

    public MessageCancelScheduledResponseCost? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageCancelScheduledResponseCost>(
                "cost"
            );
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Detailed breakdown of the message cost components.
    /// </summary>
    public MessageCancelScheduledResponseCostBreakdown? CostBreakdown {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageCancelScheduledResponseCostBreakdown>(
                "cost_breakdown"
            );
        }
        init { this._rawData.Set("cost_breakdown", value); }
    }

    /// <summary>
    /// The direction of the message. Inbound messages are sent to you whereas outbound
    /// messages are sent from you.
    /// </summary>
    public ApiEnum<string, MessageCancelScheduledResponseDirection>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageCancelScheduledResponseDirection>>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    /// <summary>
    /// Encoding scheme used for the message body.
    /// </summary>
    public string? Encoding {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "encoding"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("encoding", value);
        }
    }

    /// <summary>
    /// These errors may point at addressees when referring to unsuccessful/unconfirmed
    /// delivery statuses.
    /// </summary>
    public IReadOnlyList<MessagingError0b38e7044b>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessagingError0b38e7044b>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessagingError0b38e7044b>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MessageCancelScheduledResponseFrom? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageCancelScheduledResponseFrom>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    public IReadOnlyList<MessageCancelScheduledResponseMedia>? Media {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessageCancelScheduledResponseMedia>>(
                "media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessageCancelScheduledResponseMedia>?>(
                "media",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Unique identifier for a messaging profile.
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_profile_id", value);
        }
    }

    /// <summary>
    /// The number of characters in the message text
    /// </summary>
    public long? NumChars {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "num_chars"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("num_chars", value);
        }
    }

    /// <summary>
    /// The id of the organization the messaging profile belongs to.
    /// </summary>
    public string? OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_id", value);
        }
    }

    /// <summary>
    /// Number of parts into which the message's body must be split.
    /// </summary>
    public long? Parts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "parts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("parts", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the message request was received.
    /// </summary>
    public System::DateTimeOffset? ReceivedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "received_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("received_at", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, MessageCancelScheduledResponseRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageCancelScheduledResponseRecordType>>(
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
    /// ISO 8601 formatted date indicating when the message was sent.
    /// </summary>
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
    /// Indicates whether smart encoding was applied to this message. When `true`,
    /// one or more Unicode characters were automatically replaced with GSM-7 equivalents
    /// to reduce segment count and cost. The original message text is preserved
    /// in webhooks.
    /// </summary>
    public bool? SmartEncodingApplied {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "smart_encoding_applied"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("smart_encoding_applied", value);
        }
    }

    /// <summary>
    /// Subject of multimedia message
    /// </summary>
    public string? Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subject"
            );
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <summary>
    /// Tags associated with the resource.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates whether the TCR campaign is billable.
    /// </summary>
    public bool? TcrCampaignBillable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "tcr_campaign_billable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tcr_campaign_billable", value);
        }
    }

    /// <summary>
    /// The Campaign Registry (TCR) campaign ID associated with the message.
    /// </summary>
    public string? TcrCampaignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tcr_campaign_id"
            );
        }
        init { this._rawData.Set("tcr_campaign_id", value); }
    }

    /// <summary>
    /// The registration status of the TCR campaign.
    /// </summary>
    public string? TcrCampaignRegistered {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tcr_campaign_registered"
            );
        }
        init { this._rawData.Set("tcr_campaign_registered", value); }
    }

    /// <summary>
    /// Message body (i.e., content) as a non-empty string.
    ///
    /// <para>**Required for SMS**</para>
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    public IReadOnlyList<MessageCancelScheduledResponseTo>? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessageCancelScheduledResponseTo>>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessageCancelScheduledResponseTo>?>(
                "to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of message.
    /// </summary>
    public ApiEnum<string, MessageCancelScheduledResponseType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageCancelScheduledResponseType>>(
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
    /// Message must be out of the queue by this time or else it will be discarded
    /// and marked as 'sending_failed'. Once the message moves out of the queue,
    /// this field will be nulled
    /// </summary>
    public System::DateTimeOffset? ValidUntil {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "valid_until"
            );
        }
        init { this._rawData.Set("valid_until", value); }
    }

    /// <summary>
    /// The failover URL where webhooks related to this message will be sent if sending
    /// to the primary URL fails.
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_failover_url"
            );
        }
        init { this._rawData.Set("webhook_failover_url", value); }
    }

    /// <summary>
    /// The URL where webhooks related to this message will be sent.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Cc ?? [])
        {
            item.Validate();
        }
        _ = this.CompletedAt;
        this.Cost?.Validate();
        this.CostBreakdown?.Validate();
        this.Direction?.Validate();
        _ = this.Encoding;
        foreach (var item in this.Errors ?? [])
        {
            item.Validate();
        }
        this.From?.Validate();
        foreach (var item in this.Media ?? [])
        {
            item.Validate();
        }
        _ = this.MessagingProfileID;
        _ = this.NumChars;
        _ = this.OrganizationID;
        _ = this.Parts;
        _ = this.ReceivedAt;
        this.RecordType?.Validate();
        _ = this.SentAt;
        _ = this.SmartEncodingApplied;
        _ = this.Subject;
        _ = this.Tags;
        _ = this.TcrCampaignBillable;
        _ = this.TcrCampaignID;
        _ = this.TcrCampaignRegistered;
        _ = this.Text;
        foreach (var item in this.To ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
        _ = this.ValidUntil;
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
    }

    public MessageCancelScheduledResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCancelScheduledResponse (
        MessageCancelScheduledResponse messageCancelScheduledResponse
    ) : base(messageCancelScheduledResponse)
    {  }
    #pragma warning restore CS8618

    public MessageCancelScheduledResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCancelScheduledResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageCancelScheduledResponseFromRaw.FromRawUnchecked"/>
    public static MessageCancelScheduledResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageCancelScheduledResponseFromRaw : IFromRawJson<MessageCancelScheduledResponse>
{
    /// <inheritdoc/>
    public MessageCancelScheduledResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageCancelScheduledResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MessageCancelScheduledResponseCc, MessageCancelScheduledResponseCcFromRaw>))]
public sealed record class MessageCancelScheduledResponseCc : JsonModel
{
    /// <summary>
    /// The carrier of the receiver.
    /// </summary>
    public string? Carrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    /// <summary>
    /// The line-type of the receiver.
    /// </summary>
    public ApiEnum<string, MessageCancelScheduledResponseCcLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageCancelScheduledResponseCcLineType>>(
                "line_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("line_type", value);
        }
    }

    /// <summary>
    /// Receiving address (+E.164 formatted phone number or short code).
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
    /// The delivery status of the message.
    /// </summary>
    public ApiEnum<string, MessageCancelScheduledResponseCcStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageCancelScheduledResponseCcStatus>>(
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
        _ = this.Carrier;
        this.LineType?.Validate();
        _ = this.PhoneNumber;
        this.Status?.Validate();
    }

    public MessageCancelScheduledResponseCc ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCancelScheduledResponseCc (
        MessageCancelScheduledResponseCc messageCancelScheduledResponseCc
    ) : base(messageCancelScheduledResponseCc)
    {  }
    #pragma warning restore CS8618

    public MessageCancelScheduledResponseCc (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCancelScheduledResponseCc (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageCancelScheduledResponseCcFromRaw.FromRawUnchecked"/>
    public static MessageCancelScheduledResponseCc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageCancelScheduledResponseCcFromRaw : IFromRawJson<MessageCancelScheduledResponseCc>
{
    /// <inheritdoc/>
    public MessageCancelScheduledResponseCc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageCancelScheduledResponseCc.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(MessageCancelScheduledResponseCcLineTypeConverter))]
public enum MessageCancelScheduledResponseCcLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class MessageCancelScheduledResponseCcLineTypeConverter : JsonConverter<MessageCancelScheduledResponseCcLineType>
{
    public override MessageCancelScheduledResponseCcLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>MessageCancelScheduledResponseCcLineType.Wireline,
            "Wireless"=>MessageCancelScheduledResponseCcLineType.Wireless,
            "VoWiFi"=>MessageCancelScheduledResponseCcLineType.VoWiFi,
            "VoIP"=>MessageCancelScheduledResponseCcLineType.VoIP,
            "Pre-Paid Wireless"=>MessageCancelScheduledResponseCcLineType.PrePaidWireless,
            ""=>MessageCancelScheduledResponseCcLineType.Undefined,
            _ =>(MessageCancelScheduledResponseCcLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCancelScheduledResponseCcLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageCancelScheduledResponseCcLineType.Wireline=>"Wireline",
            MessageCancelScheduledResponseCcLineType.Wireless=>"Wireless",
            MessageCancelScheduledResponseCcLineType.VoWiFi=>"VoWiFi",
            MessageCancelScheduledResponseCcLineType.VoIP=>"VoIP",
            MessageCancelScheduledResponseCcLineType.PrePaidWireless=>"Pre-Paid Wireless",
            MessageCancelScheduledResponseCcLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The delivery status of the message.
/// </summary>
[JsonConverter(typeof(MessageCancelScheduledResponseCcStatusConverter))]
public enum MessageCancelScheduledResponseCcStatus
{
    Scheduled,
    Queued,
    Sending,
    Sent,
    Cancelled,
    Expired,
    SendingFailed,
    DeliveryUnconfirmed,
    Delivered,
    DeliveryFailed
}sealed class MessageCancelScheduledResponseCcStatusConverter : JsonConverter<MessageCancelScheduledResponseCcStatus>
{
    public override MessageCancelScheduledResponseCcStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "scheduled"=>MessageCancelScheduledResponseCcStatus.Scheduled,
            "queued"=>MessageCancelScheduledResponseCcStatus.Queued,
            "sending"=>MessageCancelScheduledResponseCcStatus.Sending,
            "sent"=>MessageCancelScheduledResponseCcStatus.Sent,
            "cancelled"=>MessageCancelScheduledResponseCcStatus.Cancelled,
            "expired"=>MessageCancelScheduledResponseCcStatus.Expired,
            "sending_failed"=>MessageCancelScheduledResponseCcStatus.SendingFailed,
            "delivery_unconfirmed"=>MessageCancelScheduledResponseCcStatus.DeliveryUnconfirmed,
            "delivered"=>MessageCancelScheduledResponseCcStatus.Delivered,
            "delivery_failed"=>MessageCancelScheduledResponseCcStatus.DeliveryFailed,
            _ =>(MessageCancelScheduledResponseCcStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCancelScheduledResponseCcStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageCancelScheduledResponseCcStatus.Scheduled=>"scheduled",
            MessageCancelScheduledResponseCcStatus.Queued=>"queued",
            MessageCancelScheduledResponseCcStatus.Sending=>"sending",
            MessageCancelScheduledResponseCcStatus.Sent=>"sent",
            MessageCancelScheduledResponseCcStatus.Cancelled=>"cancelled",
            MessageCancelScheduledResponseCcStatus.Expired=>"expired",
            MessageCancelScheduledResponseCcStatus.SendingFailed=>"sending_failed",
            MessageCancelScheduledResponseCcStatus.DeliveryUnconfirmed=>"delivery_unconfirmed",
            MessageCancelScheduledResponseCcStatus.Delivered=>"delivered",
            MessageCancelScheduledResponseCcStatus.DeliveryFailed=>"delivery_failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MessageCancelScheduledResponseCost, MessageCancelScheduledResponseCostFromRaw>))]
public sealed record class MessageCancelScheduledResponseCost : JsonModel
{
    /// <summary>
    /// The amount deducted from your account.
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// The ISO 4217 currency identifier.
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public MessageCancelScheduledResponseCost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCancelScheduledResponseCost (
        MessageCancelScheduledResponseCost messageCancelScheduledResponseCost
    ) : base(messageCancelScheduledResponseCost)
    {  }
    #pragma warning restore CS8618

    public MessageCancelScheduledResponseCost (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCancelScheduledResponseCost (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageCancelScheduledResponseCostFromRaw.FromRawUnchecked"/>
    public static MessageCancelScheduledResponseCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageCancelScheduledResponseCostFromRaw : IFromRawJson<MessageCancelScheduledResponseCost>
{
    /// <inheritdoc/>
    public MessageCancelScheduledResponseCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageCancelScheduledResponseCost.FromRawUnchecked(rawData);
}/// <summary>
/// Detailed breakdown of the message cost components.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageCancelScheduledResponseCostBreakdown, MessageCancelScheduledResponseCostBreakdownFromRaw>))]
public sealed record class MessageCancelScheduledResponseCostBreakdown : JsonModel
{
    public MessageCancelScheduledResponseCostBreakdownCarrierFee? CarrierFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageCancelScheduledResponseCostBreakdownCarrierFee>(
                "carrier_fee"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier_fee", value);
        }
    }

    public MessageCancelScheduledResponseCostBreakdownRate? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageCancelScheduledResponseCostBreakdownRate>(
                "rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CarrierFee?.Validate();
        this.Rate?.Validate();
    }

    public MessageCancelScheduledResponseCostBreakdown ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCancelScheduledResponseCostBreakdown (
        MessageCancelScheduledResponseCostBreakdown messageCancelScheduledResponseCostBreakdown
    ) : base(messageCancelScheduledResponseCostBreakdown)
    {  }
    #pragma warning restore CS8618

    public MessageCancelScheduledResponseCostBreakdown (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCancelScheduledResponseCostBreakdown (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageCancelScheduledResponseCostBreakdownFromRaw.FromRawUnchecked"/>
    public static MessageCancelScheduledResponseCostBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageCancelScheduledResponseCostBreakdownFromRaw : IFromRawJson<MessageCancelScheduledResponseCostBreakdown>
{
    /// <inheritdoc/>
    public MessageCancelScheduledResponseCostBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageCancelScheduledResponseCostBreakdown.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MessageCancelScheduledResponseCostBreakdownCarrierFee, MessageCancelScheduledResponseCostBreakdownCarrierFeeFromRaw>))]
public sealed record class MessageCancelScheduledResponseCostBreakdownCarrierFee : JsonModel
{
    /// <summary>
    /// The carrier fee amount.
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// The ISO 4217 currency identifier.
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public MessageCancelScheduledResponseCostBreakdownCarrierFee ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCancelScheduledResponseCostBreakdownCarrierFee (
        MessageCancelScheduledResponseCostBreakdownCarrierFee messageCancelScheduledResponseCostBreakdownCarrierFee
    ) : base(messageCancelScheduledResponseCostBreakdownCarrierFee)
    {  }
    #pragma warning restore CS8618

    public MessageCancelScheduledResponseCostBreakdownCarrierFee (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCancelScheduledResponseCostBreakdownCarrierFee (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageCancelScheduledResponseCostBreakdownCarrierFeeFromRaw.FromRawUnchecked"/>
    public static MessageCancelScheduledResponseCostBreakdownCarrierFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageCancelScheduledResponseCostBreakdownCarrierFeeFromRaw : IFromRawJson<MessageCancelScheduledResponseCostBreakdownCarrierFee>
{
    /// <inheritdoc/>
    public MessageCancelScheduledResponseCostBreakdownCarrierFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageCancelScheduledResponseCostBreakdownCarrierFee.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MessageCancelScheduledResponseCostBreakdownRate, MessageCancelScheduledResponseCostBreakdownRateFromRaw>))]
public sealed record class MessageCancelScheduledResponseCostBreakdownRate : JsonModel
{
    /// <summary>
    /// The rate amount applied.
    /// </summary>
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// The ISO 4217 currency identifier.
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public MessageCancelScheduledResponseCostBreakdownRate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCancelScheduledResponseCostBreakdownRate (
        MessageCancelScheduledResponseCostBreakdownRate messageCancelScheduledResponseCostBreakdownRate
    ) : base(messageCancelScheduledResponseCostBreakdownRate)
    {  }
    #pragma warning restore CS8618

    public MessageCancelScheduledResponseCostBreakdownRate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCancelScheduledResponseCostBreakdownRate (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageCancelScheduledResponseCostBreakdownRateFromRaw.FromRawUnchecked"/>
    public static MessageCancelScheduledResponseCostBreakdownRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageCancelScheduledResponseCostBreakdownRateFromRaw : IFromRawJson<MessageCancelScheduledResponseCostBreakdownRate>
{
    /// <inheritdoc/>
    public MessageCancelScheduledResponseCostBreakdownRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageCancelScheduledResponseCostBreakdownRate.FromRawUnchecked(rawData);
}/// <summary>
/// The direction of the message. Inbound messages are sent to you whereas outbound
/// messages are sent from you.
/// </summary>
[JsonConverter(typeof(MessageCancelScheduledResponseDirectionConverter))]
public enum MessageCancelScheduledResponseDirection
{
    Outbound
}sealed class MessageCancelScheduledResponseDirectionConverter : JsonConverter<MessageCancelScheduledResponseDirection>
{
    public override MessageCancelScheduledResponseDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "outbound"=>MessageCancelScheduledResponseDirection.Outbound,
            _ =>(MessageCancelScheduledResponseDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCancelScheduledResponseDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageCancelScheduledResponseDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MessageCancelScheduledResponseFrom, MessageCancelScheduledResponseFromFromRaw>))]
public sealed record class MessageCancelScheduledResponseFrom : JsonModel
{
    /// <summary>
    /// The carrier of the receiver.
    /// </summary>
    public string? Carrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    /// <summary>
    /// The line-type of the receiver.
    /// </summary>
    public ApiEnum<string, MessageCancelScheduledResponseFromLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageCancelScheduledResponseFromLineType>>(
                "line_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("line_type", value);
        }
    }

    /// <summary>
    /// Sending address (+E.164 formatted phone number, alphanumeric sender ID, or
    /// short code).
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
        _ = this.Carrier;
        this.LineType?.Validate();
        _ = this.PhoneNumber;
    }

    public MessageCancelScheduledResponseFrom ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCancelScheduledResponseFrom (
        MessageCancelScheduledResponseFrom messageCancelScheduledResponseFrom
    ) : base(messageCancelScheduledResponseFrom)
    {  }
    #pragma warning restore CS8618

    public MessageCancelScheduledResponseFrom (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCancelScheduledResponseFrom (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageCancelScheduledResponseFromFromRaw.FromRawUnchecked"/>
    public static MessageCancelScheduledResponseFrom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageCancelScheduledResponseFromFromRaw : IFromRawJson<MessageCancelScheduledResponseFrom>
{
    /// <inheritdoc/>
    public MessageCancelScheduledResponseFrom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageCancelScheduledResponseFrom.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(MessageCancelScheduledResponseFromLineTypeConverter))]
public enum MessageCancelScheduledResponseFromLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class MessageCancelScheduledResponseFromLineTypeConverter : JsonConverter<MessageCancelScheduledResponseFromLineType>
{
    public override MessageCancelScheduledResponseFromLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>MessageCancelScheduledResponseFromLineType.Wireline,
            "Wireless"=>MessageCancelScheduledResponseFromLineType.Wireless,
            "VoWiFi"=>MessageCancelScheduledResponseFromLineType.VoWiFi,
            "VoIP"=>MessageCancelScheduledResponseFromLineType.VoIP,
            "Pre-Paid Wireless"=>MessageCancelScheduledResponseFromLineType.PrePaidWireless,
            ""=>MessageCancelScheduledResponseFromLineType.Undefined,
            _ =>(MessageCancelScheduledResponseFromLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCancelScheduledResponseFromLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageCancelScheduledResponseFromLineType.Wireline=>"Wireline",
            MessageCancelScheduledResponseFromLineType.Wireless=>"Wireless",
            MessageCancelScheduledResponseFromLineType.VoWiFi=>"VoWiFi",
            MessageCancelScheduledResponseFromLineType.VoIP=>"VoIP",
            MessageCancelScheduledResponseFromLineType.PrePaidWireless=>"Pre-Paid Wireless",
            MessageCancelScheduledResponseFromLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MessageCancelScheduledResponseMedia, MessageCancelScheduledResponseMediaFromRaw>))]
public sealed record class MessageCancelScheduledResponseMedia : JsonModel
{
    /// <summary>
    /// The MIME type of the requested media.
    /// </summary>
    public string? ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content_type"
            );
        }
        init { this._rawData.Set("content_type", value); }
    }

    /// <summary>
    /// The SHA256 hash of the requested media.
    /// </summary>
    public string? Sha256 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sha256"
            );
        }
        init { this._rawData.Set("sha256", value); }
    }

    /// <summary>
    /// The size of the requested media.
    /// </summary>
    public long? Size {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "size"
            );
        }
        init { this._rawData.Set("size", value); }
    }

    /// <summary>
    /// The url of the media requested to be sent.
    /// </summary>
    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ContentType;
        _ = this.Sha256;
        _ = this.Size;
        _ = this.Url;
    }

    public MessageCancelScheduledResponseMedia ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCancelScheduledResponseMedia (
        MessageCancelScheduledResponseMedia messageCancelScheduledResponseMedia
    ) : base(messageCancelScheduledResponseMedia)
    {  }
    #pragma warning restore CS8618

    public MessageCancelScheduledResponseMedia (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCancelScheduledResponseMedia (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageCancelScheduledResponseMediaFromRaw.FromRawUnchecked"/>
    public static MessageCancelScheduledResponseMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageCancelScheduledResponseMediaFromRaw : IFromRawJson<MessageCancelScheduledResponseMedia>
{
    /// <inheritdoc/>
    public MessageCancelScheduledResponseMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageCancelScheduledResponseMedia.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(MessageCancelScheduledResponseRecordTypeConverter))]
public enum MessageCancelScheduledResponseRecordType
{
    Message
}sealed class MessageCancelScheduledResponseRecordTypeConverter : JsonConverter<MessageCancelScheduledResponseRecordType>
{
    public override MessageCancelScheduledResponseRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message"=>MessageCancelScheduledResponseRecordType.Message,
            _ =>(MessageCancelScheduledResponseRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCancelScheduledResponseRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageCancelScheduledResponseRecordType.Message=>"message",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MessageCancelScheduledResponseTo, MessageCancelScheduledResponseToFromRaw>))]
public sealed record class MessageCancelScheduledResponseTo : JsonModel
{
    /// <summary>
    /// The carrier of the receiver.
    /// </summary>
    public string? Carrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    /// <summary>
    /// The line-type of the receiver.
    /// </summary>
    public ApiEnum<string, MessageCancelScheduledResponseToLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageCancelScheduledResponseToLineType>>(
                "line_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("line_type", value);
        }
    }

    /// <summary>
    /// Receiving address (+E.164 formatted phone number or short code).
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
    /// The delivery status of the message.
    /// </summary>
    public ApiEnum<string, MessageCancelScheduledResponseToStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageCancelScheduledResponseToStatus>>(
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
        _ = this.Carrier;
        this.LineType?.Validate();
        _ = this.PhoneNumber;
        this.Status?.Validate();
    }

    public MessageCancelScheduledResponseTo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageCancelScheduledResponseTo (
        MessageCancelScheduledResponseTo messageCancelScheduledResponseTo
    ) : base(messageCancelScheduledResponseTo)
    {  }
    #pragma warning restore CS8618

    public MessageCancelScheduledResponseTo (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageCancelScheduledResponseTo (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageCancelScheduledResponseToFromRaw.FromRawUnchecked"/>
    public static MessageCancelScheduledResponseTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessageCancelScheduledResponseToFromRaw : IFromRawJson<MessageCancelScheduledResponseTo>
{
    /// <inheritdoc/>
    public MessageCancelScheduledResponseTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageCancelScheduledResponseTo.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(MessageCancelScheduledResponseToLineTypeConverter))]
public enum MessageCancelScheduledResponseToLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class MessageCancelScheduledResponseToLineTypeConverter : JsonConverter<MessageCancelScheduledResponseToLineType>
{
    public override MessageCancelScheduledResponseToLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>MessageCancelScheduledResponseToLineType.Wireline,
            "Wireless"=>MessageCancelScheduledResponseToLineType.Wireless,
            "VoWiFi"=>MessageCancelScheduledResponseToLineType.VoWiFi,
            "VoIP"=>MessageCancelScheduledResponseToLineType.VoIP,
            "Pre-Paid Wireless"=>MessageCancelScheduledResponseToLineType.PrePaidWireless,
            ""=>MessageCancelScheduledResponseToLineType.Undefined,
            _ =>(MessageCancelScheduledResponseToLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCancelScheduledResponseToLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageCancelScheduledResponseToLineType.Wireline=>"Wireline",
            MessageCancelScheduledResponseToLineType.Wireless=>"Wireless",
            MessageCancelScheduledResponseToLineType.VoWiFi=>"VoWiFi",
            MessageCancelScheduledResponseToLineType.VoIP=>"VoIP",
            MessageCancelScheduledResponseToLineType.PrePaidWireless=>"Pre-Paid Wireless",
            MessageCancelScheduledResponseToLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The delivery status of the message.
/// </summary>
[JsonConverter(typeof(MessageCancelScheduledResponseToStatusConverter))]
public enum MessageCancelScheduledResponseToStatus
{
    Scheduled,
    Queued,
    Sending,
    Sent,
    Cancelled,
    Expired,
    SendingFailed,
    DeliveryUnconfirmed,
    Delivered,
    DeliveryFailed
}sealed class MessageCancelScheduledResponseToStatusConverter : JsonConverter<MessageCancelScheduledResponseToStatus>
{
    public override MessageCancelScheduledResponseToStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "scheduled"=>MessageCancelScheduledResponseToStatus.Scheduled,
            "queued"=>MessageCancelScheduledResponseToStatus.Queued,
            "sending"=>MessageCancelScheduledResponseToStatus.Sending,
            "sent"=>MessageCancelScheduledResponseToStatus.Sent,
            "cancelled"=>MessageCancelScheduledResponseToStatus.Cancelled,
            "expired"=>MessageCancelScheduledResponseToStatus.Expired,
            "sending_failed"=>MessageCancelScheduledResponseToStatus.SendingFailed,
            "delivery_unconfirmed"=>MessageCancelScheduledResponseToStatus.DeliveryUnconfirmed,
            "delivered"=>MessageCancelScheduledResponseToStatus.Delivered,
            "delivery_failed"=>MessageCancelScheduledResponseToStatus.DeliveryFailed,
            _ =>(MessageCancelScheduledResponseToStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCancelScheduledResponseToStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageCancelScheduledResponseToStatus.Scheduled=>"scheduled",
            MessageCancelScheduledResponseToStatus.Queued=>"queued",
            MessageCancelScheduledResponseToStatus.Sending=>"sending",
            MessageCancelScheduledResponseToStatus.Sent=>"sent",
            MessageCancelScheduledResponseToStatus.Cancelled=>"cancelled",
            MessageCancelScheduledResponseToStatus.Expired=>"expired",
            MessageCancelScheduledResponseToStatus.SendingFailed=>"sending_failed",
            MessageCancelScheduledResponseToStatus.DeliveryUnconfirmed=>"delivery_unconfirmed",
            MessageCancelScheduledResponseToStatus.Delivered=>"delivered",
            MessageCancelScheduledResponseToStatus.DeliveryFailed=>"delivery_failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The type of message.
/// </summary>
[JsonConverter(typeof(MessageCancelScheduledResponseTypeConverter))]
public enum MessageCancelScheduledResponseType
{
    Sms, Mms
}sealed class MessageCancelScheduledResponseTypeConverter : JsonConverter<MessageCancelScheduledResponseType>
{
    public override MessageCancelScheduledResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>MessageCancelScheduledResponseType.Sms,
            "MMS"=>MessageCancelScheduledResponseType.Mms,
            _ =>(MessageCancelScheduledResponseType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageCancelScheduledResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageCancelScheduledResponseType.Sms=>"SMS",
            MessageCancelScheduledResponseType.Mms=>"MMS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}