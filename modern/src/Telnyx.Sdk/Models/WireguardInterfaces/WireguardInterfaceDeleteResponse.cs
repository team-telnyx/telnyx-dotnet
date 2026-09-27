using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WireguardInterfaces;

[JsonConverter(typeof(JsonModelConverter<WireguardInterfaceDeleteResponse, WireguardInterfaceDeleteResponseFromRaw>))]
public sealed record class WireguardInterfaceDeleteResponse : JsonModel
{
    public WireguardInterfaceRead? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WireguardInterfaceRead>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public WireguardInterfaceDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardInterfaceDeleteResponse (
        WireguardInterfaceDeleteResponse wireguardInterfaceDeleteResponse
    ) : base(wireguardInterfaceDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public WireguardInterfaceDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardInterfaceDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardInterfaceDeleteResponseFromRaw.FromRawUnchecked"/>
    public static WireguardInterfaceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardInterfaceDeleteResponseFromRaw : IFromRawJson<WireguardInterfaceDeleteResponse>
{
    /// <inheritdoc/>
    public WireguardInterfaceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardInterfaceDeleteResponse.FromRawUnchecked(rawData);
}