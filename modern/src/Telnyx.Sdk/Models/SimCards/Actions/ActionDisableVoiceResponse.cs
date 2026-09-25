using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionDisableVoiceResponse, ActionDisableVoiceResponseFromRaw>))]
public sealed record class ActionDisableVoiceResponse : JsonModel
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

    public ActionDisableVoiceResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionDisableVoiceResponse (
        ActionDisableVoiceResponse actionDisableVoiceResponse
    ) : base(actionDisableVoiceResponse)
    {  }
    #pragma warning restore CS8618

    public ActionDisableVoiceResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionDisableVoiceResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionDisableVoiceResponseFromRaw.FromRawUnchecked"/>
    public static ActionDisableVoiceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionDisableVoiceResponseFromRaw : IFromRawJson<ActionDisableVoiceResponse>
{
    /// <inheritdoc/>
    public ActionDisableVoiceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionDisableVoiceResponse.FromRawUnchecked(rawData);
}