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
/// Transfer a call to a new destination. If the transfer is unsuccessful, a `call.hangup`
/// webhook for the other call (Leg B) will be sent indicating that the transfer
/// could not be completed. The original call will remain active and may be issued
/// additional commands, potentially transfering the call to an alternate destination.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.initiated` - `call.bridged` to Leg B - `call.answered` or `call.hangup`
/// - `call.machine.detection.ended` if `answering_machine_detection` was requested
/// - `call.machine.greeting.ended` if `answering_machine_detection` was requested
/// to detect the end of machine greeting - `call.machine.premium.detection.ended`
/// if `answering_machine_detection=premium` was requested - `call.machine.premium.greeting.ended`
/// if `answering_machine_detection=premium` was requested and a beep was detected</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionTransferParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// The DID or SIP URI to dial out to. For SIP URI destinations, append `;secure=true`
    /// or `;secure=srtp` to enable SRTP media encryption for that endpoint, or `;secure=dtls`
    /// to enable DTLS media encryption for that endpoint. If `media_encryption` is
    /// set to `SRTP` or `DTLS`, it takes precedence over any per-endpoint `secure`
    /// URI parameter. You may also append a comma followed by DTMF digits (e.g. `+18004247767,200`)
    /// to play those digits as DTMF once the transfer destination answers — equivalent
    /// to setting `send_digits_on_answer` separately. If both are present, the explicit
    /// `send_digits_on_answer` parameter takes precedence.
    /// </summary>
    public required string To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawBodyData.Set("to", value); }
    }

    /// <summary>
    /// Enables Answering Machine Detection. When a call is answered, Telnyx runs
    /// real-time detection to determine if it was picked up by a human or a machine
    /// and sends an `call.machine.detection.ended` webhook with the analysis result.
    /// If 'greeting_end' or 'detect_words' is used and a 'machine' is detected,
    /// you will receive another 'call.machine.greeting.ended' webhook when the answering
    /// machine greeting ends with a beep or silence. If `detect_beep` is used, you
    /// will only receive 'call.machine.greeting.ended' if a beep is detected.
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
    /// The URL of a file to be played back when the transfer destination answers
    /// before bridging the call. The URL can point to either a WAV or MP3 file. media_name
    /// and audio_url cannot be used together in one request.
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
    /// Custom headers to be added to the SIP INVITE.
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
    /// If set to false, early media will not be passed to the originating leg.
    /// </summary>
    public bool? EarlyMedia {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "early_media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("early_media", value);
        }
    }

    /// <summary>
    /// The `from` number to be used as the caller id presented to the destination
    /// (`to` number). The number should be in +E164 format. This attribute will
    /// default to the `to` number of the original call if omitted.
    /// </summary>
    public string? From {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("from", value);
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
    /// Defines whether media should be encrypted on the new call leg. For SIP URI
    /// destinations, media encryption can also be requested per endpoint with the
    /// `secure` URI parameter: `;secure=true` or `;secure=srtp` enables SRTP, and
    /// `;secure=dtls` enables DTLS. This parameter, when set to `SRTP` or `DTLS`,
    /// takes precedence over the per-endpoint `secure` value.
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
    /// The media_name of a file to be played back when the transfer destination answers
    /// before bridging the call. The media_name must point to a file previously
    /// uploaded to api.telnyx.com/v2/media by the same user/organization. The file
    /// must either be a WAV or MP3 file.
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
    /// When enabled, DTMF tones are not passed to the call participant. The webhooks
    /// containing the DTMF information will be sent.
    /// </summary>
    public ApiEnum<string, ActionTransferParamsMuteDtmf>? MuteDtmf {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionTransferParamsMuteDtmf>>(
                "mute_dtmf"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("mute_dtmf", value);
        }
    }

    /// <summary>
    /// Specifies behavior after the bridge ends (i.e. the opposite leg either hangs
    /// up or is transferred). If supplied with the value `self`, the current leg
    /// will be parked after unbridge. If not set, the default behavior is to hang
    /// up the leg.
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
    /// The list of comma-separated codecs in order of preference to be used during
    /// the call. The codecs supported are `G722`, `PCMU`, `PCMA`, `G729`, `OPUS`,
    /// `VP8`, `H264`, `AMR-WB`.
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
    public ApiEnum<string, ActionTransferParamsRecord>? Record {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionTransferParamsRecord>>(
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
    public ApiEnum<string, ActionTransferParamsRecordChannels>? RecordChannels {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionTransferParamsRecordChannels>>(
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
    public ApiEnum<string, ActionTransferParamsRecordFormat>? RecordFormat {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionTransferParamsRecordFormat>>(
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
    public ApiEnum<string, ActionTransferParamsRecordTrack>? RecordTrack {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionTransferParamsRecordTrack>>(
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
    public ApiEnum<string, ActionTransferParamsRecordTrim>? RecordTrim {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionTransferParamsRecordTrim>>(
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
    /// DTMF digits to send automatically after the transfer destination answers.
    /// Useful for reaching an extension behind an IVR (e.g. `"200"` to dial extension
    /// 200 once the called party picks up). Allowed characters: `0-9`, `A-D`, `w`
    /// (0.5s pause), `W` (1s pause), `*`, `#`. Maximum 64 characters. When omitted,
    /// no automatic DTMF is sent. May also be supplied inline by appending `,&lt;digits&gt;`
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
    /// SIP headers to be added to the SIP INVITE. Currently only User-to-User header
    /// is supported.
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
    /// Use this field to add state to every subsequent webhook for the new leg.
    /// It must be a valid Base-64 encoded string.
    /// </summary>
    public string? TargetLegClientState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "target_leg_client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("target_leg_client_state", value);
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
    /// the destination to which it is being transferred. If the timeout is reached
    /// before an answer is received, the call will hangup and a `call.hangup` webhook
    /// with a `hangup_cause` of `timeout` will be sent. Minimum value is 5 seconds.
    /// Maximum value is 600 seconds.
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
    /// A map of event types to retry policies. Each retry policy contains an array
    /// of `retries_ms` specifying the delays between retry attempts in milliseconds.
    /// Maximum 5 retries, total delay cannot exceed 60 seconds.
    /// </summary>
    public IReadOnlyDictionary<string, ActionTransferParamsWebhookRetriesPoliciesItem>? WebhookRetriesPolicies {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, ActionTransferParamsWebhookRetriesPoliciesItem>>(
                "webhook_retries_policies"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, ActionTransferParamsWebhookRetriesPoliciesItem>?>(
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
    public ApiEnum<string, ActionTransferParamsWebhookUrlMethod>? WebhookUrlMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionTransferParamsWebhookUrlMethod>>(
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
    public ApiEnum<string, ActionTransferParamsWebhookUrlsMethod>? WebhookUrlsMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionTransferParamsWebhookUrlsMethod>>(
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

    public ActionTransferParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionTransferParams (
        ActionTransferParams actionTransferParams
    ) : base(actionTransferParams)
    {
        this.CallControlID = actionTransferParams.CallControlID;

        this._rawBodyData = new(actionTransferParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionTransferParams (
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
    ActionTransferParams (
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
    public static ActionTransferParams FromRawUnchecked(
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

    public virtual bool Equals(ActionTransferParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/transfer",
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
/// Enables Answering Machine Detection. When a call is answered, Telnyx runs real-time
/// detection to determine if it was picked up by a human or a machine and sends
/// an `call.machine.detection.ended` webhook with the analysis result. If 'greeting_end'
/// or 'detect_words' is used and a 'machine' is detected, you will receive another
/// 'call.machine.greeting.ended' webhook when the answering machine greeting ends
/// with a beep or silence. If `detect_beep` is used, you will only receive 'call.machine.greeting.ended'
/// if a beep is detected.
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
        IReadOnlyDictionary<string, JsonElement> rawData
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
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AnsweringMachineDetectionConfigFromRaw : IFromRawJson<AnsweringMachineDetectionConfig>
{
    /// <inheritdoc/>
    public AnsweringMachineDetectionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
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
/// Defines whether media should be encrypted on the new call leg. For SIP URI destinations,
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
/// When enabled, DTMF tones are not passed to the call participant. The webhooks
/// containing the DTMF information will be sent.
/// </summary>
[JsonConverter(typeof(ActionTransferParamsMuteDtmfConverter))]
public enum ActionTransferParamsMuteDtmf
{
    None, Both, Self, Opposite
}

sealed class ActionTransferParamsMuteDtmfConverter : JsonConverter<ActionTransferParamsMuteDtmf>
{
    public override ActionTransferParamsMuteDtmf Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none"=>ActionTransferParamsMuteDtmf.None,
            "both"=>ActionTransferParamsMuteDtmf.Both,
            "self"=>ActionTransferParamsMuteDtmf.Self,
            "opposite"=>ActionTransferParamsMuteDtmf.Opposite,
            _ =>(ActionTransferParamsMuteDtmf)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionTransferParamsMuteDtmf value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionTransferParamsMuteDtmf.None=>"none",
            ActionTransferParamsMuteDtmf.Both=>"both",
            ActionTransferParamsMuteDtmf.Self=>"self",
            ActionTransferParamsMuteDtmf.Opposite=>"opposite",
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
[JsonConverter(typeof(ActionTransferParamsRecordConverter))]
public enum ActionTransferParamsRecord
{
    RecordFromAnswer
}

sealed class ActionTransferParamsRecordConverter : JsonConverter<ActionTransferParamsRecord>
{
    public override ActionTransferParamsRecord Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "record-from-answer"=>ActionTransferParamsRecord.RecordFromAnswer,
            _ =>(ActionTransferParamsRecord)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionTransferParamsRecord value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionTransferParamsRecord.RecordFromAnswer=>"record-from-answer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines which channel should be recorded ('single' or 'dual') when `record` is specified.
/// </summary>
[JsonConverter(typeof(ActionTransferParamsRecordChannelsConverter))]
public enum ActionTransferParamsRecordChannels
{
    Single, Dual
}

sealed class ActionTransferParamsRecordChannelsConverter : JsonConverter<ActionTransferParamsRecordChannels>
{
    public override ActionTransferParamsRecordChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>ActionTransferParamsRecordChannels.Single,
            "dual"=>ActionTransferParamsRecordChannels.Dual,
            _ =>(ActionTransferParamsRecordChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionTransferParamsRecordChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionTransferParamsRecordChannels.Single=>"single",
            ActionTransferParamsRecordChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines the format of the recording ('wav' or 'mp3') when `record` is specified.
/// </summary>
[JsonConverter(typeof(ActionTransferParamsRecordFormatConverter))]
public enum ActionTransferParamsRecordFormat
{
    Wav, Mp3
}

sealed class ActionTransferParamsRecordFormatConverter : JsonConverter<ActionTransferParamsRecordFormat>
{
    public override ActionTransferParamsRecordFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wav"=>ActionTransferParamsRecordFormat.Wav,
            "mp3"=>ActionTransferParamsRecordFormat.Mp3,
            _ =>(ActionTransferParamsRecordFormat)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionTransferParamsRecordFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionTransferParamsRecordFormat.Wav=>"wav",
            ActionTransferParamsRecordFormat.Mp3=>"mp3",
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
[JsonConverter(typeof(ActionTransferParamsRecordTrackConverter))]
public enum ActionTransferParamsRecordTrack
{
    Both, Inbound, Outbound
}

sealed class ActionTransferParamsRecordTrackConverter : JsonConverter<ActionTransferParamsRecordTrack>
{
    public override ActionTransferParamsRecordTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>ActionTransferParamsRecordTrack.Both,
            "inbound"=>ActionTransferParamsRecordTrack.Inbound,
            "outbound"=>ActionTransferParamsRecordTrack.Outbound,
            _ =>(ActionTransferParamsRecordTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionTransferParamsRecordTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionTransferParamsRecordTrack.Both=>"both",
            ActionTransferParamsRecordTrack.Inbound=>"inbound",
            ActionTransferParamsRecordTrack.Outbound=>"outbound",
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
[JsonConverter(typeof(ActionTransferParamsRecordTrimConverter))]
public enum ActionTransferParamsRecordTrim
{
    TrimSilence
}

sealed class ActionTransferParamsRecordTrimConverter : JsonConverter<ActionTransferParamsRecordTrim>
{
    public override ActionTransferParamsRecordTrim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trim-silence"=>ActionTransferParamsRecordTrim.TrimSilence,
            _ =>(ActionTransferParamsRecordTrim)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionTransferParamsRecordTrim value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionTransferParamsRecordTrim.TrimSilence=>"trim-silence",
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

[JsonConverter(typeof(JsonModelConverter<ActionTransferParamsWebhookRetriesPoliciesItem, ActionTransferParamsWebhookRetriesPoliciesItemFromRaw>))]
public sealed record class ActionTransferParamsWebhookRetriesPoliciesItem : JsonModel
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

    public ActionTransferParamsWebhookRetriesPoliciesItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionTransferParamsWebhookRetriesPoliciesItem (
        ActionTransferParamsWebhookRetriesPoliciesItem actionTransferParamsWebhookRetriesPoliciesItem
    ) : base(actionTransferParamsWebhookRetriesPoliciesItem)
    {  }
    #pragma warning restore CS8618

    public ActionTransferParamsWebhookRetriesPoliciesItem (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionTransferParamsWebhookRetriesPoliciesItem (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionTransferParamsWebhookRetriesPoliciesItemFromRaw.FromRawUnchecked"/>
    public static ActionTransferParamsWebhookRetriesPoliciesItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionTransferParamsWebhookRetriesPoliciesItemFromRaw : IFromRawJson<ActionTransferParamsWebhookRetriesPoliciesItem>
{
    /// <inheritdoc/>
    public ActionTransferParamsWebhookRetriesPoliciesItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionTransferParamsWebhookRetriesPoliciesItem.FromRawUnchecked(rawData);
}

/// <summary>
/// HTTP request type used for `webhook_url`.
/// </summary>
[JsonConverter(typeof(ActionTransferParamsWebhookUrlMethodConverter))]
public enum ActionTransferParamsWebhookUrlMethod
{
    Post, Get
}

sealed class ActionTransferParamsWebhookUrlMethodConverter : JsonConverter<ActionTransferParamsWebhookUrlMethod>
{
    public override ActionTransferParamsWebhookUrlMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "POST"=>ActionTransferParamsWebhookUrlMethod.Post,
            "GET"=>ActionTransferParamsWebhookUrlMethod.Get,
            _ =>(ActionTransferParamsWebhookUrlMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionTransferParamsWebhookUrlMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionTransferParamsWebhookUrlMethod.Post=>"POST",
            ActionTransferParamsWebhookUrlMethod.Get=>"GET",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request method to invoke `webhook_urls`.
/// </summary>
[JsonConverter(typeof(ActionTransferParamsWebhookUrlsMethodConverter))]
public enum ActionTransferParamsWebhookUrlsMethod
{
    Post, Get
}

sealed class ActionTransferParamsWebhookUrlsMethodConverter : JsonConverter<ActionTransferParamsWebhookUrlsMethod>
{
    public override ActionTransferParamsWebhookUrlsMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "POST"=>ActionTransferParamsWebhookUrlsMethod.Post,
            "GET"=>ActionTransferParamsWebhookUrlsMethod.Get,
            _ =>(ActionTransferParamsWebhookUrlsMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionTransferParamsWebhookUrlsMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionTransferParamsWebhookUrlsMethod.Post=>"POST",
            ActionTransferParamsWebhookUrlsMethod.Get=>"GET",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}