using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WellKnown;

[JsonConverter(typeof(JsonModelConverter<WellKnownRetrieveAuthorizationServerMetadataResponse, WellKnownRetrieveAuthorizationServerMetadataResponseFromRaw>))]
public sealed record class WellKnownRetrieveAuthorizationServerMetadataResponse : JsonModel
{
    /// <summary>
    /// Authorization endpoint URL
    /// </summary>
    public string? AuthorizationEndpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "authorization_endpoint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("authorization_endpoint", value);
        }
    }

    /// <summary>
    /// Supported PKCE code challenge methods
    /// </summary>
    public IReadOnlyList<string>? CodeChallengeMethodsSupported {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "code_challenge_methods_supported"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "code_challenge_methods_supported",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Supported grant types
    /// </summary>
    public IReadOnlyList<string>? GrantTypesSupported {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "grant_types_supported"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "grant_types_supported",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token introspection endpoint URL
    /// </summary>
    public string? IntrospectionEndpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "introspection_endpoint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("introspection_endpoint", value);
        }
    }

    /// <summary>
    /// Authorization server issuer URL
    /// </summary>
    public string? Issuer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "issuer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("issuer", value);
        }
    }

    /// <summary>
    /// JWK Set endpoint URL
    /// </summary>
    public string? JwksUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "jwks_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("jwks_uri", value);
        }
    }

    /// <summary>
    /// Dynamic client registration endpoint URL
    /// </summary>
    public string? RegistrationEndpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "registration_endpoint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("registration_endpoint", value);
        }
    }

    /// <summary>
    /// Supported response types
    /// </summary>
    public IReadOnlyList<string>? ResponseTypesSupported {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "response_types_supported"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "response_types_supported",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Supported OAuth scopes
    /// </summary>
    public IReadOnlyList<string>? ScopesSupported {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "scopes_supported"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "scopes_supported",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token endpoint URL
    /// </summary>
    public string? TokenEndpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "token_endpoint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("token_endpoint", value);
        }
    }

    /// <summary>
    /// Supported token endpoint authentication methods
    /// </summary>
    public IReadOnlyList<string>? TokenEndpointAuthMethodsSupported {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "token_endpoint_auth_methods_supported"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "token_endpoint_auth_methods_supported",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AuthorizationEndpoint;
        _ = this.CodeChallengeMethodsSupported;
        _ = this.GrantTypesSupported;
        _ = this.IntrospectionEndpoint;
        _ = this.Issuer;
        _ = this.JwksUri;
        _ = this.RegistrationEndpoint;
        _ = this.ResponseTypesSupported;
        _ = this.ScopesSupported;
        _ = this.TokenEndpoint;
        _ = this.TokenEndpointAuthMethodsSupported;
    }

    public WellKnownRetrieveAuthorizationServerMetadataResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WellKnownRetrieveAuthorizationServerMetadataResponse (
        WellKnownRetrieveAuthorizationServerMetadataResponse wellKnownRetrieveAuthorizationServerMetadataResponse
    ) : base(wellKnownRetrieveAuthorizationServerMetadataResponse)
    {  }
    #pragma warning restore CS8618

    public WellKnownRetrieveAuthorizationServerMetadataResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WellKnownRetrieveAuthorizationServerMetadataResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WellKnownRetrieveAuthorizationServerMetadataResponseFromRaw.FromRawUnchecked"/>
    public static WellKnownRetrieveAuthorizationServerMetadataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WellKnownRetrieveAuthorizationServerMetadataResponseFromRaw : IFromRawJson<WellKnownRetrieveAuthorizationServerMetadataResponse>
{
    /// <inheritdoc/>
    public WellKnownRetrieveAuthorizationServerMetadataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WellKnownRetrieveAuthorizationServerMetadataResponse.FromRawUnchecked(rawData);
}