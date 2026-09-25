using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PrivateWirelessGateways;

[JsonConverter(typeof(JsonModelConverter<PrivateWirelessGatewayCreateResponse, PrivateWirelessGatewayCreateResponseFromRaw>))]
public sealed record class PrivateWirelessGatewayCreateResponse : JsonModel
{
    public WirelessPrivateWirelessGateway? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WirelessPrivateWirelessGateway>(
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

    public PrivateWirelessGatewayCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrivateWirelessGatewayCreateResponse (
        PrivateWirelessGatewayCreateResponse privateWirelessGatewayCreateResponse
    ) : base(privateWirelessGatewayCreateResponse)
    {  }
    #pragma warning restore CS8618

    public PrivateWirelessGatewayCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PrivateWirelessGatewayCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PrivateWirelessGatewayCreateResponseFromRaw.FromRawUnchecked"/>
    public static PrivateWirelessGatewayCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PrivateWirelessGatewayCreateResponseFromRaw : IFromRawJson<PrivateWirelessGatewayCreateResponse>
{
    /// <inheritdoc/>
    public PrivateWirelessGatewayCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PrivateWirelessGatewayCreateResponse.FromRawUnchecked(rawData);
}