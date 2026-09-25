using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.GlobalIPAssignments;
using Telnyx.Sdk.Models.Networks;
using Telnyx.Sdk.Models.PublicInternetGateways;

namespace Telnyx.Sdk.Models.VirtualCrossConnects;

[JsonConverter(typeof(JsonModelConverter<VirtualCrossConnectCreate, VirtualCrossConnectCreateFromRaw>))]
public sealed record class VirtualCrossConnectCreate : JsonModel
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
    /// The region the interface should be deployed to.
    /// </summary>
    public required string RegionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "region_code"
            );
        }
        init { this._rawData.Set("region_code", value); }
    }

    /// <summary>
    /// The desired throughput in Megabits per Second (Mbps) for your Virtual Cross
    /// Connect.&lt;br /&gt;&lt;br /&gt;The available bandwidths can be found using
    /// the /virtual_cross_connect_regions endpoint.
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
    /// The Border Gateway Protocol (BGP) Autonomous System Number (ASN). If null,
    /// value will be assigned by Telnyx.
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
    public ApiEnum<string, IntersectionMember2CloudProvider>? CloudProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IntersectionMember2CloudProvider>>(
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
    /// The region where your Virtual Private Cloud hosts are located.&lt;br /&gt;&lt;br
    /// /&gt;The available regions can be found using the /virtual_cross_connect_regions endpoint.
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
    /// The identifier for your Virtual Private Cloud. The number will be different
    /// based upon your Cloud provider.
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
    /// The IP address assigned for your side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value should be null for GCE as Google will only inform
    /// you of your assigned IP once the connection has been accepted.
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
    /// Indicates whether the primary circuit is enabled. Setting this to `false`
    /// will disable the circuit.
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
    /// The IP address assigned to the Telnyx side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value should be null for GCE as Google will only inform
    /// you of your assigned IP once the connection has been accepted.
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
    /// The authentication key for BGP peer configuration.
    /// </summary>
    public string? SecondaryBgpKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secondary_bgp_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_bgp_key", value);
        }
    }

    /// <summary>
    /// The identifier for your Virtual Private Cloud. The number will be different
    /// based upon your Cloud provider.&lt;br /&gt;&lt;br /&gt;This attribute is only
    /// necessary for GCE.
    /// </summary>
    public string? SecondaryCloudAccountID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secondary_cloud_account_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_cloud_account_id", value);
        }
    }

    /// <summary>
    /// The IP address assigned for your side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value should be null for GCE as Google will only inform
    /// you of your assigned IP once the connection has been accepted.
    /// </summary>
    public string? SecondaryCloudIP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secondary_cloud_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_cloud_ip", value);
        }
    }

    /// <summary>
    /// Indicates whether the secondary circuit is enabled. Setting this to `false`
    /// will disable the circuit.
    /// </summary>
    public bool? SecondaryEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "secondary_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_enabled", value);
        }
    }

    /// <summary>
    /// The IP address assigned to the Telnyx side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value should be null for GCE as Google will only inform
    /// you of your assigned IP once the connection has been accepted.
    /// </summary>
    public string? SecondaryTelnyxIP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secondary_telnyx_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_telnyx_ip", value);
        }
    }

    public static implicit operator Record (
        VirtualCrossConnectCreate virtualCrossConnectCreate
    )=> new() {
        ID = virtualCrossConnectCreate.ID,
        CreatedAt = virtualCrossConnectCreate.CreatedAt,
        RecordType = virtualCrossConnectCreate.RecordType,
        UpdatedAt = virtualCrossConnectCreate.UpdatedAt
    } ;

    public static implicit operator NetworkInterface (
        VirtualCrossConnectCreate virtualCrossConnectCreate
    )=> new() {
        Name = virtualCrossConnectCreate.Name,
        NetworkID = virtualCrossConnectCreate.NetworkID,
        Status = virtualCrossConnectCreate.Status
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
        _ = this.RegionCode;
        _ = this.BandwidthMbps;
        _ = this.BgpAsn;
        this.CloudProvider?.Validate();
        _ = this.CloudProviderRegion;
        _ = this.PrimaryBgpKey;
        _ = this.PrimaryCloudAccountID;
        _ = this.PrimaryCloudIP;
        _ = this.PrimaryEnabled;
        _ = this.PrimaryTelnyxIP;
        _ = this.SecondaryBgpKey;
        _ = this.SecondaryCloudAccountID;
        _ = this.SecondaryCloudIP;
        _ = this.SecondaryEnabled;
        _ = this.SecondaryTelnyxIP;
    }

    public VirtualCrossConnectCreate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectCreate (
        VirtualCrossConnectCreate virtualCrossConnectCreate
    ) : base(virtualCrossConnectCreate)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectCreate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectCreate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VirtualCrossConnectCreateFromRaw.FromRawUnchecked"/>
    public static VirtualCrossConnectCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public VirtualCrossConnectCreate (string regionCode) : this()
    { this.RegionCode = regionCode; }
}

