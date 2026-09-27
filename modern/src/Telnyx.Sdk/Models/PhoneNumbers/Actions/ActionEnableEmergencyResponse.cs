using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionEnableEmergencyResponse, ActionEnableEmergencyResponseFromRaw>))]
public sealed record class ActionEnableEmergencyResponse : JsonModel
{
    public PhoneNumberWithVoiceSettings? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumberWithVoiceSettings>(
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

    public ActionEnableEmergencyResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionEnableEmergencyResponse (
        ActionEnableEmergencyResponse actionEnableEmergencyResponse
    ) : base(actionEnableEmergencyResponse)
    {  }
    #pragma warning restore CS8618

    public ActionEnableEmergencyResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionEnableEmergencyResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionEnableEmergencyResponseFromRaw.FromRawUnchecked"/>
    public static ActionEnableEmergencyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionEnableEmergencyResponseFromRaw : IFromRawJson<ActionEnableEmergencyResponse>
{
    /// <inheritdoc/>
    public ActionEnableEmergencyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionEnableEmergencyResponse.FromRawUnchecked(rawData);
}