using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuth;

[JsonConverter(typeof(JsonModelConverter<OAuthIntrospectResponse, OAuthIntrospectResponseFromRaw>))]
public sealed record class OAuthIntrospectResponse : JsonModel
{
    /// <summary>
    /// Whether the token is active
    /// </summary>
    public required bool Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "active"
            );
        }
        init { this._rawData.Set("active", value); }
    }

    /// <summary>
    /// Audience
    /// </summary>
    public string? Aud {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "aud"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("aud", value);
        }
    }

    /// <summary>
    /// Client identifier
    /// </summary>
    public string? ClientID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_id", value);
        }
    }

    /// <summary>
    /// Expiration timestamp
    /// </summary>
    public long? Exp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "exp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("exp", value);
        }
    }

    /// <summary>
    /// Issued at timestamp
    /// </summary>
    public long? Iat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "iat"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("iat", value);
        }
    }

    /// <summary>
    /// Issuer
    /// </summary>
    public string? Iss {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "iss"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("iss", value);
        }
    }

    /// <summary>
    /// Space-separated list of scopes
    /// </summary>
    public string? Scope {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "scope"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("scope", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        _ = this.Aud;
        _ = this.ClientID;
        _ = this.Exp;
        _ = this.Iat;
        _ = this.Iss;
        _ = this.Scope;
    }

    public OAuthIntrospectResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthIntrospectResponse (
        OAuthIntrospectResponse oauthIntrospectResponse
    ) : base(oauthIntrospectResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthIntrospectResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthIntrospectResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthIntrospectResponseFromRaw.FromRawUnchecked"/>
    public static OAuthIntrospectResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public OAuthIntrospectResponse (bool active) : this()
    { this.Active = active; }
}

class OAuthIntrospectResponseFromRaw : IFromRawJson<OAuthIntrospectResponse>
{
    /// <inheritdoc/>
    public OAuthIntrospectResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthIntrospectResponse.FromRawUnchecked(rawData);
}