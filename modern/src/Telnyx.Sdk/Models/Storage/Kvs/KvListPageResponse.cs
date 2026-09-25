using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Kvs;

[JsonConverter(typeof(JsonModelConverter<KvListPageResponse, KvListPageResponseFromRaw>))]
public sealed record class KvListPageResponse : JsonModel
{
    public IReadOnlyList<KvNamespace>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<KvNamespace>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<KvNamespace>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public EdgeComputePaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EdgeComputePaginationMeta>(
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

    public KvListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public KvListPageResponse (KvListPageResponse kvListPageResponse) : base(
        kvListPageResponse
    )
    {  }
    #pragma warning restore CS8618

    public KvListPageResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    KvListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="KvListPageResponseFromRaw.FromRawUnchecked"/>
    public static KvListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class KvListPageResponseFromRaw : IFromRawJson<KvListPageResponse>
{
    /// <inheritdoc/>
    public KvListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>KvListPageResponse.FromRawUnchecked(rawData);
}