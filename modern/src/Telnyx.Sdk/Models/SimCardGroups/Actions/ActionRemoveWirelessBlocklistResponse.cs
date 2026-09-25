using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRemoveWirelessBlocklistResponse, ActionRemoveWirelessBlocklistResponseFromRaw>))]
public sealed record class ActionRemoveWirelessBlocklistResponse : JsonModel
{
    /// <summary>
    /// This object represents a SIM card group action request. It allows tracking
    /// the current status of an operation that impacts the SIM card group and SIM
    /// card in it.
    /// </summary>
    public SimCardGroupAction? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardGroupAction>(
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

    public ActionRemoveWirelessBlocklistResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRemoveWirelessBlocklistResponse (
        ActionRemoveWirelessBlocklistResponse actionRemoveWirelessBlocklistResponse
    ) : base(actionRemoveWirelessBlocklistResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRemoveWirelessBlocklistResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRemoveWirelessBlocklistResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRemoveWirelessBlocklistResponseFromRaw.FromRawUnchecked"/>
    public static ActionRemoveWirelessBlocklistResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRemoveWirelessBlocklistResponseFromRaw : IFromRawJson<ActionRemoveWirelessBlocklistResponse>
{
    /// <inheritdoc/>
    public ActionRemoveWirelessBlocklistResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRemoveWirelessBlocklistResponse.FromRawUnchecked(rawData);
}