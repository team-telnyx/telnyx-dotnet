using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Networks;

[JsonConverter(typeof(JsonModelConverter<NetworkListInterfacesPageResponse, NetworkListInterfacesPageResponseFromRaw>))]
public sealed record class NetworkListInterfacesPageResponse : JsonModel
{
    public IReadOnlyList<NetworkListInterfacesResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NetworkListInterfacesResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<NetworkListInterfacesResponse>?>(
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

    public NetworkListInterfacesPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkListInterfacesPageResponse (
        NetworkListInterfacesPageResponse networkListInterfacesPageResponse
    ) : base(networkListInterfacesPageResponse)
    {  }
    #pragma warning restore CS8618

    public NetworkListInterfacesPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkListInterfacesPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkListInterfacesPageResponseFromRaw.FromRawUnchecked"/>
    public static NetworkListInterfacesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkListInterfacesPageResponseFromRaw : IFromRawJson<NetworkListInterfacesPageResponse>
{
    /// <inheritdoc/>
    public NetworkListInterfacesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkListInterfacesPageResponse.FromRawUnchecked(rawData);
}