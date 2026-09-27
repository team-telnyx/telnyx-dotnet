using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BundlePricing.UserBundles;

[JsonConverter(typeof(JsonModelConverter<UserBundleListResourcesResponse, UserBundleListResourcesResponseFromRaw>))]
public sealed record class UserBundleListResourcesResponse : JsonModel
{
    public required IReadOnlyList<UserBundleResource> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserBundleResource>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<UserBundleResource>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public UserBundleListResourcesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserBundleListResourcesResponse (
        UserBundleListResourcesResponse userBundleListResourcesResponse
    ) : base(userBundleListResourcesResponse)
    {  }
    #pragma warning restore CS8618

    public UserBundleListResourcesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserBundleListResourcesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserBundleListResourcesResponseFromRaw.FromRawUnchecked"/>
    public static UserBundleListResourcesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public UserBundleListResourcesResponse (
        IReadOnlyList<UserBundleResource> data
    ) : this()
    { this.Data = data; }
}

class UserBundleListResourcesResponseFromRaw : IFromRawJson<UserBundleListResourcesResponse>
{
    /// <inheritdoc/>
    public UserBundleListResourcesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserBundleListResourcesResponse.FromRawUnchecked(rawData);
}