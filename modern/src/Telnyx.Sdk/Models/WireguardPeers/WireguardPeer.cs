using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAssignments;

namespace Telnyx.Sdk.Models.WireguardPeers;

[JsonConverter(typeof(JsonModelConverter<WireguardPeer, WireguardPeerFromRaw>))]
public sealed record class WireguardPeer : JsonModel
{
    /// <summary>
    /// Identifies the resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when peer sent traffic last time.
    /// </summary>
    public string? LastSeen {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "last_seen"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_seen", value);
        }
    }

    /// <summary>
    /// Your WireGuard `Interface.PrivateKey`.&lt;br /&gt;&lt;br /&gt;This attribute
    /// is only ever utlised if, on POST, you do NOT provide your own `public_key`.
    /// In which case, a new Public and Private key pair will be generated for you.
    /// When your `private_key` is returned, you must save this immediately as we
    /// do not save it within Telnyx. If you lose your Private Key, it can not be recovered.
    /// </summary>
    public string? PrivateKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "private_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("private_key", value);
        }
    }

    /// <summary>
    /// The id of the wireguard interface associated with the peer.
    /// </summary>
    public string? WireguardInterfaceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireguard_interface_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireguard_interface_id", value);
        }
    }

    public static implicit operator Record (
        WireguardPeer wireguardPeer
    )=> new() {
        ID = wireguardPeer.ID,
        CreatedAt = wireguardPeer.CreatedAt,
        RecordType = wireguardPeer.RecordType,
        UpdatedAt = wireguardPeer.UpdatedAt
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.LastSeen;
        _ = this.PrivateKey;
        _ = this.WireguardInterfaceID;
    }

    public WireguardPeer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeer (WireguardPeer wireguardPeer) : base(wireguardPeer)
    {  }
    #pragma warning restore CS8618

    public WireguardPeer (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardPeer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardPeerFromRaw.FromRawUnchecked"/>
    public static WireguardPeer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardPeerFromRaw : IFromRawJson<WireguardPeer>
{
    /// <inheritdoc/>
    public WireguardPeer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardPeer.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WireguardPeerWireguardPeer, WireguardPeerWireguardPeerFromRaw>))]
public sealed record class WireguardPeerWireguardPeer : JsonModel
{
    /// <summary>
    /// ISO 8601 formatted date-time indicating when peer sent traffic last time.
    /// </summary>
    public string? LastSeen {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "last_seen"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_seen", value);
        }
    }

    /// <summary>
    /// Your WireGuard `Interface.PrivateKey`.&lt;br /&gt;&lt;br /&gt;This attribute
    /// is only ever utlised if, on POST, you do NOT provide your own `public_key`.
    /// In which case, a new Public and Private key pair will be generated for you.
    /// When your `private_key` is returned, you must save this immediately as we
    /// do not save it within Telnyx. If you lose your Private Key, it can not be recovered.
    /// </summary>
    public string? PrivateKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "private_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("private_key", value);
        }
    }

    /// <summary>
    /// The id of the wireguard interface associated with the peer.
    /// </summary>
    public string? WireguardInterfaceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireguard_interface_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireguard_interface_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LastSeen;
        _ = this.PrivateKey;
        _ = this.WireguardInterfaceID;
    }

    public WireguardPeerWireguardPeer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardPeerWireguardPeer (
        WireguardPeerWireguardPeer wireguardPeerWireguardPeer
    ) : base(wireguardPeerWireguardPeer)
    {  }
    #pragma warning restore CS8618

    public WireguardPeerWireguardPeer (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardPeerWireguardPeer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardPeerWireguardPeerFromRaw.FromRawUnchecked"/>
    public static WireguardPeerWireguardPeer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WireguardPeerWireguardPeerFromRaw : IFromRawJson<WireguardPeerWireguardPeer>
{
    /// <inheritdoc/>
    public WireguardPeerWireguardPeer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardPeerWireguardPeer.FromRawUnchecked(rawData);
}