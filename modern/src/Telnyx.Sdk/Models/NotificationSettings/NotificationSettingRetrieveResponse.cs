using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationSettings;

[JsonConverter(typeof(JsonModelConverter<NotificationSettingRetrieveResponse, NotificationSettingRetrieveResponseFromRaw>))]
public sealed record class NotificationSettingRetrieveResponse : JsonModel
{
    public NotificationSetting? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotificationSetting>(
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

    public NotificationSettingRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationSettingRetrieveResponse (
        NotificationSettingRetrieveResponse notificationSettingRetrieveResponse
    ) : base(notificationSettingRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationSettingRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationSettingRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationSettingRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NotificationSettingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationSettingRetrieveResponseFromRaw : IFromRawJson<NotificationSettingRetrieveResponse>
{
    /// <inheritdoc/>
    public NotificationSettingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationSettingRetrieveResponse.FromRawUnchecked(rawData);
}