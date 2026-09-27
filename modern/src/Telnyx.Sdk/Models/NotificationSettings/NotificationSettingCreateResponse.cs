using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationSettings;

[JsonConverter(typeof(JsonModelConverter<NotificationSettingCreateResponse, NotificationSettingCreateResponseFromRaw>))]
public sealed record class NotificationSettingCreateResponse : JsonModel
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

    public NotificationSettingCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationSettingCreateResponse (
        NotificationSettingCreateResponse notificationSettingCreateResponse
    ) : base(notificationSettingCreateResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationSettingCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationSettingCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationSettingCreateResponseFromRaw.FromRawUnchecked"/>
    public static NotificationSettingCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationSettingCreateResponseFromRaw : IFromRawJson<NotificationSettingCreateResponse>
{
    /// <inheritdoc/>
    public NotificationSettingCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationSettingCreateResponse.FromRawUnchecked(rawData);
}