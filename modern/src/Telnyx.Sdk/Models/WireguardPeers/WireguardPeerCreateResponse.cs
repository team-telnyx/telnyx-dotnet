using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WireguardPeers;

[JsonConverter(typeof(JsonModelConverter<WireguardPeerCreateResponse, WireguardPeerCreateResponseFromRaw>))]
public sealed record class WireguardPeerCreateResponse : JsonModel
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

    public WireguardPeerCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeerCreateResponse (
        WireguardPeerCreateResponse wireguardPeerCreateResponse
    ) : base(wireguardPeerCreateResponse)
    {  }
    #pragma warning restore CS8618

    public WireguardPeerCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardPeerCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardPeerCreateResponseFromRaw.FromRawUnchecked"/>
    public static WireguardPeerCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardPeerCreateResponseFromRaw : IFromRawJson<WireguardPeerCreateResponse>
{
    /// <inheritdoc/>
    public WireguardPeerCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardPeerCreateResponse.FromRawUnchecked(rawData);
}