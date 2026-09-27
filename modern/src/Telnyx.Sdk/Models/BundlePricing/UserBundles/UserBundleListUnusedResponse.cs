using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using BillingBundles = Telnyx.Sdk.Models.BundlePricing.BillingBundles;

namespace Telnyx.Sdk.Models.BundlePricing.UserBundles;

[JsonConverter(typeof(JsonModelConverter<UserBundleListUnusedResponse, UserBundleListUnusedResponseFromRaw>))]
public sealed record class UserBundleListUnusedResponse : JsonModel
{
    public required IReadOnlyList<Data> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Data>>(
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

    public UserBundleListUnusedResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserBundleListUnusedResponse (
        UserBundleListUnusedResponse userBundleListUnusedResponse
    ) : base(userBundleListUnusedResponse)
    {  }
    #pragma warning restore CS8618

    public UserBundleListUnusedResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserBundleListUnusedResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserBundleListUnusedResponseFromRaw.FromRawUnchecked"/>
    public static UserBundleListUnusedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public UserBundleListUnusedResponse (IReadOnlyList<Data> data) : this()
    { this.Data = data; }
}

class UserBundleListUnusedResponseFromRaw : IFromRawJson<UserBundleListUnusedResponse>
{
    /// <inheritdoc/>
    public UserBundleListUnusedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserBundleListUnusedResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required BillingBundles::BillingBundleSummary BillingBundle {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BillingBundles::BillingBundleSummary>(
                "billing_bundle"
            );
        }
        init { this._rawData.Set("billing_bundle", value); }
    }

    /// <summary>
    /// List of user bundle IDs for given bundle.
    /// </summary>
    public required IReadOnlyList<string> UserBundleIds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "user_bundle_ids"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "user_bundle_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingBundle.Validate();
        _ = this.UserBundleIds;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}