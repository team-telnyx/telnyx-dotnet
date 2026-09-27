using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<MessagingSettings, MessagingSettingsFromRaw>))]
public sealed record class MessagingSettings : JsonModel
{
    /// <summary>
    /// If more than this many minutes have passed since the last message, the assistant
    /// will start a new conversation instead of continuing the existing one.
    /// </summary>
    public long? ConversationInactivityMinutes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "conversation_inactivity_minutes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_inactivity_minutes", value);
        }
    }

    /// <summary>
    /// Default Messaging Profile used for messaging exchanges with your assistant.
    /// This will be created automatically on assistant creation.
    /// </summary>
    public string? DefaultMessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "default_messaging_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_messaging_profile_id", value);
        }
    }

    /// <summary>
    /// The URL where webhooks related to delivery statused for assistant messages
    /// will be sent.
    /// </summary>
    public string? DeliveryStatusWebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "delivery_status_webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("delivery_status_webhook_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConversationInactivityMinutes;
        _ = this.DefaultMessagingProfileID;
        _ = this.DeliveryStatusWebhookUrl;
    }

    public MessagingSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingSettings (MessagingSettings messagingSettings) : base(
        messagingSettings
    )
    {  }
    #pragma warning restore CS8618

    public MessagingSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingSettingsFromRaw.FromRawUnchecked"/>
    public static MessagingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingSettingsFromRaw : IFromRawJson<MessagingSettings>
{
    /// <inheritdoc/>
    public MessagingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingSettings.FromRawUnchecked(rawData);
}