using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OAuth;

/// <summary>
/// Exchange authorization code, client credentials, or refresh token for access token
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OAuthTokenParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// OAuth 2.0 grant type
    /// </summary>
    public required ApiEnum<string, OAuthTokenParamsGrantType> GrantType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, OAuthTokenParamsGrantType>>(
                "grant_type"
            );
        }
        init { this._rawBodyData.Set("grant_type", value); }
    }

    /// <summary>
    /// OAuth client ID (if not using HTTP Basic auth)
    /// </summary>
    public string? ClientID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_id", value);
        }
    }

    /// <summary>
    /// OAuth client secret (if not using HTTP Basic auth)
    /// </summary>
    public string? ClientSecret {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_secret"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_secret", value);
        }
    }

    /// <summary>
    /// Authorization code (for authorization_code flow)
    /// </summary>
    public string? Code {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("code", value);
        }
    }

    /// <summary>
    /// PKCE code verifier (for authorization_code flow)
    /// </summary>
    public string? CodeVerifier {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "code_verifier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("code_verifier", value);
        }
    }

    /// <summary>
    /// Redirect URI (for authorization_code flow)
    /// </summary>
    public string? RedirectUri {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "redirect_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("redirect_uri", value);
        }
    }

    /// <summary>
    /// Refresh token (for refresh_token flow)
    /// </summary>
    public string? RefreshToken {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "refresh_token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("refresh_token", value);
        }
    }

    /// <summary>
    /// Space-separated list of requested scopes (for client_credentials)
    /// </summary>
    public string? Scope {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "scope"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("scope", value);
        }
    }

    public OAuthTokenParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthTokenParams (OAuthTokenParams oauthTokenParams) : base(
        oauthTokenParams
    )
    { this._rawBodyData = new(oauthTokenParams._rawBodyData); }
    #pragma warning restore CS8618

    public OAuthTokenParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthTokenParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static OAuthTokenParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(OAuthTokenParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/oauth/token"
        )
        {
            Query = this.QueryString(options, new() { OAuthClientAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { OAuthClientAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// OAuth 2.0 grant type
/// </summary>
[JsonConverter(typeof(OAuthTokenParamsGrantTypeConverter))]
public enum OAuthTokenParamsGrantType
{
    ClientCredentials, AuthorizationCode, RefreshToken
}

sealed class OAuthTokenParamsGrantTypeConverter : JsonConverter<OAuthTokenParamsGrantType>
{
    public override OAuthTokenParamsGrantType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_credentials"=>OAuthTokenParamsGrantType.ClientCredentials,
            "authorization_code"=>OAuthTokenParamsGrantType.AuthorizationCode,
            "refresh_token"=>OAuthTokenParamsGrantType.RefreshToken,
            _ =>(OAuthTokenParamsGrantType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OAuthTokenParamsGrantType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OAuthTokenParamsGrantType.ClientCredentials=>"client_credentials",
            OAuthTokenParamsGrantType.AuthorizationCode=>"authorization_code",
            OAuthTokenParamsGrantType.RefreshToken=>"refresh_token",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}