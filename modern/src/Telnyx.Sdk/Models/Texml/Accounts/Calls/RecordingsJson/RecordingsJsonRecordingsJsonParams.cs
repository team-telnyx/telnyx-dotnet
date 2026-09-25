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

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

/// <summary>
/// Starts recording with specified parameters for call idientified by call_sid.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RecordingsJsonRecordingsJsonParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string AccountSid { get; init; }

    public string? CallSid { get; init; }

    /// <summary>
    /// Whether to play a beep when recording is started.
    /// </summary>
    public bool? PlayBeep {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "PlayBeep"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("PlayBeep", value);
        }
    }

    /// <summary>
    /// When `dual`, final audio file has the first leg on channel A, and the rest
    /// on channel B. `single` mixes both tracks into a single channel.
    /// </summary>
    public ApiEnum<string, RecordingChannels>? RecordingChannels {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RecordingChannels>>(
                "RecordingChannels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("RecordingChannels", value);
        }
    }

    /// <summary>
    /// Url where status callbacks will be sent.
    /// </summary>
    public string? RecordingStatusCallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "RecordingStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("RecordingStatusCallback", value);
        }
    }

    /// <summary>
    /// The changes to the recording's state that should generate a call to `RecoridngStatusCallback`.
    /// Can be: `in-progress`, `completed` and `absent`. Separate multiple values
    /// with a space. Defaults to `completed`.
    /// </summary>
    public string? RecordingStatusCallbackEvent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "RecordingStatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("RecordingStatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP method used to send status callbacks.
    /// </summary>
    public ApiEnum<string, RecordingStatusCallbackMethod>? RecordingStatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RecordingStatusCallbackMethod>>(
                "RecordingStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("RecordingStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The audio track to record for the call. The default is `both`.
    /// </summary>
    public ApiEnum<string, RecordingTrack>? RecordingTrack {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RecordingTrack>>(
                "RecordingTrack"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("RecordingTrack", value);
        }
    }

    /// <summary>
    /// Whether to send RecordingUrl in webhooks.
    /// </summary>
    public bool? SendRecordingUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "SendRecordingUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("SendRecordingUrl", value);
        }
    }

    public RecordingsJsonRecordingsJsonParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingsJsonRecordingsJsonParams (
        RecordingsJsonRecordingsJsonParams recordingsJsonRecordingsJsonParams
    ) : base(recordingsJsonRecordingsJsonParams)
    {
        this.AccountSid = recordingsJsonRecordingsJsonParams.AccountSid;
        this.CallSid = recordingsJsonRecordingsJsonParams.CallSid;

        this._rawBodyData = new(recordingsJsonRecordingsJsonParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public RecordingsJsonRecordingsJsonParams (
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
    RecordingsJsonRecordingsJsonParams (
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
    public static RecordingsJsonRecordingsJsonParams FromRawUnchecked(
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

    public virtual bool Equals(RecordingsJsonRecordingsJsonParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Calls/{1}/Recordings.json",
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
/// When `dual`, final audio file has the first leg on channel A, and the rest on
/// channel B. `single` mixes both tracks into a single channel.
/// </summary>
[JsonConverter(typeof(RecordingChannelsConverter))]
public enum RecordingChannels
{
    Single, Dual
}

sealed class RecordingChannelsConverter : JsonConverter<RecordingChannels>
{
    public override RecordingChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>RecordingChannels.Single,
            "dual"=>RecordingChannels.Dual,
            _ =>(RecordingChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingChannels.Single=>"single",
            RecordingChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP method used to send status callbacks.
/// </summary>
[JsonConverter(typeof(RecordingStatusCallbackMethodConverter))]
public enum RecordingStatusCallbackMethod
{
    Get, Post
}

sealed class RecordingStatusCallbackMethodConverter : JsonConverter<RecordingStatusCallbackMethod>
{
    public override RecordingStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>RecordingStatusCallbackMethod.Get,
            "POST"=>RecordingStatusCallbackMethod.Post,
            _ =>(RecordingStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingStatusCallbackMethod.Get=>"GET",
            RecordingStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The audio track to record for the call. The default is `both`.
/// </summary>
[JsonConverter(typeof(RecordingTrackConverter))]
public enum RecordingTrack
{
    Inbound, Outbound, Both
}

sealed class RecordingTrackConverter : JsonConverter<RecordingTrack>
{
    public override RecordingTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>RecordingTrack.Inbound,
            "outbound"=>RecordingTrack.Outbound,
            "both"=>RecordingTrack.Both,
            _ =>(RecordingTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingTrack.Inbound=>"inbound",
            RecordingTrack.Outbound=>"outbound",
            RecordingTrack.Both=>"both",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}