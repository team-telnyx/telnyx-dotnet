using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CredentialConnections;

namespace Telnyx.Sdk.Models.TexmlApplications;

[JsonConverter(typeof(JsonModelConverter<TexmlApplication, TexmlApplicationFromRaw>))]
public sealed record class TexmlApplication : JsonModel
{
    /// <summary>
    /// Uniquely identifies the resource.
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
    /// Specifies whether the connection can be used.
    /// </summary>
    public bool? Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// `Latency` directs Telnyx to route media through the site with the lowest
    /// round-trip time to the user's connection. Telnyx calculates this time using
    /// ICMP ping messages. This can be disabled by specifying a site to handle all media.
    /// </summary>
    public ApiEnum<string, AnchorsiteOverride>? AnchorsiteOverride {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AnchorsiteOverride>>(
                "anchorsite_override"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("anchorsite_override", value);
        }
    }

    /// <summary>
    /// Specifies if call cost webhooks should be sent for this TeXML Application.
    /// </summary>
    public bool? CallCostInWebhooks {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "call_cost_in_webhooks"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_cost_in_webhooks", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that
    /// DTMF digits sent to Telnyx will be accepted in all formats.
    /// </summary>
    public ApiEnum<string, DtmfType>? DtmfType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DtmfType>>(
                "dtmf_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dtmf_type", value);
        }
    }

    /// <summary>
    /// Specifies whether calls to phone numbers associated with this connection
    /// should hangup after timing out.
    /// </summary>
    public bool? FirstCommandTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "first_command_timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_command_timeout", value);
        }
    }

    /// <summary>
    /// Specifies how many seconds to wait before timing out a dial command.
    /// </summary>
    public long? FirstCommandTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "first_command_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_command_timeout_secs", value);
        }
    }

    /// <summary>
    /// A user-assigned name to help manage the application.
    /// </summary>
    public string? FriendlyName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "friendly_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("friendly_name", value);
        }
    }

    public TexmlApplicationInbound? Inbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TexmlApplicationInbound>(
                "inbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbound", value);
        }
    }

    public TexmlApplicationOutbound? Outbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TexmlApplicationOutbound>(
                "outbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// URL for Telnyx to send requests to containing information about call progress events.
    /// </summary>
    public string? StatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status_callback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status_callback", value);
        }
    }

    /// <summary>
    /// HTTP request method Telnyx should use when requesting the status_callback URL.
    /// </summary>
    public ApiEnum<string, TexmlApplicationStatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TexmlApplicationStatusCallbackMethod>>(
                "status_callback_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status_callback_method", value);
        }
    }

    /// <summary>
    /// Tags associated with the Texml Application.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// URL to which Telnyx will deliver your XML Translator webhooks if we get an
    /// error response from your voice_url.
    /// </summary>
    public string? VoiceFallbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "voice_fallback_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_fallback_url", value);
        }
    }

    /// <summary>
    /// HTTP request method Telnyx will use to interact with your XML Translator
    /// webhooks. Either 'get' or 'post'.
    /// </summary>
    public ApiEnum<string, TexmlApplicationVoiceMethod>? VoiceMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TexmlApplicationVoiceMethod>>(
                "voice_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_method", value);
        }
    }

    /// <summary>
    /// URL to which Telnyx will deliver your XML Translator webhooks.
    /// </summary>
    public string? VoiceUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "voice_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        this.AnchorsiteOverride?.Validate();
        _ = this.CallCostInWebhooks;
        _ = this.CreatedAt;
        this.DtmfType?.Validate();
        _ = this.FirstCommandTimeout;
        _ = this.FirstCommandTimeoutSecs;
        _ = this.FriendlyName;
        this.Inbound?.Validate();
        this.Outbound?.Validate();
        _ = this.RecordType;
        _ = this.StatusCallback;
        this.StatusCallbackMethod?.Validate();
        _ = this.Tags;
        _ = this.UpdatedAt;
        _ = this.VoiceFallbackUrl;
        this.VoiceMethod?.Validate();
        _ = this.VoiceUrl;
    }

    public TexmlApplication ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplication (TexmlApplication texmlApplication) : base(
        texmlApplication
    )
    {  }
    #pragma warning restore CS8618

    public TexmlApplication (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlApplication (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlApplicationFromRaw.FromRawUnchecked"/>
    public static TexmlApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlApplicationFromRaw : IFromRawJson<TexmlApplication>
{
    /// <inheritdoc/>
    public TexmlApplication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlApplication.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TexmlApplicationInbound, TexmlApplicationInboundFromRaw>))]
