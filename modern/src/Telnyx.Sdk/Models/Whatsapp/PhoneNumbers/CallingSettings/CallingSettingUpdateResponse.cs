using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.CallingSettings;

[JsonConverter(typeof(JsonModelConverter<CallingSettingUpdateResponse, CallingSettingUpdateResponseFromRaw>))]
public sealed record class CallingSettingUpdateResponse : JsonModel
{
    public WhatsappCallingSettingsData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappCallingSettingsData>(
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

    public CallingSettingUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallingSettingUpdateResponse (
        CallingSettingUpdateResponse callingSettingUpdateResponse
    ) : base(callingSettingUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public CallingSettingUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallingSettingUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallingSettingUpdateResponseFromRaw.FromRawUnchecked"/>
    public static CallingSettingUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallingSettingUpdateResponseFromRaw : IFromRawJson<CallingSettingUpdateResponse>
{
    /// <inheritdoc/>
    public CallingSettingUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallingSettingUpdateResponse.FromRawUnchecked(rawData);
}