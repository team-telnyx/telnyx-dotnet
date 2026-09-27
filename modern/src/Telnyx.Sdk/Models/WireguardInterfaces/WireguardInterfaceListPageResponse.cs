using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.WireguardInterfaces;

[JsonConverter(typeof(JsonModelConverter<WireguardInterfaceListPageResponse, WireguardInterfaceListPageResponseFromRaw>))]
public sealed record class WireguardInterfaceListPageResponse : JsonModel
{
    public IReadOnlyList<WireguardInterfaceRead>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WireguardInterfaceRead>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WireguardInterfaceRead>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public WireguardInterfaceListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WireguardInterfaceListPageResponse (
        WireguardInterfaceListPageResponse wireguardInterfaceListPageResponse
    ) : base(wireguardInterfaceListPageResponse)
    {  }
    #pragma warning restore CS8618

    public WireguardInterfaceListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WireguardInterfaceListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WireguardInterfaceListPageResponseFromRaw.FromRawUnchecked"/>
    public static WireguardInterfaceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WireguardInterfaceListPageResponseFromRaw : IFromRawJson<WireguardInterfaceListPageResponse>
{
    /// <inheritdoc/>
    public WireguardInterfaceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WireguardInterfaceListPageResponse.FromRawUnchecked(rawData);
}