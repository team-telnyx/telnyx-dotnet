using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BundlePricing.BillingBundles;

[JsonConverter(typeof(JsonModelConverter<BillingBundleListPageResponse, BillingBundleListPageResponseFromRaw>))]
public sealed record class BillingBundleListPageResponse : JsonModel
{
    public required IReadOnlyList<BillingBundleSummary> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BillingBundleSummary>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<BillingBundleSummary>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationResponse Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginationResponse>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public BillingBundleListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingBundleListPageResponse (
        BillingBundleListPageResponse billingBundleListPageResponse
    ) : base(billingBundleListPageResponse)
    {  }
    #pragma warning restore CS8618

    public BillingBundleListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingBundleListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BillingBundleListPageResponseFromRaw.FromRawUnchecked"/>
    public static BillingBundleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BillingBundleListPageResponseFromRaw : IFromRawJson<BillingBundleListPageResponse>
{
    /// <inheritdoc/>
    public BillingBundleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BillingBundleListPageResponse.FromRawUnchecked(rawData);
}