using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WireguardPeers;

[JsonConverter(typeof(JsonModelConverter<WireguardPeerDeleteResponse, WireguardPeerDeleteResponseFromRaw>))]
public sealed record class WireguardPeerDeleteResponse : JsonModel
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

    public WireguardPeerDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeerDeleteResponse (
        WireguardPeerDeleteResponse wireguardPeerDeleteResponse
    ) : base(wireguardPeerDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public WireguardPeerDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardPeerDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardPeerDeleteResponseFromRaw.FromRawUnchecked"/>
    public static WireguardPeerDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardPeerDeleteResponseFromRaw : IFromRawJson<WireguardPeerDeleteResponse>
{
    /// <inheritdoc/>
    public WireguardPeerDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardPeerDeleteResponse.FromRawUnchecked(rawData);
}