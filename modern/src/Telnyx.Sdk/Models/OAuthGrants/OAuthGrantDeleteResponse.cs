using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuthGrants;

[JsonConverter(typeof(JsonModelConverter<OAuthGrantDeleteResponse, OAuthGrantDeleteResponseFromRaw>))]
public sealed record class OAuthGrantDeleteResponse : JsonModel
{
    public OAuthGrant? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OAuthGrant>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public OAuthGrantDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthGrantDeleteResponse (
        OAuthGrantDeleteResponse oauthGrantDeleteResponse
    ) : base(oauthGrantDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthGrantDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthGrantDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthGrantDeleteResponseFromRaw.FromRawUnchecked"/>
    public static OAuthGrantDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthGrantDeleteResponseFromRaw : IFromRawJson<OAuthGrantDeleteResponse>
{
    /// <inheritdoc/>
    public OAuthGrantDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthGrantDeleteResponse.FromRawUnchecked(rawData);
}