using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OAuth;

/// <summary>
/// Register a new OAuth client dynamically (RFC 7591)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OAuthRegisterParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Human-readable string name of the client to be presented to the end-user
    /// </summary>
    public string? ClientName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_name", value);
        }
    }

    /// <summary>
    /// Array of OAuth 2.0 grant type strings that the client may use
    /// </summary>
    public IReadOnlyList<ApiEnum<string, GrantType>>? GrantTypes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ApiEnum<string, GrantType>>>(
                "grant_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, GrantType>>?>(
                "grant_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// URL of the client logo
    /// </summary>
    public string? LogoUri {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "logo_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("logo_uri", value);
        }
    }

    /// <summary>
    /// URL of the client's privacy policy
    /// </summary>
    public string? PolicyUri {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "policy_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("policy_uri", value);
        }
    }

    /// <summary>
    /// Array of redirection URI strings for use in redirect-based flows
    /// </summary>
    public IReadOnlyList<string>? RedirectUris {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "redirect_uris"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "redirect_uris",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of the OAuth 2.0 response type strings that the client may use
    /// </summary>
    public IReadOnlyList<string>? ResponseTypes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "response_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "response_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Space-separated string of scope values that the client may use
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

    /// <summary>
    /// Authentication method for the token endpoint
    /// </summary>
    public ApiEnum<string, TokenEndpointAuthMethod>? TokenEndpointAuthMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TokenEndpointAuthMethod>>(
                "token_endpoint_auth_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("token_endpoint_auth_method", value);
        }
    }

    /// <summary>
    /// URL of the client's terms of service
    /// </summary>
    public string? TosUri {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "tos_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("tos_uri", value);
        }
    }

    public OAuthRegisterParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthRegisterParams (OAuthRegisterParams oauthRegisterParams) : base(
        oauthRegisterParams
    )
    { this._rawBodyData = new(oauthRegisterParams._rawBodyData); }
    #pragma warning restore CS8618

    public OAuthRegisterParams (
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
    OAuthRegisterParams (
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
    public static OAuthRegisterParams FromRawUnchecked(
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

    public virtual bool Equals(OAuthRegisterParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/oauth/register"
        )
        {
            Query = this.QueryString(options, new())
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
        ParamsBase.AddDefaultHeaders(request, options, new());
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

[JsonConverter(typeof(GrantTypeConverter))]
public enum GrantType
{
    AuthorizationCode, ClientCredentials, RefreshToken
}

sealed class GrantTypeConverter : JsonConverter<GrantType>
{
    public override GrantType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "authorization_code"=>GrantType.AuthorizationCode,
            "client_credentials"=>GrantType.ClientCredentials,
            "refresh_token"=>GrantType.RefreshToken,
            _ =>(GrantType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, GrantType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            GrantType.AuthorizationCode=>"authorization_code",
            GrantType.ClientCredentials=>"client_credentials",
            GrantType.RefreshToken=>"refresh_token",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Authentication method for the token endpoint
/// </summary>
[JsonConverter(typeof(TokenEndpointAuthMethodConverter))]
public enum TokenEndpointAuthMethod
{
    None, ClientSecretBasic, ClientSecretPost
}

sealed class TokenEndpointAuthMethodConverter : JsonConverter<TokenEndpointAuthMethod>
{
    public override TokenEndpointAuthMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none"=>TokenEndpointAuthMethod.None,
            "client_secret_basic"=>TokenEndpointAuthMethod.ClientSecretBasic,
            "client_secret_post"=>TokenEndpointAuthMethod.ClientSecretPost,
            _ =>(TokenEndpointAuthMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TokenEndpointAuthMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TokenEndpointAuthMethod.None=>"none",
            TokenEndpointAuthMethod.ClientSecretBasic=>"client_secret_basic",
            TokenEndpointAuthMethod.ClientSecretPost=>"client_secret_post",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}