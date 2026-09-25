using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OAuth;

[JsonConverter(typeof(JsonModelConverter<OAuthTokenResponse, OAuthTokenResponseFromRaw>))]
public sealed record class OAuthTokenResponse : JsonModel
{
    /// <summary>
    /// The access token
    /// </summary>
    public required string AccessToken {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "access_token"
            );
        }
        init { this._rawData.Set("access_token", value); }
    }

    /// <summary>
    /// Token lifetime in seconds
    /// </summary>
    public required long ExpiresIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "expires_in"
            );
        }
        init { this._rawData.Set("expires_in", value); }
    }

    /// <summary>
    /// Token type
    /// </summary>
    public required ApiEnum<string, TokenType> TokenType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TokenType>>(
                "token_type"
            );
        }
        init { this._rawData.Set("token_type", value); }
    }

    /// <summary>
    /// Refresh token (if applicable)
    /// </summary>
    public string? RefreshToken {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "refresh_token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("refresh_token", value);
        }
    }

    /// <summary>
    /// Space-separated list of granted scopes
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
        _ = this.AccessToken;
        _ = this.ExpiresIn;
        this.TokenType.Validate();
        _ = this.RefreshToken;
        _ = this.Scope;
    }

    public OAuthTokenResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthTokenResponse (OAuthTokenResponse oauthTokenResponse) : base(
        oauthTokenResponse
    )
    {  }
    #pragma warning restore CS8618

    public OAuthTokenResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthTokenResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthTokenResponseFromRaw.FromRawUnchecked"/>
    public static OAuthTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthTokenResponseFromRaw : IFromRawJson<OAuthTokenResponse>
{
    /// <inheritdoc/>
    public OAuthTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthTokenResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Token type
/// </summary>
[JsonConverter(typeof(TokenTypeConverter))]
public enum TokenType
{
    Bearer
}sealed class TokenTypeConverter : JsonConverter<TokenType>
{
    public override TokenType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "Bearer"=>TokenType.Bearer, _ =>(TokenType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, TokenType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TokenType.Bearer=>"Bearer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}