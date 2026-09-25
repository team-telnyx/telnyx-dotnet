using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAssignments;
using Telnyx.Sdk.Models.Networks;
using Telnyx.Sdk.Models.PublicInternetGateways;

namespace Telnyx.Sdk.Models.WireguardInterfaces;

[JsonConverter(typeof(JsonModelConverter<WireguardInterface, WireguardInterfaceFromRaw>))]
public sealed record class WireguardInterface : JsonModel
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
    /// A user specified name for the interface.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The id of the network associated with the interface.
    /// </summary>
    public string? NetworkID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "network_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("network_id", value);
        }
    }

    /// <summary>
    /// The current status of the interface deployment.
    /// </summary>
    public ApiEnum<string, InterfaceStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InterfaceStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Enable SIP traffic forwarding over VPN interface.
    /// </summary>
    public bool? EnableSipTrunking {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_sip_trunking"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_sip_trunking", value);
        }
    }

    /// <summary>
    /// The Telnyx WireGuard peers `Peer.endpoint` value.
    /// </summary>
    public string? Endpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "endpoint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("endpoint", value);
        }
    }

    /// <summary>
    /// The Telnyx WireGuard peers `Peer.PublicKey`.
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

    public static implicit operator Record (
        WireguardInterface wireguardInterface
    )=> new() {
        ID = wireguardInterface.ID,
        CreatedAt = wireguardInterface.CreatedAt,
        RecordType = wireguardInterface.RecordType,
        UpdatedAt = wireguardInterface.UpdatedAt
    } ;

    public static implicit operator NetworkInterface (
        WireguardInterface wireguardInterface
    )=> new() {
        Name = wireguardInterface.Name,
        NetworkID = wireguardInterface.NetworkID,
        Status = wireguardInterface.Status
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.Name;
        _ = this.NetworkID;
        this.Status?.Validate();
        _ = this.EnableSipTrunking;
        _ = this.Endpoint;
        _ = this.PublicKey;
    }

    public WireguardInterface ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardInterface (WireguardInterface wireguardInterface) : base(
        wireguardInterface
    )
    {  }
    #pragma warning restore CS8618

    public WireguardInterface (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardInterface (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardInterfaceFromRaw.FromRawUnchecked"/>
    public static WireguardInterface FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardInterfaceFromRaw : IFromRawJson<WireguardInterface>
{
    /// <inheritdoc/>
    public WireguardInterface FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardInterface.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WireguardInterfaceWireguardInterface, WireguardInterfaceWireguardInterfaceFromRaw>))]
public sealed record class WireguardInterfaceWireguardInterface : JsonModel
{
    /// <summary>
    /// Enable SIP traffic forwarding over VPN interface.
    /// </summary>
    public bool? EnableSipTrunking {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_sip_trunking"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_sip_trunking", value);
        }
    }

    /// <summary>
    /// The Telnyx WireGuard peers `Peer.endpoint` value.
    /// </summary>
    public string? Endpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "endpoint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("endpoint", value);
        }
    }

    /// <summary>
    /// The Telnyx WireGuard peers `Peer.PublicKey`.
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
    {
        _ = this.EnableSipTrunking;
        _ = this.Endpoint;
        _ = this.PublicKey;
    }

    public WireguardInterfaceWireguardInterface ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardInterfaceWireguardInterface (
        WireguardInterfaceWireguardInterface wireguardInterfaceWireguardInterface
    ) : base(wireguardInterfaceWireguardInterface)
    {  }
    #pragma warning restore CS8618

    public WireguardInterfaceWireguardInterface (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardInterfaceWireguardInterface (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardInterfaceWireguardInterfaceFromRaw.FromRawUnchecked"/>
    public static WireguardInterfaceWireguardInterface FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WireguardInterfaceWireguardInterfaceFromRaw : IFromRawJson<WireguardInterfaceWireguardInterface>
{
    /// <inheritdoc/>
    public WireguardInterfaceWireguardInterface FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardInterfaceWireguardInterface.FromRawUnchecked(rawData);
}