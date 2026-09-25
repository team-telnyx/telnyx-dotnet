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
/// Creates a new Fax Application based on the parameters sent in the request. The
/// application name and webhook URL are required. Once created, you can assign phone
/// numbers to your application using the `/phone_numbers` endpoint.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FaxApplicationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

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

    public Inbound? Inbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Inbound>(
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

    public Outbound? Outbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Outbound>(
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

    public FaxApplicationCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationCreateParams (
        FaxApplicationCreateParams faxApplicationCreateParams
    ) : base(faxApplicationCreateParams)
    { this._rawBodyData = new(faxApplicationCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public FaxApplicationCreateParams (
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
    FaxApplicationCreateParams (
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
    public static FaxApplicationCreateParams FromRawUnchecked(
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

    public virtual bool Equals(FaxApplicationCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/fax_applications"
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

[JsonConverter(typeof(JsonModelConverter<Inbound, InboundFromRaw>))]
public sealed record class Inbound : JsonModel
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
    public ApiEnum<string, SipSubdomainReceiveSettings>? SipSubdomainReceiveSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SipSubdomainReceiveSettings>>(
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

    public Inbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Inbound (Inbound inbound) : base(inbound)
    {  }
    #pragma warning restore CS8618

    public Inbound (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Inbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundFromRaw.FromRawUnchecked"/>
    public static Inbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundFromRaw : IFromRawJson<Inbound>
{
    /// <inheritdoc/>
    public Inbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Inbound.FromRawUnchecked(rawData);
}

/// <summary>
/// This option can be enabled to receive calls from: "Anyone" (any SIP endpoint in
/// the public Internet) or "Only my connections" (any connection assigned to the
/// same Telnyx user).
/// </summary>
[JsonConverter(typeof(SipSubdomainReceiveSettingsConverter))]
public enum SipSubdomainReceiveSettings
{
    OnlyMyConnections, FromAnyone
}

sealed class SipSubdomainReceiveSettingsConverter : JsonConverter<SipSubdomainReceiveSettings>
{
    public override SipSubdomainReceiveSettings Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "only_my_connections"=>SipSubdomainReceiveSettings.OnlyMyConnections,
            "from_anyone"=>SipSubdomainReceiveSettings.FromAnyone,
            _ =>(SipSubdomainReceiveSettings)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SipSubdomainReceiveSettings value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SipSubdomainReceiveSettings.OnlyMyConnections=>"only_my_connections",
            SipSubdomainReceiveSettings.FromAnyone=>"from_anyone",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Outbound, OutboundFromRaw>))]
public sealed record class Outbound : JsonModel
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

    public Outbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Outbound (Outbound outbound) : base(outbound)
    {  }
    #pragma warning restore CS8618

    public Outbound (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Outbound (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundFromRaw.FromRawUnchecked"/>
    public static Outbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OutboundFromRaw : IFromRawJson<Outbound>
{
    /// <inheritdoc/>
    public Outbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Outbound.FromRawUnchecked(rawData);
}