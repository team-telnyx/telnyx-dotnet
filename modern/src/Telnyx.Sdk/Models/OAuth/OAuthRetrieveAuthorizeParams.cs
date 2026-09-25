using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OAuth;

/// <summary>
/// OAuth 2.0 authorization endpoint for the authorization code flow
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OAuthRetrieveAuthorizeParams : ParamsBase
{
    /// <summary>
    /// OAuth client identifier
    /// </summary>
    public required string ClientID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>(
                "client_id"
            );
        }
        init { this._rawQueryData.Set("client_id", value); }
    }

    /// <summary>
    /// Redirect URI
    /// </summary>
    public required string RedirectUri {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>(
                "redirect_uri"
            );
        }
        init { this._rawQueryData.Set("redirect_uri", value); }
    }

    /// <summary>
    /// OAuth response type
    /// </summary>
    public required ApiEnum<string, ResponseType> ResponseType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, ResponseType>>(
                "response_type"
            );
        }
        init { this._rawQueryData.Set("response_type", value); }
    }

    /// <summary>
    /// PKCE code challenge
    /// </summary>
    public string? CodeChallenge {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "code_challenge"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("code_challenge", value);
        }
    }

    /// <summary>
    /// PKCE code challenge method
    /// </summary>
    public ApiEnum<string, CodeChallengeMethod>? CodeChallengeMethod {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, CodeChallengeMethod>>(
                "code_challenge_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("code_challenge_method", value);
        }
    }

    /// <summary>
    /// Space-separated list of requested scopes
    /// </summary>
    public string? Scope {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "scope"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("scope", value);
        }
    }

    /// <summary>
    /// State parameter for CSRF protection
    /// </summary>
    public string? State {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("state", value);
        }
    }

    public OAuthRetrieveAuthorizeParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthRetrieveAuthorizeParams (
        OAuthRetrieveAuthorizeParams oauthRetrieveAuthorizeParams
    ) : base(oauthRetrieveAuthorizeParams)
    {  }
    #pragma warning restore CS8618

    public OAuthRetrieveAuthorizeParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthRetrieveAuthorizeParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static OAuthRetrieveAuthorizeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(OAuthRetrieveAuthorizeParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/oauth/authorize"
        )
        {
            Query = this.QueryString(options, new())
        }.Uri) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(request, options, new());
        request.Headers.Add("Accept", "text/html");
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
/// OAuth response type
/// </summary>
[JsonConverter(typeof(ResponseTypeConverter))]
public enum ResponseType
{
    Code
}

sealed class ResponseTypeConverter : JsonConverter<ResponseType>
{
    public override ResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "code"=>ResponseType.Code, _ =>(ResponseType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, ResponseType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ResponseType.Code=>"code",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// PKCE code challenge method
/// </summary>
[JsonConverter(typeof(CodeChallengeMethodConverter))]
public enum CodeChallengeMethod
{
    Plain, S256
}

sealed class CodeChallengeMethodConverter : JsonConverter<CodeChallengeMethod>
{
    public override CodeChallengeMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "plain"=>CodeChallengeMethod.Plain,
            "S256"=>CodeChallengeMethod.S256,
            _ =>(CodeChallengeMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CodeChallengeMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CodeChallengeMethod.Plain=>"plain",
            CodeChallengeMethod.S256=>"S256",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}