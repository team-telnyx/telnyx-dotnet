using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Networks;

namespace Telnyx.Sdk.Models.PublicInternetGateways;

[JsonConverter(typeof(JsonModelConverter<NetworkInterface, NetworkInterfaceFromRaw>))]
public sealed record class NetworkInterface : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.NetworkID;
        this.Status?.Validate();
    }

    public NetworkInterface ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkInterface (NetworkInterface networkInterface) : base(
        networkInterface
    )
    {  }
    #pragma warning restore CS8618

    public NetworkInterface (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkInterface (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkInterfaceFromRaw.FromRawUnchecked"/>
    public static NetworkInterface FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkInterfaceFromRaw : IFromRawJson<NetworkInterface>
{
    /// <inheritdoc/>
    public NetworkInterface FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkInterface.FromRawUnchecked(rawData);
}