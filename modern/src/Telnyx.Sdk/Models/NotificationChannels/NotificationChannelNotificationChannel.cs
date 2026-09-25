using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NotificationChannels;

/// <summary>
/// A Notification Channel
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NotificationChannelNotificationChannel, NotificationChannelNotificationChannelFromRaw>))]
public sealed record class NotificationChannelNotificationChannel : JsonModel
{
    /// <summary>
    /// A UUID.
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
    /// The destination associated with the channel type.
    /// </summary>
    public string? ChannelDestination {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "channel_destination"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_destination", value);
        }
    }

    /// <summary>
    /// A Channel Type ID
    /// </summary>
    public ApiEnum<string, NotificationChannelNotificationChannelChannelTypeID>? ChannelTypeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NotificationChannelNotificationChannelChannelTypeID>>(
                "channel_type_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_type_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// A UUID reference to the associated Notification Profile.
    /// </summary>
    public string? NotificationProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "notification_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("notification_profile_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChannelDestination;
        this.ChannelTypeID?.Validate();
        _ = this.CreatedAt;
        _ = this.NotificationProfileID;
        _ = this.UpdatedAt;
    }

    public NotificationChannelNotificationChannel ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationChannelNotificationChannel (
        NotificationChannelNotificationChannel notificationChannelNotificationChannel
    ) : base(notificationChannelNotificationChannel)
    {  }
    #pragma warning restore CS8618

    public NotificationChannelNotificationChannel (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationChannelNotificationChannel (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationChannelNotificationChannelFromRaw.FromRawUnchecked"/>
    public static NotificationChannelNotificationChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationChannelNotificationChannelFromRaw : IFromRawJson<NotificationChannelNotificationChannel>
{
    /// <inheritdoc/>
    public NotificationChannelNotificationChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationChannelNotificationChannel.FromRawUnchecked(rawData);
}

/// <summary>
/// A Channel Type ID
/// </summary>
[JsonConverter(typeof(NotificationChannelNotificationChannelChannelTypeIDConverter))]
public enum NotificationChannelNotificationChannelChannelTypeID
{
    Sms, Voice, Email, Webhook
}sealed class NotificationChannelNotificationChannelChannelTypeIDConverter : JsonConverter<NotificationChannelNotificationChannelChannelTypeID>
{
    public override NotificationChannelNotificationChannelChannelTypeID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms"=>NotificationChannelNotificationChannelChannelTypeID.Sms,
            "voice"=>NotificationChannelNotificationChannelChannelTypeID.Voice,
            "email"=>NotificationChannelNotificationChannelChannelTypeID.Email,
            "webhook"=>NotificationChannelNotificationChannelChannelTypeID.Webhook,
            _ =>(NotificationChannelNotificationChannelChannelTypeID)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationChannelNotificationChannelChannelTypeID value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NotificationChannelNotificationChannelChannelTypeID.Sms=>"sms",
            NotificationChannelNotificationChannelChannelTypeID.Voice=>"voice",
            NotificationChannelNotificationChannelChannelTypeID.Email=>"email",
            NotificationChannelNotificationChannelChannelTypeID.Webhook=>"webhook",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}