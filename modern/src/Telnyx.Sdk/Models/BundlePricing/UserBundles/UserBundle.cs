using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BundlePricing.BillingBundles;

namespace Telnyx.Sdk.Models.BundlePricing.UserBundles;

[JsonConverter(typeof(JsonModelConverter<UserBundle, UserBundleFromRaw>))]
public sealed record class UserBundle : JsonModel
{
    /// <summary>
    /// User bundle's ID, this is used to identify the user bundle in the API.
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
    /// Status of the user bundle.
    /// </summary>
    public required bool Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "active"
            );
        }
        init { this._rawData.Set("active", value); }
    }

    public required BillingBundleSummary BillingBundle {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BillingBundleSummary>(
                "billing_bundle"
            );
        }
        init { this._rawData.Set("billing_bundle", value); }
    }

    /// <summary>
    /// Date the user bundle was created.
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

    public required IReadOnlyList<UserBundleResource> Resources {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserBundleResource>>(
                "resources"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<UserBundleResource>>(
                "resources",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The customer's ID that owns this user bundle.
    /// </summary>
    public required string UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "user_id"
            );
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// Date the user bundle was last updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        this.BillingBundle.Validate();
        _ = this.CreatedAt;
        foreach (var item in this.Resources)
        {
            item.Validate();
        }
        _ = this.UserID;
        _ = this.UpdatedAt;
    }

    public UserBundle ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserBundle (UserBundle userBundle) : base(userBundle)
    {  }
    #pragma warning restore CS8618

    public UserBundle (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserBundle (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserBundleFromRaw.FromRawUnchecked"/>
    public static UserBundle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserBundleFromRaw : IFromRawJson<UserBundle>
{
    /// <inheritdoc/>
    public UserBundle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserBundle.FromRawUnchecked(rawData);
}