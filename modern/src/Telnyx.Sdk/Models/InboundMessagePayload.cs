using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<InboundMessagePayload, InboundMessagePayloadFromRaw>))]
public sealed record class InboundMessagePayload : JsonModel
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

    public IReadOnlyList<Cc>? Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Cc>>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Cc>?>(
                "cc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Not used for inbound messages.
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

    public Cost? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cost>(
                "cost"
            );
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Detailed breakdown of the message cost components.
    /// </summary>
    public CostBreakdown? CostBreakdown {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CostBreakdown>(
                "cost_breakdown"
            );
        }
        init { this._rawData.Set("cost_breakdown", value); }
    }

    /// <summary>
    /// The direction of the message. Inbound messages are sent to you whereas outbound
    /// messages are sent from you.
    /// </summary>
    public ApiEnum<string, Direction>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Direction>>(
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
    public IReadOnlyList<MessagingError>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessagingError>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessagingError>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public From? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<From>(
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

    public IReadOnlyList<InboundMessagePayloadMedia>? Media {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InboundMessagePayloadMedia>>(
                "media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<InboundMessagePayloadMedia>?>(
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
    /// Unique identifier for a messaging profile.
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
    /// Not used for inbound messages.
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
    /// Message subject.
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

    public IReadOnlyList<To>? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<To>>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<To>?>(
                "to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of message. This value can be either 'sms' or 'mms'.
    /// </summary>
    public ApiEnum<string, InboundMessagePayloadType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InboundMessagePayloadType>>(
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
    /// Not used for inbound messages.
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

    public InboundMessagePayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMessagePayload (
        InboundMessagePayload inboundMessagePayload
    ) : base(inboundMessagePayload)
    {  }
    #pragma warning restore CS8618

    public InboundMessagePayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundMessagePayload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundMessagePayloadFromRaw.FromRawUnchecked"/>
    public static InboundMessagePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundMessagePayloadFromRaw : IFromRawJson<InboundMessagePayload>
{
    /// <inheritdoc/>
    public InboundMessagePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundMessagePayload.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Cc, CcFromRaw>))]
public sealed record class Cc : JsonModel
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
    public ApiEnum<string, LineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LineType>>(
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

    public ApiEnum<string, CcStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CcStatus>>(
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

    public Cc ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cc (Cc cc) : base(cc)
    {  }
    #pragma warning restore CS8618

    public Cc (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cc (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CcFromRaw.FromRawUnchecked"/>
    public static Cc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CcFromRaw : IFromRawJson<Cc>
{
    /// <inheritdoc/>
    public Cc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    =>Cc.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(LineTypeConverter))]
public enum LineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class LineTypeConverter : JsonConverter<LineType>
{
    public override LineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>LineType.Wireline,
            "Wireless"=>LineType.Wireless,
            "VoWiFi"=>LineType.VoWiFi,
            "VoIP"=>LineType.VoIP,
            "Pre-Paid Wireless"=>LineType.PrePaidWireless,
            ""=>LineType.Undefined,
            _ =>(LineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, LineType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            LineType.Wireline=>"Wireline",
            LineType.Wireless=>"Wireless",
            LineType.VoWiFi=>"VoWiFi",
            LineType.VoIP=>"VoIP",
            LineType.PrePaidWireless=>"Pre-Paid Wireless",
            LineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(CcStatusConverter))]
public enum CcStatus
{
    Queued,
    Sending,
    Sent,
    Delivered,
    SendingFailed,
    DeliveryFailed,
    DeliveryUnconfirmed
}sealed class CcStatusConverter : JsonConverter<CcStatus>
{
    public override CcStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>CcStatus.Queued,
            "sending"=>CcStatus.Sending,
            "sent"=>CcStatus.Sent,
            "delivered"=>CcStatus.Delivered,
            "sending_failed"=>CcStatus.SendingFailed,
            "delivery_failed"=>CcStatus.DeliveryFailed,
            "delivery_unconfirmed"=>CcStatus.DeliveryUnconfirmed,
            _ =>(CcStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CcStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CcStatus.Queued=>"queued",
            CcStatus.Sending=>"sending",
            CcStatus.Sent=>"sent",
            CcStatus.Delivered=>"delivered",
            CcStatus.SendingFailed=>"sending_failed",
            CcStatus.DeliveryFailed=>"delivery_failed",
            CcStatus.DeliveryUnconfirmed=>"delivery_unconfirmed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Cost, CostFromRaw>))]
public sealed record class Cost : JsonModel
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

    public Cost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cost (Cost cost) : base(cost)
    {  }
    #pragma warning restore CS8618

    public Cost (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostFromRaw.FromRawUnchecked"/>
    public static Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CostFromRaw : IFromRawJson<Cost>
{
    /// <inheritdoc/>
    public Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Cost.FromRawUnchecked(rawData);
}/// <summary>
/// Detailed breakdown of the message cost components.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CostBreakdown, CostBreakdownFromRaw>))]
public sealed record class CostBreakdown : JsonModel
{
    public CarrierFee? CarrierFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CarrierFee>(
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

    public Rate? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Rate>(
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

    public CostBreakdown ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CostBreakdown (CostBreakdown costBreakdown) : base(costBreakdown)
    {  }
    #pragma warning restore CS8618

    public CostBreakdown (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CostBreakdown (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostBreakdownFromRaw.FromRawUnchecked"/>
    public static CostBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CostBreakdownFromRaw : IFromRawJson<CostBreakdown>
{
    /// <inheritdoc/>
    public CostBreakdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CostBreakdown.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<CarrierFee, CarrierFeeFromRaw>))]
public sealed record class CarrierFee : JsonModel
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

    public CarrierFee ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CarrierFee (CarrierFee carrierFee) : base(carrierFee)
    {  }
    #pragma warning restore CS8618

    public CarrierFee (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CarrierFee (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CarrierFeeFromRaw.FromRawUnchecked"/>
    public static CarrierFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CarrierFeeFromRaw : IFromRawJson<CarrierFee>
{
    /// <inheritdoc/>
    public CarrierFee FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CarrierFee.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Rate, RateFromRaw>))]
public sealed record class Rate : JsonModel
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

    public Rate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rate (Rate rate) : base(rate)
    {  }
    #pragma warning restore CS8618

    public Rate (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Rate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RateFromRaw.FromRawUnchecked"/>
    public static Rate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RateFromRaw : IFromRawJson<Rate>
{
    /// <inheritdoc/>
    public Rate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Rate.FromRawUnchecked(rawData);
}/// <summary>
/// The direction of the message. Inbound messages are sent to you whereas outbound
/// messages are sent from you.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    Inbound
}sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "inbound"=>Direction.Inbound, _ =>(Direction)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Direction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Direction.Inbound=>"inbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<From, FromFromRaw>))]
public sealed record class From : JsonModel
{
    /// <summary>
    /// The carrier of the sender.
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
    /// The line-type of the sender.
    /// </summary>
    public ApiEnum<string, FromLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FromLineType>>(
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

    public ApiEnum<string, FromStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FromStatus>>(
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

    public From ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public From (From from) : base(from)
    {  }
    #pragma warning restore CS8618

    public From (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    From (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FromFromRaw.FromRawUnchecked"/>
    public static From FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FromFromRaw : IFromRawJson<From>
{
    /// <inheritdoc/>
    public From FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>From.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the sender.
/// </summary>
[JsonConverter(typeof(FromLineTypeConverter))]
public enum FromLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class FromLineTypeConverter : JsonConverter<FromLineType>
{
    public override FromLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>FromLineType.Wireline,
            "Wireless"=>FromLineType.Wireless,
            "VoWiFi"=>FromLineType.VoWiFi,
            "VoIP"=>FromLineType.VoIP,
            "Pre-Paid Wireless"=>FromLineType.PrePaidWireless,
            ""=>FromLineType.Undefined,
            _ =>(FromLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FromLineType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FromLineType.Wireline=>"Wireline",
            FromLineType.Wireless=>"Wireless",
            FromLineType.VoWiFi=>"VoWiFi",
            FromLineType.VoIP=>"VoIP",
            FromLineType.PrePaidWireless=>"Pre-Paid Wireless",
            FromLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(FromStatusConverter))]
public enum FromStatus
{
    Received, Delivered
}sealed class FromStatusConverter : JsonConverter<FromStatus>
{
    public override FromStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "received"=>FromStatus.Received,
            "delivered"=>FromStatus.Delivered,
            _ =>(FromStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FromStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FromStatus.Received=>"received",
            FromStatus.Delivered=>"delivered",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<InboundMessagePayloadMedia, InboundMessagePayloadMediaFromRaw>))]
public sealed record class InboundMessagePayloadMedia : JsonModel
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
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_type", value);
        }
    }

    /// <summary>
    /// The SHA256 hash of the requested media.
    /// </summary>
    public string? HashSha256 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "hash_sha256"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hash_sha256", value);
        }
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
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("size", value);
        }
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
        _ = this.HashSha256;
        _ = this.Size;
        _ = this.Url;
    }

    public InboundMessagePayloadMedia ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundMessagePayloadMedia (
        InboundMessagePayloadMedia inboundMessagePayloadMedia
    ) : base(inboundMessagePayloadMedia)
    {  }
    #pragma warning restore CS8618

    public InboundMessagePayloadMedia (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundMessagePayloadMedia (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundMessagePayloadMediaFromRaw.FromRawUnchecked"/>
    public static InboundMessagePayloadMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class InboundMessagePayloadMediaFromRaw : IFromRawJson<InboundMessagePayloadMedia>
{
    /// <inheritdoc/>
    public InboundMessagePayloadMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundMessagePayloadMedia.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Message
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "message"=>RecordType.Message, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Message=>"message",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<To, ToFromRaw>))]
public sealed record class To : JsonModel
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
    public ApiEnum<string, ToLineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ToLineType>>(
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

    public ApiEnum<string, ToStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ToStatus>>(
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

    public To ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public To (To to) : base(to)
    {  }
    #pragma warning restore CS8618

    public To (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    To (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ToFromRaw.FromRawUnchecked"/>
    public static To FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ToFromRaw : IFromRawJson<To>
{
    /// <inheritdoc/>
    public To FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    =>To.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(ToLineTypeConverter))]
public enum ToLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class ToLineTypeConverter : JsonConverter<ToLineType>
{
    public override ToLineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>ToLineType.Wireline,
            "Wireless"=>ToLineType.Wireless,
            "VoWiFi"=>ToLineType.VoWiFi,
            "VoIP"=>ToLineType.VoIP,
            "Pre-Paid Wireless"=>ToLineType.PrePaidWireless,
            ""=>ToLineType.Undefined,
            _ =>(ToLineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ToLineType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ToLineType.Wireline=>"Wireline",
            ToLineType.Wireless=>"Wireless",
            ToLineType.VoWiFi=>"VoWiFi",
            ToLineType.VoIP=>"VoIP",
            ToLineType.PrePaidWireless=>"Pre-Paid Wireless",
            ToLineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(ToStatusConverter))]
public enum ToStatus
{
    Queued,
    Sending,
    Sent,
    Delivered,
    SendingFailed,
    DeliveryFailed,
    DeliveryUnconfirmed,
    WebhookDelivered
}sealed class ToStatusConverter : JsonConverter<ToStatus>
{
    public override ToStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>ToStatus.Queued,
            "sending"=>ToStatus.Sending,
            "sent"=>ToStatus.Sent,
            "delivered"=>ToStatus.Delivered,
            "sending_failed"=>ToStatus.SendingFailed,
            "delivery_failed"=>ToStatus.DeliveryFailed,
            "delivery_unconfirmed"=>ToStatus.DeliveryUnconfirmed,
            "webhook_delivered"=>ToStatus.WebhookDelivered,
            _ =>(ToStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ToStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ToStatus.Queued=>"queued",
            ToStatus.Sending=>"sending",
            ToStatus.Sent=>"sent",
            ToStatus.Delivered=>"delivered",
            ToStatus.SendingFailed=>"sending_failed",
            ToStatus.DeliveryFailed=>"delivery_failed",
            ToStatus.DeliveryUnconfirmed=>"delivery_unconfirmed",
            ToStatus.WebhookDelivered=>"webhook_delivered",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The type of message. This value can be either 'sms' or 'mms'.
/// </summary>
[JsonConverter(typeof(InboundMessagePayloadTypeConverter))]
public enum InboundMessagePayloadType
{
    Sms, Mms
}sealed class InboundMessagePayloadTypeConverter : JsonConverter<InboundMessagePayloadType>
{
    public override InboundMessagePayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>InboundMessagePayloadType.Sms,
            "MMS"=>InboundMessagePayloadType.Mms,
            _ =>(InboundMessagePayloadType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InboundMessagePayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InboundMessagePayloadType.Sms=>"SMS",
            InboundMessagePayloadType.Mms=>"MMS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}