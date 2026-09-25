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
/// Answer an incoming call. You must issue this command before executing subsequent
/// commands on an incoming call.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.answered` - `call.hold` and `call.unhold` if the call is held/unheld
/// - `call.deepfake_detection.result` if `deepfake_detection` was enabled - `call.deepfake_detection.error`
/// if `deepfake_detection` was enabled and an error occurred - `streaming.started`,
/// `streaming.stopped` or `streaming.failed` if `stream_url` was set</para>
///
/// <para>When the `record` parameter is set to `record-from-answer`, the response
/// will include a `recording_id` field.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionAnswerParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// AI Assistant configuration. All fields except `id` are optional — the assistant's
    /// stored configuration will be used as fallback for any omitted fields.
    /// </summary>
    public CallAssistantRequest? Assistant {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CallAssistantRequest>(
                "assistant"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("assistant", value);
        }
    }

    /// <summary>
    /// Use this field to set the Billing Group ID for the call. Must be a valid
    /// and existing Billing Group ID.
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("billing_group_id", value);
        }
    }

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
    /// Starts a Conversation Relay session automatically when the answered/dialed
    /// call is answered. This embedded shape is supported on `answer` and `dial`.
    /// It uses public field names (`url`, `dtmf_detection`, `greeting`, `voice`,
    /// `language`, etc.) and maps them to the underlying Conversation Relay action.
    /// `client_state`, `tts_language`, and `transcription_language` inside this object
    /// are ignored; use the parent command's `client_state` and `command_id` fields instead.
    /// </summary>
    public ConversationRelayEmbeddedConfig? ConversationRelayConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ConversationRelayEmbeddedConfig>(
                "conversation_relay_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("conversation_relay_config", value);
        }
    }

    /// <summary>
    /// Custom headers to be added to the SIP INVITE response.
    /// </summary>
    public IReadOnlyList<CustomSipHeader>? CustomHeaders {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<CustomSipHeader>>(
                "custom_headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<CustomSipHeader>?>(
                "custom_headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Enables deepfake detection on the call. When enabled, audio from the remote
    /// party is streamed to a detection service that analyzes whether the voice
    /// is AI-generated. Results are delivered via the `call.deepfake_detection.result` webhook.
    /// </summary>
    public DeepfakeDetection? DeepfakeDetection {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DeepfakeDetection>(
                "deepfake_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("deepfake_detection", value);
        }
    }

    /// <summary>
    /// The list of comma-separated codecs in a preferred order for the forked media
    /// to be received.
    /// </summary>
    public ApiEnum<string, PreferredCodecs>? PreferredCodecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PreferredCodecs>>(
                "preferred_codecs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("preferred_codecs", value);
        }
    }

    /// <summary>
    /// Start recording automatically after an event. Disabled by default.
    /// </summary>
    public ApiEnum<string, Record>? Record {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Record>>(
                "record"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record", value);
        }
    }

    /// <summary>
    /// Defines which channel should be recorded ('single' or 'dual') when `record`
    /// is specified.
    /// </summary>
    public ApiEnum<string, RecordChannels>? RecordChannels {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RecordChannels>>(
                "record_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_channels", value);
        }
    }

    /// <summary>
    /// The custom recording file name to be used instead of the default `call_leg_id`.
    /// Telnyx will still add a Unix timestamp suffix.
    /// </summary>
    public string? RecordCustomFileName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "record_custom_file_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_custom_file_name", value);
        }
    }

    /// <summary>
    /// Defines the format of the recording ('wav' or 'mp3') when `record` is specified.
    /// </summary>
    public ApiEnum<string, RecordFormat>? RecordFormat {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RecordFormat>>(
                "record_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_format", value);
        }
    }

    /// <summary>
    /// Defines the maximum length for the recording in seconds when `record` is
    /// specified. The minimum value is 0. The maximum value is 43200. The default
    /// value is 0 (infinite).
    /// </summary>
    public int? RecordMaxLength {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "record_max_length"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_max_length", value);
        }
    }

    /// <summary>
    /// The number of seconds that Telnyx will wait for the recording to be stopped
    /// if silence is detected when `record` is specified. The timer only starts
    /// when the speech is detected. Please note that call transcription is used
    /// to detect silence and the related charge will be applied. The minimum value
    /// is 0. The default value is 0 (infinite).
    /// </summary>
    public int? RecordTimeoutSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "record_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_timeout_secs", value);
        }
    }

    /// <summary>
    /// The audio track to be recorded. Can be either `both`, `inbound` or `outbound`.
    /// If only single track is specified (`inbound`, `outbound`), `channels` configuration
    /// is ignored and it will be recorded as mono (single channel).
    /// </summary>
    public ApiEnum<string, RecordTrack>? RecordTrack {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RecordTrack>>(
                "record_track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_track", value);
        }
    }

    /// <summary>
    /// When set to `trim-silence`, silence will be removed from the beginning and
    /// end of the recording.
    /// </summary>
    public ApiEnum<string, RecordTrim>? RecordTrim {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RecordTrim>>(
                "record_trim"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("record_trim", value);
        }
    }

    /// <summary>
    /// Generate silence RTP packets when no transmission available.
    /// </summary>
    public bool? SendSilenceWhenIdle {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "send_silence_when_idle"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("send_silence_when_idle", value);
        }
    }

    /// <summary>
    /// SIP headers to be added to the SIP INVITE response. Currently only User-to-User
    /// header is supported.
    /// </summary>
    public IReadOnlyList<SipHeader>? SipHeaders {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<SipHeader>>(
                "sip_headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<SipHeader>?>(
                "sip_headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Use this field to modify sound effects, for example adjust the pitch.
    /// </summary>
    public SoundModifications? SoundModifications {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SoundModifications>(
                "sound_modifications"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sound_modifications", value);
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
    public ApiEnum<string, StreamTrack>? StreamTrack {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StreamTrack>>(
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

    /// <summary>
    /// Enable transcription upon call answer. The default value is false.
    /// </summary>
    public bool? Transcription {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "transcription"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription", value);
        }
    }

    public TranscriptionStartRequest? TranscriptionConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TranscriptionStartRequest>(
                "transcription_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription_config", value);
        }
    }

    /// <summary>
    /// A map of event types to retry policies. Each retry policy contains an array
    /// of `retries_ms` specifying the delays between retry attempts in milliseconds.
    /// Maximum 5 retries, total delay cannot exceed 60 seconds.
    /// </summary>
    public IReadOnlyDictionary<string, WebhookRetriesPoliciesItem>? WebhookRetriesPolicies {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, WebhookRetriesPoliciesItem>>(
                "webhook_retries_policies"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, WebhookRetriesPoliciesItem>?>(
                "webhook_retries_policies",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Use this field to override the URL for which Telnyx will send subsequent webhooks
    /// to for this call.
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `webhook_url`.
    /// </summary>
    public ApiEnum<string, WebhookUrlMethod>? WebhookUrlMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, WebhookUrlMethod>>(
                "webhook_url_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url_method", value);
        }
    }

    /// <summary>
    /// A map of event types to arrays of webhook URLs. When an event of the specified
    /// type occurs, the webhook URLs associated with that event type will be called
    /// instead of `webhook_url`. Events not mapped here will use the default `webhook_url`.
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? WebhookUrls {
        get {
            this._rawBodyData.Freeze();
            var value = this._rawBodyData.GetNullableClass<FrozenDictionary<string, ImmutableArray<string>>>(
                "webhook_urls"
            );
            if (value == null) {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(value, entry => entry.Key, ( entry )=>(IReadOnlyList<string>)entry.Value);
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "webhook_urls",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value, entry => entry.Key, ( entry )=>ImmutableArray.ToImmutableArray(entry.Value))
            );
        }
    }

    /// <summary>
    /// HTTP request method to invoke `webhook_urls`.
    /// </summary>
    public ApiEnum<string, WebhookUrlsMethod>? WebhookUrlsMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, WebhookUrlsMethod>>(
                "webhook_urls_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_urls_method", value);
        }
    }

    public ActionAnswerParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionAnswerParams (ActionAnswerParams actionAnswerParams) : base(
        actionAnswerParams
    )
    {
        this.CallControlID = actionAnswerParams.CallControlID;

        this._rawBodyData = new(actionAnswerParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionAnswerParams (
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
    ActionAnswerParams (
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
    public static ActionAnswerParams FromRawUnchecked(
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

    public virtual bool Equals(ActionAnswerParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/answer",
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
/// Enables deepfake detection on the call. When enabled, audio from the remote party
/// is streamed to a detection service that analyzes whether the voice is AI-generated.
/// Results are delivered via the `call.deepfake_detection.result` webhook.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DeepfakeDetection, DeepfakeDetectionFromRaw>))]
public sealed record class DeepfakeDetection : JsonModel
{
    /// <summary>
    /// Whether deepfake detection is enabled.
    /// </summary>
    public required bool Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "enabled"
            );
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <summary>
    /// Maximum time in seconds to wait for RTP audio before timing out. If no audio
    /// is received within this window, detection stops with an error.
    /// </summary>
    public int? RtpTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "rtp_timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rtp_timeout", value);
        }
    }

    /// <summary>
    /// Maximum time in seconds to wait for a detection result before timing out.
    /// </summary>
    public int? Timeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timeout", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.RtpTimeout;
        _ = this.Timeout;
    }

    public DeepfakeDetection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeepfakeDetection (DeepfakeDetection deepfakeDetection) : base(
        deepfakeDetection
    )
    {  }
    #pragma warning restore CS8618

    public DeepfakeDetection (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DeepfakeDetection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DeepfakeDetectionFromRaw.FromRawUnchecked"/>
    public static DeepfakeDetection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public DeepfakeDetection (bool enabled) : this()
    { this.Enabled = enabled; }
}

class DeepfakeDetectionFromRaw : IFromRawJson<DeepfakeDetection>
{
    /// <inheritdoc/>
    public DeepfakeDetection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DeepfakeDetection.FromRawUnchecked(rawData);
}

/// <summary>
/// The list of comma-separated codecs in a preferred order for the forked media to
/// be received.
/// </summary>
[JsonConverter(typeof(PreferredCodecsConverter))]
public enum PreferredCodecs
{
    G722PcmuPcmaG729OpusVp8H264
}

sealed class PreferredCodecsConverter : JsonConverter<PreferredCodecs>
{
    public override PreferredCodecs Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "G722,PCMU,PCMA,G729,OPUS,VP8,H264"=>PreferredCodecs.G722PcmuPcmaG729OpusVp8H264,
            _ =>(PreferredCodecs)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreferredCodecs value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PreferredCodecs.G722PcmuPcmaG729OpusVp8H264=>"G722,PCMU,PCMA,G729,OPUS,VP8,H264",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Start recording automatically after an event. Disabled by default.
/// </summary>
[JsonConverter(typeof(RecordConverter))]
public enum Record
{
    RecordFromAnswer
}

sealed class RecordConverter : JsonConverter<Record>
{
    public override Record Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "record-from-answer"=>Record.RecordFromAnswer, _ =>(Record)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Record value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Record.RecordFromAnswer=>"record-from-answer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines which channel should be recorded ('single' or 'dual') when `record` is specified.
/// </summary>
[JsonConverter(typeof(RecordChannelsConverter))]
public enum RecordChannels
{
    Single, Dual
}

sealed class RecordChannelsConverter : JsonConverter<RecordChannels>
{
    public override RecordChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>RecordChannels.Single,
            "dual"=>RecordChannels.Dual,
            _ =>(RecordChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordChannels.Single=>"single",
            RecordChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines the format of the recording ('wav' or 'mp3') when `record` is specified.
/// </summary>
[JsonConverter(typeof(RecordFormatConverter))]
public enum RecordFormat
{
    Wav, Mp3
}

sealed class RecordFormatConverter : JsonConverter<RecordFormat>
{
    public override RecordFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wav"=>RecordFormat.Wav,
            "mp3"=>RecordFormat.Mp3,
            _ =>(RecordFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordFormat value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordFormat.Wav=>"wav",
            RecordFormat.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The audio track to be recorded. Can be either `both`, `inbound` or `outbound`.
/// If only single track is specified (`inbound`, `outbound`), `channels` configuration
/// is ignored and it will be recorded as mono (single channel).
/// </summary>
[JsonConverter(typeof(RecordTrackConverter))]
public enum RecordTrack
{
    Both, Inbound, Outbound
}

sealed class RecordTrackConverter : JsonConverter<RecordTrack>
{
    public override RecordTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>RecordTrack.Both,
            "inbound"=>RecordTrack.Inbound,
            "outbound"=>RecordTrack.Outbound,
            _ =>(RecordTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordTrack value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordTrack.Both=>"both",
            RecordTrack.Inbound=>"inbound",
            RecordTrack.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// When set to `trim-silence`, silence will be removed from the beginning and end
/// of the recording.
/// </summary>
[JsonConverter(typeof(RecordTrimConverter))]
public enum RecordTrim
{
    TrimSilence
}

sealed class RecordTrimConverter : JsonConverter<RecordTrim>
{
    public override RecordTrim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "trim-silence"=>RecordTrim.TrimSilence, _ =>(RecordTrim)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordTrim value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordTrim.TrimSilence=>"trim-silence",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Specifies which track should be streamed.
/// </summary>
[JsonConverter(typeof(StreamTrackConverter))]
public enum StreamTrack
{
    InboundTrack, OutboundTrack, BothTracks
}

sealed class StreamTrackConverter : JsonConverter<StreamTrack>
{
    public override StreamTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound_track"=>StreamTrack.InboundTrack,
            "outbound_track"=>StreamTrack.OutboundTrack,
            "both_tracks"=>StreamTrack.BothTracks,
            _ =>(StreamTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, StreamTrack value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StreamTrack.InboundTrack=>"inbound_track",
            StreamTrack.OutboundTrack=>"outbound_track",
            StreamTrack.BothTracks=>"both_tracks",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<WebhookRetriesPoliciesItem, WebhookRetriesPoliciesItemFromRaw>))]
public sealed record class WebhookRetriesPoliciesItem : JsonModel
{
    /// <summary>
    /// Array of delays in milliseconds between retry attempts. Total sum cannot exceed 60000ms.
    /// </summary>
    public IReadOnlyList<long>? RetriesMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>(
                "retries_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "retries_ms",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.RetriesMs; }

    public WebhookRetriesPoliciesItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookRetriesPoliciesItem (
        WebhookRetriesPoliciesItem webhookRetriesPoliciesItem
    ) : base(webhookRetriesPoliciesItem)
    {  }
    #pragma warning restore CS8618

    public WebhookRetriesPoliciesItem (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRetriesPoliciesItem (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookRetriesPoliciesItemFromRaw.FromRawUnchecked"/>
    public static WebhookRetriesPoliciesItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookRetriesPoliciesItemFromRaw : IFromRawJson<WebhookRetriesPoliciesItem>
{
    /// <inheritdoc/>
    public WebhookRetriesPoliciesItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookRetriesPoliciesItem.FromRawUnchecked(rawData);
}

/// <summary>
/// HTTP request type used for `webhook_url`.
/// </summary>
[JsonConverter(typeof(WebhookUrlMethodConverter))]
public enum WebhookUrlMethod
{
    Post, Get
}

sealed class WebhookUrlMethodConverter : JsonConverter<WebhookUrlMethod>
{
    public override WebhookUrlMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "POST"=>WebhookUrlMethod.Post,
            "GET"=>WebhookUrlMethod.Get,
            _ =>(WebhookUrlMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookUrlMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookUrlMethod.Post=>"POST",
            WebhookUrlMethod.Get=>"GET",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request method to invoke `webhook_urls`.
/// </summary>
[JsonConverter(typeof(WebhookUrlsMethodConverter))]
public enum WebhookUrlsMethod
{
    Post, Get
}

sealed class WebhookUrlsMethodConverter : JsonConverter<WebhookUrlsMethod>
{
    public override WebhookUrlsMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "POST"=>WebhookUrlsMethod.Post,
            "GET"=>WebhookUrlsMethod.Get,
            _ =>(WebhookUrlsMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookUrlsMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookUrlsMethod.Post=>"POST",
            WebhookUrlsMethod.Get=>"GET",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}