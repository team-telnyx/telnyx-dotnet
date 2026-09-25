using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.CallingSettings;

[JsonConverter(typeof(JsonModelConverter<CallingSettingRetrieveResponse, CallingSettingRetrieveResponseFromRaw>))]
public sealed record class CallingSettingRetrieveResponse : JsonModel
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

    public CallingSettingRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallingSettingRetrieveResponse (
        CallingSettingRetrieveResponse callingSettingRetrieveResponse
    ) : base(callingSettingRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public CallingSettingRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallingSettingRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallingSettingRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CallingSettingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallingSettingRetrieveResponseFromRaw : IFromRawJson<CallingSettingRetrieveResponse>
{
    /// <inheritdoc/>
    public CallingSettingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallingSettingRetrieveResponse.FromRawUnchecked(rawData);
}