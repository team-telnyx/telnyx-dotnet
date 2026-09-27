using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BundlePricing.BillingBundles;

namespace Telnyx.Sdk.Models.BundlePricing.UserBundles;

[JsonConverter(typeof(JsonModelConverter<UserBundleListPageResponse, UserBundleListPageResponseFromRaw>))]
public sealed record class UserBundleListPageResponse : JsonModel
{
    public required IReadOnlyList<UserBundle> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserBundle>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<UserBundle>>(
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

    public UserBundleListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserBundleListPageResponse (
        UserBundleListPageResponse userBundleListPageResponse
    ) : base(userBundleListPageResponse)
    {  }
    #pragma warning restore CS8618

    public UserBundleListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserBundleListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserBundleListPageResponseFromRaw.FromRawUnchecked"/>
    public static UserBundleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserBundleListPageResponseFromRaw : IFromRawJson<UserBundleListPageResponse>
{
    /// <inheritdoc/>
    public UserBundleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserBundleListPageResponse.FromRawUnchecked(rawData);
}