using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionEnableVoiceResponse, ActionEnableVoiceResponseFromRaw>))]
public sealed record class ActionEnableVoiceResponse : JsonModel
{
    /// <summary>
    /// This object represents a SIM card action. It allows tracking the current
    /// status of an operation that impacts the SIM card.
    /// </summary>
    public WirelessSimCardAction? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WirelessSimCardAction>(
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

    public ActionEnableVoiceResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionEnableVoiceResponse (
        ActionEnableVoiceResponse actionEnableVoiceResponse
    ) : base(actionEnableVoiceResponse)
    {  }
    #pragma warning restore CS8618

    public ActionEnableVoiceResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionEnableVoiceResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionEnableVoiceResponseFromRaw.FromRawUnchecked"/>
    public static ActionEnableVoiceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionEnableVoiceResponseFromRaw : IFromRawJson<ActionEnableVoiceResponse>
{
    /// <inheritdoc/>
    public ActionEnableVoiceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionEnableVoiceResponse.FromRawUnchecked(rawData);
}