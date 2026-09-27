using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PublicInternetGateways;

[JsonConverter(typeof(JsonModelConverter<NetworkInterfaceRegion, NetworkInterfaceRegionFromRaw>))]
public sealed record class NetworkInterfaceRegion : JsonModel
{
    /// <summary>
    /// The region the interface should be deployed to.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.RegionCode; }

    public NetworkInterfaceRegion ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkInterfaceRegion (
        NetworkInterfaceRegion networkInterfaceRegion
    ) : base(networkInterfaceRegion)
    {  }
    #pragma warning restore CS8618

    public NetworkInterfaceRegion (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkInterfaceRegion (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkInterfaceRegionFromRaw.FromRawUnchecked"/>
    public static NetworkInterfaceRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkInterfaceRegionFromRaw : IFromRawJson<NetworkInterfaceRegion>
{
    /// <inheritdoc/>
    public NetworkInterfaceRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkInterfaceRegion.FromRawUnchecked(rawData);
}