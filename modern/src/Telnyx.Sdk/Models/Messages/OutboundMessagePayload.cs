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

[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayload, OutboundMessagePayloadFromRaw>))]
public sealed record class OutboundMessagePayload : JsonModel
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
    public OutboundMessagePayloadBody? Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundMessagePayloadBody>(
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

    public IReadOnlyList<OutboundMessagePayloadCc>? Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OutboundMessagePayloadCc>>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<OutboundMessagePayloadCc>?>(
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

    public OutboundMessagePayloadCost? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundMessagePayloadCost>(
                "cost"
            );
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Detailed breakdown of the message cost components.
    /// </summary>
    public OutboundMessagePayloadCostBreakdown? CostBreakdown {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundMessagePayloadCostBreakdown>(
                "cost_breakdown"
            );
        }
        init { this._rawData.Set("cost_breakdown", value); }
    }

    /// <summary>
    /// The direction of the message. Inbound messages are sent to you whereas outbound
    /// messages are sent from you.
    /// </summary>
    public ApiEnum<string, OutboundMessagePayloadDirection>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutboundMessagePayloadDirection>>(
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

    public OutboundMessagePayloadFrom? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundMessagePayloadFrom>(
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

    public IReadOnlyList<OutboundMessagePayloadMedia>? Media {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OutboundMessagePayloadMedia>>(
                "media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<OutboundMessagePayloadMedia>?>(
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
    public ApiEnum<string, OutboundMessagePayloadRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutboundMessagePayloadRecordType>>(
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

    public IReadOnlyList<OutboundMessagePayloadTo>? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OutboundMessagePayloadTo>>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<OutboundMessagePayloadTo>?>(
                "to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of message.
    /// </summary>
    public ApiEnum<string, OutboundMessagePayloadType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutboundMessagePayloadType>>(
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

    public OutboundMessagePayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayload (
        OutboundMessagePayload outboundMessagePayload
    ) : base(outboundMessagePayload)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OutboundMessagePayloadFromRaw : IFromRawJson<OutboundMessagePayload>
{
    /// <inheritdoc/>
    public OutboundMessagePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayload.FromRawUnchecked(rawData);
}

/// <summary>
/// RCS webhook message body. Text messages use the text property.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayloadBody, OutboundMessagePayloadBodyFromRaw>))]
public sealed record class OutboundMessagePayloadBody : JsonModel
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

    public OutboundMessagePayloadBody ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayloadBody (
        OutboundMessagePayloadBody outboundMessagePayloadBody
    ) : base(outboundMessagePayloadBody)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayloadBody (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayloadBody (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadBodyFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayloadBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundMessagePayloadBodyFromRaw : IFromRawJson<OutboundMessagePayloadBody>
{
    /// <inheritdoc/>
    public OutboundMessagePayloadBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayloadBody.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayloadCc, OutboundMessagePayloadCcFromRaw>))]
public sealed record class OutboundMessagePayloadCc : JsonModel
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
    public ApiEnum<string, OutboundMessagePayloadCcLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutboundMessagePayloadCcLineType>>(
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

    public ApiEnum<string, OutboundMessagePayloadCcStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutboundMessagePayloadCcStatus>>(
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

    public OutboundMessagePayloadCc ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayloadCc (
        OutboundMessagePayloadCc outboundMessagePayloadCc
    ) : base(outboundMessagePayloadCc)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayloadCc (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayloadCc (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadCcFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayloadCc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundMessagePayloadCcFromRaw : IFromRawJson<OutboundMessagePayloadCc>
{
    /// <inheritdoc/>
    public OutboundMessagePayloadCc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayloadCc.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(OutboundMessagePayloadCcLineTypeConverter))]
public enum OutboundMessagePayloadCcLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class OutboundMessagePayloadCcLineTypeConverter : JsonConverter<OutboundMessagePayloadCcLineType>
{
    public override OutboundMessagePayloadCcLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>OutboundMessagePayloadCcLineType.Wireline,
            "Wireless"=>OutboundMessagePayloadCcLineType.Wireless,
            "VoWiFi"=>OutboundMessagePayloadCcLineType.VoWiFi,
            "VoIP"=>OutboundMessagePayloadCcLineType.VoIP,
            "Pre-Paid Wireless"=>OutboundMessagePayloadCcLineType.PrePaidWireless,
            ""=>OutboundMessagePayloadCcLineType.Undefined,
            _ =>(OutboundMessagePayloadCcLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutboundMessagePayloadCcLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutboundMessagePayloadCcLineType.Wireline=>"Wireline",
            OutboundMessagePayloadCcLineType.Wireless=>"Wireless",
            OutboundMessagePayloadCcLineType.VoWiFi=>"VoWiFi",
            OutboundMessagePayloadCcLineType.VoIP=>"VoIP",
            OutboundMessagePayloadCcLineType.PrePaidWireless=>"Pre-Paid Wireless",
            OutboundMessagePayloadCcLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(OutboundMessagePayloadCcStatusConverter))]
public enum OutboundMessagePayloadCcStatus
{
    Queued,
    Sending,
    Sent,
    Delivered,
    SendingFailed,
    DeliveryFailed,
    DeliveryUnconfirmed
}sealed class OutboundMessagePayloadCcStatusConverter : JsonConverter<OutboundMessagePayloadCcStatus>
{
    public override OutboundMessagePayloadCcStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>OutboundMessagePayloadCcStatus.Queued,
            "sending"=>OutboundMessagePayloadCcStatus.Sending,
            "sent"=>OutboundMessagePayloadCcStatus.Sent,
            "delivered"=>OutboundMessagePayloadCcStatus.Delivered,
            "sending_failed"=>OutboundMessagePayloadCcStatus.SendingFailed,
            "delivery_failed"=>OutboundMessagePayloadCcStatus.DeliveryFailed,
            "delivery_unconfirmed"=>OutboundMessagePayloadCcStatus.DeliveryUnconfirmed,
            _ =>(OutboundMessagePayloadCcStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutboundMessagePayloadCcStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutboundMessagePayloadCcStatus.Queued=>"queued",
            OutboundMessagePayloadCcStatus.Sending=>"sending",
            OutboundMessagePayloadCcStatus.Sent=>"sent",
            OutboundMessagePayloadCcStatus.Delivered=>"delivered",
            OutboundMessagePayloadCcStatus.SendingFailed=>"sending_failed",
            OutboundMessagePayloadCcStatus.DeliveryFailed=>"delivery_failed",
            OutboundMessagePayloadCcStatus.DeliveryUnconfirmed=>"delivery_unconfirmed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayloadCost, OutboundMessagePayloadCostFromRaw>))]
public sealed record class OutboundMessagePayloadCost : JsonModel
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

    public OutboundMessagePayloadCost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayloadCost (
        OutboundMessagePayloadCost outboundMessagePayloadCost
    ) : base(outboundMessagePayloadCost)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayloadCost (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayloadCost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadCostFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayloadCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundMessagePayloadCostFromRaw : IFromRawJson<OutboundMessagePayloadCost>
{
    /// <inheritdoc/>
    public OutboundMessagePayloadCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayloadCost.FromRawUnchecked(rawData);
}/// <summary>
/// Detailed breakdown of the message cost components.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayloadCostBreakdown, OutboundMessagePayloadCostBreakdownFromRaw>))]
public sealed record class OutboundMessagePayloadCostBreakdown : JsonModel
{
    public OutboundMessagePayloadCostBreakdownCarrierFee? CarrierFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundMessagePayloadCostBreakdownCarrierFee>(
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

    public OutboundMessagePayloadCostBreakdownRate? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundMessagePayloadCostBreakdownRate>(
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

    public OutboundMessagePayloadCostBreakdown ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayloadCostBreakdown (
        OutboundMessagePayloadCostBreakdown outboundMessagePayloadCostBreakdown
    ) : base(outboundMessagePayloadCostBreakdown)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayloadCostBreakdown (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayloadCostBreakdown (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadCostBreakdownFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayloadCostBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundMessagePayloadCostBreakdownFromRaw : IFromRawJson<OutboundMessagePayloadCostBreakdown>
{
    /// <inheritdoc/>
    public OutboundMessagePayloadCostBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayloadCostBreakdown.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayloadCostBreakdownCarrierFee, OutboundMessagePayloadCostBreakdownCarrierFeeFromRaw>))]
public sealed record class OutboundMessagePayloadCostBreakdownCarrierFee : JsonModel
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

    public OutboundMessagePayloadCostBreakdownCarrierFee ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayloadCostBreakdownCarrierFee (
        OutboundMessagePayloadCostBreakdownCarrierFee outboundMessagePayloadCostBreakdownCarrierFee
    ) : base(outboundMessagePayloadCostBreakdownCarrierFee)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayloadCostBreakdownCarrierFee (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayloadCostBreakdownCarrierFee (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadCostBreakdownCarrierFeeFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayloadCostBreakdownCarrierFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundMessagePayloadCostBreakdownCarrierFeeFromRaw : IFromRawJson<OutboundMessagePayloadCostBreakdownCarrierFee>
{
    /// <inheritdoc/>
    public OutboundMessagePayloadCostBreakdownCarrierFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayloadCostBreakdownCarrierFee.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayloadCostBreakdownRate, OutboundMessagePayloadCostBreakdownRateFromRaw>))]
public sealed record class OutboundMessagePayloadCostBreakdownRate : JsonModel
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

    public OutboundMessagePayloadCostBreakdownRate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayloadCostBreakdownRate (
        OutboundMessagePayloadCostBreakdownRate outboundMessagePayloadCostBreakdownRate
    ) : base(outboundMessagePayloadCostBreakdownRate)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayloadCostBreakdownRate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayloadCostBreakdownRate (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadCostBreakdownRateFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayloadCostBreakdownRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundMessagePayloadCostBreakdownRateFromRaw : IFromRawJson<OutboundMessagePayloadCostBreakdownRate>
{
    /// <inheritdoc/>
    public OutboundMessagePayloadCostBreakdownRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayloadCostBreakdownRate.FromRawUnchecked(rawData);
}/// <summary>
/// The direction of the message. Inbound messages are sent to you whereas outbound
/// messages are sent from you.
/// </summary>
[JsonConverter(typeof(OutboundMessagePayloadDirectionConverter))]
public enum OutboundMessagePayloadDirection
{
    Outbound
}sealed class OutboundMessagePayloadDirectionConverter : JsonConverter<OutboundMessagePayloadDirection>
{
    public override OutboundMessagePayloadDirection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "outbound"=>OutboundMessagePayloadDirection.Outbound,
            _ =>(OutboundMessagePayloadDirection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutboundMessagePayloadDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutboundMessagePayloadDirection.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayloadFrom, OutboundMessagePayloadFromFromRaw>))]
public sealed record class OutboundMessagePayloadFrom : JsonModel
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
    public ApiEnum<string, OutboundMessagePayloadFromLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutboundMessagePayloadFromLineType>>(
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

    public OutboundMessagePayloadFrom ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayloadFrom (
        OutboundMessagePayloadFrom outboundMessagePayloadFrom
    ) : base(outboundMessagePayloadFrom)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayloadFrom (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayloadFrom (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadFromFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayloadFrom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundMessagePayloadFromFromRaw : IFromRawJson<OutboundMessagePayloadFrom>
{
    /// <inheritdoc/>
    public OutboundMessagePayloadFrom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayloadFrom.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(OutboundMessagePayloadFromLineTypeConverter))]
public enum OutboundMessagePayloadFromLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class OutboundMessagePayloadFromLineTypeConverter : JsonConverter<OutboundMessagePayloadFromLineType>
{
    public override OutboundMessagePayloadFromLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>OutboundMessagePayloadFromLineType.Wireline,
            "Wireless"=>OutboundMessagePayloadFromLineType.Wireless,
            "VoWiFi"=>OutboundMessagePayloadFromLineType.VoWiFi,
            "VoIP"=>OutboundMessagePayloadFromLineType.VoIP,
            "Pre-Paid Wireless"=>OutboundMessagePayloadFromLineType.PrePaidWireless,
            ""=>OutboundMessagePayloadFromLineType.Undefined,
            _ =>(OutboundMessagePayloadFromLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutboundMessagePayloadFromLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutboundMessagePayloadFromLineType.Wireline=>"Wireline",
            OutboundMessagePayloadFromLineType.Wireless=>"Wireless",
            OutboundMessagePayloadFromLineType.VoWiFi=>"VoWiFi",
            OutboundMessagePayloadFromLineType.VoIP=>"VoIP",
            OutboundMessagePayloadFromLineType.PrePaidWireless=>"Pre-Paid Wireless",
            OutboundMessagePayloadFromLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayloadMedia, OutboundMessagePayloadMediaFromRaw>))]
public sealed record class OutboundMessagePayloadMedia : JsonModel
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

    public OutboundMessagePayloadMedia ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayloadMedia (
        OutboundMessagePayloadMedia outboundMessagePayloadMedia
    ) : base(outboundMessagePayloadMedia)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayloadMedia (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayloadMedia (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadMediaFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayloadMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundMessagePayloadMediaFromRaw : IFromRawJson<OutboundMessagePayloadMedia>
{
    /// <inheritdoc/>
    public OutboundMessagePayloadMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayloadMedia.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(OutboundMessagePayloadRecordTypeConverter))]
public enum OutboundMessagePayloadRecordType
{
    Message
}sealed class OutboundMessagePayloadRecordTypeConverter : JsonConverter<OutboundMessagePayloadRecordType>
{
    public override OutboundMessagePayloadRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message"=>OutboundMessagePayloadRecordType.Message,
            _ =>(OutboundMessagePayloadRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutboundMessagePayloadRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutboundMessagePayloadRecordType.Message=>"message",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<OutboundMessagePayloadTo, OutboundMessagePayloadToFromRaw>))]
public sealed record class OutboundMessagePayloadTo : JsonModel
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
    public ApiEnum<string, OutboundMessagePayloadToLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutboundMessagePayloadToLineType>>(
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
    public ApiEnum<string, OutboundMessagePayloadToStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutboundMessagePayloadToStatus>>(
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

    public OutboundMessagePayloadTo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundMessagePayloadTo (
        OutboundMessagePayloadTo outboundMessagePayloadTo
    ) : base(outboundMessagePayloadTo)
    {  }
    #pragma warning restore CS8618

    public OutboundMessagePayloadTo (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundMessagePayloadTo (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundMessagePayloadToFromRaw.FromRawUnchecked"/>
    public static OutboundMessagePayloadTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundMessagePayloadToFromRaw : IFromRawJson<OutboundMessagePayloadTo>
{
    /// <inheritdoc/>
    public OutboundMessagePayloadTo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundMessagePayloadTo.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(OutboundMessagePayloadToLineTypeConverter))]
public enum OutboundMessagePayloadToLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class OutboundMessagePayloadToLineTypeConverter : JsonConverter<OutboundMessagePayloadToLineType>
{
    public override OutboundMessagePayloadToLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>OutboundMessagePayloadToLineType.Wireline,
            "Wireless"=>OutboundMessagePayloadToLineType.Wireless,
            "VoWiFi"=>OutboundMessagePayloadToLineType.VoWiFi,
            "VoIP"=>OutboundMessagePayloadToLineType.VoIP,
            "Pre-Paid Wireless"=>OutboundMessagePayloadToLineType.PrePaidWireless,
            ""=>OutboundMessagePayloadToLineType.Undefined,
            _ =>(OutboundMessagePayloadToLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutboundMessagePayloadToLineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutboundMessagePayloadToLineType.Wireline=>"Wireline",
            OutboundMessagePayloadToLineType.Wireless=>"Wireless",
            OutboundMessagePayloadToLineType.VoWiFi=>"VoWiFi",
            OutboundMessagePayloadToLineType.VoIP=>"VoIP",
            OutboundMessagePayloadToLineType.PrePaidWireless=>"Pre-Paid Wireless",
            OutboundMessagePayloadToLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The delivery status of the message.
/// </summary>
[JsonConverter(typeof(OutboundMessagePayloadToStatusConverter))]
public enum OutboundMessagePayloadToStatus
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
}sealed class OutboundMessagePayloadToStatusConverter : JsonConverter<OutboundMessagePayloadToStatus>
{
    public override OutboundMessagePayloadToStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>OutboundMessagePayloadToStatus.Queued,
            "sending"=>OutboundMessagePayloadToStatus.Sending,
            "sent"=>OutboundMessagePayloadToStatus.Sent,
            "expired"=>OutboundMessagePayloadToStatus.Expired,
            "sending_failed"=>OutboundMessagePayloadToStatus.SendingFailed,
            "delivery_unconfirmed"=>OutboundMessagePayloadToStatus.DeliveryUnconfirmed,
            "delivered"=>OutboundMessagePayloadToStatus.Delivered,
            "delivery_failed"=>OutboundMessagePayloadToStatus.DeliveryFailed,
            "read"=>OutboundMessagePayloadToStatus.Read,
            _ =>(OutboundMessagePayloadToStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutboundMessagePayloadToStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutboundMessagePayloadToStatus.Queued=>"queued",
            OutboundMessagePayloadToStatus.Sending=>"sending",
            OutboundMessagePayloadToStatus.Sent=>"sent",
            OutboundMessagePayloadToStatus.Expired=>"expired",
            OutboundMessagePayloadToStatus.SendingFailed=>"sending_failed",
            OutboundMessagePayloadToStatus.DeliveryUnconfirmed=>"delivery_unconfirmed",
            OutboundMessagePayloadToStatus.Delivered=>"delivered",
            OutboundMessagePayloadToStatus.DeliveryFailed=>"delivery_failed",
            OutboundMessagePayloadToStatus.Read=>"read",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The type of message.
/// </summary>
[JsonConverter(typeof(OutboundMessagePayloadTypeConverter))]
public enum OutboundMessagePayloadType
{
    Sms, Mms, Rcs
}sealed class OutboundMessagePayloadTypeConverter : JsonConverter<OutboundMessagePayloadType>
{
    public override OutboundMessagePayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>OutboundMessagePayloadType.Sms,
            "MMS"=>OutboundMessagePayloadType.Mms,
            "RCS"=>OutboundMessagePayloadType.Rcs,
            _ =>(OutboundMessagePayloadType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutboundMessagePayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OutboundMessagePayloadType.Sms=>"SMS",
            OutboundMessagePayloadType.Mms=>"MMS",
            OutboundMessagePayloadType.Rcs=>"RCS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}