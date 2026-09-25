using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Actions = Telnyx.Sdk.Models.Calls.Actions;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Dial a number or SIP URI from a given connection. A successful response will
/// include a `call_leg_id` which can be used to correlate the command with subsequent webhooks.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.initiated` - `call.answered` or `call.hangup` - `call.hold` and
/// `call.unhold` if the call is held/unheld - `call.machine.detection.ended` if
/// `answering_machine_detection` was requested - `call.machine.greeting.ended` if
/// `answering_machine_detection` was requested to detect the end of machine greeting
/// - `call.machine.premium.detection.ended` if `answering_machine_detection=premium`
/// was requested - `call.machine.premium.greeting.ended` if `answering_machine_detection=premium`
/// was requested and a beep was detected - `call.deepfake_detection.result` if `deepfake_detection`
/// was enabled - `call.deepfake_detection.error` if `deepfake_detection` was enabled
/// and an error occurred - `streaming.started`, `streaming.stopped` or `streaming.failed`
/// if `stream_url` was set</para>
///
/// <para>When the `record` parameter is set to `record-from-answer`, the response
/// will include a `recording_id` field.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallDialParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public Generic::IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The ID of the Call Control App (formerly ID of the connection) to be used
    /// when dialing the destination.
    /// </summary>
    public required string ConnectionID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "connection_id"
            );
        }
        init { this._rawBodyData.Set("connection_id", value); }
    }

    /// <summary>
    /// The `from` number to be used as the caller id presented to the destination
    /// (`to` number). The number should be in +E164 format.
    /// </summary>
    public required string From {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "from"
            );
        }
        init { this._rawBodyData.Set("from", value); }
    }

    /// <summary>
    /// The DID or SIP URI to dial out to. Multiple DID or SIP URIs can be provided
    /// using an array of strings. For SIP URI destinations, append `;secure=true`
    /// or `;secure=srtp` to enable SRTP media encryption for that endpoint, or `;secure=dtls`
    /// to enable DTLS media encryption for that endpoint. If `media_encryption`
    /// is set to `SRTP` or `DTLS`, it takes precedence over any per-endpoint `secure`
    /// URI parameter. For a single string destination, you may append a comma followed
    /// by DTMF digits (e.g. `+18004247767,200`) to play those digits as DTMF once
    /// the called party answers — equivalent to setting `send_digits_on_answer` separately.
    /// If both are present, the explicit `send_digits_on_answer` parameter takes
    /// precedence. This shorthand is not supported when `to` is an array.
    /// </summary>
    public required To To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<To>(
                "to"
            );
        }
        init { this._rawBodyData.Set("to", value); }
    }

    /// <summary>
    /// Enables Answering Machine Detection. Telnyx offers Premium and Standard detections.
    /// With Premium detection, when a call is answered, Telnyx runs real-time detection
    /// and sends a `call.machine.premium.detection.ended` webhook with one of the
    /// following results: `human_residence`, `human_business`, `machine`, `silence`
    /// or `fax_detected`. If we detect a beep, we also send a `call.machine.premium.greeting.ended`
    /// webhook with the result of `beep_detected`. If we detect a beep before `call.machine.premium.detection.ended`
    /// we only send `call.machine.premium.greeting.ended`, and if we detect a beep
    /// after `call.machine.premium.detection.ended`, we send both webhooks. With
    /// Standard detection, when a call is answered, Telnyx runs real-time detection
    /// to determine if it was picked up by a human or a machine and sends an `call.machine.detection.ended`
    /// webhook with the analysis result. If `greeting_end` or `detect_words` is used
    /// and a `machine` is detected, you will receive another `call.machine.greeting.ended`
    /// webhook when the answering machine greeting ends with a beep or silence.
    /// If `detect_beep` is used, you will only receive `call.machine.greeting.ended`
    /// if a beep is detected.
    /// </summary>
    public ApiEnum<string, AnsweringMachineDetection>? AnsweringMachineDetection {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AnsweringMachineDetection>>(
                "answering_machine_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("answering_machine_detection", value);
        }
    }

    /// <summary>
    /// Optional configuration parameters to modify 'answering_machine_detection'
    /// performance. Only `total_analysis_time_millis` and `greeting_duration_millis`
    /// parameters are applicable when `premium` is selected as answering_machine_detection.
    /// </summary>
    public AnsweringMachineDetectionConfig? AnsweringMachineDetectionConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AnsweringMachineDetectionConfig>(
                "answering_machine_detection_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("answering_machine_detection_config", value);
        }
    }

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
    /// The URL of a file to be played back to the callee when the call is answered.
    /// The URL can point to either a WAV or MP3 file. media_name and audio_url cannot
    /// be used together in one request.
    /// </summary>
    public string? AudioUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "audio_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("audio_url", value);
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
    /// Indicates the intent to bridge this call with the call specified in link_to.
    /// When bridge_intent is true, link_to becomes required and the from number
    /// will be overwritten by the from number from the linked call.
    /// </summary>
    public bool? BridgeIntent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "bridge_intent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("bridge_intent", value);
        }
    }

    /// <summary>
    /// Whether to automatically bridge answered call to the call specified in link_to.
    /// When bridge_on_answer is true, link_to becomes required.
    /// </summary>
    public bool? BridgeOnAnswer {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "bridge_on_answer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("bridge_on_answer", value);
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
    /// Use this field to avoid duplicate commands. Telnyx will ignore others Dial
    /// commands with the same `command_id`.
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
    /// Optional configuration parameters to dial new participant into a conference.
    /// </summary>
    public ConferenceConfig? ConferenceConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ConferenceConfig>(
                "conference_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("conference_config", value);
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
    /// Custom headers to be added to the SIP INVITE.
    /// </summary>
    public Generic::IReadOnlyList<CustomSipHeader>? CustomHeaders {
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
    /// The `to` number of an active inbound call, in +E164 format. Telnyx checks
    /// whether there is currently an active inbound call where `to` matches this
    /// `diversion` value and `from` matches the `from` number supplied for this
    /// request. If such a call exists, the `from` number is treated as verified (since
    /// it is already on an active inbound call to you) and can be used as the caller
    /// id for this outbound call.
    /// </summary>
    public string? Diversion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "diversion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("diversion", value);
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
    /// The `from_display_name` string to be used as the caller id name (SIP From
    /// Display Name) presented to the destination (`to` number). The string should
    /// have a maximum of 128 characters, containing only letters, numbers, spaces,
    /// and -_~!.+ special characters. If ommited, the display name will be the same
    /// as the number in the `from` field.
    /// </summary>
    public string? FromDisplayName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "from_display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("from_display_name", value);
        }
    }

    /// <summary>
    /// Use another call's control id for sharing the same call session id
    /// </summary>
    public string? LinkTo {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "link_to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("link_to", value);
        }
    }

    /// <summary>
    /// Defines whether media should be encrypted on the call. For SIP URI destinations,
    /// media encryption can also be requested per endpoint with the `secure` URI
    /// parameter: `;secure=true` or `;secure=srtp` enables SRTP, and `;secure=dtls`
    /// enables DTLS. This parameter, when set to `SRTP` or `DTLS`, takes precedence
    /// over the per-endpoint `secure` value.
    /// </summary>
    public ApiEnum<string, MediaEncryption>? MediaEncryption {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MediaEncryption>>(
                "media_encryption"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("media_encryption", value);
        }
    }

    /// <summary>
    /// The media_name of a file to be played back to the callee when the call is
    /// answered. The media_name must point to a file previously uploaded to api.telnyx.com/v2/media
    /// by the same user/organization. The file must either be a WAV or MP3 file.
    /// </summary>
    public string? MediaName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("media_name", value);
        }
    }

    /// <summary>
    /// If supplied with the value `self`, the current leg will be parked after unbridge.
    /// If not set, the default behavior is to hang up the leg. When park_after_unbridge
    /// is set, link_to becomes required.
    /// </summary>
    public string? ParkAfterUnbridge {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "park_after_unbridge"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("park_after_unbridge", value);
        }
    }

    /// <summary>
    /// The list of comma-separated codecs in a preferred order for the forked media
    /// to be received.
    /// </summary>
    public string? PreferredCodecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
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
    /// Prevents bridging and hangs up the call if the target is already bridged.
    /// Disabled by default.
    /// </summary>
    public bool? PreventDoubleBridge {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "prevent_double_bridge"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("prevent_double_bridge", value);
        }
    }

    /// <summary>
    /// Indicates the privacy level to be used for the call. When set to `id`, caller
    /// ID information (name and number) will be hidden from the called party. When
    /// set to `none` or omitted, caller ID will be shown normally.
    /// </summary>
    public ApiEnum<string, Privacy>? Privacy {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Privacy>>(
                "privacy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("privacy", value);
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
    /// Whether to keep trying the remaining routing paths (e.g. alternate providers/gateways)
    /// for the same destination after `timeout_secs` is reached for the current
    /// attempt. When set to `false`, reaching `timeout_secs` aborts the entire dial
    /// attempt and the `call.hangup` webhook reports a `hangup_cause` of `no_answer`
    /// instead of `timeout`.
    /// </summary>
    public bool? RetryOnTimeout {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "retry_on_timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("retry_on_timeout", value);
        }
    }

    /// <summary>
    /// When set to true, routes the call directly to the mobile device associated
    /// with the destination Telnyx Mobile number, bypassing Inbound Calls Interception
    /// configured in the Telnyx Portal under Mobile Numbers → select the number →
    /// Voice → Call Interception. Use this when transferring an intercepted call
    /// to the mobile device to prevent the call from being intercepted again. Defaults
    /// to false.
    /// </summary>
    public bool? RouteToMobile {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "route_to_mobile"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("route_to_mobile", value);
        }
    }

    /// <summary>
    /// DTMF digits to send automatically after the called party answers. Useful for
    /// reaching an extension behind an IVR (e.g. `"200"` to dial extension 200 once
    /// the called party picks up). Allowed characters: `0-9`, `A-D`, `w` (0.5s pause),
    /// `W` (1s pause), `*`, `#`. Maximum 64 characters. When omitted, no automatic
    /// DTMF is sent. May also be supplied inline by appending `,&lt;digits&gt;`
    /// to `to` (e.g. `to=+18004247767,200`); if both forms are present, this explicit
    /// field takes precedence.
    /// </summary>
    public string? SendDigitsOnAnswer {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "send_digits_on_answer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("send_digits_on_answer", value);
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
    /// SIP Authentication password used for SIP challenges.
    /// </summary>
    public string? SipAuthPassword {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "sip_auth_password"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sip_auth_password", value);
        }
    }

    /// <summary>
    /// SIP Authentication username used for SIP challenges.
    /// </summary>
    public string? SipAuthUsername {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "sip_auth_username"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sip_auth_username", value);
        }
    }

    /// <summary>
    /// SIP headers to be added to the SIP INVITE request. Currently only User-to-User
    /// header is supported.
    /// </summary>
    public Generic::IReadOnlyList<SipHeader>? SipHeaders {
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
    /// Defines the SIP region to be used for the call.
    /// </summary>
    public ApiEnum<string, SipRegion>? SipRegion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SipRegion>>(
                "sip_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sip_region", value);
        }
    }

    /// <summary>
    /// Defines SIP transport protocol to be used on the call.
    /// </summary>
    public ApiEnum<string, SipTransportProtocol>? SipTransportProtocol {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SipTransportProtocol>>(
                "sip_transport_protocol"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sip_transport_protocol", value);
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
    /// An authentication token to be sent as part of the WebSocket connection when
    /// using streaming. Maximum length is 4000 characters.
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
    /// Establish websocket connection before dialing the destination. This is useful
    /// for cases where the websocket connection takes a long time to establish.
    /// </summary>
    public bool? StreamEstablishBeforeCallOriginate {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "stream_establish_before_call_originate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream_establish_before_call_originate", value);
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
    /// The call leg which will be supervised by the new call.
    /// </summary>
    public string? SuperviseCallControlID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "supervise_call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("supervise_call_control_id", value);
        }
    }

    /// <summary>
    /// The role of the supervisor call. 'barge' means that supervisor call hears
    /// and is being heard by both ends of the call (caller &amp; callee). 'whisper'
    /// means that only supervised_call_control_id hears supervisor but supervisor
    /// can hear everything. 'monitor' means that nobody can hear supervisor call,
    /// but supervisor can hear everything on the call.
    /// </summary>
    public ApiEnum<string, CallDialParamsSupervisorRole>? SupervisorRole {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CallDialParamsSupervisorRole>>(
                "supervisor_role"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("supervisor_role", value);
        }
    }

    /// <summary>
    /// Sets the maximum duration of a Call Control Leg in seconds. If the time limit
    /// is reached, the call will hangup and a `call.hangup` webhook with a `hangup_cause`
    /// of `time_limit` will be sent. For example, by setting a time limit of 120
    /// seconds, a Call Leg will be automatically terminated two minutes after being
    /// answered. The default time limit is 14400 seconds or 4 hours and this is
    /// also the maximum allowed call length.
    /// </summary>
    public int? TimeLimitSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "time_limit_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("time_limit_secs", value);
        }
    }

    /// <summary>
    /// The number of seconds that Telnyx will wait for the call to be answered by
    /// the destination to which it is being called. If the timeout is reached before
    /// an answer is received, the call will hangup and a `call.hangup` webhook with
    /// a `hangup_cause` of `timeout` will be sent. Minimum value is 5 seconds. Maximum
    /// value is 600 seconds.
    /// </summary>
    public int? TimeoutSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("timeout_secs", value);
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

    public Actions::TranscriptionStartRequest? TranscriptionConfig {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Actions::TranscriptionStartRequest>(
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
    public Generic::IReadOnlyDictionary<string, WebhookRetriesPoliciesItem>? WebhookRetriesPolicies {
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
    /// instead of the default webhook URL. Events not mapped here will use the default
    /// webhook URL.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, Generic::IReadOnlyList<string>>? WebhookUrls {
        get {
            this._rawBodyData.Freeze();
            var value = this._rawBodyData.GetNullableClass<FrozenDictionary<string, ImmutableArray<string>>>(
                "webhook_urls"
            );
            if (value == null) {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(value, entry => entry.Key, ( entry )=>(Generic::IReadOnlyList<string>)entry.Value);
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

    public CallDialParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallDialParams (CallDialParams callDialParams) : base(callDialParams)
    { this._rawBodyData = new(callDialParams._rawBodyData); }
    #pragma warning restore CS8618

    public CallDialParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallDialParams (
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
    public static CallDialParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CallDialParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/calls"
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
/// The DID or SIP URI to dial out to. Multiple DID or SIP URIs can be provided using
/// an array of strings. For SIP URI destinations, append `;secure=true` or `;secure=srtp`
/// to enable SRTP media encryption for that endpoint, or `;secure=dtls` to enable
/// DTLS media encryption for that endpoint. If `media_encryption` is set to `SRTP`
/// or `DTLS`, it takes precedence over any per-endpoint `secure` URI parameter. For
/// a single string destination, you may append a comma followed by DTMF digits (e.g.
/// `+18004247767,200`) to play those digits as DTMF once the called party answers
/// — equivalent to setting `send_digits_on_answer` separately. If both are present,
/// the explicit `send_digits_on_answer` parameter takes precedence. This shorthand
/// is not supported when `to` is an array.
/// </summary>
[JsonConverter(typeof(ToConverter))]
public record class To : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public To (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To (
        Generic::IReadOnlyList<string> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public To (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>string</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickStrings(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;string&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickStrings(
        [NotNullWhen(true)] out Generic::IReadOnlyList<string>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<string> ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of To");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyList<string> value=>strings(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of To")
        } ;
    }

    public static implicit operator To (string value)=> new(value) ;

    public static implicit operator To (
        Generic::List<string> value
    )=> new((Generic::IReadOnlyList<string>)value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of To");
        }
    }

    public virtual bool Equals(To? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { string _=>0, Generic::IReadOnlyList<string> _=>1, _ =>-1 } ;
    }
}

sealed class ToConverter : JsonConverter<To>
{
    public override To? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<string>>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, To value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Enables Answering Machine Detection. Telnyx offers Premium and Standard detections.
/// With Premium detection, when a call is answered, Telnyx runs real-time detection
/// and sends a `call.machine.premium.detection.ended` webhook with one of the following
/// results: `human_residence`, `human_business`, `machine`, `silence` or `fax_detected`.
/// If we detect a beep, we also send a `call.machine.premium.greeting.ended` webhook
/// with the result of `beep_detected`. If we detect a beep before `call.machine.premium.detection.ended`
/// we only send `call.machine.premium.greeting.ended`, and if we detect a beep after
/// `call.machine.premium.detection.ended`, we send both webhooks. With Standard
/// detection, when a call is answered, Telnyx runs real-time detection to determine
/// if it was picked up by a human or a machine and sends an `call.machine.detection.ended`
/// webhook with the analysis result. If `greeting_end` or `detect_words` is used
/// and a `machine` is detected, you will receive another `call.machine.greeting.ended`
/// webhook when the answering machine greeting ends with a beep or silence. If `detect_beep`
/// is used, you will only receive `call.machine.greeting.ended` if a beep is detected.
/// </summary>
[JsonConverter(typeof(AnsweringMachineDetectionConverter))]
public enum AnsweringMachineDetection
{
    Premium, Detect, DetectBeep, DetectWords, GreetingEnd, Disabled
}

sealed class AnsweringMachineDetectionConverter : JsonConverter<AnsweringMachineDetection>
{
    public override AnsweringMachineDetection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "premium"=>AnsweringMachineDetection.Premium,
            "detect"=>AnsweringMachineDetection.Detect,
            "detect_beep"=>AnsweringMachineDetection.DetectBeep,
            "detect_words"=>AnsweringMachineDetection.DetectWords,
            "greeting_end"=>AnsweringMachineDetection.GreetingEnd,
            "disabled"=>AnsweringMachineDetection.Disabled,
            _ =>(AnsweringMachineDetection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnsweringMachineDetection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AnsweringMachineDetection.Premium=>"premium",
            AnsweringMachineDetection.Detect=>"detect",
            AnsweringMachineDetection.DetectBeep=>"detect_beep",
            AnsweringMachineDetection.DetectWords=>"detect_words",
            AnsweringMachineDetection.GreetingEnd=>"greeting_end",
            AnsweringMachineDetection.Disabled=>"disabled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Optional configuration parameters to modify 'answering_machine_detection' performance.
/// Only `total_analysis_time_millis` and `greeting_duration_millis` parameters are
/// applicable when `premium` is selected as answering_machine_detection.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AnsweringMachineDetectionConfig, AnsweringMachineDetectionConfigFromRaw>))]
public sealed record class AnsweringMachineDetectionConfig : JsonModel
{
    /// <summary>
    /// Silence duration threshold after a greeting message or voice for it be considered human.
    /// </summary>
    public int? AfterGreetingSilenceMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "after_greeting_silence_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("after_greeting_silence_millis", value);
        }
    }

    /// <summary>
    /// Selects which detectors must validate a beep. `both` requires the amplitude
    /// and frequency detectors to agree. `freq_only` uses the frequency detector
    /// alone, for beeps whose volume is too unsteady for the default profile.
    /// </summary>
    public ApiEnum<string, BeepDetectionProfile>? BeepDetectionProfile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BeepDetectionProfile>>(
                "beep_detection_profile"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("beep_detection_profile", value);
        }
    }

    /// <summary>
    /// Highest frequency, in Hz, that a tone can reach and still be treated as a
    /// beep. Only used when beep detection is active.
    /// </summary>
    public int? BeepMaxFrequencyHz {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "beep_max_frequency_hz"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("beep_max_frequency_hz", value);
        }
    }

    /// <summary>
    /// Lowest frequency, in Hz, that a tone must reach to be treated as a beep. Raising
    /// it above 480 excludes North American ringback (440 + 480 Hz), which can otherwise
    /// be reported as a beep when the `freq_only` profile is in use. Only used when
    /// beep detection is active.
    /// </summary>
    public int? BeepMinFrequencyHz {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "beep_min_frequency_hz"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("beep_min_frequency_hz", value);
        }
    }

    /// <summary>
    /// Shortest tone, in milliseconds, that can be treated as a beep. Raising it
    /// rejects brief tones such as call-progress blips. Only used when beep detection
    /// is active.
    /// </summary>
    public int? BeepMinToneDurationMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "beep_min_tone_duration_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("beep_min_tone_duration_millis", value);
        }
    }

    /// <summary>
    /// When enabled, a candidate beep must pass an additional spectral check before
    /// it is reported. Only used when beep detection is active.
    /// </summary>
    public bool? BeepSpectralConfirmation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "beep_spectral_confirmation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("beep_spectral_confirmation", value);
        }
    }

    /// <summary>
    /// Minimum spectral purity, from 0 to 1, for a tone to be treated as a beep.
    /// Raising it rejects mixed tones such as ringback, which combines two frequencies.
    /// Only used when beep detection is active.
    /// </summary>
    public double? BeepSpectralMinPurity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "beep_spectral_min_purity"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("beep_spectral_min_purity", value);
        }
    }

    /// <summary>
    /// When enabled, the fax CNG tone is rejected rather than reported as a beep.
    /// Only used when beep detection is active.
    /// </summary>
    public bool? BeepSpectralRejectFaxCng {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "beep_spectral_reject_fax_cng"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("beep_spectral_reject_fax_cng", value);
        }
    }

    /// <summary>
    /// Length of the spectral confirmation window, in milliseconds. Only used when
    /// beep detection is active.
    /// </summary>
    public int? BeepSpectralWindowMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "beep_spectral_window_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("beep_spectral_window_millis", value);
        }
    }

    /// <summary>
    /// Maximum threshold for silence between words.
    /// </summary>
    public int? BetweenWordsSilenceMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "between_words_silence_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("between_words_silence_millis", value);
        }
    }

    /// <summary>
    /// Maximum threshold of a human greeting. If greeting longer than this value,
    /// considered machine.
    /// </summary>
    public int? GreetingDurationMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "greeting_duration_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("greeting_duration_millis", value);
        }
    }

    /// <summary>
    /// If machine already detected, maximum threshold for silence between words.
    /// If exceeded, the greeting is considered ended.
    /// </summary>
    public int? GreetingSilenceDurationMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "greeting_silence_duration_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("greeting_silence_duration_millis", value);
        }
    }

    /// <summary>
    /// If machine already detected, maximum timeout threshold to determine the end
    /// of the machine greeting.
    /// </summary>
    public int? GreetingTotalAnalysisTimeMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "greeting_total_analysis_time_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("greeting_total_analysis_time_millis", value);
        }
    }

    /// <summary>
    /// If initial silence duration is greater than this value, consider it a machine.
    /// </summary>
    public int? InitialSilenceMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "initial_silence_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("initial_silence_millis", value);
        }
    }

    /// <summary>
    /// If number of detected words is greater than this value, consder it a machine.
    /// </summary>
    public int? MaximumNumberOfWords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "maximum_number_of_words"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("maximum_number_of_words", value);
        }
    }

    /// <summary>
    /// If a single word lasts longer than this threshold, consider it a machine.
    /// </summary>
    public int? MaximumWordLengthMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "maximum_word_length_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("maximum_word_length_millis", value);
        }
    }

    /// <summary>
    /// Minimum noise threshold for any analysis.
    /// </summary>
    public int? SilenceThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "silence_threshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("silence_threshold", value);
        }
    }

    /// <summary>
    /// Maximum timeout threshold for overall detection.
    /// </summary>
    public int? TotalAnalysisTimeMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "total_analysis_time_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_analysis_time_millis", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AfterGreetingSilenceMillis;
        this.BeepDetectionProfile?.Validate();
        _ = this.BeepMaxFrequencyHz;
        _ = this.BeepMinFrequencyHz;
        _ = this.BeepMinToneDurationMillis;
        _ = this.BeepSpectralConfirmation;
        _ = this.BeepSpectralMinPurity;
        _ = this.BeepSpectralRejectFaxCng;
        _ = this.BeepSpectralWindowMillis;
        _ = this.BetweenWordsSilenceMillis;
        _ = this.GreetingDurationMillis;
        _ = this.GreetingSilenceDurationMillis;
        _ = this.GreetingTotalAnalysisTimeMillis;
        _ = this.InitialSilenceMillis;
        _ = this.MaximumNumberOfWords;
        _ = this.MaximumWordLengthMillis;
        _ = this.SilenceThreshold;
        _ = this.TotalAnalysisTimeMillis;
    }

    public AnsweringMachineDetectionConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnsweringMachineDetectionConfig (
        AnsweringMachineDetectionConfig answeringMachineDetectionConfig
    ) : base(answeringMachineDetectionConfig)
    {  }
    #pragma warning restore CS8618

    public AnsweringMachineDetectionConfig (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AnsweringMachineDetectionConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AnsweringMachineDetectionConfigFromRaw.FromRawUnchecked"/>
    public static AnsweringMachineDetectionConfig FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AnsweringMachineDetectionConfigFromRaw : IFromRawJson<AnsweringMachineDetectionConfig>
{
    /// <inheritdoc/>
    public AnsweringMachineDetectionConfig FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AnsweringMachineDetectionConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Selects which detectors must validate a beep. `both` requires the amplitude and
/// frequency detectors to agree. `freq_only` uses the frequency detector alone,
/// for beeps whose volume is too unsteady for the default profile.
/// </summary>
[JsonConverter(typeof(BeepDetectionProfileConverter))]
public enum BeepDetectionProfile
{
    Both, FreqOnly
}

sealed class BeepDetectionProfileConverter : JsonConverter<BeepDetectionProfile>
{
    public override BeepDetectionProfile Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>BeepDetectionProfile.Both,
            "freq_only"=>BeepDetectionProfile.FreqOnly,
            _ =>(BeepDetectionProfile)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BeepDetectionProfile value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BeepDetectionProfile.Both=>"both",
            BeepDetectionProfile.FreqOnly=>"freq_only",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Optional configuration parameters to dial new participant into a conference.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConferenceConfig, ConferenceConfigFromRaw>))]
