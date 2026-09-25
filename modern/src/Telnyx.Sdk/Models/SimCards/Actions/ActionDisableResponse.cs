using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionDisableResponse, ActionDisableResponseFromRaw>))]
public sealed record class ActionDisableResponse : JsonModel
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

    public ActionDisableResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionDisableResponse (
        ActionDisableResponse actionDisableResponse
    ) : base(actionDisableResponse)
    {  }
    #pragma warning restore CS8618

    public ActionDisableResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionDisableResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionDisableResponseFromRaw.FromRawUnchecked"/>
    public static ActionDisableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionDisableResponseFromRaw : IFromRawJson<ActionDisableResponse>
{
    /// <inheritdoc/>
    public ActionDisableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionDisableResponse.FromRawUnchecked(rawData);
}