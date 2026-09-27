using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionSetWirelessBlocklistResponse, ActionSetWirelessBlocklistResponseFromRaw>))]
public sealed record class ActionSetWirelessBlocklistResponse : JsonModel
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

    public ActionSetWirelessBlocklistResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionSetWirelessBlocklistResponse (
        ActionSetWirelessBlocklistResponse actionSetWirelessBlocklistResponse
    ) : base(actionSetWirelessBlocklistResponse)
    {  }
    #pragma warning restore CS8618

    public ActionSetWirelessBlocklistResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionSetWirelessBlocklistResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionSetWirelessBlocklistResponseFromRaw.FromRawUnchecked"/>
    public static ActionSetWirelessBlocklistResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionSetWirelessBlocklistResponseFromRaw : IFromRawJson<ActionSetWirelessBlocklistResponse>
{
    /// <inheritdoc/>
    public ActionSetWirelessBlocklistResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionSetWirelessBlocklistResponse.FromRawUnchecked(rawData);
}