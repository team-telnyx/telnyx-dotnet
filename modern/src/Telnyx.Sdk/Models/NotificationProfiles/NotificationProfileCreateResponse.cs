using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationProfiles;

[JsonConverter(typeof(JsonModelConverter<NotificationProfileCreateResponse, NotificationProfileCreateResponseFromRaw>))]
public sealed record class NotificationProfileCreateResponse : JsonModel
{
    /// <summary>
    /// A Collection of Notification Channels
    /// </summary>
    public NotificationProfile? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotificationProfile>(
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

    public NotificationProfileCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationProfileCreateResponse (
        NotificationProfileCreateResponse notificationProfileCreateResponse
    ) : base(notificationProfileCreateResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationProfileCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationProfileCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationProfileCreateResponseFromRaw.FromRawUnchecked"/>
    public static NotificationProfileCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationProfileCreateResponseFromRaw : IFromRawJson<NotificationProfileCreateResponse>
{
    /// <inheritdoc/>
    public NotificationProfileCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationProfileCreateResponse.FromRawUnchecked(rawData);
}