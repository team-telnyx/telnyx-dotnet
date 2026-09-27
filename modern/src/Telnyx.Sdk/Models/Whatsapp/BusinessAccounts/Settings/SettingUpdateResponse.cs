using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.BusinessAccounts.Settings;

[JsonConverter(typeof(JsonModelConverter<SettingUpdateResponse, SettingUpdateResponseFromRaw>))]
public sealed record class SettingUpdateResponse : JsonModel
{
    public WabaSettings? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WabaSettings>(
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

    public SettingUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SettingUpdateResponse (
        SettingUpdateResponse settingUpdateResponse
    ) : base(settingUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public SettingUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SettingUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SettingUpdateResponseFromRaw.FromRawUnchecked"/>
    public static SettingUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SettingUpdateResponseFromRaw : IFromRawJson<SettingUpdateResponse>
{
    /// <inheritdoc/>
    public SettingUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SettingUpdateResponse.FromRawUnchecked(rawData);
}