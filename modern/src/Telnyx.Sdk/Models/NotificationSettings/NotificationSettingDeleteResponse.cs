using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NotificationSettings;

[JsonConverter(typeof(JsonModelConverter<NotificationSettingDeleteResponse, NotificationSettingDeleteResponseFromRaw>))]
public sealed record class NotificationSettingDeleteResponse : JsonModel
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

    public NotificationSettingDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationSettingDeleteResponse (
        NotificationSettingDeleteResponse notificationSettingDeleteResponse
    ) : base(notificationSettingDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationSettingDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationSettingDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationSettingDeleteResponseFromRaw.FromRawUnchecked"/>
    public static NotificationSettingDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationSettingDeleteResponseFromRaw : IFromRawJson<NotificationSettingDeleteResponse>
{
    /// <inheritdoc/>
    public NotificationSettingDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationSettingDeleteResponse.FromRawUnchecked(rawData);
}