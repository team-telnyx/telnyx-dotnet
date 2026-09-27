using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationProfiles;

[JsonConverter(typeof(JsonModelConverter<NotificationProfileUpdateResponse, NotificationProfileUpdateResponseFromRaw>))]
public sealed record class NotificationProfileUpdateResponse : JsonModel
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

    public NotificationProfileUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationProfileUpdateResponse (
        NotificationProfileUpdateResponse notificationProfileUpdateResponse
    ) : base(notificationProfileUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationProfileUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationProfileUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationProfileUpdateResponseFromRaw.FromRawUnchecked"/>
    public static NotificationProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationProfileUpdateResponseFromRaw : IFromRawJson<NotificationProfileUpdateResponse>
{
    /// <inheritdoc/>
    public NotificationProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationProfileUpdateResponse.FromRawUnchecked(rawData);
}