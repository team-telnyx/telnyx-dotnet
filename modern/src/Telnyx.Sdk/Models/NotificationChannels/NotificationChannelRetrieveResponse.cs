using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationChannels;

[JsonConverter(typeof(JsonModelConverter<NotificationChannelRetrieveResponse, NotificationChannelRetrieveResponseFromRaw>))]
public sealed record class NotificationChannelRetrieveResponse : JsonModel
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

    public NotificationChannelRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationChannelRetrieveResponse (
        NotificationChannelRetrieveResponse notificationChannelRetrieveResponse
    ) : base(notificationChannelRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationChannelRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationChannelRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationChannelRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NotificationChannelRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationChannelRetrieveResponseFromRaw : IFromRawJson<NotificationChannelRetrieveResponse>
{
    /// <inheritdoc/>
    public NotificationChannelRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationChannelRetrieveResponse.FromRawUnchecked(rawData);
}