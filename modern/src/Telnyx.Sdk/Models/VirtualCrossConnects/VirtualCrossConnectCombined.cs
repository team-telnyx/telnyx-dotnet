using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Networks;

namespace Telnyx.Sdk.Models.VirtualCrossConnects;

[JsonConverter(typeof(JsonModelConverter<VirtualCrossConnectCombined, VirtualCrossConnectCombinedFromRaw>))]
public sealed record class VirtualCrossConnectCombined : JsonModel
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
    /// The desired throughput in Megabits per Second (Mbps) for your Virtual Cross Connect.
    /// </summary>
    public double? BandwidthMbps {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "bandwidth_mbps"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bandwidth_mbps", value);
        }
    }

    /// <summary>
    /// The Border Gateway Protocol (BGP) Autonomous System Number (ASN).
    /// </summary>
    public double? BgpAsn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "bgp_asn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bgp_asn", value);
        }
    }

    /// <summary>
    /// The Virtual Private Cloud with which you would like to establish a cross connect.
    /// </summary>
    public ApiEnum<string, VirtualCrossConnectCombinedCloudProvider>? CloudProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VirtualCrossConnectCombinedCloudProvider>>(
                "cloud_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cloud_provider", value);
        }
    }

    /// <summary>
    /// The region where your Virtual Private Cloud hosts are located.
    /// </summary>
    public string? CloudProviderRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cloud_provider_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cloud_provider_region", value);
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
    /// The authentication key for BGP peer configuration.
    /// </summary>
    public string? PrimaryBgpKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "primary_bgp_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("primary_bgp_key", value);
        }
    }

    /// <summary>
    /// The identifier for your Virtual Private Cloud.
    /// </summary>
    public string? PrimaryCloudAccountID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "primary_cloud_account_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("primary_cloud_account_id", value);
        }
    }

    /// <summary>
    /// The IP address assigned for your side of the Virtual Cross Connect.
    /// </summary>
    public string? PrimaryCloudIP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "primary_cloud_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("primary_cloud_ip", value);
        }
    }

    /// <summary>
    /// Indicates whether the primary circuit is enabled.
    /// </summary>
    public bool? PrimaryEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "primary_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("primary_enabled", value);
        }
    }

    /// <summary>
    /// Whether
    /// </summary>
    public bool? PrimaryRoutingAnnouncement {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "primary_routing_announcement"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("primary_routing_announcement", value);
        }
    }

    /// <summary>
    /// The IP address assigned to the Telnyx side of the Virtual Cross Connect.
    /// </summary>
    public string? PrimaryTelnyxIP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "primary_telnyx_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("primary_telnyx_ip", value);
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

    public VirtualCrossConnectCombinedRegion? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VirtualCrossConnectCombinedRegion>(
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
        _ = this.BandwidthMbps;
        _ = this.BgpAsn;
        this.CloudProvider?.Validate();
        _ = this.CloudProviderRegion;
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.NetworkID;
        _ = this.PrimaryBgpKey;
        _ = this.PrimaryCloudAccountID;
        _ = this.PrimaryCloudIP;
        _ = this.PrimaryEnabled;
        _ = this.PrimaryRoutingAnnouncement;
        _ = this.PrimaryTelnyxIP;
        _ = this.RecordType;
        this.Region?.Validate();
        _ = this.RegionCode;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public VirtualCrossConnectCombined ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectCombined (
        VirtualCrossConnectCombined virtualCrossConnectCombined
    ) : base(virtualCrossConnectCombined)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectCombined (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectCombined (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VirtualCrossConnectCombinedFromRaw.FromRawUnchecked"/>
    public static VirtualCrossConnectCombined FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VirtualCrossConnectCombinedFromRaw : IFromRawJson<VirtualCrossConnectCombined>
{
    /// <inheritdoc/>
    public VirtualCrossConnectCombined FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VirtualCrossConnectCombined.FromRawUnchecked(rawData);
}

/// <summary>
/// The Virtual Private Cloud with which you would like to establish a cross connect.
/// </summary>
[JsonConverter(typeof(VirtualCrossConnectCombinedCloudProviderConverter))]
public enum VirtualCrossConnectCombinedCloudProvider
{
    Aws, Azure, Gce
}sealed class VirtualCrossConnectCombinedCloudProviderConverter : JsonConverter<VirtualCrossConnectCombinedCloudProvider>
{
    public override VirtualCrossConnectCombinedCloudProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws"=>VirtualCrossConnectCombinedCloudProvider.Aws,
            "azure"=>VirtualCrossConnectCombinedCloudProvider.Azure,
            "gce"=>VirtualCrossConnectCombinedCloudProvider.Gce,
            _ =>(VirtualCrossConnectCombinedCloudProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VirtualCrossConnectCombinedCloudProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VirtualCrossConnectCombinedCloudProvider.Aws=>"aws",
            VirtualCrossConnectCombinedCloudProvider.Azure=>"azure",
            VirtualCrossConnectCombinedCloudProvider.Gce=>"gce",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<VirtualCrossConnectCombinedRegion, VirtualCrossConnectCombinedRegionFromRaw>))]
public sealed record class VirtualCrossConnectCombinedRegion : JsonModel
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

    public VirtualCrossConnectCombinedRegion ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectCombinedRegion (
        VirtualCrossConnectCombinedRegion virtualCrossConnectCombinedRegion
    ) : base(virtualCrossConnectCombinedRegion)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectCombinedRegion (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectCombinedRegion (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VirtualCrossConnectCombinedRegionFromRaw.FromRawUnchecked"/>
    public static VirtualCrossConnectCombinedRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VirtualCrossConnectCombinedRegionFromRaw : IFromRawJson<VirtualCrossConnectCombinedRegion>
{
    /// <inheritdoc/>
    public VirtualCrossConnectCombinedRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VirtualCrossConnectCombinedRegion.FromRawUnchecked(rawData);
}