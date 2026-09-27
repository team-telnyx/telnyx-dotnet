using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WireguardInterfaces;

[JsonConverter(typeof(JsonModelConverter<WireguardInterfaceRetrieveResponse, WireguardInterfaceRetrieveResponseFromRaw>))]
public sealed record class WireguardInterfaceRetrieveResponse : JsonModel
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

    public WireguardInterfaceRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardInterfaceRetrieveResponse (
        WireguardInterfaceRetrieveResponse wireguardInterfaceRetrieveResponse
    ) : base(wireguardInterfaceRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public WireguardInterfaceRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardInterfaceRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardInterfaceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WireguardInterfaceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardInterfaceRetrieveResponseFromRaw : IFromRawJson<WireguardInterfaceRetrieveResponse>
{
    /// <inheritdoc/>
    public WireguardInterfaceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardInterfaceRetrieveResponse.FromRawUnchecked(rawData);
}