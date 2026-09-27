using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OAuthClients;

[JsonConverter(typeof(JsonModelConverter<OAuthClient, OAuthClientFromRaw>))]
public sealed record class OAuthClient : JsonModel
{
    /// <summary>
    /// OAuth client identifier
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
    /// OAuth client type
    /// </summary>
    public required ApiEnum<string, OAuthClientClientType> ClientType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OAuthClientClientType>>(
                "client_type"
            );
        }
        init { this._rawData.Set("client_type", value); }
    }

    /// <summary>
    /// Timestamp when the client was created
    /// </summary>
    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Human-readable name for the OAuth client
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Organization ID that owns this OAuth client
    /// </summary>
    public required string OrgID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "org_id"
            );
        }
        init { this._rawData.Set("org_id", value); }
    }

    /// <summary>
    /// Record type identifier
    /// </summary>
    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Whether PKCE (Proof Key for Code Exchange) is required for this client
    /// </summary>
    public required bool RequirePkce {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "require_pkce"
            );
        }
        init { this._rawData.Set("require_pkce", value); }
    }

    /// <summary>
    /// Timestamp when the client was last updated
    /// </summary>
    public required System::DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// User ID that created this OAuth client
    /// </summary>
    public required string UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "user_id"
            );
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// List of allowed OAuth grant types
    /// </summary>
    public IReadOnlyList<ApiEnum<string, OAuthClientAllowedGrantType>>? AllowedGrantTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, OAuthClientAllowedGrantType>>>(
                "allowed_grant_types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, OAuthClientAllowedGrantType>>?>(
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "allowed_scopes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_scopes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Client secret (only included when available, for confidential clients)
    /// </summary>
    public string? ClientSecret {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_secret"
            );
        }
        init { this._rawData.Set("client_secret", value); }
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
        init { this._rawData.Set("logo_uri", value); }
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
        init { this._rawData.Set("policy_uri", value); }
    }

    /// <summary>
    /// List of allowed redirect URIs
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
    /// URL of the client's terms of service
    /// </summary>
    public string? TosUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tos_uri"
            );
        }
        init { this._rawData.Set("tos_uri", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientID;
        this.ClientType.Validate();
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.OrgID;
        this.RecordType.Validate();
        _ = this.RequirePkce;
        _ = this.UpdatedAt;
        _ = this.UserID;
        foreach (var item in this.AllowedGrantTypes ?? [])
        {
            item.Validate();
        }
        _ = this.AllowedScopes;
        _ = this.ClientSecret;
        _ = this.LogoUri;
        _ = this.PolicyUri;
        _ = this.RedirectUris;
        _ = this.TosUri;
    }

    public OAuthClient ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthClient (OAuthClient oauthClient) : base(oauthClient)
    {  }
    #pragma warning restore CS8618

    public OAuthClient (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthClient (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthClientFromRaw.FromRawUnchecked"/>
    public static OAuthClient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthClientFromRaw : IFromRawJson<OAuthClient>
{
    /// <inheritdoc/>
    public OAuthClient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthClient.FromRawUnchecked(rawData);
}

/// <summary>
/// OAuth client type
/// </summary>
[JsonConverter(typeof(OAuthClientClientTypeConverter))]
public enum OAuthClientClientType
{
    Public, Confidential
}sealed class OAuthClientClientTypeConverter : JsonConverter<OAuthClientClientType>
{
    public override OAuthClientClientType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "public"=>OAuthClientClientType.Public,
            "confidential"=>OAuthClientClientType.Confidential,
            _ =>(OAuthClientClientType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OAuthClientClientType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OAuthClientClientType.Public=>"public",
            OAuthClientClientType.Confidential=>"confidential",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Record type identifier
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    OAuthClient
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "oauth_client"=>RecordType.OAuthClient, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.OAuthClient=>"oauth_client",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(OAuthClientAllowedGrantTypeConverter))]
public enum OAuthClientAllowedGrantType
{
    ClientCredentials, AuthorizationCode, RefreshToken
}sealed class OAuthClientAllowedGrantTypeConverter : JsonConverter<OAuthClientAllowedGrantType>
{
    public override OAuthClientAllowedGrantType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "client_credentials"=>OAuthClientAllowedGrantType.ClientCredentials,
            "authorization_code"=>OAuthClientAllowedGrantType.AuthorizationCode,
            "refresh_token"=>OAuthClientAllowedGrantType.RefreshToken,
            _ =>(OAuthClientAllowedGrantType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OAuthClientAllowedGrantType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OAuthClientAllowedGrantType.ClientCredentials=>"client_credentials",
            OAuthClientAllowedGrantType.AuthorizationCode=>"authorization_code",
            OAuthClientAllowedGrantType.RefreshToken=>"refresh_token",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}