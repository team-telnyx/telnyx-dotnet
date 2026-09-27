using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationProfiles;

[JsonConverter(typeof(JsonModelConverter<NotificationProfileDeleteResponse, NotificationProfileDeleteResponseFromRaw>))]
public sealed record class NotificationProfileDeleteResponse : JsonModel
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

    public NotificationProfileDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationProfileDeleteResponse (
        NotificationProfileDeleteResponse notificationProfileDeleteResponse
    ) : base(notificationProfileDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationProfileDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationProfileDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationProfileDeleteResponseFromRaw.FromRawUnchecked"/>
    public static NotificationProfileDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationProfileDeleteResponseFromRaw : IFromRawJson<NotificationProfileDeleteResponse>
{
    /// <inheritdoc/>
    public NotificationProfileDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationProfileDeleteResponse.FromRawUnchecked(rawData);
}