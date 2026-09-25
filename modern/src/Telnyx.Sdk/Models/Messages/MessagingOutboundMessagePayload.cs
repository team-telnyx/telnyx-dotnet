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

[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayload, MessagingOutboundMessagePayloadFromRaw>))]
public sealed record class MessagingOutboundMessagePayload : JsonModel
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

    /// <summary>
    /// RCS webhook message body. Text messages use the text property.
    /// </summary>
    public MessagingOutboundMessagePayloadBody? Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingOutboundMessagePayloadBody>(
                "body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

    public IReadOnlyList<MessagingOutboundMessagePayloadCc>? Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessagingOutboundMessagePayloadCc>>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessagingOutboundMessagePayloadCc>?>(
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

    public MessagingOutboundMessagePayloadCost? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingOutboundMessagePayloadCost>(
                "cost"
            );
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Detailed breakdown of the message cost components.
    /// </summary>
    public MessagingOutboundMessagePayloadCostBreakdown? CostBreakdown {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingOutboundMessagePayloadCostBreakdown>(
                "cost_breakdown"
            );
        }
        init { this._rawData.Set("cost_breakdown", value); }
    }

    /// <summary>
    /// The direction of the message. Inbound messages are sent to you whereas outbound
    /// messages are sent from you.
    /// </summary>
    public ApiEnum<string, MessagingOutboundMessagePayloadDirection>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingOutboundMessagePayloadDirection>>(
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

    public MessagingOutboundMessagePayloadFrom? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingOutboundMessagePayloadFrom>(
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

    public IReadOnlyList<MessagingOutboundMessagePayloadMedia>? Media {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessagingOutboundMessagePayloadMedia>>(
                "media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessagingOutboundMessagePayloadMedia>?>(
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
    public ApiEnum<string, MessagingOutboundMessagePayloadRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingOutboundMessagePayloadRecordType>>(
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

    public IReadOnlyList<MessagingOutboundMessagePayloadTo>? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessagingOutboundMessagePayloadTo>>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessagingOutboundMessagePayloadTo>?>(
                "to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of message.
    /// </summary>
    public ApiEnum<string, MessagingOutboundMessagePayloadType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingOutboundMessagePayloadType>>(
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
    /// Seconds the message is queued due to rate limiting before being sent to the
    /// carrier. Represents the maximum wait across all applicable rate limits (account,
    /// carrier, campaign). 0.0 = no queuing delay.
    /// </summary>
    public float? WaitSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "wait_seconds"
            );
        }
        init { this._rawData.Set("wait_seconds", value); }
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
        this.Body?.Validate();
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
        _ = this.WaitSeconds;
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
    }

    public MessagingOutboundMessagePayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayload (
        MessagingOutboundMessagePayload messagingOutboundMessagePayload
    ) : base(messagingOutboundMessagePayload)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingOutboundMessagePayloadFromRaw : IFromRawJson<MessagingOutboundMessagePayload>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayload.FromRawUnchecked(rawData);
}

/// <summary>
/// RCS webhook message body. Text messages use the text property.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayloadBody, MessagingOutboundMessagePayloadBodyFromRaw>))]
public sealed record class MessagingOutboundMessagePayloadBody : JsonModel
{
    /// <summary>
    /// RCS text message.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Text; }

    public MessagingOutboundMessagePayloadBody ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayloadBody (
        MessagingOutboundMessagePayloadBody messagingOutboundMessagePayloadBody
    ) : base(messagingOutboundMessagePayloadBody)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayloadBody (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayloadBody (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadBodyFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayloadBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingOutboundMessagePayloadBodyFromRaw : IFromRawJson<MessagingOutboundMessagePayloadBody>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayloadBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayloadBody.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayloadCc, MessagingOutboundMessagePayloadCcFromRaw>))]
public sealed record class MessagingOutboundMessagePayloadCc : JsonModel
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
    public ApiEnum<string, MessagingOutboundMessagePayloadCcLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingOutboundMessagePayloadCcLineType>>(
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

    public ApiEnum<string, MessagingOutboundMessagePayloadCcStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingOutboundMessagePayloadCcStatus>>(
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

    public MessagingOutboundMessagePayloadCc ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayloadCc (
        MessagingOutboundMessagePayloadCc messagingOutboundMessagePayloadCc
    ) : base(messagingOutboundMessagePayloadCc)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayloadCc (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayloadCc (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadCcFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayloadCc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingOutboundMessagePayloadCcFromRaw : IFromRawJson<MessagingOutboundMessagePayloadCc>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayloadCc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayloadCc.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(MessagingOutboundMessagePayloadCcLineTypeConverter))]
public enum MessagingOutboundMessagePayloadCcLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class MessagingOutboundMessagePayloadCcLineTypeConverter : JsonConverter<MessagingOutboundMessagePayloadCcLineType>
{
    public override MessagingOutboundMessagePayloadCcLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>MessagingOutboundMessagePayloadCcLineType.Wireline,
            "Wireless"=>MessagingOutboundMessagePayloadCcLineType.Wireless,
            "VoWiFi"=>MessagingOutboundMessagePayloadCcLineType.VoWiFi,
            "VoIP"=>MessagingOutboundMessagePayloadCcLineType.VoIP,
            "Pre-Paid Wireless"=>MessagingOutboundMessagePayloadCcLineType.PrePaidWireless,
            ""=>MessagingOutboundMessagePayloadCcLineType.Undefined,
            _ =>(MessagingOutboundMessagePayloadCcLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingOutboundMessagePayloadCcLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingOutboundMessagePayloadCcLineType.Wireline=>"Wireline",
            MessagingOutboundMessagePayloadCcLineType.Wireless=>"Wireless",
            MessagingOutboundMessagePayloadCcLineType.VoWiFi=>"VoWiFi",
            MessagingOutboundMessagePayloadCcLineType.VoIP=>"VoIP",
            MessagingOutboundMessagePayloadCcLineType.PrePaidWireless=>"Pre-Paid Wireless",
            MessagingOutboundMessagePayloadCcLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(MessagingOutboundMessagePayloadCcStatusConverter))]
public enum MessagingOutboundMessagePayloadCcStatus
{
    Queued,
    Sending,
    Sent,
    Delivered,
    SendingFailed,
    DeliveryFailed,
    DeliveryUnconfirmed
}sealed class MessagingOutboundMessagePayloadCcStatusConverter : JsonConverter<MessagingOutboundMessagePayloadCcStatus>
{
    public override MessagingOutboundMessagePayloadCcStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>MessagingOutboundMessagePayloadCcStatus.Queued,
            "sending"=>MessagingOutboundMessagePayloadCcStatus.Sending,
            "sent"=>MessagingOutboundMessagePayloadCcStatus.Sent,
            "delivered"=>MessagingOutboundMessagePayloadCcStatus.Delivered,
            "sending_failed"=>MessagingOutboundMessagePayloadCcStatus.SendingFailed,
            "delivery_failed"=>MessagingOutboundMessagePayloadCcStatus.DeliveryFailed,
            "delivery_unconfirmed"=>MessagingOutboundMessagePayloadCcStatus.DeliveryUnconfirmed,
            _ =>(MessagingOutboundMessagePayloadCcStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingOutboundMessagePayloadCcStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingOutboundMessagePayloadCcStatus.Queued=>"queued",
            MessagingOutboundMessagePayloadCcStatus.Sending=>"sending",
            MessagingOutboundMessagePayloadCcStatus.Sent=>"sent",
            MessagingOutboundMessagePayloadCcStatus.Delivered=>"delivered",
            MessagingOutboundMessagePayloadCcStatus.SendingFailed=>"sending_failed",
            MessagingOutboundMessagePayloadCcStatus.DeliveryFailed=>"delivery_failed",
            MessagingOutboundMessagePayloadCcStatus.DeliveryUnconfirmed=>"delivery_unconfirmed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayloadCost, MessagingOutboundMessagePayloadCostFromRaw>))]
public sealed record class MessagingOutboundMessagePayloadCost : JsonModel
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

    public MessagingOutboundMessagePayloadCost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayloadCost (
        MessagingOutboundMessagePayloadCost messagingOutboundMessagePayloadCost
    ) : base(messagingOutboundMessagePayloadCost)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayloadCost (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayloadCost (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadCostFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayloadCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingOutboundMessagePayloadCostFromRaw : IFromRawJson<MessagingOutboundMessagePayloadCost>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayloadCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayloadCost.FromRawUnchecked(rawData);
}/// <summary>
/// Detailed breakdown of the message cost components.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayloadCostBreakdown, MessagingOutboundMessagePayloadCostBreakdownFromRaw>))]
public sealed record class MessagingOutboundMessagePayloadCostBreakdown : JsonModel
{
    public MessagingOutboundMessagePayloadCostBreakdownCarrierFee? CarrierFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingOutboundMessagePayloadCostBreakdownCarrierFee>(
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

    public MessagingOutboundMessagePayloadCostBreakdownRate? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingOutboundMessagePayloadCostBreakdownRate>(
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

    public MessagingOutboundMessagePayloadCostBreakdown ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayloadCostBreakdown (
        MessagingOutboundMessagePayloadCostBreakdown messagingOutboundMessagePayloadCostBreakdown
    ) : base(messagingOutboundMessagePayloadCostBreakdown)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayloadCostBreakdown (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayloadCostBreakdown (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadCostBreakdownFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayloadCostBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingOutboundMessagePayloadCostBreakdownFromRaw : IFromRawJson<MessagingOutboundMessagePayloadCostBreakdown>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayloadCostBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayloadCostBreakdown.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayloadCostBreakdownCarrierFee, MessagingOutboundMessagePayloadCostBreakdownCarrierFeeFromRaw>))]
public sealed record class MessagingOutboundMessagePayloadCostBreakdownCarrierFee : JsonModel
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

    public MessagingOutboundMessagePayloadCostBreakdownCarrierFee ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayloadCostBreakdownCarrierFee (
        MessagingOutboundMessagePayloadCostBreakdownCarrierFee messagingOutboundMessagePayloadCostBreakdownCarrierFee
    ) : base(messagingOutboundMessagePayloadCostBreakdownCarrierFee)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayloadCostBreakdownCarrierFee (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayloadCostBreakdownCarrierFee (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadCostBreakdownCarrierFeeFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayloadCostBreakdownCarrierFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingOutboundMessagePayloadCostBreakdownCarrierFeeFromRaw : IFromRawJson<MessagingOutboundMessagePayloadCostBreakdownCarrierFee>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayloadCostBreakdownCarrierFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayloadCostBreakdownCarrierFee.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayloadCostBreakdownRate, MessagingOutboundMessagePayloadCostBreakdownRateFromRaw>))]
public sealed record class MessagingOutboundMessagePayloadCostBreakdownRate : JsonModel
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

    public MessagingOutboundMessagePayloadCostBreakdownRate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayloadCostBreakdownRate (
        MessagingOutboundMessagePayloadCostBreakdownRate messagingOutboundMessagePayloadCostBreakdownRate
    ) : base(messagingOutboundMessagePayloadCostBreakdownRate)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayloadCostBreakdownRate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayloadCostBreakdownRate (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadCostBreakdownRateFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayloadCostBreakdownRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingOutboundMessagePayloadCostBreakdownRateFromRaw : IFromRawJson<MessagingOutboundMessagePayloadCostBreakdownRate>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayloadCostBreakdownRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayloadCostBreakdownRate.FromRawUnchecked(rawData);
}/// <summary>
/// The direction of the message. Inbound messages are sent to you whereas outbound
/// messages are sent from you.
/// </summary>
[JsonConverter(typeof(MessagingOutboundMessagePayloadDirectionConverter))]
public enum MessagingOutboundMessagePayloadDirection
{
    Outbound
}sealed class MessagingOutboundMessagePayloadDirectionConverter : JsonConverter<MessagingOutboundMessagePayloadDirection>
{
    public override MessagingOutboundMessagePayloadDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "outbound"=>MessagingOutboundMessagePayloadDirection.Outbound,
            _ =>(MessagingOutboundMessagePayloadDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingOutboundMessagePayloadDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingOutboundMessagePayloadDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayloadFrom, MessagingOutboundMessagePayloadFromFromRaw>))]
public sealed record class MessagingOutboundMessagePayloadFrom : JsonModel
{
    /// <summary>
    /// RCS agent identifier.
    /// </summary>
    public string? AgentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "agent_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("agent_id", value);
        }
    }

    /// <summary>
    /// RCS agent name.
    /// </summary>
    public string? AgentName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "agent_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("agent_name", value);
        }
    }

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
    public ApiEnum<string, MessagingOutboundMessagePayloadFromLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingOutboundMessagePayloadFromLineType>>(
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
        _ = this.AgentID;
        _ = this.AgentName;
        _ = this.Carrier;
        this.LineType?.Validate();
        _ = this.PhoneNumber;
    }

    public MessagingOutboundMessagePayloadFrom ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayloadFrom (
        MessagingOutboundMessagePayloadFrom messagingOutboundMessagePayloadFrom
    ) : base(messagingOutboundMessagePayloadFrom)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayloadFrom (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayloadFrom (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadFromFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayloadFrom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingOutboundMessagePayloadFromFromRaw : IFromRawJson<MessagingOutboundMessagePayloadFrom>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayloadFrom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayloadFrom.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(MessagingOutboundMessagePayloadFromLineTypeConverter))]
public enum MessagingOutboundMessagePayloadFromLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class MessagingOutboundMessagePayloadFromLineTypeConverter : JsonConverter<MessagingOutboundMessagePayloadFromLineType>
{
    public override MessagingOutboundMessagePayloadFromLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>MessagingOutboundMessagePayloadFromLineType.Wireline,
            "Wireless"=>MessagingOutboundMessagePayloadFromLineType.Wireless,
            "VoWiFi"=>MessagingOutboundMessagePayloadFromLineType.VoWiFi,
            "VoIP"=>MessagingOutboundMessagePayloadFromLineType.VoIP,
            "Pre-Paid Wireless"=>MessagingOutboundMessagePayloadFromLineType.PrePaidWireless,
            ""=>MessagingOutboundMessagePayloadFromLineType.Undefined,
            _ =>(MessagingOutboundMessagePayloadFromLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingOutboundMessagePayloadFromLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingOutboundMessagePayloadFromLineType.Wireline=>"Wireline",
            MessagingOutboundMessagePayloadFromLineType.Wireless=>"Wireless",
            MessagingOutboundMessagePayloadFromLineType.VoWiFi=>"VoWiFi",
            MessagingOutboundMessagePayloadFromLineType.VoIP=>"VoIP",
            MessagingOutboundMessagePayloadFromLineType.PrePaidWireless=>"Pre-Paid Wireless",
            MessagingOutboundMessagePayloadFromLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayloadMedia, MessagingOutboundMessagePayloadMediaFromRaw>))]
public sealed record class MessagingOutboundMessagePayloadMedia : JsonModel
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

    public MessagingOutboundMessagePayloadMedia ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayloadMedia (
        MessagingOutboundMessagePayloadMedia messagingOutboundMessagePayloadMedia
    ) : base(messagingOutboundMessagePayloadMedia)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayloadMedia (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayloadMedia (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadMediaFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayloadMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingOutboundMessagePayloadMediaFromRaw : IFromRawJson<MessagingOutboundMessagePayloadMedia>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayloadMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayloadMedia.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(MessagingOutboundMessagePayloadRecordTypeConverter))]
public enum MessagingOutboundMessagePayloadRecordType
{
    Message
}sealed class MessagingOutboundMessagePayloadRecordTypeConverter : JsonConverter<MessagingOutboundMessagePayloadRecordType>
{
    public override MessagingOutboundMessagePayloadRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message"=>MessagingOutboundMessagePayloadRecordType.Message,
            _ =>(MessagingOutboundMessagePayloadRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingOutboundMessagePayloadRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingOutboundMessagePayloadRecordType.Message=>"message",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MessagingOutboundMessagePayloadTo, MessagingOutboundMessagePayloadToFromRaw>))]
public sealed record class MessagingOutboundMessagePayloadTo : JsonModel
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
    public ApiEnum<string, MessagingOutboundMessagePayloadToLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingOutboundMessagePayloadToLineType>>(
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
    public ApiEnum<string, MessagingOutboundMessagePayloadToStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingOutboundMessagePayloadToStatus>>(
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

    public MessagingOutboundMessagePayloadTo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingOutboundMessagePayloadTo (
        MessagingOutboundMessagePayloadTo messagingOutboundMessagePayloadTo
    ) : base(messagingOutboundMessagePayloadTo)
    {  }
    #pragma warning restore CS8618

    public MessagingOutboundMessagePayloadTo (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingOutboundMessagePayloadTo (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingOutboundMessagePayloadToFromRaw.FromRawUnchecked"/>
    public static MessagingOutboundMessagePayloadTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingOutboundMessagePayloadToFromRaw : IFromRawJson<MessagingOutboundMessagePayloadTo>
{
    /// <inheritdoc/>
    public MessagingOutboundMessagePayloadTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingOutboundMessagePayloadTo.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(MessagingOutboundMessagePayloadToLineTypeConverter))]
public enum MessagingOutboundMessagePayloadToLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class MessagingOutboundMessagePayloadToLineTypeConverter : JsonConverter<MessagingOutboundMessagePayloadToLineType>
{
    public override MessagingOutboundMessagePayloadToLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>MessagingOutboundMessagePayloadToLineType.Wireline,
            "Wireless"=>MessagingOutboundMessagePayloadToLineType.Wireless,
            "VoWiFi"=>MessagingOutboundMessagePayloadToLineType.VoWiFi,
            "VoIP"=>MessagingOutboundMessagePayloadToLineType.VoIP,
            "Pre-Paid Wireless"=>MessagingOutboundMessagePayloadToLineType.PrePaidWireless,
            ""=>MessagingOutboundMessagePayloadToLineType.Undefined,
            _ =>(MessagingOutboundMessagePayloadToLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingOutboundMessagePayloadToLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingOutboundMessagePayloadToLineType.Wireline=>"Wireline",
            MessagingOutboundMessagePayloadToLineType.Wireless=>"Wireless",
            MessagingOutboundMessagePayloadToLineType.VoWiFi=>"VoWiFi",
            MessagingOutboundMessagePayloadToLineType.VoIP=>"VoIP",
            MessagingOutboundMessagePayloadToLineType.PrePaidWireless=>"Pre-Paid Wireless",
            MessagingOutboundMessagePayloadToLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The delivery status of the message.
/// </summary>
[JsonConverter(typeof(MessagingOutboundMessagePayloadToStatusConverter))]
public enum MessagingOutboundMessagePayloadToStatus
{
    Queued,
    Sending,
    Sent,
    Expired,
    SendingFailed,
    DeliveryUnconfirmed,
    Delivered,
    DeliveryFailed,
    Read
}sealed class MessagingOutboundMessagePayloadToStatusConverter : JsonConverter<MessagingOutboundMessagePayloadToStatus>
{
    public override MessagingOutboundMessagePayloadToStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>MessagingOutboundMessagePayloadToStatus.Queued,
            "sending"=>MessagingOutboundMessagePayloadToStatus.Sending,
            "sent"=>MessagingOutboundMessagePayloadToStatus.Sent,
            "expired"=>MessagingOutboundMessagePayloadToStatus.Expired,
            "sending_failed"=>MessagingOutboundMessagePayloadToStatus.SendingFailed,
            "delivery_unconfirmed"=>MessagingOutboundMessagePayloadToStatus.DeliveryUnconfirmed,
            "delivered"=>MessagingOutboundMessagePayloadToStatus.Delivered,
            "delivery_failed"=>MessagingOutboundMessagePayloadToStatus.DeliveryFailed,
            "read"=>MessagingOutboundMessagePayloadToStatus.Read,
            _ =>(MessagingOutboundMessagePayloadToStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingOutboundMessagePayloadToStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingOutboundMessagePayloadToStatus.Queued=>"queued",
            MessagingOutboundMessagePayloadToStatus.Sending=>"sending",
            MessagingOutboundMessagePayloadToStatus.Sent=>"sent",
            MessagingOutboundMessagePayloadToStatus.Expired=>"expired",
            MessagingOutboundMessagePayloadToStatus.SendingFailed=>"sending_failed",
            MessagingOutboundMessagePayloadToStatus.DeliveryUnconfirmed=>"delivery_unconfirmed",
            MessagingOutboundMessagePayloadToStatus.Delivered=>"delivered",
            MessagingOutboundMessagePayloadToStatus.DeliveryFailed=>"delivery_failed",
            MessagingOutboundMessagePayloadToStatus.Read=>"read",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The type of message.
/// </summary>
[JsonConverter(typeof(MessagingOutboundMessagePayloadTypeConverter))]
public enum MessagingOutboundMessagePayloadType
{
    Sms, Mms, Rcs
}sealed class MessagingOutboundMessagePayloadTypeConverter : JsonConverter<MessagingOutboundMessagePayloadType>
{
    public override MessagingOutboundMessagePayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>MessagingOutboundMessagePayloadType.Sms,
            "MMS"=>MessagingOutboundMessagePayloadType.Mms,
            "RCS"=>MessagingOutboundMessagePayloadType.Rcs,
            _ =>(MessagingOutboundMessagePayloadType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingOutboundMessagePayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingOutboundMessagePayloadType.Sms=>"SMS",
            MessagingOutboundMessagePayloadType.Mms=>"MMS",
            MessagingOutboundMessagePayloadType.Rcs=>"RCS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}