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
using Telnyx.Sdk.Models.CredentialConnections;

namespace Telnyx.Sdk.Models.TexmlApplications;

/// <summary>
/// Updates settings of an existing TeXML Application.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TexmlApplicationUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// A user-assigned name to help manage the application.
    /// </summary>
    public required string FriendlyName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "friendly_name"
            );
        }
        init { this._rawBodyData.Set("friendly_name", value); }
    }

    /// <summary>
    /// URL to which Telnyx will deliver your XML Translator webhooks.
    /// </summary>
    public required string VoiceUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "voice_url"
            );
        }
        init { this._rawBodyData.Set("voice_url", value); }
    }

    /// <summary>
    /// Specifies whether the connection can be used.
    /// </summary>
    public bool? Active {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("active", value);
        }
    }

    /// <summary>
    /// `Latency` directs Telnyx to route media through the site with the lowest
    /// round-trip time to the user's connection. Telnyx calculates this time using
    /// ICMP ping messages. This can be disabled by specifying a site to handle all media.
    /// </summary>
    public ApiEnum<string, AnchorsiteOverride>? AnchorsiteOverride {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AnchorsiteOverride>>(
                "anchorsite_override"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("anchorsite_override", value);
        }
    }

    /// <summary>
    /// Specifies if call cost webhooks should be sent for this TeXML Application.
    /// </summary>
    public bool? CallCostInWebhooks {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "call_cost_in_webhooks"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("call_cost_in_webhooks", value);
        }
    }

    /// <summary>
    /// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that
    /// DTMF digits sent to Telnyx will be accepted in all formats.
    /// </summary>
    public ApiEnum<string, DtmfType>? DtmfType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, DtmfType>>(
                "dtmf_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("dtmf_type", value);
        }
    }

    /// <summary>
    /// Specifies whether calls to phone numbers associated with this connection
    /// should hangup after timing out.
    /// </summary>
    public bool? FirstCommandTimeout {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "first_command_timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("first_command_timeout", value);
        }
    }

    /// <summary>
    /// Specifies how many seconds to wait before timing out a dial command.
    /// </summary>
    public long? FirstCommandTimeoutSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "first_command_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("first_command_timeout_secs", value);
        }
    }

    public TexmlApplicationUpdateParamsInbound? Inbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TexmlApplicationUpdateParamsInbound>(
                "inbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("inbound", value);
        }
    }

    public TexmlApplicationUpdateParamsOutbound? Outbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TexmlApplicationUpdateParamsOutbound>(
                "outbound"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("outbound", value);
        }
    }

    /// <summary>
    /// URL for Telnyx to send requests to containing information about call progress events.
    /// </summary>
    public string? StatusCallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "status_callback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("status_callback", value);
        }
    }

    /// <summary>
    /// HTTP request method Telnyx should use when requesting the status_callback URL.
    /// </summary>
    public ApiEnum<string, TexmlApplicationUpdateParamsStatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TexmlApplicationUpdateParamsStatusCallbackMethod>>(
                "status_callback_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("status_callback_method", value);
        }
    }

    /// <summary>
    /// Tags associated with the Texml Application.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// URL to which Telnyx will deliver your XML Translator webhooks if we get an
    /// error response from your voice_url.
    /// </summary>
    public string? VoiceFallbackUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "voice_fallback_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("voice_fallback_url", value);
        }
    }

    /// <summary>
    /// HTTP request method Telnyx will use to interact with your XML Translator
    /// webhooks. Either 'get' or 'post'.
    /// </summary>
    public ApiEnum<string, TexmlApplicationUpdateParamsVoiceMethod>? VoiceMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TexmlApplicationUpdateParamsVoiceMethod>>(
                "voice_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("voice_method", value);
        }
    }

    public TexmlApplicationUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplicationUpdateParams (
        TexmlApplicationUpdateParams texmlApplicationUpdateParams
    ) : base(texmlApplicationUpdateParams)
    {
        this.ID = texmlApplicationUpdateParams.ID;

        this._rawBodyData = new(texmlApplicationUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public TexmlApplicationUpdateParams (
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
    TexmlApplicationUpdateParams (
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
    public static TexmlApplicationUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(TexmlApplicationUpdateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml_applications/{0}",
            EncodePathSegment(this.ID))
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

[JsonConverter(typeof(JsonModelConverter<TexmlApplicationUpdateParamsInbound, TexmlApplicationUpdateParamsInboundFromRaw>))]
public sealed record class TexmlApplicationUpdateParamsInbound : JsonModel
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
    public ApiEnum<string, TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings>? SipSubdomainReceiveSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings>>(
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

    public TexmlApplicationUpdateParamsInbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplicationUpdateParamsInbound (
        TexmlApplicationUpdateParamsInbound texmlApplicationUpdateParamsInbound
    ) : base(texmlApplicationUpdateParamsInbound)
    {  }
    #pragma warning restore CS8618

    public TexmlApplicationUpdateParamsInbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlApplicationUpdateParamsInbound (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlApplicationUpdateParamsInboundFromRaw.FromRawUnchecked"/>
    public static TexmlApplicationUpdateParamsInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlApplicationUpdateParamsInboundFromRaw : IFromRawJson<TexmlApplicationUpdateParamsInbound>
{
    /// <inheritdoc/>
    public TexmlApplicationUpdateParamsInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlApplicationUpdateParamsInbound.FromRawUnchecked(rawData);
}

/// <summary>
/// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint in
/// the public Internet) or "Only my connections" (any connection assigned to the
/// same Telnyx user).
/// </summary>
[JsonConverter(typeof(TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettingsConverter))]
public enum TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings
{
    OnlyMyConnections, FromAnyone
}

sealed class TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettingsConverter : JsonConverter<TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings>
{
    public override TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "only_my_connections"=>TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings.OnlyMyConnections,
            "from_anyone"=>TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings.FromAnyone,
            _ =>(TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings.OnlyMyConnections=>"only_my_connections",
            TexmlApplicationUpdateParamsInboundSipSubdomainReceiveSettings.FromAnyone=>"from_anyone",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<TexmlApplicationUpdateParamsOutbound, TexmlApplicationUpdateParamsOutboundFromRaw>))]
public sealed record class TexmlApplicationUpdateParamsOutbound : JsonModel
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

    public TexmlApplicationUpdateParamsOutbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplicationUpdateParamsOutbound (
        TexmlApplicationUpdateParamsOutbound texmlApplicationUpdateParamsOutbound
    ) : base(texmlApplicationUpdateParamsOutbound)
    {  }
    #pragma warning restore CS8618

    public TexmlApplicationUpdateParamsOutbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlApplicationUpdateParamsOutbound (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlApplicationUpdateParamsOutboundFromRaw.FromRawUnchecked"/>
    public static TexmlApplicationUpdateParamsOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlApplicationUpdateParamsOutboundFromRaw : IFromRawJson<TexmlApplicationUpdateParamsOutbound>
{
    /// <inheritdoc/>
    public TexmlApplicationUpdateParamsOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlApplicationUpdateParamsOutbound.FromRawUnchecked(rawData);
}

/// <summary>
/// HTTP request method Telnyx should use when requesting the status_callback URL.
/// </summary>
[JsonConverter(typeof(TexmlApplicationUpdateParamsStatusCallbackMethodConverter))]
public enum TexmlApplicationUpdateParamsStatusCallbackMethod
{
    Get, Post
}

sealed class TexmlApplicationUpdateParamsStatusCallbackMethodConverter : JsonConverter<TexmlApplicationUpdateParamsStatusCallbackMethod>
{
    public override TexmlApplicationUpdateParamsStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "get"=>TexmlApplicationUpdateParamsStatusCallbackMethod.Get,
            "post"=>TexmlApplicationUpdateParamsStatusCallbackMethod.Post,
            _ =>(TexmlApplicationUpdateParamsStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TexmlApplicationUpdateParamsStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TexmlApplicationUpdateParamsStatusCallbackMethod.Get=>"get",
            TexmlApplicationUpdateParamsStatusCallbackMethod.Post=>"post",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request method Telnyx will use to interact with your XML Translator webhooks.
/// Either 'get' or 'post'.
/// </summary>
[JsonConverter(typeof(TexmlApplicationUpdateParamsVoiceMethodConverter))]
public enum TexmlApplicationUpdateParamsVoiceMethod
{
    Get, Post
}

sealed class TexmlApplicationUpdateParamsVoiceMethodConverter : JsonConverter<TexmlApplicationUpdateParamsVoiceMethod>
{
    public override TexmlApplicationUpdateParamsVoiceMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "get"=>TexmlApplicationUpdateParamsVoiceMethod.Get,
            "post"=>TexmlApplicationUpdateParamsVoiceMethod.Post,
            _ =>(TexmlApplicationUpdateParamsVoiceMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TexmlApplicationUpdateParamsVoiceMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TexmlApplicationUpdateParamsVoiceMethod.Get=>"get",
            TexmlApplicationUpdateParamsVoiceMethod.Post=>"post",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}