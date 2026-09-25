using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAssignments;

namespace Telnyx.Sdk.Models.Networks.DefaultGateway;

[JsonConverter(typeof(JsonModelConverter<DefaultGatewayDefaultGateway, DefaultGatewayDefaultGatewayFromRaw>))]
public sealed record class DefaultGatewayDefaultGateway : JsonModel
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
    /// Network ID.
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
    /// Wireguard peer ID.
    /// </summary>
    public string? WireguardPeerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireguard_peer_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireguard_peer_id", value);
        }
    }

    public static implicit operator Record (
        DefaultGatewayDefaultGateway defaultGatewayDefaultGateway
    )=> new() {
        ID = defaultGatewayDefaultGateway.ID,
        CreatedAt = defaultGatewayDefaultGateway.CreatedAt,
        RecordType = defaultGatewayDefaultGateway.RecordType,
        UpdatedAt = defaultGatewayDefaultGateway.UpdatedAt
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.NetworkID;
        this.Status?.Validate();
        _ = this.WireguardPeerID;
    }

    public DefaultGatewayDefaultGateway ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DefaultGatewayDefaultGateway (
        DefaultGatewayDefaultGateway defaultGatewayDefaultGateway
    ) : base(defaultGatewayDefaultGateway)
    {  }
    #pragma warning restore CS8618

    public DefaultGatewayDefaultGateway (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultGatewayDefaultGateway (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DefaultGatewayDefaultGatewayFromRaw.FromRawUnchecked"/>
    public static DefaultGatewayDefaultGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DefaultGatewayDefaultGatewayFromRaw : IFromRawJson<DefaultGatewayDefaultGateway>
{
    /// <inheritdoc/>
    public DefaultGatewayDefaultGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DefaultGatewayDefaultGateway.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DefaultGatewayDefaultGatewayDefaultGateway, DefaultGatewayDefaultGatewayDefaultGatewayFromRaw>))]
public sealed record class DefaultGatewayDefaultGatewayDefaultGateway : JsonModel
{
    /// <summary>
    /// Network ID.
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
    /// Wireguard peer ID.
    /// </summary>
    public string? WireguardPeerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireguard_peer_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireguard_peer_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NetworkID;
        this.Status?.Validate();
        _ = this.WireguardPeerID;
    }

    public DefaultGatewayDefaultGatewayDefaultGateway ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DefaultGatewayDefaultGatewayDefaultGateway (
        DefaultGatewayDefaultGatewayDefaultGateway defaultGatewayDefaultGatewayDefaultGateway
    ) : base(defaultGatewayDefaultGatewayDefaultGateway)
    {  }
    #pragma warning restore CS8618

    public DefaultGatewayDefaultGatewayDefaultGateway (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultGatewayDefaultGatewayDefaultGateway (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DefaultGatewayDefaultGatewayDefaultGatewayFromRaw.FromRawUnchecked"/>
    public static DefaultGatewayDefaultGatewayDefaultGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DefaultGatewayDefaultGatewayDefaultGatewayFromRaw : IFromRawJson<DefaultGatewayDefaultGatewayDefaultGateway>
{
    /// <inheritdoc/>
    public DefaultGatewayDefaultGatewayDefaultGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DefaultGatewayDefaultGatewayDefaultGateway.FromRawUnchecked(rawData);
}