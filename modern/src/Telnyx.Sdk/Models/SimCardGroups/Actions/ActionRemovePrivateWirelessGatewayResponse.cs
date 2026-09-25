using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRemovePrivateWirelessGatewayResponse, ActionRemovePrivateWirelessGatewayResponseFromRaw>))]
public sealed record class ActionRemovePrivateWirelessGatewayResponse : JsonModel
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

    public ActionRemovePrivateWirelessGatewayResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRemovePrivateWirelessGatewayResponse (
        ActionRemovePrivateWirelessGatewayResponse actionRemovePrivateWirelessGatewayResponse
    ) : base(actionRemovePrivateWirelessGatewayResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRemovePrivateWirelessGatewayResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRemovePrivateWirelessGatewayResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRemovePrivateWirelessGatewayResponseFromRaw.FromRawUnchecked"/>
    public static ActionRemovePrivateWirelessGatewayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRemovePrivateWirelessGatewayResponseFromRaw : IFromRawJson<ActionRemovePrivateWirelessGatewayResponse>
{
    /// <inheritdoc/>
    public ActionRemovePrivateWirelessGatewayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRemovePrivateWirelessGatewayResponse.FromRawUnchecked(rawData);
}