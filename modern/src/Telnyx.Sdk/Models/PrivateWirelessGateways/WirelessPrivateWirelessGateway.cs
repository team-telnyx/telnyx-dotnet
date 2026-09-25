using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PrivateWirelessGateways;

[JsonConverter(typeof(JsonModelConverter<WirelessPrivateWirelessGateway, WirelessPrivateWirelessGatewayFromRaw>))]
public sealed record class WirelessPrivateWirelessGateway : JsonModel
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
    /// The address mode of the private wireless gateway. With static, each SIM card
    /// gets a fixed IP address from the gateway's IP range that is preserved across
    /// sessions. With dynamic, IP addresses are assigned by the network at attach
    /// time and may change between sessions.
    /// </summary>
    public ApiEnum<string, WirelessPrivateWirelessGatewayAddressMode>? AddressMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WirelessPrivateWirelessGatewayAddressMode>>(
                "address_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address_mode", value);
        }
    }

    /// <summary>
    /// A list of the resources that have been assigned to the Private Wireless Gateway.
    /// </summary>
    public IReadOnlyList<PwgAssignedResourcesSummary>? AssignedResources {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PwgAssignedResourcesSummary>>(
                "assigned_resources"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PwgAssignedResourcesSummary>?>(
                "assigned_resources",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
    /// IP block used to assign IPs to the SIM cards in the Private Wireless Gateway.
    /// </summary>
    public string? IPRange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ip_range"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ip_range", value);
        }
    }

    /// <summary>
    /// The private wireless gateway name.
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
    /// The identification of the related network resource.
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
    /// The name of the region where the Private Wireless Gateway is deployed.
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
    /// The current status or failure details of the Private Wireless Gateway.
    /// </summary>
    public PrivateWirelessGatewayStatus? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PrivateWirelessGatewayStatus>(
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
        this.AddressMode?.Validate();
        foreach (var item in this.AssignedResources ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.IPRange;
        _ = this.Name;
        _ = this.NetworkID;
        _ = this.RecordType;
        _ = this.RegionCode;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public WirelessPrivateWirelessGateway ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessPrivateWirelessGateway (
        WirelessPrivateWirelessGateway wirelessPrivateWirelessGateway
    ) : base(wirelessPrivateWirelessGateway)
    {  }
    #pragma warning restore CS8618

    public WirelessPrivateWirelessGateway (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessPrivateWirelessGateway (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessPrivateWirelessGatewayFromRaw.FromRawUnchecked"/>
    public static WirelessPrivateWirelessGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WirelessPrivateWirelessGatewayFromRaw : IFromRawJson<WirelessPrivateWirelessGateway>
{
    /// <inheritdoc/>
    public WirelessPrivateWirelessGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessPrivateWirelessGateway.FromRawUnchecked(rawData);
}

/// <summary>
/// The address mode of the private wireless gateway. With static, each SIM card gets
/// a fixed IP address from the gateway's IP range that is preserved across sessions.
/// With dynamic, IP addresses are assigned by the network at attach time and may
/// change between sessions.
/// </summary>
[JsonConverter(typeof(WirelessPrivateWirelessGatewayAddressModeConverter))]
public enum WirelessPrivateWirelessGatewayAddressMode
{
    Static, Dynamic
}sealed class WirelessPrivateWirelessGatewayAddressModeConverter : JsonConverter<WirelessPrivateWirelessGatewayAddressMode>
{
    public override WirelessPrivateWirelessGatewayAddressMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "static"=>WirelessPrivateWirelessGatewayAddressMode.Static,
            "dynamic"=>WirelessPrivateWirelessGatewayAddressMode.Dynamic,
            _ =>(WirelessPrivateWirelessGatewayAddressMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WirelessPrivateWirelessGatewayAddressMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WirelessPrivateWirelessGatewayAddressMode.Static=>"static",
            WirelessPrivateWirelessGatewayAddressMode.Dynamic=>"dynamic",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}