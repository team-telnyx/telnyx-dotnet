using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WireguardPeers;

[JsonConverter(typeof(JsonModelConverter<WireguardPeerUpdateResponse, WireguardPeerUpdateResponseFromRaw>))]
public sealed record class WireguardPeerUpdateResponse : JsonModel
{
    public WireguardPeer? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireguardPeer>(
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

    public WireguardPeerUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeerUpdateResponse (
        WireguardPeerUpdateResponse wireguardPeerUpdateResponse
    ) : base(wireguardPeerUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public WireguardPeerUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardPeerUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardPeerUpdateResponseFromRaw.FromRawUnchecked"/>
    public static WireguardPeerUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardPeerUpdateResponseFromRaw : IFromRawJson<WireguardPeerUpdateResponse>
{
    /// <inheritdoc/>
    public WireguardPeerUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardPeerUpdateResponse.FromRawUnchecked(rawData);
}