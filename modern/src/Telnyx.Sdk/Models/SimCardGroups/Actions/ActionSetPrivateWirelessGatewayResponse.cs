using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionSetPrivateWirelessGatewayResponse, ActionSetPrivateWirelessGatewayResponseFromRaw>))]
public sealed record class ActionSetPrivateWirelessGatewayResponse : JsonModel
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

    public ActionSetPrivateWirelessGatewayResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionSetPrivateWirelessGatewayResponse (
        ActionSetPrivateWirelessGatewayResponse actionSetPrivateWirelessGatewayResponse
    ) : base(actionSetPrivateWirelessGatewayResponse)
    {  }
    #pragma warning restore CS8618

    public ActionSetPrivateWirelessGatewayResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionSetPrivateWirelessGatewayResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionSetPrivateWirelessGatewayResponseFromRaw.FromRawUnchecked"/>
    public static ActionSetPrivateWirelessGatewayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionSetPrivateWirelessGatewayResponseFromRaw : IFromRawJson<ActionSetPrivateWirelessGatewayResponse>
{
    /// <inheritdoc/>
    public ActionSetPrivateWirelessGatewayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionSetPrivateWirelessGatewayResponse.FromRawUnchecked(rawData);
}