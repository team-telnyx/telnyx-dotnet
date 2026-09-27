using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Networks;

[JsonConverter(typeof(JsonModelConverter<NetworkListPageResponse, NetworkListPageResponseFromRaw>))]
public sealed record class NetworkListPageResponse : JsonModel
{
    public IReadOnlyList<Network>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Network>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Network>?>(
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

    public NetworkListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkListPageResponse (
        NetworkListPageResponse networkListPageResponse
    ) : base(networkListPageResponse)
    {  }
    #pragma warning restore CS8618

    public NetworkListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkListPageResponseFromRaw.FromRawUnchecked"/>
    public static NetworkListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkListPageResponseFromRaw : IFromRawJson<NetworkListPageResponse>
{
    /// <inheritdoc/>
    public NetworkListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkListPageResponse.FromRawUnchecked(rawData);
}