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

namespace Telnyx.Sdk.Models.FaxApplications;

/// <summary>
/// Updates settings of an existing Fax Application based on the parameters of the request.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FaxApplicationUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// A user-assigned name to help manage the application.
    /// </summary>
    public required string ApplicationName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "application_name"
            );
        }
        init { this._rawBodyData.Set("application_name", value); }
    }

    /// <summary>
    /// The URL where webhooks related to this connection will be sent. Must include
    /// a scheme, such as 'https'.
    /// </summary>
    public required string WebhookEventUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "webhook_event_url"
            );
        }
        init { this._rawBodyData.Set("webhook_event_url", value); }
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
    /// Specifies an email address where faxes sent to this application will be forwarded
    /// to (as pdf or tiff attachments)
    /// </summary>
    public string? FaxEmailRecipient {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "fax_email_recipient"
            );
        }
        init { this._rawBodyData.Set("fax_email_recipient", value); }
    }

    public FaxApplicationUpdateParamsInbound? Inbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FaxApplicationUpdateParamsInbound>(
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

    public FaxApplicationUpdateParamsOutbound? Outbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FaxApplicationUpdateParamsOutbound>(
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
    /// Tags associated with the Fax Application.
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
    /// The failover URL where webhooks related to this connection will be sent if
    /// sending to the primary URL fails. Must include a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventFailoverUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_event_failover_url"
            );
        }
        init { this._rawBodyData.Set("webhook_event_failover_url", value); }
    }

    /// <summary>
    /// Specifies how many seconds to wait before timing out a webhook.
    /// </summary>
    public long? WebhookTimeoutSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "webhook_timeout_secs"
            );
        }
        init { this._rawBodyData.Set("webhook_timeout_secs", value); }
    }

    public FaxApplicationUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationUpdateParams (
        FaxApplicationUpdateParams faxApplicationUpdateParams
    ) : base(faxApplicationUpdateParams)
    {
        this.ID = faxApplicationUpdateParams.ID;

        this._rawBodyData = new(faxApplicationUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public FaxApplicationUpdateParams (
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
    FaxApplicationUpdateParams (
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
    public static FaxApplicationUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(FaxApplicationUpdateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/fax_applications/{0}",
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

[JsonConverter(typeof(JsonModelConverter<FaxApplicationUpdateParamsInbound, FaxApplicationUpdateParamsInboundFromRaw>))]
public sealed record class FaxApplicationUpdateParamsInbound : JsonModel
{
    /// <summary>
    /// When set, this will limit the number of concurrent inbound calls to phone
    /// numbers associated with this connection.
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
    public ApiEnum<string, FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings>? SipSubdomainReceiveSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings>>(
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
        _ = this.SipSubdomain;
        this.SipSubdomainReceiveSettings?.Validate();
    }

    public FaxApplicationUpdateParamsInbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationUpdateParamsInbound (
        FaxApplicationUpdateParamsInbound faxApplicationUpdateParamsInbound
    ) : base(faxApplicationUpdateParamsInbound)
    {  }
    #pragma warning restore CS8618

    public FaxApplicationUpdateParamsInbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxApplicationUpdateParamsInbound (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxApplicationUpdateParamsInboundFromRaw.FromRawUnchecked"/>
    public static FaxApplicationUpdateParamsInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxApplicationUpdateParamsInboundFromRaw : IFromRawJson<FaxApplicationUpdateParamsInbound>
{
    /// <inheritdoc/>
    public FaxApplicationUpdateParamsInbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxApplicationUpdateParamsInbound.FromRawUnchecked(rawData);
}

/// <summary>
/// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint in
/// the public Internet) or "Only my connections" (any connection assigned to the
/// same Telnyx user).
/// </summary>
[JsonConverter(typeof(FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettingsConverter))]
public enum FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings
{
    OnlyMyConnections, FromAnyone
}

sealed class FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettingsConverter : JsonConverter<FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings>
{
    public override FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "only_my_connections"=>FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings.OnlyMyConnections,
            "from_anyone"=>FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings.FromAnyone,
            _ =>(FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings.OnlyMyConnections=>"only_my_connections",
            FaxApplicationUpdateParamsInboundSipSubdomainReceiveSettings.FromAnyone=>"from_anyone",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<FaxApplicationUpdateParamsOutbound, FaxApplicationUpdateParamsOutboundFromRaw>))]
public sealed record class FaxApplicationUpdateParamsOutbound : JsonModel
{
    /// <summary>
    /// When set, this will limit the number of concurrent outbound calls to phone
    /// numbers associated with this connection.
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

    public FaxApplicationUpdateParamsOutbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationUpdateParamsOutbound (
        FaxApplicationUpdateParamsOutbound faxApplicationUpdateParamsOutbound
    ) : base(faxApplicationUpdateParamsOutbound)
    {  }
    #pragma warning restore CS8618

    public FaxApplicationUpdateParamsOutbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxApplicationUpdateParamsOutbound (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxApplicationUpdateParamsOutboundFromRaw.FromRawUnchecked"/>
    public static FaxApplicationUpdateParamsOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxApplicationUpdateParamsOutboundFromRaw : IFromRawJson<FaxApplicationUpdateParamsOutbound>
{
    /// <inheritdoc/>
    public FaxApplicationUpdateParamsOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxApplicationUpdateParamsOutbound.FromRawUnchecked(rawData);
}