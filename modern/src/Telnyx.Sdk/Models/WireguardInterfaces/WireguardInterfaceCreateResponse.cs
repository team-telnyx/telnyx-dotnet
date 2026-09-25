using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WireguardInterfaces;

[JsonConverter(typeof(JsonModelConverter<WireguardInterfaceCreateResponse, WireguardInterfaceCreateResponseFromRaw>))]
public sealed record class WireguardInterfaceCreateResponse : JsonModel
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

    public WireguardInterfaceCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardInterfaceCreateResponse (
        WireguardInterfaceCreateResponse wireguardInterfaceCreateResponse
    ) : base(wireguardInterfaceCreateResponse)
    {  }
    #pragma warning restore CS8618

    public WireguardInterfaceCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardInterfaceCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardInterfaceCreateResponseFromRaw.FromRawUnchecked"/>
    public static WireguardInterfaceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardInterfaceCreateResponseFromRaw : IFromRawJson<WireguardInterfaceCreateResponse>
{
    /// <inheritdoc/>
    public WireguardInterfaceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardInterfaceCreateResponse.FromRawUnchecked(rawData);
}