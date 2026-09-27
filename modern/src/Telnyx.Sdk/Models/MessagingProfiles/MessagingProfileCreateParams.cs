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

namespace Telnyx.Sdk.Models.MessagingProfiles;

/// <summary>
/// Creates a messaging profile that controls outbound sender selection, webhook
/// delivery, and inbound message handling for associated numbers and short codes.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessagingProfileCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A user friendly name for the messaging profile.
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
    /// Destinations to which the messaging profile is allowed to send. The elements
    /// in the list must be valid ISO 3166-1 alpha-2 country codes. If set to `["*"]`
    /// all destinations will be allowed.
    /// </summary>
    public required IReadOnlyList<string> WhitelistedDestinations {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "whitelisted_destinations"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "whitelisted_destinations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The AI assistant ID to associate with this messaging profile.
    /// </summary>
    public string? AIAssistantID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ai_assistant_id"
            );
        }
        init { this._rawBodyData.Set("ai_assistant_id", value); }
    }

    /// <summary>
    /// The alphanumeric sender ID to use when sending to destinations that require
    /// an alphanumeric sender ID.
    /// </summary>
    public string? AlphaSender {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "alpha_sender"
            );
        }
        init { this._rawBodyData.Set("alpha_sender", value); }
    }

    /// <summary>
    /// The maximum amount of money (in USD) that can be spent by this profile before
    /// midnight UTC.
    /// </summary>
    public string? DailySpendLimit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "daily_spend_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("daily_spend_limit", value);
        }
    }

    /// <summary>
    /// Whether to enforce the value configured by `daily_spend_limit`.
    /// </summary>
    public bool? DailySpendLimitEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "daily_spend_limit_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("daily_spend_limit_enabled", value);
        }
    }

    /// <summary>
    /// Specifies whether the messaging profile is enabled or not.
    /// </summary>
    public bool? Enabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Telnyx product features the messaging customer can enable on the messaging
    /// profile. Keys map to individual feature flags; unknown keys are accepted
    /// and preserved for forward compatibility with rolling deployments.
    /// </summary>
    public MessagingProfileFeatures? Features {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MessagingProfileFeatures>(
                "features"
            );
        }
        init { this._rawBodyData.Set("features", value); }
    }

    /// <summary>
    /// A URL to receive health check webhooks for numbers in this profile.
    /// </summary>
    public string? HealthWebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "health_webhook_url"
            );
        }
        init { this._rawBodyData.Set("health_webhook_url", value); }
    }

    /// <summary>
    /// enables SMS fallback for MMS messages.
    /// </summary>
    public bool? MmsFallBackToSms {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "mms_fall_back_to_sms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("mms_fall_back_to_sms", value);
        }
    }

    /// <summary>
    /// enables automated resizing of MMS media.
    /// </summary>
    public bool? MmsTranscoding {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "mms_transcoding"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("mms_transcoding", value);
        }
    }

    /// <summary>
    /// Send messages only to mobile phone numbers.
    /// </summary>
    public bool? MobileOnly {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "mobile_only"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("mobile_only", value);
        }
    }

    /// <summary>
    /// Number Pool allows you to send messages from a pool of numbers of different
    /// types, assigning weights to each type. The pool consists of all the long code
    /// and toll free numbers assigned to the messaging profile.
    ///
    /// <para>To disable this feature, set the object field to `null`. </para>
    /// </summary>
    public NumberPoolSettings? NumberPoolSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<NumberPoolSettings>(
                "number_pool_settings"
            );
        }
        init { this._rawBodyData.Set("number_pool_settings", value); }
    }

    /// <summary>
    /// The resource group ID to associate with this messaging profile.
    /// </summary>
    public string? ResourceGroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "resource_group_id"
            );
        }
        init { this._rawBodyData.Set("resource_group_id", value); }
    }

    /// <summary>
    /// Enables automatic character encoding optimization for SMS messages. When enabled,
    /// the system automatically selects the most efficient encoding (GSM-7 or UCS-2)
    /// based on message content to maximize character limits and minimize costs.
    /// </summary>
    public bool? SmartEncoding {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "smart_encoding"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("smart_encoding", value);
        }
    }

    /// <summary>
    /// The URL shortener feature allows automatic replacement of URLs that were generated
    /// using a public URL shortener service. Some examples include bit.do, bit.ly,
    /// goo.gl, ht.ly, is.gd, ow.ly, rebrand.ly, t.co, tiny.cc, and tinyurl.com.
    /// Such URLs are replaced with with links generated by Telnyx. The use of custom
    /// links can improve branding and message deliverability.
    ///
    /// <para>To disable this feature, set the object field to `null`. </para>
    /// </summary>
    public UrlShortenerSettings? UrlShortenerSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UrlShortenerSettings>(
                "url_shortener_settings"
            );
        }
        init { this._rawBodyData.Set("url_shortener_settings", value); }
    }

    /// <summary>
    /// Determines which webhook format will be used, Telnyx API v1, v2, or a legacy
    /// 2010-04-01 format.
    /// </summary>
    public ApiEnum<string, WebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, WebhookApiVersion>>(
                "webhook_api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_api_version", value);
        }
    }

    /// <summary>
    /// The failover URL where webhooks related to this messaging profile will be
    /// sent if sending to the primary URL fails.
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_failover_url"
            );
        }
        init { this._rawBodyData.Set("webhook_failover_url", value); }
    }

    /// <summary>
    /// The URL where webhooks related to this messaging profile will be sent.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init { this._rawBodyData.Set("webhook_url", value); }
    }

    public MessagingProfileCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileCreateParams (
        MessagingProfileCreateParams messagingProfileCreateParams
    ) : base(messagingProfileCreateParams)
    { this._rawBodyData = new(messagingProfileCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public MessagingProfileCreateParams (
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
    MessagingProfileCreateParams (
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
    public static MessagingProfileCreateParams FromRawUnchecked(
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

    public virtual bool Equals(MessagingProfileCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/messaging_profiles"
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

/// <summary>
/// Determines which webhook format will be used, Telnyx API v1, v2, or a legacy
/// 2010-04-01 format.
/// </summary>
[JsonConverter(typeof(WebhookApiVersionConverter))]
public enum WebhookApiVersion
{
    V1, V2, V2010_04_01
}

sealed class WebhookApiVersionConverter : JsonConverter<WebhookApiVersion>
{
    public override WebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>WebhookApiVersion.V1,
            "2"=>WebhookApiVersion.V2,
            "2010-04-01"=>WebhookApiVersion.V2010_04_01,
            _ =>(WebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookApiVersion.V1=>"1",
            WebhookApiVersion.V2=>"2",
            WebhookApiVersion.V2010_04_01=>"2010-04-01",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}