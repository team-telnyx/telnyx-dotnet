using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRetrieveResponse, ActionRetrieveResponseFromRaw>))]
public sealed record class ActionRetrieveResponse : JsonModel
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

    public ActionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRetrieveResponse (
        ActionRetrieveResponse actionRetrieveResponse
    ) : base(actionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ActionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRetrieveResponseFromRaw : IFromRawJson<ActionRetrieveResponse>
{
    /// <inheritdoc/>
    public ActionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRetrieveResponse.FromRawUnchecked(rawData);
}