using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UacConnections;

[JsonConverter(typeof(JsonModelConverter<UacConnectionListPageResponse, UacConnectionListPageResponseFromRaw>))]
public sealed record class UacConnectionListPageResponse : JsonModel
{
    public IReadOnlyList<UacConnection>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UacConnection>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<UacConnection>?>(
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

    public UacConnectionListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UacConnectionListPageResponse (
        UacConnectionListPageResponse uacConnectionListPageResponse
    ) : base(uacConnectionListPageResponse)
    {  }
    #pragma warning restore CS8618

    public UacConnectionListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UacConnectionListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UacConnectionListPageResponseFromRaw.FromRawUnchecked"/>
    public static UacConnectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UacConnectionListPageResponseFromRaw : IFromRawJson<UacConnectionListPageResponse>
{
    /// <inheritdoc/>
    public UacConnectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UacConnectionListPageResponse.FromRawUnchecked(rawData);
}