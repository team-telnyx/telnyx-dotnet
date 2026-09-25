using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.InexplicitNumberOrders;

[JsonConverter(typeof(JsonModelConverter<InexplicitNumberOrderListPageResponse, InexplicitNumberOrderListPageResponseFromRaw>))]
public sealed record class InexplicitNumberOrderListPageResponse : JsonModel
{
    public IReadOnlyList<InexplicitNumberOrderResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InexplicitNumberOrderResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<InexplicitNumberOrderResponse>?>(
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

    public InexplicitNumberOrderListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InexplicitNumberOrderListPageResponse (
        InexplicitNumberOrderListPageResponse inexplicitNumberOrderListPageResponse
    ) : base(inexplicitNumberOrderListPageResponse)
    {  }
    #pragma warning restore CS8618

    public InexplicitNumberOrderListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InexplicitNumberOrderListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InexplicitNumberOrderListPageResponseFromRaw.FromRawUnchecked"/>
    public static InexplicitNumberOrderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InexplicitNumberOrderListPageResponseFromRaw : IFromRawJson<InexplicitNumberOrderListPageResponse>
{
    /// <inheritdoc/>
    public InexplicitNumberOrderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InexplicitNumberOrderListPageResponse.FromRawUnchecked(rawData);
}