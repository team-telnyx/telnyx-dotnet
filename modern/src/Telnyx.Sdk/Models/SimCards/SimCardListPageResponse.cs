using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.SimCards;

[JsonConverter(typeof(JsonModelConverter<SimCardListPageResponse, SimCardListPageResponseFromRaw>))]
public sealed record class SimCardListPageResponse : JsonModel
{
    public IReadOnlyList<SimpleSimCard>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimpleSimCard>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SimpleSimCard>?>(
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

    public SimCardListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardListPageResponse (
        SimCardListPageResponse simCardListPageResponse
    ) : base(simCardListPageResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardListPageResponseFromRaw.FromRawUnchecked"/>
    public static SimCardListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardListPageResponseFromRaw : IFromRawJson<SimCardListPageResponse>
{
    /// <inheritdoc/>
    public SimCardListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardListPageResponse.FromRawUnchecked(rawData);
}