using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BundlePricing.UserBundles;

[JsonConverter(typeof(JsonModelConverter<UserBundleDeactivateResponse, UserBundleDeactivateResponseFromRaw>))]
public sealed record class UserBundleDeactivateResponse : JsonModel
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

    public UserBundleDeactivateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserBundleDeactivateResponse (
        UserBundleDeactivateResponse userBundleDeactivateResponse
    ) : base(userBundleDeactivateResponse)
    {  }
    #pragma warning restore CS8618

    public UserBundleDeactivateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserBundleDeactivateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserBundleDeactivateResponseFromRaw.FromRawUnchecked"/>
    public static UserBundleDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public UserBundleDeactivateResponse (UserBundle data) : this()
    { this.Data = data; }
}

class UserBundleDeactivateResponseFromRaw : IFromRawJson<UserBundleDeactivateResponse>
{
    /// <inheritdoc/>
    public UserBundleDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserBundleDeactivateResponse.FromRawUnchecked(rawData);
}