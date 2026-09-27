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

namespace Telnyx.Sdk.Models.OAuthClients;

/// <summary>
/// Creates a new OAuth client on your account for authenticating third-party integrations,
/// and returns the created client.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OAuthClientCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// List of allowed OAuth grant types
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, AllowedGrantType>> AllowedGrantTypes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ApiEnum<string, AllowedGrantType>>>(
                "allowed_grant_types"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, AllowedGrantType>>>(
                "allowed_grant_types",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of allowed OAuth scopes
    /// </summary>
    public required IReadOnlyList<string> AllowedScopes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "allowed_scopes"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "allowed_scopes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// OAuth client type
    /// </summary>
    public required ApiEnum<string, ClientType> ClientType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ClientType>>(
                "client_type"
            );
        }
        init { this._rawBodyData.Set("client_type", value); }
    }

    /// <summary>
    /// The name of the OAuth client
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
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
    /// List of redirect URIs (required for authorization_code flow)
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
    /// Whether PKCE (Proof Key for Code Exchange) is required for this client
    /// </summary>
    public bool? RequirePkce {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "require_pkce"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("require_pkce", value);
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

    public OAuthClientCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthClientCreateParams (
        OAuthClientCreateParams oauthClientCreateParams
    ) : base(oauthClientCreateParams)
    { this._rawBodyData = new(oauthClientCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public OAuthClientCreateParams (
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
    OAuthClientCreateParams (
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
    public static OAuthClientCreateParams FromRawUnchecked(
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

    public virtual bool Equals(OAuthClientCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/oauth_clients"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
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
            request, options, new() { BearerAuth = true }
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

[JsonConverter(typeof(AllowedGrantTypeConverter))]
public enum AllowedGrantType
{
    ClientCredentials, AuthorizationCode, RefreshToken
}

sealed class AllowedGrantTypeConverter : JsonConverter<AllowedGrantType>
{
    public override AllowedGrantType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_credentials"=>AllowedGrantType.ClientCredentials,
            "authorization_code"=>AllowedGrantType.AuthorizationCode,
            "refresh_token"=>AllowedGrantType.RefreshToken,
            _ =>(AllowedGrantType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AllowedGrantType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AllowedGrantType.ClientCredentials=>"client_credentials",
            AllowedGrantType.AuthorizationCode=>"authorization_code",
            AllowedGrantType.RefreshToken=>"refresh_token",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// OAuth client type
/// </summary>
[JsonConverter(typeof(ClientTypeConverter))]
public enum ClientType
{
    Public, Confidential
}

sealed class ClientTypeConverter : JsonConverter<ClientType>
{
    public override ClientType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "public"=>ClientType.Public,
            "confidential"=>ClientType.Confidential,
            _ =>(ClientType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ClientType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ClientType.Public=>"public",
            ClientType.Confidential=>"confidential",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}