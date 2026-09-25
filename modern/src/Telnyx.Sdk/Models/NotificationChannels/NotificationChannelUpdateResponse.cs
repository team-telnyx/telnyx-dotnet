using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationChannels;

[JsonConverter(typeof(JsonModelConverter<NotificationChannelUpdateResponse, NotificationChannelUpdateResponseFromRaw>))]
public sealed record class NotificationChannelUpdateResponse : JsonModel
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

    public NotificationChannelUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationChannelUpdateResponse (
        NotificationChannelUpdateResponse notificationChannelUpdateResponse
    ) : base(notificationChannelUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationChannelUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationChannelUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationChannelUpdateResponseFromRaw.FromRawUnchecked"/>
    public static NotificationChannelUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationChannelUpdateResponseFromRaw : IFromRawJson<NotificationChannelUpdateResponse>
{
    /// <inheritdoc/>
    public NotificationChannelUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationChannelUpdateResponse.FromRawUnchecked(rawData);
}