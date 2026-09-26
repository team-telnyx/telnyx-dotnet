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
/// Starts streaming media from a call to a specific WebSocket address.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallStreamsJsonParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string AccountSid { get; init; }

    public string? CallSid { get; init; }

    /// <summary>
    /// Indicates codec for bidirectional streaming RTP payloads. Used only with
    /// stream_bidirectional_mode=rtp. Case sensitive.
    /// </summary>
    public ApiEnum<string, BidirectionalCodec>? BidirectionalCodec {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BidirectionalCodec>>(
                "BidirectionalCodec"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("BidirectionalCodec", value);
        }
    }

    /// <summary>
    /// Configures method of bidirectional streaming (mp3, rtp).
    /// </summary>
    public ApiEnum<string, BidirectionalMode>? BidirectionalMode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BidirectionalMode>>(
                "BidirectionalMode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("BidirectionalMode", value);
        }
    }

    /// <summary>
    /// The user specified name of Stream.
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
    /// Url where status callbacks will be sent.
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
    /// HTTP method used to send status callbacks.
    /// </summary>
    public ApiEnum<string, CallStreamsJsonParamsStatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CallStreamsJsonParamsStatusCallbackMethod>>(
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
    /// Tracks to be included in the stream
    /// </summary>
    public ApiEnum<string, CallStreamsJsonParamsTrack>? Track {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CallStreamsJsonParamsTrack>>(
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

    /// <summary>
    /// The destination WebSocket address where the stream is going to be delivered.
    /// </summary>
    public string? UrlValue {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "Url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Url", value);
        }
    }

    public CallStreamsJsonParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallStreamsJsonParams (
        CallStreamsJsonParams callStreamsJsonParams
    ) : base(callStreamsJsonParams)
    {
        this.AccountSid = callStreamsJsonParams.AccountSid;
        this.CallSid = callStreamsJsonParams.CallSid;

        this._rawBodyData = new(callStreamsJsonParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public CallStreamsJsonParams (
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
    CallStreamsJsonParams (
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
    public static CallStreamsJsonParams FromRawUnchecked(
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

    public virtual bool Equals(CallStreamsJsonParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Calls/{1}/Streams.json",
            EncodePathSegment(this.AccountSid),
            EncodePathSegment(this.CallSid))
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
/// Indicates codec for bidirectional streaming RTP payloads. Used only with stream_bidirectional_mode=rtp.
/// Case sensitive.
/// </summary>
[JsonConverter(typeof(BidirectionalCodecConverter))]
public enum BidirectionalCodec
{
    Pcmu, Pcma, G722
}

sealed class BidirectionalCodecConverter : JsonConverter<BidirectionalCodec>
{
    public override BidirectionalCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PCMU"=>BidirectionalCodec.Pcmu,
            "PCMA"=>BidirectionalCodec.Pcma,
            "G722"=>BidirectionalCodec.G722,
            _ =>(BidirectionalCodec)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BidirectionalCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BidirectionalCodec.Pcmu=>"PCMU",
            BidirectionalCodec.Pcma=>"PCMA",
            BidirectionalCodec.G722=>"G722",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Configures method of bidirectional streaming (mp3, rtp).
/// </summary>
[JsonConverter(typeof(BidirectionalModeConverter))]
public enum BidirectionalMode
{
    Mp3, Rtp
}

sealed class BidirectionalModeConverter : JsonConverter<BidirectionalMode>
{
    public override BidirectionalMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp3"=>BidirectionalMode.Mp3,
            "rtp"=>BidirectionalMode.Rtp,
            _ =>(BidirectionalMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BidirectionalMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BidirectionalMode.Mp3=>"mp3",
            BidirectionalMode.Rtp=>"rtp",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP method used to send status callbacks.
/// </summary>
[JsonConverter(typeof(CallStreamsJsonParamsStatusCallbackMethodConverter))]
public enum CallStreamsJsonParamsStatusCallbackMethod
{
    Get, Post
}

sealed class CallStreamsJsonParamsStatusCallbackMethodConverter : JsonConverter<CallStreamsJsonParamsStatusCallbackMethod>
{
    public override CallStreamsJsonParamsStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>CallStreamsJsonParamsStatusCallbackMethod.Get,
            "POST"=>CallStreamsJsonParamsStatusCallbackMethod.Post,
            _ =>(CallStreamsJsonParamsStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallStreamsJsonParamsStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallStreamsJsonParamsStatusCallbackMethod.Get=>"GET",
            CallStreamsJsonParamsStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Tracks to be included in the stream
/// </summary>
[JsonConverter(typeof(CallStreamsJsonParamsTrackConverter))]
public enum CallStreamsJsonParamsTrack
{
    InboundTrack, OutboundTrack, BothTracks
}

sealed class CallStreamsJsonParamsTrackConverter : JsonConverter<CallStreamsJsonParamsTrack>
{
    public override CallStreamsJsonParamsTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_track"=>CallStreamsJsonParamsTrack.InboundTrack,
            "outbound_track"=>CallStreamsJsonParamsTrack.OutboundTrack,
            "both_tracks"=>CallStreamsJsonParamsTrack.BothTracks,
            _ =>(CallStreamsJsonParamsTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallStreamsJsonParamsTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallStreamsJsonParamsTrack.InboundTrack=>"inbound_track",
            CallStreamsJsonParamsTrack.OutboundTrack=>"outbound_track",
            CallStreamsJsonParamsTrack.BothTracks=>"both_tracks",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}