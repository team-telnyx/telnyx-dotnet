using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VirtualCrossConnects;

[JsonConverter(typeof(JsonModelConverter<VirtualCrossConnectPatch, VirtualCrossConnectPatchFromRaw>))]
public sealed record class VirtualCrossConnectPatch : JsonModel
{
    /// <summary>
    /// The IP address assigned for your side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value can not be patched once the VXC has bene provisioned.
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
    /// Whether the primary BGP route is being announced.
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
    /// The IP address assigned for your side of the Virtual Cross Connect.&lt;br
    /// /&gt;&lt;br /&gt;If none is provided, one will be generated for you.&lt;br
    /// /&gt;&lt;br /&gt;This value can not be patched once the VXC has bene provisioned.
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
    /// Whether the secondary BGP route is being announced.
    /// </summary>
    public bool? SecondaryRoutingAnnouncement {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "secondary_routing_announcement"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("secondary_routing_announcement", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PrimaryCloudIP;
        _ = this.PrimaryEnabled;
        _ = this.PrimaryRoutingAnnouncement;
        _ = this.SecondaryCloudIP;
        _ = this.SecondaryEnabled;
        _ = this.SecondaryRoutingAnnouncement;
    }

    public VirtualCrossConnectPatch ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectPatch (
        VirtualCrossConnectPatch virtualCrossConnectPatch
    ) : base(virtualCrossConnectPatch)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectPatch (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectPatch (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VirtualCrossConnectPatchFromRaw.FromRawUnchecked"/>
    public static VirtualCrossConnectPatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VirtualCrossConnectPatchFromRaw : IFromRawJson<VirtualCrossConnectPatch>
{
    /// <inheritdoc/>
    public VirtualCrossConnectPatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VirtualCrossConnectPatch.FromRawUnchecked(rawData);
}