using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.WireguardPeers;

[JsonConverter(typeof(JsonModelConverter<WireguardPeerListPageResponse, WireguardPeerListPageResponseFromRaw>))]
public sealed record class WireguardPeerListPageResponse : JsonModel
{
    public IReadOnlyList<WireguardPeer>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WireguardPeer>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WireguardPeer>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public WireguardPeerListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeerListPageResponse (
        WireguardPeerListPageResponse wireguardPeerListPageResponse
    ) : base(wireguardPeerListPageResponse)
    {  }
    #pragma warning restore CS8618

    public WireguardPeerListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardPeerListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardPeerListPageResponseFromRaw.FromRawUnchecked"/>
    public static WireguardPeerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardPeerListPageResponseFromRaw : IFromRawJson<WireguardPeerListPageResponse>
{
    /// <inheritdoc/>
    public WireguardPeerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardPeerListPageResponse.FromRawUnchecked(rawData);
}