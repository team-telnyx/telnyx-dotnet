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

namespace Telnyx.Sdk.Models.CallControlApplications;

/// <summary>
/// Creates a call control application, which defines the webhook endpoints and settings
/// used to control calls on associated connections.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallControlApplicationCreateParams : ParamsBase
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
    /// &lt;code&gt;Latency&lt;/code&gt; directs Telnyx to route media through the
    /// site with the lowest round-trip time to the user's connection. Telnyx calculates
    /// this time using ICMP ping messages. This can be disabled by specifying a site
    /// to handle all media.
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
    /// Specifies if call cost webhooks should be sent for this Call Control Application.
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

    public CallControlApplicationInbound? Inbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CallControlApplicationInbound>(
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

    public CallControlApplicationOutbound? Outbound {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CallControlApplicationOutbound>(
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
    /// When enabled, DTMF digits entered by users will be redacted in debug logs
    /// to protect PII data entered through IVR interactions.
    /// </summary>
    public bool? RedactDtmfDebugLogging {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "redact_dtmf_debug_logging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("redact_dtmf_debug_logging", value);
        }
    }

    /// <summary>
    /// Determines which webhook format will be used, Telnyx API v1 or v2.
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

    public CallControlApplicationCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlApplicationCreateParams (
        CallControlApplicationCreateParams callControlApplicationCreateParams
    ) : base(callControlApplicationCreateParams)
    {
        this._rawBodyData = new(callControlApplicationCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public CallControlApplicationCreateParams (
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
    CallControlApplicationCreateParams (
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
    public static CallControlApplicationCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CallControlApplicationCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/call_control_applications"
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
/// &lt;code&gt;Latency&lt;/code&gt; directs Telnyx to route media through the site
/// with the lowest round-trip time to the user's connection. Telnyx calculates this
/// time using ICMP ping messages. This can be disabled by specifying a site to handle
/// all media.
/// </summary>
[JsonConverter(typeof(AnchorsiteOverrideConverter))]
public enum AnchorsiteOverride
{
    Latency,
    ChicagoIl,
    AshburnVa,
    SanJoseCa,
    LondonUk,
    ChennaiIn,
    AmsterdamNetherlands,
    TorontoCanada,
    SydneyAustralia
}

sealed class AnchorsiteOverrideConverter : JsonConverter<AnchorsiteOverride>
{
    public override AnchorsiteOverride Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Latency"=>AnchorsiteOverride.Latency,
            "Chicago, IL"=>AnchorsiteOverride.ChicagoIl,
            "Ashburn, VA"=>AnchorsiteOverride.AshburnVa,
            "San Jose, CA"=>AnchorsiteOverride.SanJoseCa,
            "London, UK"=>AnchorsiteOverride.LondonUk,
            "Chennai, IN"=>AnchorsiteOverride.ChennaiIn,
            "Amsterdam, Netherlands"=>AnchorsiteOverride.AmsterdamNetherlands,
            "Toronto, Canada"=>AnchorsiteOverride.TorontoCanada,
            "Sydney, Australia"=>AnchorsiteOverride.SydneyAustralia,
            _ =>(AnchorsiteOverride)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnchorsiteOverride value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AnchorsiteOverride.Latency=>"Latency",
            AnchorsiteOverride.ChicagoIl=>"Chicago, IL",
            AnchorsiteOverride.AshburnVa=>"Ashburn, VA",
            AnchorsiteOverride.SanJoseCa=>"San Jose, CA",
            AnchorsiteOverride.LondonUk=>"London, UK",
            AnchorsiteOverride.ChennaiIn=>"Chennai, IN",
            AnchorsiteOverride.AmsterdamNetherlands=>"Amsterdam, Netherlands",
            AnchorsiteOverride.TorontoCanada=>"Toronto, Canada",
            AnchorsiteOverride.SydneyAustralia=>"Sydney, Australia",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Sets the type of DTMF digits sent from Telnyx to this Connection. Note that DTMF
/// digits sent to Telnyx will be accepted in all formats.
/// </summary>
[JsonConverter(typeof(DtmfTypeConverter))]
public enum DtmfType
{
    Rfc2833, Inband, SipInfo
}

sealed class DtmfTypeConverter : JsonConverter<DtmfType>
{
    public override DtmfType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RFC 2833"=>DtmfType.Rfc2833,
            "Inband"=>DtmfType.Inband,
            "SIP INFO"=>DtmfType.SipInfo,
            _ =>(DtmfType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DtmfType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DtmfType.Rfc2833=>"RFC 2833",
            DtmfType.Inband=>"Inband",
            DtmfType.SipInfo=>"SIP INFO",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Determines which webhook format will be used, Telnyx API v1 or v2.
/// </summary>
[JsonConverter(typeof(WebhookApiVersionConverter))]
public enum WebhookApiVersion
{
    V1, V2
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
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}