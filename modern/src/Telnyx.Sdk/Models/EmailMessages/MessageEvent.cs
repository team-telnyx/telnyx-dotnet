using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailEvents;

namespace Telnyx.Sdk.Models.EmailMessages;

/// <summary>
/// An event on the per-message events endpoint. The legacy event_type and additive
/// canonical_event_type are email.-prefixed. The deprecated type preserves the bare
/// stored event name for compatibility.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageEvent, MessageEventFromRaw>))]
public sealed record class MessageEvent : JsonModel
{
    /// <summary>
    /// Additive canonical outcome name, prefixed with `email.`. Gateway rejection
    /// is `email.gw_reject`, ambiguous injection timeout is `email.injection_timeout`,
    /// and MTA expiration is `email.expired`. Unchanged outcomes retain their names.
    /// Existing stored rows are translated only when recorded payload evidence proves
    /// the outcome; a legacy failed row is not guessed or sharpened.
    /// </summary>
    public required string CanonicalEventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "canonical_event_type"
            );
        }
        init { this._rawData.Set("canonical_event_type", value); }
    }

    /// <summary>
    /// Legacy customer-visible event name, prefixed with `email.`. Gateway rejections
    /// render `email.failed`; MTA expirations render `email.bounced`. Webhook subscription
    /// allowlists match the legacy name.
    /// </summary>
    public required string EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "event_type"
            );
        }
        init { this._rawData.Set("event_type", value); }
    }

    public required DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    /// <summary>
    /// Bare stored event names returned by message history. In addition to the normal
    /// send and delivery lifecycle, polling can expose suppression, scan, and quarantine
    /// lifecycle rows. Sharp canonical names gw_reject, injection_timeout, and expired
    /// distinguish gateway rejection, ambiguous injection timeout, and MTA expiration.
    /// The failed and bounced names remain valid for system/admin failures and hard
    /// bounces respectively. Existing stored rows retain their original names.
    /// </summary>
    [Obsolete("deprecated")]
    public required ApiEnum<string, EmailEventType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EmailEventType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "payload",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanonicalEventType;
        _ = this.EventType;
        _ = this.OccurredAt;
        this.Type.Validate();
        _ = this.Payload;
    }

    [Obsolete("Required properties are deprecated: type")]
    public MessageEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers][Obsolete("Required properties are deprecated: type")]
    public MessageEvent (MessageEvent messageEvent) : base(messageEvent)
    {  }
    #pragma warning restore CS8618

    [Obsolete("Required properties are deprecated: type")]
    public MessageEvent (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [Obsolete("Required properties are deprecated: type")][SetsRequiredMembers]
    MessageEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageEventFromRaw.FromRawUnchecked"/>
    public static MessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageEventFromRaw : IFromRawJson<MessageEvent>
{
    /// <inheritdoc/>
    public MessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageEvent.FromRawUnchecked(rawData);
}