public sealed record class ConferenceConfig : JsonModel
{
    /// <summary>
    /// Conference ID to be joined
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Whether a beep sound should be played when the participant joins and/or leaves
    /// the conference. Can be used to override the conference-level setting.
    /// </summary>
    public ApiEnum<string, BeepEnabled>? BeepEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BeepEnabled>>(
                "beep_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("beep_enabled", value);
        }
    }

    /// <summary>
    /// Conference name to be joined
    /// </summary>
    public string? ConferenceName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conference_name", value);
        }
    }

    /// <summary>
    /// Controls the moment when dialled call is joined into conference. If set to
    /// `true` user will be joined as soon as media is available (ringback). If `false`
    /// user will be joined when call is answered. Defaults to `true`
    /// </summary>
    public bool? EarlyMedia {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "early_media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("early_media", value);
        }
    }

    /// <summary>
    /// Whether the conference should end and all remaining participants be hung up
    /// after the participant leaves the conference. Defaults to "false".
    /// </summary>
    public bool? EndConferenceOnExit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "end_conference_on_exit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_conference_on_exit", value);
        }
    }

    /// <summary>
    /// Whether the participant should be put on hold immediately after joining the
    /// conference. Defaults to "false".
    /// </summary>
    public bool? Hold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "hold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hold", value);
        }
    }

    /// <summary>
    /// The URL of a file to be played to the participant when they are put on hold
    /// after joining the conference. hold_media_name and hold_audio_url cannot be
    /// used together in one request. Takes effect only when "start_conference_on_create"
    /// is set to "false". This property takes effect only if "hold" is set to "true".
    /// </summary>
    public string? HoldAudioUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "hold_audio_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hold_audio_url", value);
        }
    }

    /// <summary>
    /// The media_name of a file to be played to the participant when they are put
    /// on hold after joining the conference. The media_name must point to a file
    /// previously uploaded to api.telnyx.com/v2/media by the same user/organization.
    /// The file must either be a WAV or MP3 file. Takes effect only when "start_conference_on_create"
    /// is set to "false". This property takes effect only if "hold" is set to "true".
    /// </summary>
    public string? HoldMediaName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "hold_media_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hold_media_name", value);
        }
    }

    /// <summary>
    /// Whether the participant should be muted immediately after joining the conference.
    /// Defaults to "false".
    /// </summary>
    public bool? Mute {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "mute"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mute", value);
        }
    }

    /// <summary>
    /// Whether the conference should end after the participant leaves the conference.
    /// NOTE this doesn't hang up the other participants. Defaults to "false".
    /// </summary>
    public bool? SoftEndConferenceOnExit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "soft_end_conference_on_exit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("soft_end_conference_on_exit", value);
        }
    }

    /// <summary>
    /// Whether the conference should be started on creation. If the conference isn't
    /// started all participants that join are automatically put on hold. Defaults
    /// to "true".
    /// </summary>
    public bool? StartConferenceOnCreate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "start_conference_on_create"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_conference_on_create", value);
        }
    }

    /// <summary>
    /// Whether the conference should be started after the participant joins the conference.
    /// Defaults to "false".
    /// </summary>
    public bool? StartConferenceOnEnter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "start_conference_on_enter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_conference_on_enter", value);
        }
    }

    /// <summary>
    /// Sets the joining participant as a supervisor for the conference. A conference
    /// can have multiple supervisors. "barge" means the supervisor enters the conference
    /// as a normal participant. This is the same as "none". "monitor" means the
    /// supervisor is muted but can hear all participants. "whisper" means that only
    /// the specified "whisper_call_control_ids" can hear the supervisor. Defaults
    /// to "none".
    /// </summary>
    public ApiEnum<string, SupervisorRole>? SupervisorRole {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SupervisorRole>>(
                "supervisor_role"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("supervisor_role", value);
        }
    }

    /// <summary>
    /// Array of unique call_control_ids the joining supervisor can whisper to. If
    /// none provided, the supervisor will join the conference as a monitoring participant only.
    /// </summary>
    public Generic::IReadOnlyList<string>? WhisperCallControlIds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "whisper_call_control_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "whisper_call_control_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.BeepEnabled?.Validate();
        _ = this.ConferenceName;
        _ = this.EarlyMedia;
        _ = this.EndConferenceOnExit;
        _ = this.Hold;
        _ = this.HoldAudioUrl;
        _ = this.HoldMediaName;
        _ = this.Mute;
        _ = this.SoftEndConferenceOnExit;
        _ = this.StartConferenceOnCreate;
        _ = this.StartConferenceOnEnter;
        this.SupervisorRole?.Validate();
        _ = this.WhisperCallControlIds;
    }

    public ConferenceConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceConfig (ConferenceConfig conferenceConfig) : base(
        conferenceConfig
    )
    {  }
    #pragma warning restore CS8618

    public ConferenceConfig (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceConfigFromRaw.FromRawUnchecked"/>
    public static ConferenceConfig FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceConfigFromRaw : IFromRawJson<ConferenceConfig>
{
    /// <inheritdoc/>
    public ConferenceConfig FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether a beep sound should be played when the participant joins and/or leaves
/// the conference. Can be used to override the conference-level setting.
/// </summary>
[JsonConverter(typeof(BeepEnabledConverter))]
public enum BeepEnabled
{
    Always, Never, OnEnter, OnExit
}

sealed class BeepEnabledConverter : JsonConverter<BeepEnabled>
{
    public override BeepEnabled Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>BeepEnabled.Always,
            "never"=>BeepEnabled.Never,
            "on_enter"=>BeepEnabled.OnEnter,
            "on_exit"=>BeepEnabled.OnExit,
            _ =>(BeepEnabled)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, BeepEnabled value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BeepEnabled.Always=>"always",
            BeepEnabled.Never=>"never",
            BeepEnabled.OnEnter=>"on_enter",
            BeepEnabled.OnExit=>"on_exit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Sets the joining participant as a supervisor for the conference. A conference
/// can have multiple supervisors. "barge" means the supervisor enters the conference
/// as a normal participant. This is the same as "none". "monitor" means the supervisor
/// is muted but can hear all participants. "whisper" means that only the specified
/// "whisper_call_control_ids" can hear the supervisor. Defaults to "none".
/// </summary>
[JsonConverter(typeof(SupervisorRoleConverter))]
public enum SupervisorRole
{
    Barge, Monitor, None, Whisper
}

sealed class SupervisorRoleConverter : JsonConverter<SupervisorRole>
{
    public override SupervisorRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "barge"=>SupervisorRole.Barge,
            "monitor"=>SupervisorRole.Monitor,
            "none"=>SupervisorRole.None,
            "whisper"=>SupervisorRole.Whisper,
            _ =>(SupervisorRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SupervisorRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SupervisorRole.Barge=>"barge",
            SupervisorRole.Monitor=>"monitor",
            SupervisorRole.None=>"none",
            SupervisorRole.Whisper=>"whisper",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
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

    public DeepfakeDetection (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DeepfakeDetection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DeepfakeDetectionFromRaw.FromRawUnchecked"/>
    public static DeepfakeDetection FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
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
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DeepfakeDetection.FromRawUnchecked(rawData);
}

/// <summary>
/// Defines whether media should be encrypted on the call. For SIP URI destinations,
/// media encryption can also be requested per endpoint with the `secure` URI parameter:
/// `;secure=true` or `;secure=srtp` enables SRTP, and `;secure=dtls` enables DTLS.
/// This parameter, when set to `SRTP` or `DTLS`, takes precedence over the per-endpoint
/// `secure` value.
/// </summary>
[JsonConverter(typeof(MediaEncryptionConverter))]
public enum MediaEncryption
{
    Disabled, Srtp, Dtls
}

sealed class MediaEncryptionConverter : JsonConverter<MediaEncryption>
{
    public override MediaEncryption Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>MediaEncryption.Disabled,
            "SRTP"=>MediaEncryption.Srtp,
            "DTLS"=>MediaEncryption.Dtls,
            _ =>(MediaEncryption)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MediaEncryption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MediaEncryption.Disabled=>"disabled",
            MediaEncryption.Srtp=>"SRTP",
            MediaEncryption.Dtls=>"DTLS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Indicates the privacy level to be used for the call. When set to `id`, caller
/// ID information (name and number) will be hidden from the called party. When set
/// to `none` or omitted, caller ID will be shown normally.
/// </summary>
[JsonConverter(typeof(PrivacyConverter))]
public enum Privacy
{
    ID, None
}

sealed class PrivacyConverter : JsonConverter<Privacy>
{
    public override Privacy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "id"=>Privacy.ID, "none"=>Privacy.None, _ =>(Privacy)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Privacy value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Privacy.ID=>"id",
            Privacy.None=>"none",
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
/// Defines the SIP region to be used for the call.
/// </summary>
[JsonConverter(typeof(SipRegionConverter))]
public enum SipRegion
{
    Us, Europe, Canada, Australia, MiddleEast
}

sealed class SipRegionConverter : JsonConverter<SipRegion>
{
    public override SipRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "US"=>SipRegion.Us,
            "Europe"=>SipRegion.Europe,
            "Canada"=>SipRegion.Canada,
            "Australia"=>SipRegion.Australia,
            "Middle East"=>SipRegion.MiddleEast,
            _ =>(SipRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SipRegion value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SipRegion.Us=>"US",
            SipRegion.Europe=>"Europe",
            SipRegion.Canada=>"Canada",
            SipRegion.Australia=>"Australia",
            SipRegion.MiddleEast=>"Middle East",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines SIP transport protocol to be used on the call.
/// </summary>
[JsonConverter(typeof(SipTransportProtocolConverter))]
public enum SipTransportProtocol
{
    Udp, Tcp, Tls
}

sealed class SipTransportProtocolConverter : JsonConverter<SipTransportProtocol>
{
    public override SipTransportProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UDP"=>SipTransportProtocol.Udp,
            "TCP"=>SipTransportProtocol.Tcp,
            "TLS"=>SipTransportProtocol.Tls,
            _ =>(SipTransportProtocol)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SipTransportProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SipTransportProtocol.Udp=>"UDP",
            SipTransportProtocol.Tcp=>"TCP",
            SipTransportProtocol.Tls=>"TLS",
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

/// <summary>
/// The role of the supervisor call. 'barge' means that supervisor call hears and
/// is being heard by both ends of the call (caller &amp; callee). 'whisper' means
/// that only supervised_call_control_id hears supervisor but supervisor can hear
/// everything. 'monitor' means that nobody can hear supervisor call, but supervisor
/// can hear everything on the call.
/// </summary>
[JsonConverter(typeof(CallDialParamsSupervisorRoleConverter))]
public enum CallDialParamsSupervisorRole
{
    Barge, Whisper, Monitor
}

sealed class CallDialParamsSupervisorRoleConverter : JsonConverter<CallDialParamsSupervisorRole>
{
    public override CallDialParamsSupervisorRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "barge"=>CallDialParamsSupervisorRole.Barge,
            "whisper"=>CallDialParamsSupervisorRole.Whisper,
            "monitor"=>CallDialParamsSupervisorRole.Monitor,
            _ =>(CallDialParamsSupervisorRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallDialParamsSupervisorRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallDialParamsSupervisorRole.Barge=>"barge",
            CallDialParamsSupervisorRole.Whisper=>"whisper",
            CallDialParamsSupervisorRole.Monitor=>"monitor",
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
    public Generic::IReadOnlyList<long>? RetriesMs {
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
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRetriesPoliciesItem (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookRetriesPoliciesItemFromRaw.FromRawUnchecked"/>
    public static WebhookRetriesPoliciesItem FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookRetriesPoliciesItemFromRaw : IFromRawJson<WebhookRetriesPoliciesItem>
{
    /// <inheritdoc/>
    public WebhookRetriesPoliciesItem FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
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