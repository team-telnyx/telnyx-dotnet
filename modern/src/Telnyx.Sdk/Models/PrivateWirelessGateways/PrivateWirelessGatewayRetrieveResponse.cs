using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PrivateWirelessGateways;

[JsonConverter(typeof(JsonModelConverter<PrivateWirelessGatewayRetrieveResponse, PrivateWirelessGatewayRetrieveResponseFromRaw>))]
public sealed record class PrivateWirelessGatewayRetrieveResponse : JsonModel
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

    public PrivateWirelessGatewayRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrivateWirelessGatewayRetrieveResponse (
        PrivateWirelessGatewayRetrieveResponse privateWirelessGatewayRetrieveResponse
    ) : base(privateWirelessGatewayRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public PrivateWirelessGatewayRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PrivateWirelessGatewayRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PrivateWirelessGatewayRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PrivateWirelessGatewayRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PrivateWirelessGatewayRetrieveResponseFromRaw : IFromRawJson<PrivateWirelessGatewayRetrieveResponse>
{
    /// <inheritdoc/>
    public PrivateWirelessGatewayRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PrivateWirelessGatewayRetrieveResponse.FromRawUnchecked(rawData);
}