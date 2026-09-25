using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Networks = Telnyx.Sdk.Models.Networks;

namespace Telnyx.Sdk.Models.WireguardInterfaces;

[JsonConverter(typeof(JsonModelConverter<WireguardInterfaceRead, WireguardInterfaceReadFromRaw>))]
public sealed record class WireguardInterfaceRead : JsonModel
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

    public Region? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Region>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <summary>
    /// The region interface is deployed to.
    /// </summary>
    public string? RegionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region_code", value);
        }
    }

    /// <summary>
    /// The current status of the interface deployment.
    /// </summary>
    public ApiEnum<string, Networks::InterfaceStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Networks::InterfaceStatus>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.EnableSipTrunking;
        _ = this.Endpoint;
        _ = this.Name;
        _ = this.NetworkID;
        _ = this.PublicKey;
        _ = this.RecordType;
        this.Region?.Validate();
        _ = this.RegionCode;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public WireguardInterfaceRead ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardInterfaceRead (
        WireguardInterfaceRead wireguardInterfaceRead
    ) : base(wireguardInterfaceRead)
    {  }
    #pragma warning restore CS8618

    public WireguardInterfaceRead (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardInterfaceRead (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardInterfaceReadFromRaw.FromRawUnchecked"/>
    public static WireguardInterfaceRead FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardInterfaceReadFromRaw : IFromRawJson<WireguardInterfaceRead>
{
    /// <inheritdoc/>
    public WireguardInterfaceRead FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardInterfaceRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Region, RegionFromRaw>))]
public sealed record class Region : JsonModel
{
    /// <summary>
    /// Region code of the interface.
    /// </summary>
    public string? Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Region name of the interface.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Name;
        _ = this.RecordType;
    }

    public Region ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Region (Region region) : base(region)
    {  }
    #pragma warning restore CS8618

    public Region (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Region (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegionFromRaw.FromRawUnchecked"/>
    public static Region FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RegionFromRaw : IFromRawJson<Region>
{
    /// <inheritdoc/>
    public Region FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Region.FromRawUnchecked(rawData);
}