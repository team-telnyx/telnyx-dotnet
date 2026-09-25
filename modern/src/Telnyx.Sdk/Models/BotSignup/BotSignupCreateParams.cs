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

namespace Telnyx.Sdk.Models.BotSignup;

/// <summary>
/// Creates a freemium Telnyx account through the agentic signup flow. The request
/// must carry a valid answer to a previously issued bot challenge (`bot_challenge_nonce`
/// and `bot_challenge_answer`), accept the terms of service, and echo the exact terms-and-conditions
/// and privacy-policy URLs returned by the challenge endpoint. When EU consent enforcement
/// is enabled, `terms_of_service_eu` and `terms_and_conditions_eu_url` are also required.
/// On success a one-time sign-in (magic) link is emailed to the address provided;
/// if the email address belongs to an existing account, a sign-in link is sent instead
/// of creating a duplicate account. `email` may only be omitted when placeholder-email
/// registration is enabled server-side. This endpoint is public and unauthenticated,
/// gated by the freemium feature flags and per-country availability, and subject
/// to per-IP and per-domain registration limits.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BotSignupCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Answer to the issued bot challenge.
    /// </summary>
    public required string BotChallengeAnswer {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "bot_challenge_answer"
            );
        }
        init { this._rawBodyData.Set("bot_challenge_answer", value); }
    }

    /// <summary>
    /// Nonce from a previously issued bot challenge.
    /// </summary>
    public required string BotChallengeNonce {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "bot_challenge_nonce"
            );
        }
        init { this._rawBodyData.Set("bot_challenge_nonce", value); }
    }

    /// <summary>
    /// Must exactly match the privacy-policy URL returned by the challenge endpoint.
    /// </summary>
    public required string PrivacyPolicyUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "privacy_policy_url"
            );
        }
        init { this._rawBodyData.Set("privacy_policy_url", value); }
    }

    /// <summary>
    /// Must exactly match the terms-and-conditions URL returned by the challenge endpoint.
    /// </summary>
    public required string TermsAndConditionsUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "terms_and_conditions_url"
            );
        }
        init { this._rawBodyData.Set("terms_and_conditions_url", value); }
    }

    /// <summary>
    /// Must be true to accept the terms of service.
    /// </summary>
    public required ApiEnum<bool, BotSignupCreateParamsTermsOfService> TermsOfService {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<bool, BotSignupCreateParamsTermsOfService>>(
                "terms_of_service"
            );
        }
        init { this._rawBodyData.Set("terms_of_service", value); }
    }

    /// <summary>
    /// Email address for the new account. The magic link is sent here. May only
    /// be omitted when placeholder-email registration is enabled server-side.
    /// </summary>
    public string? Email {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("email", value);
        }
    }

    /// <summary>
    /// EU terms-and-conditions URL. Required when EU consent enforcement is enabled.
    /// </summary>
    public string? TermsAndConditionsEuUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "terms_and_conditions_eu_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("terms_and_conditions_eu_url", value);
        }
    }

    /// <summary>
    /// EU terms-of-service acceptance. Required when EU consent enforcement is enabled.
    /// </summary>
    public ApiEnum<bool, TermsOfServiceEu>? TermsOfServiceEu {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<bool, TermsOfServiceEu>>(
                "terms_of_service_eu"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("terms_of_service_eu", value);
        }
    }

    public BotSignupCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BotSignupCreateParams (
        BotSignupCreateParams botSignupCreateParams
    ) : base(botSignupCreateParams)
    { this._rawBodyData = new(botSignupCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public BotSignupCreateParams (
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
    BotSignupCreateParams (
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
    public static BotSignupCreateParams FromRawUnchecked(
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

    public virtual bool Equals(BotSignupCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/v2/bot_signup"
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

/// <summary>
/// Must be true to accept the terms of service.
/// </summary>
[JsonConverter(typeof(BotSignupCreateParamsTermsOfServiceConverter))]
public enum BotSignupCreateParamsTermsOfService
{
    True
}

sealed class BotSignupCreateParamsTermsOfServiceConverter : JsonConverter<BotSignupCreateParamsTermsOfService>
{
    public override BotSignupCreateParamsTermsOfService Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true=>BotSignupCreateParamsTermsOfService.True,
            _ =>(BotSignupCreateParamsTermsOfService)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BotSignupCreateParamsTermsOfService value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BotSignupCreateParamsTermsOfService.True=>true,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// EU terms-of-service acceptance. Required when EU consent enforcement is enabled.
/// </summary>
[JsonConverter(typeof(TermsOfServiceEuConverter))]
public enum TermsOfServiceEu
{
    True
}

sealed class TermsOfServiceEuConverter : JsonConverter<TermsOfServiceEu>
{
    public override TermsOfServiceEu Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        { true=>TermsOfServiceEu.True, _ =>(TermsOfServiceEu)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TermsOfServiceEu value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TermsOfServiceEu.True=>true,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}