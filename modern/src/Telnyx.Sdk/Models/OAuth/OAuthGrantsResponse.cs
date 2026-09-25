using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuth;

[JsonConverter(typeof(JsonModelConverter<OAuthGrantsResponse, OAuthGrantsResponseFromRaw>))]
public sealed record class OAuthGrantsResponse : JsonModel
{
    /// <summary>
    /// Redirect URI with authorization code or error
    /// </summary>
    public required string RedirectUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "redirect_uri"
            );
        }
        init { this._rawData.Set("redirect_uri", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.RedirectUri; }

    public OAuthGrantsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthGrantsResponse (OAuthGrantsResponse oauthGrantsResponse) : base(
        oauthGrantsResponse
    )
    {  }
    #pragma warning restore CS8618

    public OAuthGrantsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthGrantsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthGrantsResponseFromRaw.FromRawUnchecked"/>
    public static OAuthGrantsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public OAuthGrantsResponse (string redirectUri) : this()
    { this.RedirectUri = redirectUri; }
}

class OAuthGrantsResponseFromRaw : IFromRawJson<OAuthGrantsResponse>
{
    /// <inheritdoc/>
    public OAuthGrantsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthGrantsResponse.FromRawUnchecked(rawData);
}