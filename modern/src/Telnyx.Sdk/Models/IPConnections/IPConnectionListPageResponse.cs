using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.IPConnections;

[JsonConverter(typeof(JsonModelConverter<IPConnectionListPageResponse, IPConnectionListPageResponseFromRaw>))]
public sealed record class IPConnectionListPageResponse : JsonModel
{
    public IReadOnlyList<IPConnection>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<IPConnection>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<IPConnection>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ConnectionsPaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConnectionsPaginationMeta>(
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

    public IPConnectionListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IPConnectionListPageResponse (
        IPConnectionListPageResponse ipConnectionListPageResponse
    ) : base(ipConnectionListPageResponse)
    {  }
    #pragma warning restore CS8618

    public IPConnectionListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IPConnectionListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IPConnectionListPageResponseFromRaw.FromRawUnchecked"/>
    public static IPConnectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IPConnectionListPageResponseFromRaw : IFromRawJson<IPConnectionListPageResponse>
{
    /// <inheritdoc/>
    public IPConnectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IPConnectionListPageResponse.FromRawUnchecked(rawData);
}