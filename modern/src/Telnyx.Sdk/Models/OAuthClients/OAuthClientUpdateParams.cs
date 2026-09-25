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
/// Updates the specified OAuth client's configuration and returns the updated client.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OAuthClientUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// List of allowed OAuth grant types
    /// </summary>
    public IReadOnlyList<ApiEnum<string, OAuthClientUpdateParamsAllowedGrantType>>? AllowedGrantTypes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ApiEnum<string, OAuthClientUpdateParamsAllowedGrantType>>>(
                "allowed_grant_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, OAuthClientUpdateParamsAllowedGrantType>>?>(
                "allowed_grant_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of allowed OAuth scopes
    /// </summary>
    public IReadOnlyList<string>? AllowedScopes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "allowed_scopes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "allowed_scopes",
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
    /// The name of the OAuth client
    /// </summary>
    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("name", value);
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
    /// List of redirect URIs
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

    public OAuthClientUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthClientUpdateParams (
        OAuthClientUpdateParams oauthClientUpdateParams
    ) : base(oauthClientUpdateParams)
    {
        this.ID = oauthClientUpdateParams.ID;

        this._rawBodyData = new(oauthClientUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public OAuthClientUpdateParams (
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
    OAuthClientUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static OAuthClientUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(OAuthClientUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/oauth_clients/{0}",
            this.ID)
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

[JsonConverter(typeof(OAuthClientUpdateParamsAllowedGrantTypeConverter))]
public enum OAuthClientUpdateParamsAllowedGrantType
{
    ClientCredentials, AuthorizationCode, RefreshToken
}

sealed class OAuthClientUpdateParamsAllowedGrantTypeConverter : JsonConverter<OAuthClientUpdateParamsAllowedGrantType>
{
    public override OAuthClientUpdateParamsAllowedGrantType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_credentials"=>OAuthClientUpdateParamsAllowedGrantType.ClientCredentials,
            "authorization_code"=>OAuthClientUpdateParamsAllowedGrantType.AuthorizationCode,
            "refresh_token"=>OAuthClientUpdateParamsAllowedGrantType.RefreshToken,
            _ =>(OAuthClientUpdateParamsAllowedGrantType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OAuthClientUpdateParamsAllowedGrantType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OAuthClientUpdateParamsAllowedGrantType.ClientCredentials=>"client_credentials",
            OAuthClientUpdateParamsAllowedGrantType.AuthorizationCode=>"authorization_code",
            OAuthClientUpdateParamsAllowedGrantType.RefreshToken=>"refresh_token",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}