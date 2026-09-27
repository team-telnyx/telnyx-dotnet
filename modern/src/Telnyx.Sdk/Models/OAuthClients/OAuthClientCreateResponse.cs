using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuthClients;

[JsonConverter(typeof(JsonModelConverter<OAuthClientCreateResponse, OAuthClientCreateResponseFromRaw>))]
public sealed record class OAuthClientCreateResponse : JsonModel
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

    public OAuthClientCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthClientCreateResponse (
        OAuthClientCreateResponse oauthClientCreateResponse
    ) : base(oauthClientCreateResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthClientCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthClientCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthClientCreateResponseFromRaw.FromRawUnchecked"/>
    public static OAuthClientCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthClientCreateResponseFromRaw : IFromRawJson<OAuthClientCreateResponse>
{
    /// <inheritdoc/>
    public OAuthClientCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthClientCreateResponse.FromRawUnchecked(rawData);
}