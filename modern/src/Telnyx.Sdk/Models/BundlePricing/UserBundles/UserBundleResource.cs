using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BundlePricing.UserBundles;

[JsonConverter(typeof(JsonModelConverter<UserBundleResource, UserBundleResourceFromRaw>))]
public sealed record class UserBundleResource : JsonModel
{
    /// <summary>
    /// Resource's ID.
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
    /// Date the resource was created.
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
    /// The resource itself (usually a phone number).
    /// </summary>
    public required string Resource {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "resource"
            );
        }
        init { this._rawData.Set("resource", value); }
    }

    /// <summary>
    /// The type of the resource (usually 'number').
    /// </summary>
    public required string ResourceType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "resource_type"
            );
        }
        init { this._rawData.Set("resource_type", value); }
    }

    /// <summary>
    /// Date the resource was last updated.
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
        _ = this.CreatedAt;
        _ = this.Resource;
        _ = this.ResourceType;
        _ = this.UpdatedAt;
    }

    public UserBundleResource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserBundleResource (UserBundleResource userBundleResource) : base(
        userBundleResource
    )
    {  }
    #pragma warning restore CS8618

    public UserBundleResource (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserBundleResource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserBundleResourceFromRaw.FromRawUnchecked"/>
    public static UserBundleResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserBundleResourceFromRaw : IFromRawJson<UserBundleResource>
{
    /// <inheritdoc/>
    public UserBundleResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserBundleResource.FromRawUnchecked(rawData);
}