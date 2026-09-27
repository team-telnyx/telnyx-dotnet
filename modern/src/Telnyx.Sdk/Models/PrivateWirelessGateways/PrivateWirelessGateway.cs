using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PrivateWirelessGateways;

[JsonConverter(typeof(JsonModelConverter<PrivateWirelessGateway, PrivateWirelessGatewayFromRaw>))]
public sealed record class PrivateWirelessGateway : JsonModel
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

    public PrivateWirelessGateway ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrivateWirelessGateway (
        PrivateWirelessGateway privateWirelessGateway
    ) : base(privateWirelessGateway)
    {  }
    #pragma warning restore CS8618

    public PrivateWirelessGateway (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PrivateWirelessGateway (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PrivateWirelessGatewayFromRaw.FromRawUnchecked"/>
    public static PrivateWirelessGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PrivateWirelessGatewayFromRaw : IFromRawJson<PrivateWirelessGateway>
{
    /// <inheritdoc/>
    public PrivateWirelessGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PrivateWirelessGateway.FromRawUnchecked(rawData);
}