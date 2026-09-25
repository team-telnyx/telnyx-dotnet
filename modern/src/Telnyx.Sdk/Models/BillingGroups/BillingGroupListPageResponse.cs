using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.BillingGroups;

[JsonConverter(typeof(JsonModelConverter<BillingGroupListPageResponse, BillingGroupListPageResponseFromRaw>))]
public sealed record class BillingGroupListPageResponse : JsonModel
{
    public IReadOnlyList<BillingGroup>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BillingGroup>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<BillingGroup>?>(
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

    public BillingGroupListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingGroupListPageResponse (
        BillingGroupListPageResponse billingGroupListPageResponse
    ) : base(billingGroupListPageResponse)
    {  }
    #pragma warning restore CS8618

    public BillingGroupListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingGroupListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BillingGroupListPageResponseFromRaw.FromRawUnchecked"/>
    public static BillingGroupListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BillingGroupListPageResponseFromRaw : IFromRawJson<BillingGroupListPageResponse>
{
    /// <inheritdoc/>
    public BillingGroupListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BillingGroupListPageResponse.FromRawUnchecked(rawData);
}