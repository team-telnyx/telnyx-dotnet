using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WireguardPeers;

[JsonConverter(typeof(JsonModelConverter<WireguardPeerRetrieveResponse, WireguardPeerRetrieveResponseFromRaw>))]
public sealed record class WireguardPeerRetrieveResponse : JsonModel
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

    public WireguardPeerRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeerRetrieveResponse (
        WireguardPeerRetrieveResponse wireguardPeerRetrieveResponse
    ) : base(wireguardPeerRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public WireguardPeerRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardPeerRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardPeerRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WireguardPeerRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardPeerRetrieveResponseFromRaw : IFromRawJson<WireguardPeerRetrieveResponse>
{
    /// <inheritdoc/>
    public WireguardPeerRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardPeerRetrieveResponse.FromRawUnchecked(rawData);
}