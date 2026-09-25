using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuth;

[JsonConverter(typeof(JsonModelConverter<OAuthRegisterResponse, OAuthRegisterResponseFromRaw>))]
public sealed record class OAuthRegisterResponse : JsonModel
{
    /// <summary>
    /// Unique client identifier
    /// </summary>
    public required string ClientID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "client_id"
            );
        }
        init { this._rawData.Set("client_id", value); }
    }

    /// <summary>
    /// Unix timestamp of when the client ID was issued
    /// </summary>
    public required long ClientIDIssuedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "client_id_issued_at"
            );
        }
        init { this._rawData.Set("client_id_issued_at", value); }
    }

    /// <summary>
    /// Human-readable client name
    /// </summary>
    public string? ClientName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_name", value);
        }
    }

    /// <summary>
    /// Client secret (only for confidential clients)
    /// </summary>
    public string? ClientSecret {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_secret"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_secret", value);
        }
    }

    /// <summary>
    /// Array of allowed grant types
    /// </summary>
    public IReadOnlyList<string>? GrantTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "grant_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "logo_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("logo_uri", value);
        }
    }

    /// <summary>
    /// URL of the client's privacy policy
    /// </summary>
    public string? PolicyUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "policy_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("policy_uri", value);
        }
    }

    /// <summary>
    /// Array of redirection URIs
    /// </summary>
    public IReadOnlyList<string>? RedirectUris {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "redirect_uris"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "redirect_uris",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of allowed response types
    /// </summary>
    public IReadOnlyList<string>? ResponseTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "response_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "response_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Space-separated scope values
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

    /// <summary>
    /// Token endpoint authentication method
    /// </summary>
    public string? TokenEndpointAuthMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "token_endpoint_auth_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("token_endpoint_auth_method", value);
        }
    }

    /// <summary>
    /// URL of the client's terms of service
    /// </summary>
    public string? TosUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tos_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tos_uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientID;
        _ = this.ClientIDIssuedAt;
        _ = this.ClientName;
        _ = this.ClientSecret;
        _ = this.GrantTypes;
        _ = this.LogoUri;
        _ = this.PolicyUri;
        _ = this.RedirectUris;
        _ = this.ResponseTypes;
        _ = this.Scope;
        _ = this.TokenEndpointAuthMethod;
        _ = this.TosUri;
    }

    public OAuthRegisterResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthRegisterResponse (
        OAuthRegisterResponse oauthRegisterResponse
    ) : base(oauthRegisterResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthRegisterResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthRegisterResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthRegisterResponseFromRaw.FromRawUnchecked"/>
    public static OAuthRegisterResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthRegisterResponseFromRaw : IFromRawJson<OAuthRegisterResponse>
{
    /// <inheritdoc/>
    public OAuthRegisterResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthRegisterResponse.FromRawUnchecked(rawData);
}