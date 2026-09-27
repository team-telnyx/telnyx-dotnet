using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationChannels;

[JsonConverter(typeof(JsonModelConverter<NotificationChannelDeleteResponse, NotificationChannelDeleteResponseFromRaw>))]
public sealed record class NotificationChannelDeleteResponse : JsonModel
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

    public NotificationChannelDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationChannelDeleteResponse (
        NotificationChannelDeleteResponse notificationChannelDeleteResponse
    ) : base(notificationChannelDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationChannelDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationChannelDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationChannelDeleteResponseFromRaw.FromRawUnchecked"/>
    public static NotificationChannelDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationChannelDeleteResponseFromRaw : IFromRawJson<NotificationChannelDeleteResponse>
{
    /// <inheritdoc/>
    public NotificationChannelDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationChannelDeleteResponse.FromRawUnchecked(rawData);
}