class VirtualCrossConnectCreateFromRaw : IFromRawJson<VirtualCrossConnectCreate>
{
    /// <inheritdoc/>
    public VirtualCrossConnectCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VirtualCrossConnectCreate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember2, IntersectionMember2FromRaw>))]
public sealed record class IntersectionMember2 : JsonModel
{
    /// <summary>
    /// The region the interface should be deployed to.
    /// </summary>
    public required string RegionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "region_code"
            );
        }
        init { this._rawData.Set("region_code", value); }
    }

    /// <summary>
    /// The desired throughput in Megabits per Second (Mbps) for your Virtual Cross
    /// Connect.&lt;br /&gt;&lt;br /&gt;The available bandwidths can be found using
    /// the /virtual_cross_connect_regions endpoint.
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
    /// The Border Gateway Protocol (BGP) Autonomous System Number (ASN). If null,
    /// value will be assigned by Telnyx.
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
    public ApiEnum<string, IntersectionMember2CloudProvider>? CloudProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IntersectionMember2CloudProvider>>(
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
    /// The region where your Virtual Private Cloud hosts are located.&lt;br /&gt;&lt;br
    /// /&gt;The available regions can be found using the /virtual_cross_connect_regions endpoint.
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
    /// The identifier for your Virtual Private Cloud. The number will be different
    /// based upon your Cloud provider.
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
    /// The IP address assigned for your side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value should be null for GCE as Google will only inform
    /// you of your assigned IP once the connection has been accepted.
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
    /// Indicates whether the primary circuit is enabled. Setting this to `false`
    /// will disable the circuit.
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
    /// The IP address assigned to the Telnyx side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value should be null for GCE as Google will only inform
    /// you of your assigned IP once the connection has been accepted.
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
    /// The authentication key for BGP peer configuration.
    /// </summary>
    public string? SecondaryBgpKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secondary_bgp_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_bgp_key", value);
        }
    }

    /// <summary>
    /// The identifier for your Virtual Private Cloud. The number will be different
    /// based upon your Cloud provider.&lt;br /&gt;&lt;br /&gt;This attribute is only
    /// necessary for GCE.
    /// </summary>
    public string? SecondaryCloudAccountID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secondary_cloud_account_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_cloud_account_id", value);
        }
    }

    /// <summary>
    /// The IP address assigned for your side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value should be null for GCE as Google will only inform
    /// you of your assigned IP once the connection has been accepted.
    /// </summary>
    public string? SecondaryCloudIP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secondary_cloud_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_cloud_ip", value);
        }
    }

    /// <summary>
    /// Indicates whether the secondary circuit is enabled. Setting this to `false`
    /// will disable the circuit.
    /// </summary>
    public bool? SecondaryEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "secondary_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_enabled", value);
        }
    }

    /// <summary>
    /// The IP address assigned to the Telnyx side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value should be null for GCE as Google will only inform
    /// you of your assigned IP once the connection has been accepted.
    /// </summary>
    public string? SecondaryTelnyxIP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "secondary_telnyx_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_telnyx_ip", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RegionCode;
        _ = this.BandwidthMbps;
        _ = this.BgpAsn;
        this.CloudProvider?.Validate();
        _ = this.CloudProviderRegion;
        _ = this.PrimaryBgpKey;
        _ = this.PrimaryCloudAccountID;
        _ = this.PrimaryCloudIP;
        _ = this.PrimaryEnabled;
        _ = this.PrimaryTelnyxIP;
        _ = this.SecondaryBgpKey;
        _ = this.SecondaryCloudAccountID;
        _ = this.SecondaryCloudIP;
        _ = this.SecondaryEnabled;
        _ = this.SecondaryTelnyxIP;
    }

    public IntersectionMember2 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember2 (IntersectionMember2 intersectionMember2) : base(
        intersectionMember2
    )
    {  }
    #pragma warning restore CS8618

    public IntersectionMember2 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember2 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember2FromRaw.FromRawUnchecked"/>
    public static IntersectionMember2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public IntersectionMember2 (string regionCode) : this()
    { this.RegionCode = regionCode; }
}class IntersectionMember2FromRaw : IFromRawJson<IntersectionMember2>
{
    /// <inheritdoc/>
    public IntersectionMember2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntersectionMember2.FromRawUnchecked(rawData);
}/// <summary>
/// The Virtual Private Cloud with which you would like to establish a cross connect.
/// </summary>
[JsonConverter(typeof(IntersectionMember2CloudProviderConverter))]
public enum IntersectionMember2CloudProvider
{
    Aws, Azure, Gce
}sealed class IntersectionMember2CloudProviderConverter : JsonConverter<IntersectionMember2CloudProvider>
{
    public override IntersectionMember2CloudProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws"=>IntersectionMember2CloudProvider.Aws,
            "azure"=>IntersectionMember2CloudProvider.Azure,
            "gce"=>IntersectionMember2CloudProvider.Gce,
            _ =>(IntersectionMember2CloudProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntersectionMember2CloudProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            IntersectionMember2CloudProvider.Aws=>"aws",
            IntersectionMember2CloudProvider.Azure=>"azure",
            IntersectionMember2CloudProvider.Gce=>"gce",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}