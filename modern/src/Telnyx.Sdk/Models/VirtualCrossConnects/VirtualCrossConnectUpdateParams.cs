using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VirtualCrossConnects;

/// <summary>
/// Update the Virtual Cross Connect.&lt;br /&gt;&lt;br /&gt;Cloud IPs can only be
/// patched during the `created` state, as GCE will only inform you of your generated
/// IP once the pending connection requested has been accepted. Once the Virtual Cross
/// Connect has moved to `provisioning`, the IPs can no longer be patched.&lt;br
/// /&gt;&lt;br /&gt;Once the Virtual Cross Connect has moved to `provisioned` and
/// you are ready to enable routing, you can toggle the routing announcements to `true`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VirtualCrossConnectUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// The IP address assigned for your side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value can not be patched once the VXC has bene provisioned.
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
    /// Indicates whether the primary circuit is enabled. Setting this to `false`
    /// will disable the circuit.
    /// </summary>
    public bool? PrimaryEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "primary_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("primary_enabled", value);
        }
    }

    /// <summary>
    /// Whether the primary BGP route is being announced.
    /// </summary>
    public bool? PrimaryRoutingAnnouncement {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "primary_routing_announcement"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("primary_routing_announcement", value);
        }
    }

    /// <summary>
    /// The IP address assigned for your side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value can not be patched once the VXC has bene provisioned.
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
    /// Indicates whether the secondary circuit is enabled. Setting this to `false`
    /// will disable the circuit.
    /// </summary>
    public bool? SecondaryEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "secondary_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("secondary_enabled", value);
        }
    }

    /// <summary>
    /// Whether the secondary BGP route is being announced.
    /// </summary>
    public bool? SecondaryRoutingAnnouncement {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "secondary_routing_announcement"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("secondary_routing_announcement", value);
        }
    }

    public VirtualCrossConnectUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectUpdateParams (
        VirtualCrossConnectUpdateParams virtualCrossConnectUpdateParams
    ) : base(virtualCrossConnectUpdateParams)
    {
        this.ID = virtualCrossConnectUpdateParams.ID;

        this._rawBodyData = new(virtualCrossConnectUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public VirtualCrossConnectUpdateParams (
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
    VirtualCrossConnectUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VirtualCrossConnectUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(VirtualCrossConnectUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/virtual_cross_connects/{0}",
            EncodePathSegment(this.ID))
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