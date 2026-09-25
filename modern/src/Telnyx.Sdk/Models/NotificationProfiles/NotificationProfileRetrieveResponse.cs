using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationProfiles;

[JsonConverter(typeof(JsonModelConverter<NotificationProfileRetrieveResponse, NotificationProfileRetrieveResponseFromRaw>))]
public sealed record class NotificationProfileRetrieveResponse : JsonModel
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

    public NotificationProfileRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationProfileRetrieveResponse (
        NotificationProfileRetrieveResponse notificationProfileRetrieveResponse
    ) : base(notificationProfileRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationProfileRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationProfileRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationProfileRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NotificationProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationProfileRetrieveResponseFromRaw : IFromRawJson<NotificationProfileRetrieveResponse>
{
    /// <inheritdoc/>
    public NotificationProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationProfileRetrieveResponse.FromRawUnchecked(rawData);
}