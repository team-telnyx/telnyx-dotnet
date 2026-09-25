using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.BusinessAccounts.Settings;

[JsonConverter(typeof(JsonModelConverter<SettingRetrieveResponse, SettingRetrieveResponseFromRaw>))]
public sealed record class SettingRetrieveResponse : JsonModel
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

    public SettingRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SettingRetrieveResponse (
        SettingRetrieveResponse settingRetrieveResponse
    ) : base(settingRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SettingRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SettingRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SettingRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SettingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SettingRetrieveResponseFromRaw : IFromRawJson<SettingRetrieveResponse>
{
    /// <inheritdoc/>
    public SettingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SettingRetrieveResponse.FromRawUnchecked(rawData);
}