using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessagingInboundMessagePayload, MessagingInboundMessagePayloadFromRaw>))]
public sealed record class MessagingInboundMessagePayload : JsonModel
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
    /// Automatic response type triggered by an inbound opt-in, opt-out, or help keyword.
    /// Examples include START, STOP, and HELP.
    /// </summary>
    public string? AutoresponseType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "autoresponse_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("autoresponse_type", value);
        }
    }

    /// <summary>
    /// Message body for RCS and WhatsApp. RCS messages contain text, user_file, location,
    /// or suggestion_response. For WhatsApp edits and revocations, inspect type and
    /// the corresponding edit or revoke object.
    /// </summary>
    public Body? Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Body>(
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

    public Generic::IReadOnlyList<Cc>? Cc {
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
    public Generic::IReadOnlyList<MessagingError0b38e7044b>? Errors {
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

    public Generic::IReadOnlyList<MessagingInboundMessagePayloadMedia>? Media {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MessagingInboundMessagePayloadMedia>>(
                "media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MessagingInboundMessagePayloadMedia>?>(
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
    public Generic::IReadOnlyList<string>? Tags {
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

    /// <summary>
    /// Receiving address. SMS, MMS and RCS webhooks use an array of recipients.
    /// RCS recipients are identified by agent_id and agent_name. WhatsApp webhooks
    /// use one E.164 phone number.
    /// </summary>
    public To? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<To>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <summary>
    /// The messaging channel used for the message.
    /// </summary>
    public ApiEnum<string, MessagingInboundMessagePayloadType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingInboundMessagePayloadType>>(
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
        _ = this.AutoresponseType;
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
        _ = this.Subject;
        _ = this.Tags;
        _ = this.TcrCampaignBillable;
        _ = this.TcrCampaignID;
        _ = this.TcrCampaignRegistered;
        _ = this.Text;
        this.To?.Validate();
        this.Type?.Validate();
        _ = this.ValidUntil;
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
    }

    public MessagingInboundMessagePayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingInboundMessagePayload (
        MessagingInboundMessagePayload messagingInboundMessagePayload
    ) : base(messagingInboundMessagePayload)
    {  }
    #pragma warning restore CS8618

    public MessagingInboundMessagePayload (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingInboundMessagePayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingInboundMessagePayloadFromRaw.FromRawUnchecked"/>
    public static MessagingInboundMessagePayload FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingInboundMessagePayloadFromRaw : IFromRawJson<MessagingInboundMessagePayload>
{
    /// <inheritdoc/>
    public MessagingInboundMessagePayload FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingInboundMessagePayload.FromRawUnchecked(rawData);
}

/// <summary>
/// Message body for RCS and WhatsApp. RCS messages contain text, user_file, location,
/// or suggestion_response. For WhatsApp edits and revocations, inspect type and
/// the corresponding edit or revoke object.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Body, BodyFromRaw>))]
public sealed record class Body : JsonModel
{
    /// <summary>
    /// Telnyx identifier for this webhook message.
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
    /// Details for an edited WhatsApp message.
    /// </summary>
    public Edit? Edit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Edit>(
                "edit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("edit", value);
        }
    }

    /// <summary>
    /// Meta WhatsApp message identifier for this webhook event.
    /// </summary>
    public string? ForeignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "foreign_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("foreign_id", value);
        }
    }

    /// <summary>
    /// WhatsApp sender in E.164 format.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// Location shared in an RCS message.
    /// </summary>
    public Location? Location {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Location>(
                "location"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    /// <summary>
    /// Details for a revoked WhatsApp message.
    /// </summary>
    public Revoke? Revoke {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Revoke>(
                "revoke"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("revoke", value);
        }
    }

    /// <summary>
    /// Selected RCS suggestion.
    /// </summary>
    public SuggestionResponse? SuggestionResponse {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SuggestionResponse>(
                "suggestion_response"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("suggestion_response", value);
        }
    }

    /// <summary>
    /// RCS text string or WhatsApp text object.
    /// </summary>
    public Text? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Text>(
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

    /// <summary>
    /// Unix timestamp supplied by Meta.
    /// </summary>
    public string? Timestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "timestamp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <summary>
    /// WhatsApp message body type. Edit and revoke events use `edit` and `revoke`, respectively.
    /// </summary>
    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// RCS file attachment and optional thumbnail.
    /// </summary>
    public UserFile? UserFile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserFile>(
                "user_file"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_file", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Edit?.Validate();
        _ = this.ForeignID;
        _ = this.From;
        this.Location?.Validate();
        this.Revoke?.Validate();
        this.SuggestionResponse?.Validate();
        this.Text?.Validate();
        _ = this.Timestamp;
        _ = this.Type;
        this.UserFile?.Validate();
    }

    public Body ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Body (Body body) : base(body)
    {  }
    #pragma warning restore CS8618

    public Body (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Body (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BodyFromRaw.FromRawUnchecked"/>
    public static Body FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class BodyFromRaw : IFromRawJson<Body>
{
    /// <inheritdoc/>
    public Body FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Body.FromRawUnchecked(rawData);
}/// <summary>
/// Details for an edited WhatsApp message.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Edit, EditFromRaw>))]
public sealed record class Edit : JsonModel
{
    /// <summary>
    /// Replacement WhatsApp message content. Its shape depends on the message type.
    /// </summary>
    public required Generic::IReadOnlyDictionary<string, JsonElement> Message {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "message"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "message",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Telnyx message ID when a mapping exists, otherwise the original Meta WhatsApp
    /// message ID. Treat this value as opaque.
    /// </summary>
    public required string OriginalMessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "original_message_id"
            );
        }
        init { this._rawData.Set("original_message_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.OriginalMessageID;
    }

    public Edit ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Edit (Edit edit) : base(edit)
    {  }
    #pragma warning restore CS8618

    public Edit (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Edit (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EditFromRaw.FromRawUnchecked"/>
    public static Edit FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EditFromRaw : IFromRawJson<Edit>
{
    /// <inheritdoc/>
    public Edit FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Edit.FromRawUnchecked(rawData);
}/// <summary>
/// Location shared in an RCS message.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Location, LocationFromRaw>))]
public sealed record class Location : JsonModel
{
    public double? Latitude {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "latitude"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("latitude", value);
        }
    }

    public double? Longitude {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "longitude"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("longitude", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Latitude;
        _ = this.Longitude;
    }

    public Location ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Location (Location location) : base(location)
    {  }
    #pragma warning restore CS8618

    public Location (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Location (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LocationFromRaw.FromRawUnchecked"/>
    public static Location FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class LocationFromRaw : IFromRawJson<Location>
{
    /// <inheritdoc/>
    public Location FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Location.FromRawUnchecked(rawData);
}/// <summary>
/// Details for a revoked WhatsApp message.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Revoke, RevokeFromRaw>))]
public sealed record class Revoke : JsonModel
{
    /// <summary>
    /// Telnyx message ID when a mapping exists, otherwise the original Meta WhatsApp
    /// message ID. Treat this value as opaque.
    /// </summary>
    public required string OriginalMessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "original_message_id"
            );
        }
        init { this._rawData.Set("original_message_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.OriginalMessageID; }

    public Revoke ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Revoke (Revoke revoke) : base(revoke)
    {  }
    #pragma warning restore CS8618

    public Revoke (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Revoke (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RevokeFromRaw.FromRawUnchecked"/>
    public static Revoke FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Revoke (string originalMessageID) : this()
    { this.OriginalMessageID = originalMessageID; }
}class RevokeFromRaw : IFromRawJson<Revoke>
{
    /// <inheritdoc/>
    public Revoke FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Revoke.FromRawUnchecked(rawData);
}/// <summary>
/// Selected RCS suggestion.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SuggestionResponse, SuggestionResponseFromRaw>))]
public sealed record class SuggestionResponse : JsonModel
{
    public string? PostbackData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postback_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postback_data", value);
        }
    }

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
    {
        _ = this.PostbackData;
        _ = this.Text;
    }

    public SuggestionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SuggestionResponse (SuggestionResponse suggestionResponse) : base(
        suggestionResponse
    )
    {  }
    #pragma warning restore CS8618

    public SuggestionResponse (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SuggestionResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SuggestionResponseFromRaw.FromRawUnchecked"/>
    public static SuggestionResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SuggestionResponseFromRaw : IFromRawJson<SuggestionResponse>
{
    /// <inheritdoc/>
    public SuggestionResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SuggestionResponse.FromRawUnchecked(rawData);
}/// <summary>
/// RCS text string or WhatsApp text object.
/// </summary>
[JsonConverter(typeof(TextConverter))]
public record class Text : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Text (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Text (TextBody value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Text (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TextBody"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTextBody(out var value)) {
///     // `value` is of type `TextBody`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTextBody([NotNullWhen(true)] out TextBody? value)
    {
        value =this.Value as TextBody ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (string value) =&gt; {...},
///     (TextBody value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string, System::Action<TextBody> textBody
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case TextBody value:
                textBody(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Text");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (string value) =&gt; {...},
///     (TextBody value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (System::Func<string, T> @string, System::Func<TextBody, T> textBody)
    {
        return this.Value switch
        {
            string value=>@string(value),
            TextBody value=>textBody(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Text")
        } ;
    }

    public static implicit operator Text (string value)=> new(value) ;

    public static implicit operator Text (TextBody value)=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of Text");
        }
        this.Switch((_) => {}, (textBody) => textBody.Validate());
    }

    public virtual bool Equals(Text? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { string _=>0, TextBody _=>1, _ =>-1 } ;
    }
}sealed class TextConverter : JsonConverter<Text>
{
    public override Text? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<TextBody>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, Text value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<TextBody, TextBodyFromRaw>))]
public sealed record class TextBody : JsonModel
{
    public string? Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Body; }

    public TextBody ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextBody (TextBody textBody) : base(textBody)
    {  }
    #pragma warning restore CS8618

    public TextBody (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TextBody (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TextBodyFromRaw.FromRawUnchecked"/>
    public static TextBody FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TextBodyFromRaw : IFromRawJson<TextBody>
{
    /// <inheritdoc/>
    public TextBody FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TextBody.FromRawUnchecked(rawData);
}/// <summary>
/// RCS file attachment and optional thumbnail.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserFile, UserFileFromRaw>))]
public sealed record class UserFile : JsonModel
{
    public Payload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Payload>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload", value);
        }
    }

    public Thumbnail? Thumbnail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Thumbnail>(
                "thumbnail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("thumbnail", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Payload?.Validate();
        this.Thumbnail?.Validate();
    }

    public UserFile ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserFile (UserFile userFile) : base(userFile)
    {  }
    #pragma warning restore CS8618

    public UserFile (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserFile (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserFileFromRaw.FromRawUnchecked"/>
    public static UserFile FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UserFileFromRaw : IFromRawJson<UserFile>
{
    /// <inheritdoc/>
    public UserFile FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserFile.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Payload, PayloadFromRaw>))]
public sealed record class Payload : JsonModel
{
    public string? FileName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "file_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("file_name", value);
        }
    }

    public long? FileSizeBytes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "file_size_bytes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("file_size_bytes", value);
        }
    }

    public string? FileUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "file_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("file_uri", value);
        }
    }

    public string? MimeType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mime_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mime_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileName;
        _ = this.FileSizeBytes;
        _ = this.FileUri;
        _ = this.MimeType;
    }

    public Payload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Payload (Payload payload) : base(payload)
    {  }
    #pragma warning restore CS8618

    public Payload (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Payload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PayloadFromRaw.FromRawUnchecked"/>
    public static Payload FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PayloadFromRaw : IFromRawJson<Payload>
{
    /// <inheritdoc/>
    public Payload FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Payload.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Thumbnail, ThumbnailFromRaw>))]
public sealed record class Thumbnail : JsonModel
{
    public string? FileName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "file_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("file_name", value);
        }
    }

    public long? FileSizeBytes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "file_size_bytes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("file_size_bytes", value);
        }
    }

    public string? FileUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "file_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("file_uri", value);
        }
    }

    public string? MimeType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mime_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mime_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileName;
        _ = this.FileSizeBytes;
        _ = this.FileUri;
        _ = this.MimeType;
    }

    public Thumbnail ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Thumbnail (Thumbnail thumbnail) : base(thumbnail)
    {  }
    #pragma warning restore CS8618

    public Thumbnail (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Thumbnail (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ThumbnailFromRaw.FromRawUnchecked"/>
    public static Thumbnail FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ThumbnailFromRaw : IFromRawJson<Thumbnail>
{
    /// <inheritdoc/>
    public Thumbnail FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Thumbnail.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Cc, CcFromRaw>))]
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

    public Cc (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cc (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CcFromRaw.FromRawUnchecked"/>
    public static Cc FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CcFromRaw : IFromRawJson<Cc>
{
    /// <inheritdoc/>
    public Cc FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
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
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Queued,
    Sending,
    Sent,
    Delivered,
    SendingFailed,
    DeliveryFailed,
    DeliveryUnconfirmed
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
            "queued"=>Status.Queued,
            "sending"=>Status.Sending,
            "sent"=>Status.Sent,
            "delivered"=>Status.Delivered,
            "sending_failed"=>Status.SendingFailed,
            "delivery_failed"=>Status.DeliveryFailed,
            "delivery_unconfirmed"=>Status.DeliveryUnconfirmed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Queued=>"queued",
            Status.Sending=>"sending",
            Status.Sent=>"sent",
            Status.Delivered=>"delivered",
            Status.SendingFailed=>"sending_failed",
            Status.DeliveryFailed=>"delivery_failed",
            Status.DeliveryUnconfirmed=>"delivery_unconfirmed",
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
        init { this._rawData.Set("amount", value); }
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
        init { this._rawData.Set("currency", value); }
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

    public Cost (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostFromRaw.FromRawUnchecked"/>
    public static Cost FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CostFromRaw : IFromRawJson<Cost>
{
    /// <inheritdoc/>
    public Cost FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
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

    public CostBreakdown (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CostBreakdown (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostBreakdownFromRaw.FromRawUnchecked"/>
    public static CostBreakdown FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CostBreakdownFromRaw : IFromRawJson<CostBreakdown>
{
    /// <inheritdoc/>
    public CostBreakdown FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
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

    public CarrierFee (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CarrierFee (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CarrierFeeFromRaw.FromRawUnchecked"/>
    public static CarrierFee FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CarrierFeeFromRaw : IFromRawJson<CarrierFee>
{
    /// <inheritdoc/>
    public CarrierFee FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
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

    public Rate (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Rate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RateFromRaw.FromRawUnchecked"/>
    public static Rate FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RateFromRaw : IFromRawJson<Rate>
{
    /// <inheritdoc/>
    public Rate FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
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

    public From (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    From (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FromFromRaw.FromRawUnchecked"/>
    public static From FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FromFromRaw : IFromRawJson<From>
{
    /// <inheritdoc/>
    public From FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>From.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the sender.
/// </summary>
[JsonConverter(typeof(FromLineTypeConverter))]
public enum FromLineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined, LongCode
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
            "long_code"=>FromLineType.LongCode,
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
            FromLineType.LongCode=>"long_code",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(FromStatusConverter))]
public enum FromStatus
{
    Received, Delivered, WebhookDelivered
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
            "webhook_delivered"=>FromStatus.WebhookDelivered,
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
            FromStatus.WebhookDelivered=>"webhook_delivered",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MessagingInboundMessagePayloadMedia, MessagingInboundMessagePayloadMediaFromRaw>))]
public sealed record class MessagingInboundMessagePayloadMedia : JsonModel
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

    public MessagingInboundMessagePayloadMedia ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingInboundMessagePayloadMedia (
        MessagingInboundMessagePayloadMedia messagingInboundMessagePayloadMedia
    ) : base(messagingInboundMessagePayloadMedia)
    {  }
    #pragma warning restore CS8618

    public MessagingInboundMessagePayloadMedia (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingInboundMessagePayloadMedia (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingInboundMessagePayloadMediaFromRaw.FromRawUnchecked"/>
    public static MessagingInboundMessagePayloadMedia FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingInboundMessagePayloadMediaFromRaw : IFromRawJson<MessagingInboundMessagePayloadMedia>
{
    /// <inheritdoc/>
    public MessagingInboundMessagePayloadMedia FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingInboundMessagePayloadMedia.FromRawUnchecked(rawData);
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
}/// <summary>
/// Receiving address. SMS, MMS and RCS webhooks use an array of recipients. RCS recipients
/// are identified by agent_id and agent_name. WhatsApp webhooks use one E.164 phone number.
/// </summary>
[JsonConverter(typeof(ToConverter))]
public record class To : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public To (
        Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public To (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>UnnamedSchemaWithArrayParent0</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickUnnamedSchemaWithArrayParent0s(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;UnnamedSchemaWithArrayParent0&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickUnnamedSchemaWithArrayParent0s(
        [NotNullWhen(true)] out Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (Generic::IReadOnlyList&lt;UnnamedSchemaWithArrayParent0&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0>> unnamedSchemaWithArrayParent0s,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0> value:
                unnamedSchemaWithArrayParent0s(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of To");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (Generic::IReadOnlyList&lt;UnnamedSchemaWithArrayParent0&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0>, T> unnamedSchemaWithArrayParent0s,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0> value=>unnamedSchemaWithArrayParent0s(value),
            string value=>@string(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of To")
        } ;
    }

    public static implicit operator To (
        Generic::List<UnnamedSchemaWithArrayParent0> value
    )=> new((Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0>)value) ;

    public static implicit operator To (string value)=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of To");
        }
        this.Switch((unnamedSchemaWithArrayParent0s) => {foreach (var item in unnamedSchemaWithArrayParent0s)
        {
            item.Validate();
        }},
        (_) => {});
    }

    public virtual bool Equals(To? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0> _=>0,
            string _=>1,
            _ =>-1
        } ;
    }
}sealed class ToConverter : JsonConverter<To>
{
    public override To? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<UnnamedSchemaWithArrayParent0>>(element, options);
            if (deserialized != null) {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, To value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<UnnamedSchemaWithArrayParent0, UnnamedSchemaWithArrayParent0FromRaw>))]
public sealed record class UnnamedSchemaWithArrayParent0 : JsonModel
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
    public ApiEnum<string, UnnamedSchemaWithArrayParent0LineType>? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UnnamedSchemaWithArrayParent0LineType>>(
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

    public ApiEnum<string, UnnamedSchemaWithArrayParent0Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UnnamedSchemaWithArrayParent0Status>>(
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
        _ = this.AgentID;
        _ = this.AgentName;
        _ = this.Carrier;
        this.LineType?.Validate();
        _ = this.PhoneNumber;
        this.Status?.Validate();
    }

    public UnnamedSchemaWithArrayParent0 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnnamedSchemaWithArrayParent0 (
        UnnamedSchemaWithArrayParent0 unnamedSchemaWithArrayParent0
    ) : base(unnamedSchemaWithArrayParent0)
    {  }
    #pragma warning restore CS8618

    public UnnamedSchemaWithArrayParent0 (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UnnamedSchemaWithArrayParent0 (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UnnamedSchemaWithArrayParent0FromRaw.FromRawUnchecked"/>
    public static UnnamedSchemaWithArrayParent0 FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UnnamedSchemaWithArrayParent0FromRaw : IFromRawJson<UnnamedSchemaWithArrayParent0>
{
    /// <inheritdoc/>
    public UnnamedSchemaWithArrayParent0 FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UnnamedSchemaWithArrayParent0.FromRawUnchecked(rawData);
}/// <summary>
/// The line-type of the receiver.
/// </summary>
[JsonConverter(typeof(UnnamedSchemaWithArrayParent0LineTypeConverter))]
public enum UnnamedSchemaWithArrayParent0LineType
{
    Wireline, Wireless, VoWiFi, VoIP, PrePaidWireless, Undefined
}sealed class UnnamedSchemaWithArrayParent0LineTypeConverter : JsonConverter<UnnamedSchemaWithArrayParent0LineType>
{
    public override UnnamedSchemaWithArrayParent0LineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Wireline"=>UnnamedSchemaWithArrayParent0LineType.Wireline,
            "Wireless"=>UnnamedSchemaWithArrayParent0LineType.Wireless,
            "VoWiFi"=>UnnamedSchemaWithArrayParent0LineType.VoWiFi,
            "VoIP"=>UnnamedSchemaWithArrayParent0LineType.VoIP,
            "Pre-Paid Wireless"=>UnnamedSchemaWithArrayParent0LineType.PrePaidWireless,
            ""=>UnnamedSchemaWithArrayParent0LineType.Undefined,
            _ =>(UnnamedSchemaWithArrayParent0LineType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0LineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UnnamedSchemaWithArrayParent0LineType.Wireline=>"Wireline",
            UnnamedSchemaWithArrayParent0LineType.Wireless=>"Wireless",
            UnnamedSchemaWithArrayParent0LineType.VoWiFi=>"VoWiFi",
            UnnamedSchemaWithArrayParent0LineType.VoIP=>"VoIP",
            UnnamedSchemaWithArrayParent0LineType.PrePaidWireless=>"Pre-Paid Wireless",
            UnnamedSchemaWithArrayParent0LineType.Undefined=>"",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(UnnamedSchemaWithArrayParent0StatusConverter))]
public enum UnnamedSchemaWithArrayParent0Status
{
    Queued,
    Sending,
    Sent,
    Delivered,
    SendingFailed,
    DeliveryFailed,
    DeliveryUnconfirmed,
    WebhookDelivered
}sealed class UnnamedSchemaWithArrayParent0StatusConverter : JsonConverter<UnnamedSchemaWithArrayParent0Status>
{
    public override UnnamedSchemaWithArrayParent0Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>UnnamedSchemaWithArrayParent0Status.Queued,
            "sending"=>UnnamedSchemaWithArrayParent0Status.Sending,
            "sent"=>UnnamedSchemaWithArrayParent0Status.Sent,
            "delivered"=>UnnamedSchemaWithArrayParent0Status.Delivered,
            "sending_failed"=>UnnamedSchemaWithArrayParent0Status.SendingFailed,
            "delivery_failed"=>UnnamedSchemaWithArrayParent0Status.DeliveryFailed,
            "delivery_unconfirmed"=>UnnamedSchemaWithArrayParent0Status.DeliveryUnconfirmed,
            "webhook_delivered"=>UnnamedSchemaWithArrayParent0Status.WebhookDelivered,
            _ =>(UnnamedSchemaWithArrayParent0Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UnnamedSchemaWithArrayParent0Status.Queued=>"queued",
            UnnamedSchemaWithArrayParent0Status.Sending=>"sending",
            UnnamedSchemaWithArrayParent0Status.Sent=>"sent",
            UnnamedSchemaWithArrayParent0Status.Delivered=>"delivered",
            UnnamedSchemaWithArrayParent0Status.SendingFailed=>"sending_failed",
            UnnamedSchemaWithArrayParent0Status.DeliveryFailed=>"delivery_failed",
            UnnamedSchemaWithArrayParent0Status.DeliveryUnconfirmed=>"delivery_unconfirmed",
            UnnamedSchemaWithArrayParent0Status.WebhookDelivered=>"webhook_delivered",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The messaging channel used for the message.
/// </summary>
[JsonConverter(typeof(MessagingInboundMessagePayloadTypeConverter))]
public enum MessagingInboundMessagePayloadType
{
    Sms, Mms, Whatsapp, Rcs
}sealed class MessagingInboundMessagePayloadTypeConverter : JsonConverter<MessagingInboundMessagePayloadType>
{
    public override MessagingInboundMessagePayloadType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>MessagingInboundMessagePayloadType.Sms,
            "MMS"=>MessagingInboundMessagePayloadType.Mms,
            "WHATSAPP"=>MessagingInboundMessagePayloadType.Whatsapp,
            "RCS"=>MessagingInboundMessagePayloadType.Rcs,
            _ =>(MessagingInboundMessagePayloadType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingInboundMessagePayloadType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingInboundMessagePayloadType.Sms=>"SMS",
            MessagingInboundMessagePayloadType.Mms=>"MMS",
            MessagingInboundMessagePayloadType.Whatsapp=>"WHATSAPP",
            MessagingInboundMessagePayloadType.Rcs=>"RCS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}