using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WireguardPeers;

[JsonConverter(typeof(JsonModelConverter<WireguardPeerPatch, WireguardPeerPatchFromRaw>))]
public sealed record class WireguardPeerPatch : JsonModel
{
    /// <summary>
    /// The WireGuard `PublicKey`.&lt;br /&gt;&lt;br /&gt;If you do not provide a
    /// Public Key, a new Public and Private key pair will be generated for you.
    /// </summary>
    public string? PublicKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "public_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("public_key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.PublicKey; }

    public WireguardPeerPatch ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeerPatch (WireguardPeerPatch wireguardPeerPatch) : base(
        wireguardPeerPatch
    )
    {  }
    #pragma warning restore CS8618

    public WireguardPeerPatch (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardPeerPatch (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardPeerPatchFromRaw.FromRawUnchecked"/>
    public static WireguardPeerPatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardPeerPatchFromRaw : IFromRawJson<WireguardPeerPatch>
{
    /// <inheritdoc/>
    public WireguardPeerPatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardPeerPatch.FromRawUnchecked(rawData);
}