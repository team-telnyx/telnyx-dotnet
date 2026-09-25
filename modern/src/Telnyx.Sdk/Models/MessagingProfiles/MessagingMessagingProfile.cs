using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingProfiles;

[JsonConverter(typeof(JsonModelConverter<MessagingMessagingProfile, MessagingMessagingProfileFromRaw>))]
public sealed record class MessagingMessagingProfile : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The AI assistant ID associated with this messaging profile.
    /// </summary>
    public string? AIAssistantID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ai_assistant_id"
            );
        }
        init { this._rawData.Set("ai_assistant_id", value); }
    }

    /// <summary>
    /// The alphanumeric sender ID to use when sending to destinations that require
    /// an alphanumeric sender ID.
    /// </summary>
    public string? AlphaSender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "alpha_sender"
            );
        }
        init { this._rawData.Set("alpha_sender", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// The maximum amount of money (in USD) that can be spent by this profile before
    /// midnight UTC.
    /// </summary>
    public string? DailySpendLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "daily_spend_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("daily_spend_limit", value);
        }
    }

    /// <summary>
    /// Whether to enforce the value configured by `daily_spend_limit`.
    /// </summary>
    public bool? DailySpendLimitEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "daily_spend_limit_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("daily_spend_limit_enabled", value);
        }
    }

    /// <summary>
    /// Specifies whether the messaging profile is enabled or not.
    /// </summary>
    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Telnyx product features the messaging customer can enable on the messaging
    /// profile. Keys map to individual feature flags; unknown keys are accepted
    /// and preserved for forward compatibility with rolling deployments.
    /// </summary>
    public MessagingProfileFeatures? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingProfileFeatures>(
                "features"
            );
        }
        init { this._rawData.Set("features", value); }
    }

    /// <summary>
    /// DEPRECATED: health check url service checking
    /// </summary>
    public string? HealthWebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "health_webhook_url"
            );
        }
        init { this._rawData.Set("health_webhook_url", value); }
    }

    /// <summary>
    /// enables SMS fallback for MMS messages.
    /// </summary>
    public bool? MmsFallBackToSms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "mms_fall_back_to_sms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mms_fall_back_to_sms", value);
        }
    }

    /// <summary>
    /// enables automated resizing of MMS media.
    /// </summary>
    public bool? MmsTranscoding {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "mms_transcoding"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mms_transcoding", value);
        }
    }

    /// <summary>
    /// Send messages only to mobile phone numbers.
    /// </summary>
    public bool? MobileOnly {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "mobile_only"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mobile_only", value);
        }
    }

    /// <summary>
    /// A user friendly name for the messaging profile.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumberPoolSettings>(
                "number_pool_settings"
            );
        }
        init { this._rawData.Set("number_pool_settings", value); }
    }

    /// <summary>
    /// The organization that owns this messaging profile.
    /// </summary>
    public string? OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// Indicates whether message content redaction is enabled for this profile.
    /// When enabled, message text, MMS media, and the counterparty phone number are
    /// redacted in message records and reporting. Requires organization activation
    /// — contact support to enable. The field is only present in responses for organizations
    /// with redaction access.
    /// </summary>
    public bool? RedactionEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "redaction_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("redaction_enabled", value);
        }
    }

    /// <summary>
    /// Determines how much information is redacted for privacy or compliance purposes.
    /// Level 1: message records and reporting are redacted, but inbound webhook
    /// payloads are not. Level 2 (default): message records, reporting, and inbound
    /// webhook payloads are all redacted.
    /// </summary>
    public long? RedactionLevel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "redaction_level"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("redaction_level", value);
        }
    }

    /// <summary>
    /// The resource group ID associated with this messaging profile.
    /// </summary>
    public string? ResourceGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "resource_group_id"
            );
        }
        init { this._rawData.Set("resource_group_id", value); }
    }

    /// <summary>
    /// Enables automatic character encoding optimization for SMS messages. When enabled,
    /// the system automatically selects the most efficient encoding (GSM-7 or UCS-2)
    /// based on message content to maximize character limits and minimize costs.
    /// </summary>
    public bool? SmartEncoding {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "smart_encoding"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("smart_encoding", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UrlShortenerSettings>(
                "url_shortener_settings"
            );
        }
        init { this._rawData.Set("url_shortener_settings", value); }
    }

    /// <summary>
    /// Secret used to authenticate with v1 endpoints.
    /// </summary>
    public string? V1Secret {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "v1_secret"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("v1_secret", value);
        }
    }

    /// <summary>
    /// Determines which webhook format will be used, Telnyx API v1, v2, or a legacy
    /// 2010-04-01 format.
    /// </summary>
    public ApiEnum<string, MessagingMessagingProfileWebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingMessagingProfileWebhookApiVersion>>(
                "webhook_api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_api_version", value);
        }
    }

    /// <summary>
    /// The failover URL where webhooks related to this messaging profile will be
    /// sent if sending to the primary URL fails.
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_failover_url"
            );
        }
        init { this._rawData.Set("webhook_failover_url", value); }
    }

    /// <summary>
    /// The URL where webhooks related to this messaging profile will be sent.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <summary>
    /// Destinations to which the messaging profile is allowed to send. The elements
    /// in the list must be valid ISO 3166-1 alpha-2 country codes. If set to `["*"]`,
    /// all destinations will be allowed.
    /// </summary>
    public IReadOnlyList<string>? WhitelistedDestinations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "whitelisted_destinations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "whitelisted_destinations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AIAssistantID;
        _ = this.AlphaSender;
        _ = this.CreatedAt;
        _ = this.DailySpendLimit;
        _ = this.DailySpendLimitEnabled;
        _ = this.Enabled;
        this.Features?.Validate();
        _ = this.HealthWebhookUrl;
        _ = this.MmsFallBackToSms;
        _ = this.MmsTranscoding;
        _ = this.MobileOnly;
        _ = this.Name;
        this.NumberPoolSettings?.Validate();
        _ = this.OrganizationID;
        this.RecordType?.Validate();
        _ = this.RedactionEnabled;
        _ = this.RedactionLevel;
        _ = this.ResourceGroupID;
        _ = this.SmartEncoding;
        _ = this.UpdatedAt;
        this.UrlShortenerSettings?.Validate();
        _ = this.V1Secret;
        this.WebhookApiVersion?.Validate();
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
        _ = this.WhitelistedDestinations;
    }

    public MessagingMessagingProfile ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingMessagingProfile (
        MessagingMessagingProfile messagingMessagingProfile
    ) : base(messagingMessagingProfile)
    {  }
    #pragma warning restore CS8618

    public MessagingMessagingProfile (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingMessagingProfile (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingMessagingProfileFromRaw.FromRawUnchecked"/>
    public static MessagingMessagingProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingMessagingProfileFromRaw : IFromRawJson<MessagingMessagingProfile>
{
    /// <inheritdoc/>
    public MessagingMessagingProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingMessagingProfile.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    MessagingProfile
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "messaging_profile"=>RecordType.MessagingProfile,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.MessagingProfile=>"messaging_profile",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Determines which webhook format will be used, Telnyx API v1, v2, or a legacy
/// 2010-04-01 format.
/// </summary>
[JsonConverter(typeof(MessagingMessagingProfileWebhookApiVersionConverter))]
public enum MessagingMessagingProfileWebhookApiVersion
{
    V1, V2, V2010_04_01
}sealed class MessagingMessagingProfileWebhookApiVersionConverter : JsonConverter<MessagingMessagingProfileWebhookApiVersion>
{
    public override MessagingMessagingProfileWebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>MessagingMessagingProfileWebhookApiVersion.V1,
            "2"=>MessagingMessagingProfileWebhookApiVersion.V2,
            "2010-04-01"=>MessagingMessagingProfileWebhookApiVersion.V2010_04_01,
            _ =>(MessagingMessagingProfileWebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingMessagingProfileWebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingMessagingProfileWebhookApiVersion.V1=>"1",
            MessagingMessagingProfileWebhookApiVersion.V2=>"2",
            MessagingMessagingProfileWebhookApiVersion.V2010_04_01=>"2010-04-01",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}