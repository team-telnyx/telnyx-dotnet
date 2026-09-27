using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BundlePricing.UserBundles;

[JsonConverter(typeof(JsonModelConverter<UserBundleCreateResponse, UserBundleCreateResponseFromRaw>))]
public sealed record class UserBundleCreateResponse : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public UserBundleCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserBundleCreateResponse (
        UserBundleCreateResponse userBundleCreateResponse
    ) : base(userBundleCreateResponse)
    {  }
    #pragma warning restore CS8618

    public UserBundleCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserBundleCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserBundleCreateResponseFromRaw.FromRawUnchecked"/>
    public static UserBundleCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public UserBundleCreateResponse (IReadOnlyList<UserBundle> data) : this()
    { this.Data = data; }
}

class UserBundleCreateResponseFromRaw : IFromRawJson<UserBundleCreateResponse>
{
    /// <inheritdoc/>
    public UserBundleCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserBundleCreateResponse.FromRawUnchecked(rawData);
}