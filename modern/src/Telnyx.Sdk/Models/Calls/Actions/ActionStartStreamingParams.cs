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

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Start streaming the media from a call to a specific WebSocket address or Dialogflow
/// connection in near-realtime. Audio will be delivered as base64-encoded RTP payload
/// (raw audio), wrapped in JSON payloads.
///
/// <para>Please find more details about media streaming messages specification under
/// the [link](https://developers.telnyx.com/docs/voice/programmable-voice/media-streaming).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionStartStreamingParams : ParamsBase
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
    /// Use this field to avoid duplicate commands. Telnyx will ignore any command
    /// with the same `command_id` for the same `call_control_id`.
    /// </summary>
    public string? CommandID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("command_id", value);
        }
    }

    /// <summary>
    /// Custom parameters to be sent as part of the WebSocket connection.
    /// </summary>
    public IReadOnlyList<CustomParameter>? CustomParameters {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<CustomParameter>>(
                "custom_parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<CustomParameter>?>(
                "custom_parameters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DialogflowConfig? DialogflowConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DialogflowConfig>(
                "dialogflow_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("dialogflow_config", value);
        }
    }

    /// <summary>
    /// Enables Dialogflow for the current call. The default value is false.
    /// </summary>
    public bool? EnableDialogflow {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "enable_dialogflow"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("enable_dialogflow", value);
        }
    }

    /// <summary>
    /// An authentication token to be sent as part of the WebSocket connection. Maximum
    /// length is 4000 characters.
    /// </summary>
    public string? StreamAuthToken {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "stream_auth_token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream_auth_token", value);
        }
    }

    /// <summary>
    /// Indicates codec for bidirectional streaming RTP payloads. Used only with
    /// stream_bidirectional_mode=rtp. Case sensitive.
    /// </summary>
    public ApiEnum<string, StreamBidirectionalCodec>? StreamBidirectionalCodec {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StreamBidirectionalCodec>>(
                "stream_bidirectional_codec"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream_bidirectional_codec", value);
        }
    }

    /// <summary>
    /// Configures method of bidirectional streaming (mp3, rtp).
    /// </summary>
    public ApiEnum<string, StreamBidirectionalMode>? StreamBidirectionalMode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StreamBidirectionalMode>>(
                "stream_bidirectional_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream_bidirectional_mode", value);
        }
    }

    /// <summary>
    /// Audio sampling rate.
    /// </summary>
    public ApiEnum<long, StreamBidirectionalSamplingRate>? StreamBidirectionalSamplingRate {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<long, StreamBidirectionalSamplingRate>>(
                "stream_bidirectional_sampling_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream_bidirectional_sampling_rate", value);
        }
    }

    /// <summary>
    /// Specifies which call legs should receive the bidirectional stream audio.
    /// </summary>
    public ApiEnum<string, StreamBidirectionalTargetLegs>? StreamBidirectionalTargetLegs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StreamBidirectionalTargetLegs>>(
                "stream_bidirectional_target_legs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream_bidirectional_target_legs", value);
        }
    }

    /// <summary>
    /// Specifies the codec to be used for the streamed audio. When set to 'default'
    /// or when transcoding is not possible, the codec from the call will be used.
    /// </summary>
    public ApiEnum<string, StreamCodec>? StreamCodec {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StreamCodec>>(
                "stream_codec"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream_codec", value);
        }
    }

    /// <summary>
    /// Specifies which track should be streamed.
    /// </summary>
    public ApiEnum<string, ActionStartStreamingParamsStreamTrack>? StreamTrack {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionStartStreamingParamsStreamTrack>>(
                "stream_track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream_track", value);
        }
    }

    /// <summary>
    /// The destination WebSocket address where the stream is going to be delivered.
    /// </summary>
    public string? StreamUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "stream_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream_url", value);
        }
    }

    public ActionStartStreamingParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartStreamingParams (
        ActionStartStreamingParams actionStartStreamingParams
    ) : base(actionStartStreamingParams)
    {
        this.CallControlID = actionStartStreamingParams.CallControlID;

        this._rawBodyData = new(actionStartStreamingParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionStartStreamingParams (
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
    ActionStartStreamingParams (
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
    public static ActionStartStreamingParams FromRawUnchecked(
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

    public virtual bool Equals(ActionStartStreamingParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/streaming_start",
            EncodePathSegment(this.CallControlID))
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

[JsonConverter(typeof(JsonModelConverter<CustomParameter, CustomParameterFromRaw>))]
public sealed record class CustomParameter : JsonModel
{
    /// <summary>
    /// The name of the custom parameter.
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
    /// The value of the custom parameter.
    /// </summary>
    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public CustomParameter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomParameter (CustomParameter customParameter) : base(
        customParameter
    )
    {  }
    #pragma warning restore CS8618

    public CustomParameter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomParameter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomParameterFromRaw.FromRawUnchecked"/>
    public static CustomParameter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomParameterFromRaw : IFromRawJson<CustomParameter>
{
    /// <inheritdoc/>
    public CustomParameter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomParameter.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies which track should be streamed.
/// </summary>
[JsonConverter(typeof(ActionStartStreamingParamsStreamTrackConverter))]
public enum ActionStartStreamingParamsStreamTrack
{
    InboundTrack, OutboundTrack, BothTracks
}

sealed class ActionStartStreamingParamsStreamTrackConverter : JsonConverter<ActionStartStreamingParamsStreamTrack>
{
    public override ActionStartStreamingParamsStreamTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_track"=>ActionStartStreamingParamsStreamTrack.InboundTrack,
            "outbound_track"=>ActionStartStreamingParamsStreamTrack.OutboundTrack,
            "both_tracks"=>ActionStartStreamingParamsStreamTrack.BothTracks,
            _ =>(ActionStartStreamingParamsStreamTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionStartStreamingParamsStreamTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionStartStreamingParamsStreamTrack.InboundTrack=>"inbound_track",
            ActionStartStreamingParamsStreamTrack.OutboundTrack=>"outbound_track",
            ActionStartStreamingParamsStreamTrack.BothTracks=>"both_tracks",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}