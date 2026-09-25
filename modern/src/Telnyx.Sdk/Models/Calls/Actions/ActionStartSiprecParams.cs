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

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Start siprec session to configured in SIPREC connector SRS.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `siprec.started` - `siprec.stopped` - `siprec.failed`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionStartSiprecParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
    /// </summary>
    public string? ClientState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Name of configured SIPREC connector to be used.
    /// </summary>
    public string? ConnectorName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "connector_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("connector_name", value);
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
                "include_metadata_custom_headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("include_metadata_custom_headers", value);
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
                "secure"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("secure", value);
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
                "session_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("session_timeout_secs", value);
        }
    }

    /// <summary>
    /// Specifies SIP transport protocol.
    /// </summary>
    public ApiEnum<string, SipTransport>? SipTransport {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SipTransport>>(
                "sip_transport"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sip_transport", value);
        }
    }

    /// <summary>
    /// Specifies which track should be sent on siprec session.
    /// </summary>
    public ApiEnum<string, SiprecTrack>? SiprecTrack {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SiprecTrack>>(
                "siprec_track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("siprec_track", value);
        }
    }

    public ActionStartSiprecParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartSiprecParams (
        ActionStartSiprecParams actionStartSiprecParams
    ) : base(actionStartSiprecParams)
    {
        this.CallControlID = actionStartSiprecParams.CallControlID;

        this._rawBodyData = new(actionStartSiprecParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionStartSiprecParams (
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
    ActionStartSiprecParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CallControlID = callControlID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionStartSiprecParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            callControlID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CallControlID"] = JsonSerializer.SerializeToElement(this.CallControlID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionStartSiprecParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallControlID?.Equals(other.CallControlID) ?? other.CallControlID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/siprec_start",
            this.CallControlID)
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
/// Specifies which track should be sent on siprec session.
/// </summary>
[JsonConverter(typeof(SiprecTrackConverter))]
public enum SiprecTrack
{
    InboundTrack, OutboundTrack, BothTracks
}

sealed class SiprecTrackConverter : JsonConverter<SiprecTrack>
{
    public override SiprecTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_track"=>SiprecTrack.InboundTrack,
            "outbound_track"=>SiprecTrack.OutboundTrack,
            "both_tracks"=>SiprecTrack.BothTracks,
            _ =>(SiprecTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SiprecTrack value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SiprecTrack.InboundTrack=>"inbound_track",
            SiprecTrack.OutboundTrack=>"outbound_track",
            SiprecTrack.BothTracks=>"both_tracks",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}