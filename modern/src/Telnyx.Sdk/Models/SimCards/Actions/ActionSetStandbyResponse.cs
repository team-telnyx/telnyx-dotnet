using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionSetStandbyResponse, ActionSetStandbyResponseFromRaw>))]
public sealed record class ActionSetStandbyResponse : JsonModel
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

    public ActionSetStandbyResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionSetStandbyResponse (
        ActionSetStandbyResponse actionSetStandbyResponse
    ) : base(actionSetStandbyResponse)
    {  }
    #pragma warning restore CS8618

    public ActionSetStandbyResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionSetStandbyResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionSetStandbyResponseFromRaw.FromRawUnchecked"/>
    public static ActionSetStandbyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionSetStandbyResponseFromRaw : IFromRawJson<ActionSetStandbyResponse>
{
    /// <inheritdoc/>
    public ActionSetStandbyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionSetStandbyResponse.FromRawUnchecked(rawData);
}