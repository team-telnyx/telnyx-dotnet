using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuthGrants;

[JsonConverter(typeof(JsonModelConverter<OAuthGrantRetrieveResponse, OAuthGrantRetrieveResponseFromRaw>))]
public sealed record class OAuthGrantRetrieveResponse : JsonModel
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

    public OAuthGrantRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthGrantRetrieveResponse (
        OAuthGrantRetrieveResponse oauthGrantRetrieveResponse
    ) : base(oauthGrantRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthGrantRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthGrantRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthGrantRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static OAuthGrantRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthGrantRetrieveResponseFromRaw : IFromRawJson<OAuthGrantRetrieveResponse>
{
    /// <inheritdoc/>
    public OAuthGrantRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthGrantRetrieveResponse.FromRawUnchecked(rawData);
}