using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BundlePricing.UserBundles;

[JsonConverter(typeof(JsonModelConverter<UserBundleRetrieveResponse, UserBundleRetrieveResponseFromRaw>))]
public sealed record class UserBundleRetrieveResponse : JsonModel
{
    public required UserBundle Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UserBundle>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public UserBundleRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserBundleRetrieveResponse (
        UserBundleRetrieveResponse userBundleRetrieveResponse
    ) : base(userBundleRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public UserBundleRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserBundleRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserBundleRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static UserBundleRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public UserBundleRetrieveResponse (UserBundle data) : this()
    { this.Data = data; }
}

class UserBundleRetrieveResponseFromRaw : IFromRawJson<UserBundleRetrieveResponse>
{
    /// <inheritdoc/>
    public UserBundleRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserBundleRetrieveResponse.FromRawUnchecked(rawData);
}