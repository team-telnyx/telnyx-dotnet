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

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls;

/// <summary>
/// Starts siprec session with specified parameters for call idientified by call_sid.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallSiprecJsonParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string AccountSid { get; init; }

    public string? CallSid { get; init; }

    /// <summary>
    /// The name of the connector to use for the SIPREC session.
    /// </summary>
    public string? ConnectorName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ConnectorName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConnectorName", value);
        }
    }

    /// <summary>
    /// When set, custom parameters will be added as metadata (recording.session.ExtensionParameters).
    /// Otherwise, they’ll be added to sip headers.
    /// </summary>
    public ApiEnum<bool, IncludeMetadataCustomHeaders>? IncludeMetadataCustomHeaders {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<bool, IncludeMetadataCustomHeaders>>(
                "IncludeMetadataCustomHeaders"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("IncludeMetadataCustomHeaders", value);
        }
    }

    /// <summary>
    /// Name of the SIPREC session. May be used to stop the SIPREC session from TeXML instruction.
    /// </summary>
    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "Name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Name", value);
        }
    }

    /// <summary>
    /// Controls whether to encrypt media sent to your SRS using SRTP and TLS. When
    /// set you need to configure SRS port in your connector to 5061.
    /// </summary>
    public ApiEnum<bool, Secure>? Secure {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<bool, Secure>>(
                "Secure"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Secure", value);
        }
    }

    /// <summary>
    /// Sets `Session-Expires` header to the INVITE. A reinvite is sent every half
    /// the value set. Usefull for session keep alive. Minimum value is 90, set to
    /// 0 to disable.
    /// </summary>
    public long? SessionTimeoutSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "SessionTimeoutSecs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("SessionTimeoutSecs", value);
        }
    }

    /// <summary>
    /// Specifies SIP transport protocol.
    /// </summary>
    public ApiEnum<string, SipTransport>? SipTransport {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SipTransport>>(
                "SipTransport"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("SipTransport", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send status callback events to for the siprec session.
    /// </summary>
    public string? StatusCallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "StatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("StatusCallback", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `StatusCallback`.
    /// </summary>
    public ApiEnum<string, CallSiprecJsonParamsStatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CallSiprecJsonParamsStatusCallbackMethod>>(
                "StatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("StatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The track to be used for siprec session. Can be `both_tracks`, `inbound_track`
    /// or `outbound_track`. Defaults to `both_tracks`.
    /// </summary>
    public ApiEnum<string, Track>? Track {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Track>>(
                "Track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Track", value);
        }
    }

    public CallSiprecJsonParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallSiprecJsonParams (
        CallSiprecJsonParams callSiprecJsonParams
    ) : base(callSiprecJsonParams)
    {
        this.AccountSid = callSiprecJsonParams.AccountSid;
        this.CallSid = callSiprecJsonParams.CallSid;

        this._rawBodyData = new(callSiprecJsonParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public CallSiprecJsonParams (
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
    CallSiprecJsonParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string callSid
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AccountSid = accountSid;
        this.CallSid = callSid;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CallSiprecJsonParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string callSid
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            accountSid,
            callSid
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["CallSid"] = JsonSerializer.SerializeToElement(this.CallSid),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CallSiprecJsonParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.AccountSid.Equals(other.AccountSid)&&(this.CallSid?.Equals(other.CallSid) ?? other.CallSid == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Calls/{1}/Siprec.json",
            this.AccountSid,
            this.CallSid)
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
/// When set, custom parameters will be added as metadata (recording.session.ExtensionParameters).
/// Otherwise, they’ll be added to sip headers.
/// </summary>
[JsonConverter(typeof(IncludeMetadataCustomHeadersConverter))]
public enum IncludeMetadataCustomHeaders
{
    True, False
}

sealed class IncludeMetadataCustomHeadersConverter : JsonConverter<IncludeMetadataCustomHeaders>
{
    public override IncludeMetadataCustomHeaders Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true=>IncludeMetadataCustomHeaders.True,
            false=>IncludeMetadataCustomHeaders.False
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IncludeMetadataCustomHeaders value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            IncludeMetadataCustomHeaders.True=>true,
            IncludeMetadataCustomHeaders.False=>false,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Controls whether to encrypt media sent to your SRS using SRTP and TLS. When set
/// you need to configure SRS port in your connector to 5061.
/// </summary>
[JsonConverter(typeof(SecureConverter))]
public enum Secure
{
    True, False
}

sealed class SecureConverter : JsonConverter<Secure>
{
    public override Secure Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        { true=>Secure.True, false=>Secure.False };
    }

    public override void Write(
        Utf8JsonWriter writer, Secure value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Secure.True=>true,
            Secure.False=>false,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Specifies SIP transport protocol.
/// </summary>
[JsonConverter(typeof(SipTransportConverter))]
public enum SipTransport
{
    Udp, Tcp, Tls
}

sealed class SipTransportConverter : JsonConverter<SipTransport>
{
    public override SipTransport Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "udp"=>SipTransport.Udp,
            "tcp"=>SipTransport.Tcp,
            "tls"=>SipTransport.Tls,
            _ =>(SipTransport)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SipTransport value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SipTransport.Udp=>"udp",
            SipTransport.Tcp=>"tcp",
            SipTransport.Tls=>"tls",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `StatusCallback`.
/// </summary>
[JsonConverter(typeof(CallSiprecJsonParamsStatusCallbackMethodConverter))]
public enum CallSiprecJsonParamsStatusCallbackMethod
{
    Get, Post
}

sealed class CallSiprecJsonParamsStatusCallbackMethodConverter : JsonConverter<CallSiprecJsonParamsStatusCallbackMethod>
{
    public override CallSiprecJsonParamsStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>CallSiprecJsonParamsStatusCallbackMethod.Get,
            "POST"=>CallSiprecJsonParamsStatusCallbackMethod.Post,
            _ =>(CallSiprecJsonParamsStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallSiprecJsonParamsStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallSiprecJsonParamsStatusCallbackMethod.Get=>"GET",
            CallSiprecJsonParamsStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The track to be used for siprec session. Can be `both_tracks`, `inbound_track`
/// or `outbound_track`. Defaults to `both_tracks`.
/// </summary>
[JsonConverter(typeof(TrackConverter))]
public enum Track
{
    BothTracks, InboundTrack, OutboundTrack
}

sealed class TrackConverter : JsonConverter<Track>
{
    public override Track Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both_tracks"=>Track.BothTracks,
            "inbound_track"=>Track.InboundTrack,
            "outbound_track"=>Track.OutboundTrack,
            _ =>(Track)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Track value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Track.BothTracks=>"both_tracks",
            Track.InboundTrack=>"inbound_track",
            Track.OutboundTrack=>"outbound_track",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}