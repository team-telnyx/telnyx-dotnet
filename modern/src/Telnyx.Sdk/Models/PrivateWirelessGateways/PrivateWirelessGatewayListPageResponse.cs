using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PrivateWirelessGateways;

[JsonConverter(typeof(JsonModelConverter<PrivateWirelessGatewayListPageResponse, PrivateWirelessGatewayListPageResponseFromRaw>))]
public sealed record class PrivateWirelessGatewayListPageResponse : JsonModel
{
    public IReadOnlyList<WirelessPrivateWirelessGateway>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WirelessPrivateWirelessGateway>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WirelessPrivateWirelessGateway>?>(
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

    public PrivateWirelessGatewayListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrivateWirelessGatewayListPageResponse (
        PrivateWirelessGatewayListPageResponse privateWirelessGatewayListPageResponse
    ) : base(privateWirelessGatewayListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PrivateWirelessGatewayListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PrivateWirelessGatewayListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PrivateWirelessGatewayListPageResponseFromRaw.FromRawUnchecked"/>
    public static PrivateWirelessGatewayListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PrivateWirelessGatewayListPageResponseFromRaw : IFromRawJson<PrivateWirelessGatewayListPageResponse>
{
    /// <inheritdoc/>
    public PrivateWirelessGatewayListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PrivateWirelessGatewayListPageResponse.FromRawUnchecked(rawData);
}