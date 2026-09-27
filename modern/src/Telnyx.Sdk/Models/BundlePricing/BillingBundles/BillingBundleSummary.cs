using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BundlePricing.BillingBundles;

[JsonConverter(typeof(JsonModelConverter<BillingBundleSummary, BillingBundleSummaryFromRaw>))]
public sealed record class BillingBundleSummary : JsonModel
{
    /// <summary>
    /// Bundle's ID, this is used to identify the bundle in the API.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Bundle's cost code, this is used to identify the bundle in the billing system.
    /// </summary>
    public required string CostCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "cost_code"
            );
        }
        init { this._rawData.Set("cost_code", value); }
    }

    /// <summary>
    /// Date the bundle was created.
    /// </summary>
    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Available to all customers or only to specific customers.
    /// </summary>
    public required bool IsPublic {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "is_public"
            );
        }
        init { this._rawData.Set("is_public", value); }
    }

    /// <summary>
    /// Bundle's name, this is used to identify the bundle in the UI.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Bundle's currency code.
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Monthly recurring charge price.
    /// </summary>
    public float? MrcPrice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "mrc_price"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mrc_price", value);
        }
    }

    /// <summary>
    /// Slugified version of the bundle's name.
    /// </summary>
    public string? Slug {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "slug"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("slug", value);
        }
    }

    public IReadOnlyList<string>? Specs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "specs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "specs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CostCode;
        _ = this.CreatedAt;
        _ = this.IsPublic;
        _ = this.Name;
        _ = this.Currency;
        _ = this.MrcPrice;
        _ = this.Slug;
        _ = this.Specs;
    }

    public BillingBundleSummary ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingBundleSummary (
        BillingBundleSummary billingBundleSummary
    ) : base(billingBundleSummary)
    {  }
    #pragma warning restore CS8618

    public BillingBundleSummary (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingBundleSummary (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BillingBundleSummaryFromRaw.FromRawUnchecked"/>
    public static BillingBundleSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BillingBundleSummaryFromRaw : IFromRawJson<BillingBundleSummary>
{
    /// <inheritdoc/>
    public BillingBundleSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BillingBundleSummary.FromRawUnchecked(rawData);
}