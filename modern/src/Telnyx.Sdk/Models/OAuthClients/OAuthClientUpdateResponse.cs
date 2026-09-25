using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuthClients;

[JsonConverter(typeof(JsonModelConverter<OAuthClientUpdateResponse, OAuthClientUpdateResponseFromRaw>))]
public sealed record class OAuthClientUpdateResponse : JsonModel
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

    public OAuthClientUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthClientUpdateResponse (
        OAuthClientUpdateResponse oauthClientUpdateResponse
    ) : base(oauthClientUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthClientUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthClientUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthClientUpdateResponseFromRaw.FromRawUnchecked"/>
    public static OAuthClientUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthClientUpdateResponseFromRaw : IFromRawJson<OAuthClientUpdateResponse>
{
    /// <inheritdoc/>
    public OAuthClientUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthClientUpdateResponse.FromRawUnchecked(rawData);
}