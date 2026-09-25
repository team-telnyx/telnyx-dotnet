using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.VirtualCrossConnects;

/// <summary>
/// Create a new Virtual Cross Connect.&lt;br /&gt;&lt;br /&gt;For AWS and GCE, you
/// have the option of creating the primary connection first and the secondary connection
/// later. You also have the option of disabling the primary and/or secondary connections
/// at any time and later re-enabling them. With Azure, you do not have this option.
/// Azure requires both the primary and secondary connections to be created at the
/// same time and they can not be independantly disabled.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VirtualCrossConnectCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The region the interface should be deployed to.
    /// </summary>
    public required string RegionCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "region_code"
            );
        }
        init { this._rawBodyData.Set("region_code", value); }
    }

    /// <summary>
    /// The desired throughput in Megabits per Second (Mbps) for your Virtual Cross
    /// Connect.&lt;br /&gt;&lt;br /&gt;The available bandwidths can be found using
    /// the /virtual_cross_connect_regions endpoint.
    /// </summary>
    public double? BandwidthMbps {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "bandwidth_mbps"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("bandwidth_mbps", value);
        }
    }

    /// <summary>
    /// The Border Gateway Protocol (BGP) Autonomous System Number (ASN). If null,
    /// value will be assigned by Telnyx.
    /// </summary>
    public double? BgpAsn {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "bgp_asn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("bgp_asn", value);
        }
    }

    /// <summary>
    /// The Virtual Private Cloud with which you would like to establish a cross connect.
    /// </summary>
    public ApiEnum<string, CloudProvider>? CloudProvider {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CloudProvider>>(
                "cloud_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("cloud_provider", value);
        }
    }

    /// <summary>
    /// The region where your Virtual Private Cloud hosts are located.&lt;br /&gt;&lt;br
    /// /&gt;The available regions can be found using the /virtual_cross_connect_regions endpoint.
    /// </summary>
    public string? CloudProviderRegion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "cloud_provider_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("cloud_provider_region", value);
        }
    }

    /// <summary>
    /// A user specified name for the interface.
    /// </summary>
    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// The id of the network associated with the interface.
    /// </summary>
    public string? NetworkID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "network_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("network_id", value);
        }
    }

    /// <summary>
    /// The authentication key for BGP peer configuration.
    /// </summary>
    public string? PrimaryBgpKey {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "primary_bgp_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("primary_bgp_key", value);
        }
    }

    /// <summary>
    /// The identifier for your Virtual Private Cloud. The number will be different
    /// based upon your Cloud provider.
    /// </summary>
    public string? PrimaryCloudAccountID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "primary_cloud_account_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("primary_cloud_account_id", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "primary_cloud_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("primary_cloud_ip", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "primary_telnyx_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("primary_telnyx_ip", value);
        }
    }

    /// <summary>
    /// The authentication key for BGP peer configuration.
    /// </summary>
    public string? SecondaryBgpKey {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "secondary_bgp_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("secondary_bgp_key", value);
        }
    }

    /// <summary>
    /// The identifier for your Virtual Private Cloud. The number will be different
    /// based upon your Cloud provider.&lt;br /&gt;&lt;br /&gt;This attribute is only
    /// necessary for GCE.
    /// </summary>
    public string? SecondaryCloudAccountID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "secondary_cloud_account_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("secondary_cloud_account_id", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "secondary_cloud_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("secondary_cloud_ip", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "secondary_telnyx_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("secondary_telnyx_ip", value);
        }
    }

    public VirtualCrossConnectCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectCreateParams (
        VirtualCrossConnectCreateParams virtualCrossConnectCreateParams
    ) : base(virtualCrossConnectCreateParams)
    { this._rawBodyData = new(virtualCrossConnectCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public VirtualCrossConnectCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VirtualCrossConnectCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(VirtualCrossConnectCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/virtual_cross_connects"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// The Virtual Private Cloud with which you would like to establish a cross connect.
/// </summary>
[JsonConverter(typeof(CloudProviderConverter))]
public enum CloudProvider
{
    Aws, Azure, Gce
}

sealed class CloudProviderConverter : JsonConverter<CloudProvider>
{
    public override CloudProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws"=>CloudProvider.Aws,
            "azure"=>CloudProvider.Azure,
            "gce"=>CloudProvider.Gce,
            _ =>(CloudProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CloudProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CloudProvider.Aws=>"aws",
            CloudProvider.Azure=>"azure",
            CloudProvider.Gce=>"gce",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}