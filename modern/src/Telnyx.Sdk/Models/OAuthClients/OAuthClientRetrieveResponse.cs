using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuthClients;

[JsonConverter(typeof(JsonModelConverter<OAuthClientRetrieveResponse, OAuthClientRetrieveResponseFromRaw>))]
public sealed record class OAuthClientRetrieveResponse : JsonModel
{
    public OAuthClient? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OAuthClient>(
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

    public OAuthClientRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthClientRetrieveResponse (
        OAuthClientRetrieveResponse oauthClientRetrieveResponse
    ) : base(oauthClientRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthClientRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthClientRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthClientRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static OAuthClientRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthClientRetrieveResponseFromRaw : IFromRawJson<OAuthClientRetrieveResponse>
{
    /// <inheritdoc/>
    public OAuthClientRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthClientRetrieveResponse.FromRawUnchecked(rawData);
}