public sealed record class TexmlApplicationInbound : JsonModel
{
    /// <summary>
    /// When set, this will limit the total number of inbound calls to phone numbers
    /// associated with this connection.
    /// </summary>
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_limit", value);
        }
    }

    /// <summary>
    /// When enabled Telnyx will include Shaken/Stir data in the Webhook for new
    /// inbound calls.
    /// </summary>
    public bool? ShakenStirEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shaken_stir_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shaken_stir_enabled", value);
        }
    }

    /// <summary>
    /// Specifies a subdomain that can be used to receive Inbound calls to a Connection,
    /// in the same way a phone number is used, from a SIP endpoint. Example: the
    /// subdomain "example.sip.telnyx.com" can be called from any SIP endpoint by
    /// using the SIP URI "sip:@example.sip.telnyx.com" where the user part can be
    /// any alphanumeric value. Please note TLS encrypted calls are not allowed for
    /// subdomain calls.
    /// </summary>
    public string? SipSubdomain {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_subdomain"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_subdomain", value);
        }
    }

    /// <summary>
    /// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint
    /// in the public Internet) or "Only my connections" (any connection assigned
    /// to the same Telnyx user).
    /// </summary>
    public ApiEnum<string, TexmlApplicationInboundSipSubdomainReceiveSettings>? SipSubdomainReceiveSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TexmlApplicationInboundSipSubdomainReceiveSettings>>(
                "sip_subdomain_receive_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_subdomain_receive_settings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelLimit;
        _ = this.ShakenStirEnabled;
        _ = this.SipSubdomain;
        this.SipSubdomainReceiveSettings?.Validate();
    }

    public TexmlApplicationInbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplicationInbound (
        TexmlApplicationInbound texmlApplicationInbound
    ) : base(texmlApplicationInbound)
    {  }
    #pragma warning restore CS8618

    public TexmlApplicationInbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlApplicationInbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlApplicationInboundFromRaw.FromRawUnchecked"/>
    public static TexmlApplicationInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TexmlApplicationInboundFromRaw : IFromRawJson<TexmlApplicationInbound>
{
    /// <inheritdoc/>
    public TexmlApplicationInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlApplicationInbound.FromRawUnchecked(rawData);
}/// <summary>
/// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint in
/// the public Internet) or "Only my connections" (any connection assigned to the
/// same Telnyx user).
/// </summary>
[JsonConverter(typeof(TexmlApplicationInboundSipSubdomainReceiveSettingsConverter))]
public enum TexmlApplicationInboundSipSubdomainReceiveSettings
{
    OnlyMyConnections, FromAnyone
}sealed class TexmlApplicationInboundSipSubdomainReceiveSettingsConverter : JsonConverter<TexmlApplicationInboundSipSubdomainReceiveSettings>
{
    public override TexmlApplicationInboundSipSubdomainReceiveSettings Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "only_my_connections"=>TexmlApplicationInboundSipSubdomainReceiveSettings.OnlyMyConnections,
            "from_anyone"=>TexmlApplicationInboundSipSubdomainReceiveSettings.FromAnyone,
            _ =>(TexmlApplicationInboundSipSubdomainReceiveSettings)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TexmlApplicationInboundSipSubdomainReceiveSettings value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TexmlApplicationInboundSipSubdomainReceiveSettings.OnlyMyConnections=>"only_my_connections",
            TexmlApplicationInboundSipSubdomainReceiveSettings.FromAnyone=>"from_anyone",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<TexmlApplicationOutbound, TexmlApplicationOutboundFromRaw>))]
public sealed record class TexmlApplicationOutbound : JsonModel
{
    /// <summary>
    /// When set, this will limit the total number of outbound calls to phone numbers
    /// associated with this connection.
    /// </summary>
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_limit", value);
        }
    }

    /// <summary>
    /// Identifies the associated outbound voice profile.
    /// </summary>
    public string? OutboundVoiceProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "outbound_voice_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound_voice_profile_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelLimit;
        _ = this.OutboundVoiceProfileID;
    }

    public TexmlApplicationOutbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplicationOutbound (
        TexmlApplicationOutbound texmlApplicationOutbound
    ) : base(texmlApplicationOutbound)
    {  }
    #pragma warning restore CS8618

    public TexmlApplicationOutbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlApplicationOutbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlApplicationOutboundFromRaw.FromRawUnchecked"/>
    public static TexmlApplicationOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TexmlApplicationOutboundFromRaw : IFromRawJson<TexmlApplicationOutbound>
{
    /// <inheritdoc/>
    public TexmlApplicationOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlApplicationOutbound.FromRawUnchecked(rawData);
}/// <summary>
/// HTTP request method Telnyx should use when requesting the status_callback URL.
/// </summary>
[JsonConverter(typeof(TexmlApplicationStatusCallbackMethodConverter))]
public enum TexmlApplicationStatusCallbackMethod
{
    Get, Post
}sealed class TexmlApplicationStatusCallbackMethodConverter : JsonConverter<TexmlApplicationStatusCallbackMethod>
{
    public override TexmlApplicationStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "get"=>TexmlApplicationStatusCallbackMethod.Get,
            "post"=>TexmlApplicationStatusCallbackMethod.Post,
            _ =>(TexmlApplicationStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TexmlApplicationStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TexmlApplicationStatusCallbackMethod.Get=>"get",
            TexmlApplicationStatusCallbackMethod.Post=>"post",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// HTTP request method Telnyx will use to interact with your XML Translator webhooks.
/// Either 'get' or 'post'.
/// </summary>
[JsonConverter(typeof(TexmlApplicationVoiceMethodConverter))]
public enum TexmlApplicationVoiceMethod
{
    Get, Post
}sealed class TexmlApplicationVoiceMethodConverter : JsonConverter<TexmlApplicationVoiceMethod>
{
    public override TexmlApplicationVoiceMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "get"=>TexmlApplicationVoiceMethod.Get,
            "post"=>TexmlApplicationVoiceMethod.Post,
            _ =>(TexmlApplicationVoiceMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TexmlApplicationVoiceMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TexmlApplicationVoiceMethod.Get=>"get",
            TexmlApplicationVoiceMethod.Post=>"post",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}