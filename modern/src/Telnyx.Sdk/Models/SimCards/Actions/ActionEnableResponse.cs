using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionEnableResponse, ActionEnableResponseFromRaw>))]
public sealed record class ActionEnableResponse : JsonModel
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

    public ActionEnableResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionEnableResponse (
        ActionEnableResponse actionEnableResponse
    ) : base(actionEnableResponse)
    {  }
    #pragma warning restore CS8618

    public ActionEnableResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionEnableResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionEnableResponseFromRaw.FromRawUnchecked"/>
    public static ActionEnableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionEnableResponseFromRaw : IFromRawJson<ActionEnableResponse>
{
    /// <inheritdoc/>
    public ActionEnableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionEnableResponse.FromRawUnchecked(rawData);
}