using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationChannels;

[JsonConverter(typeof(JsonModelConverter<NotificationChannelCreateResponse, NotificationChannelCreateResponseFromRaw>))]
public sealed record class NotificationChannelCreateResponse : JsonModel
{
    /// <summary>
    /// A Notification Channel
    /// </summary>
    public NotificationChannelNotificationChannel? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotificationChannelNotificationChannel>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public NotificationChannelCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationChannelCreateResponse (
        NotificationChannelCreateResponse notificationChannelCreateResponse
    ) : base(notificationChannelCreateResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationChannelCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationChannelCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationChannelCreateResponseFromRaw.FromRawUnchecked"/>
    public static NotificationChannelCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationChannelCreateResponseFromRaw : IFromRawJson<NotificationChannelCreateResponse>
{
    /// <inheritdoc/>
    public NotificationChannelCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationChannelCreateResponse.FromRawUnchecked(rawData);
}