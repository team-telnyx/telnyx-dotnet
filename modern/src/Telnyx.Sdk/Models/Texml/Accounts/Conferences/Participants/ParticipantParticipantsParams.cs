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

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences.Participants;

/// <summary>
/// Dials a new participant into the specified conference and returns the created
/// participant resource.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ParticipantParticipantsParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string AccountSid { get; init; }

    public string? ConferenceSid { get; init; }

    /// <summary>
    /// The URL the result of answering machine detection will be sent to.
    /// </summary>
    public string? AmdStatusCallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "AmdStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("AmdStatusCallback", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `AmdStatusCallback`. Defaults to `POST`.
    /// </summary>
    public ApiEnum<string, AmdStatusCallbackMethod>? AmdStatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AmdStatusCallbackMethod>>(
                "AmdStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("AmdStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The SID of the TeXML application that will handle the new participant's call.
    /// Required unless joining an existing conference by its ConferenceSid.
    /// </summary>
    public string? ApplicationSid {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ApplicationSid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ApplicationSid", value);
        }
    }

    /// <summary>
    /// Whether to play a notification beep to the conference when the participant
    /// enters and exits.
    /// </summary>
    public ApiEnum<string, Beep>? Beep {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Beep>>(
                "Beep"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Beep", value);
        }
    }

    /// <summary>
    /// To be used as the caller id name (SIP From Display Name) presented to the
    /// destination (`To` number). The string should have a maximum of 128 characters,
    /// containing only letters, numbers, spaces, and `-_~!.+` special characters.
    /// If ommited, the display name will be the same as the number in the `From` field.
    /// </summary>
    public string? CallerID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "CallerId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("CallerId", value);
        }
    }

    /// <summary>
    /// The SID of the participant who is being coached. The participant being coached
    /// is the only participant who can hear the participant who is coaching.
    /// </summary>
    public string? CallSidToCoach {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "CallSidToCoach"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("CallSidToCoach", value);
        }
    }

    /// <summary>
    /// Whether to cancel ongoing playback on `greeting ended` detection. Defaults
    /// to `true`.
    /// </summary>
    public bool? CancelPlaybackOnDetectMessageEnd {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "CancelPlaybackOnDetectMessageEnd"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("CancelPlaybackOnDetectMessageEnd", value);
        }
    }

    /// <summary>
    /// Whether to cancel ongoing playback on `machine` detection. Defaults to `true`.
    /// </summary>
    public bool? CancelPlaybackOnMachineDetection {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "CancelPlaybackOnMachineDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("CancelPlaybackOnMachineDetection", value);
        }
    }

    /// <summary>
    /// Whether the participant is coaching another call. When `true`, `CallSidToCoach`
    /// has to be given.
    /// </summary>
    public bool? Coaching {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "Coaching"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Coaching", value);
        }
    }

    /// <summary>
    /// Whether to record the conference the participant is joining. Defualts to `do-not-record`.
    /// The boolean values `true` and `false` are synonymous with `record-from-start`
    /// and `do-not-record` respectively.
    /// </summary>
    public ApiEnum<string, ConferenceRecord>? ConferenceRecord {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConferenceRecord>>(
                "ConferenceRecord"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConferenceRecord", value);
        }
    }

    /// <summary>
    /// The URL the conference recording callbacks will be sent to.
    /// </summary>
    public string? ConferenceRecordingStatusCallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ConferenceRecordingStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConferenceRecordingStatusCallback", value);
        }
    }

    /// <summary>
    /// The changes to the conference recording's state that should generate a call
    /// to `RecoridngStatusCallback`. Can be: `in-progress`, `completed` and `absent`.
    /// Separate multiple values with a space. Defaults to `completed`. `failed`
    /// and `absent` are synonymous.
    /// </summary>
    public string? ConferenceRecordingStatusCallbackEvent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ConferenceRecordingStatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConferenceRecordingStatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `ConferenceRecordingStatusCallback`. Defaults to `POST`.
    /// </summary>
    public ApiEnum<string, ConferenceRecordingStatusCallbackMethod>? ConferenceRecordingStatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConferenceRecordingStatusCallbackMethod>>(
                "ConferenceRecordingStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConferenceRecordingStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The number of seconds that Telnyx will wait for the recording to be stopped
    /// if silence is detected. The timer only starts when the speech is detected.
    /// Please note that the transcription is used to detect silence and the related
    /// charge will be applied. The minimum value is 0. The default value is 0 (infinite)
    /// </summary>
    public long? ConferenceRecordingTimeout {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "ConferenceRecordingTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConferenceRecordingTimeout", value);
        }
    }

    /// <summary>
    /// The URL the conference callbacks will be sent to.
    /// </summary>
    public string? ConferenceStatusCallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ConferenceStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConferenceStatusCallback", value);
        }
    }

    /// <summary>
    /// The changes to the conference's state that should generate a call to `ConferenceStatusCallback`.
    /// Can be: `start`, `end`, `join` and `leave`. Separate multiple values with
    /// a space. By default no callbacks are sent.
    /// </summary>
    public string? ConferenceStatusCallbackEvent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ConferenceStatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConferenceStatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `ConferenceStatusCallback`. Defaults to `POST`.
    /// </summary>
    public ApiEnum<string, ConferenceStatusCallbackMethod>? ConferenceStatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConferenceStatusCallbackMethod>>(
                "ConferenceStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConferenceStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// Whether to trim any leading and trailing silence from the conference recording.
    /// Defaults to `trim-silence`.
    /// </summary>
    public ApiEnum<string, ConferenceTrim>? ConferenceTrim {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConferenceTrim>>(
                "ConferenceTrim"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConferenceTrim", value);
        }
    }

    /// <summary>
    /// Custom HTTP headers to be sent with the call. Each header should be an object
    /// with 'name' and 'value' properties.
    /// </summary>
    public IReadOnlyList<CustomHeader>? CustomHeaders {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<CustomHeader>>(
                "CustomHeaders"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<CustomHeader>?>(
                "CustomHeaders",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether participant shall be bridged to conference before the participant
    /// answers (from early media if available). Defaults to `false`.
    /// </summary>
    public bool? EarlyMedia {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "EarlyMedia"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("EarlyMedia", value);
        }
    }

    /// <summary>
    /// Whether to end the conference when the participant leaves. Defaults to `false`.
    /// </summary>
    public bool? EndConferenceOnExit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "EndConferenceOnExit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("EndConferenceOnExit", value);
        }
    }

    /// <summary>
    /// The phone number of the party that initiated the call. Phone numbers are formatted
    /// with a `+` and country code.
    /// </summary>
    public string? From {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "From"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("From", value);
        }
    }

    /// <summary>
    /// A unique label for the participant that will be added to the conference. The
    /// label can be used to reference the participant for updates via the TeXML REST API.
    /// </summary>
    public string? Label {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "Label"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Label", value);
        }
    }

    /// <summary>
    /// Whether to detect if a human or an answering machine picked up the call.
    /// Use `Enable` if you would like to ne notified as soon as the called party
    /// is identified. Use `DetectMessageEnd`, if you would like to leave a message
    /// on an answering machine.
    /// </summary>
    public ApiEnum<string, MachineDetection>? MachineDetection {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MachineDetection>>(
                "MachineDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetection", value);
        }
    }

    /// <summary>
    /// Highest frequency, in Hz, that a tone can reach and still be treated as a
    /// beep. Only used when MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepMaxFrequency {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "MachineDetectionBeepMaxFrequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionBeepMaxFrequency", value);
        }
    }

    /// <summary>
    /// Lowest frequency, in Hz, that a tone must reach to be treated as a beep. Raising
    /// it above 480 excludes North American ringback (440 + 480 Hz), which can otherwise
    /// be reported as a beep when the `freq_only` profile is in use. Only used when
    /// MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepMinFrequency {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "MachineDetectionBeepMinFrequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionBeepMinFrequency", value);
        }
    }

    /// <summary>
    /// Shortest tone, in milliseconds, that can be treated as a beep. Raising it
    /// rejects brief tones such as call-progress blips. Only used when MachineDetection
    /// is enabled.
    /// </summary>
    public int? MachineDetectionBeepMinToneDuration {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "MachineDetectionBeepMinToneDuration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionBeepMinToneDuration", value);
        }
    }

    /// <summary>
    /// Selects which detectors must validate a beep. `both` requires the amplitude
    /// and frequency detectors to agree. `freq_only` uses the frequency detector
    /// alone, for beeps whose volume is too unsteady for the default profile. Only
    /// used when MachineDetection is enabled.
    /// </summary>
    public ApiEnum<string, MachineDetectionBeepProfile>? MachineDetectionBeepProfile {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MachineDetectionBeepProfile>>(
                "MachineDetectionBeepProfile"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionBeepProfile", value);
        }
    }

    /// <summary>
    /// When enabled, a candidate beep must pass an additional spectral check before
    /// it is reported. Only used when MachineDetection is enabled.
    /// </summary>
    public bool? MachineDetectionBeepSpectralConfirmation {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "MachineDetectionBeepSpectralConfirmation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionBeepSpectralConfirmation", value);
        }
    }

    /// <summary>
    /// Minimum spectral purity, from 0 to 1, for a tone to be treated as a beep.
    /// Raising it rejects mixed tones such as ringback, which combines two frequencies.
    /// Only used when MachineDetection is enabled.
    /// </summary>
    public double? MachineDetectionBeepSpectralMinPurity {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "MachineDetectionBeepSpectralMinPurity"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionBeepSpectralMinPurity", value);
        }
    }

    /// <summary>
    /// When enabled, the fax CNG tone is rejected rather than reported as a beep.
    /// Only used when MachineDetection is enabled.
    /// </summary>
    public bool? MachineDetectionBeepSpectralRejectFaxCng {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "MachineDetectionBeepSpectralRejectFaxCng"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionBeepSpectralRejectFaxCng", value);
        }
    }

    /// <summary>
    /// Length of the spectral confirmation window, in milliseconds. Only used when
    /// MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepSpectralWindow {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "MachineDetectionBeepSpectralWindow"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionBeepSpectralWindow", value);
        }
    }

    /// <summary>
    /// If initial silence duration is greater than this value, consider it a machine.
    /// Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSilenceTimeout {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "MachineDetectionSilenceTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionSilenceTimeout", value);
        }
    }

    /// <summary>
    /// Silence duration threshold after a greeting message or voice for it be considered
    /// human. Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSpeechEndThreshold {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "MachineDetectionSpeechEndThreshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionSpeechEndThreshold", value);
        }
    }

    /// <summary>
    /// Maximum threshold of a human greeting. If greeting longer than this value,
    /// considered machine. Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSpeechThreshold {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "MachineDetectionSpeechThreshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionSpeechThreshold", value);
        }
    }

    /// <summary>
    /// How long answering machine detection should go on for before sending an `Unknown`
    /// result. Given in milliseconds.
    /// </summary>
    public long? MachineDetectionTimeout {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "MachineDetectionTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionTimeout", value);
        }
    }

    /// <summary>
    /// The maximum number of participants in the conference. Can be a positive integer
    /// from 2 to 800. The default value is 250.
    /// </summary>
    public long? MaxParticipants {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "MaxParticipants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MaxParticipants", value);
        }
    }

    /// <summary>
    /// Whether the participant should be muted.
    /// </summary>
    public bool? Muted {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "Muted"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Muted", value);
        }
    }

    /// <summary>
    /// The list of comma-separated codecs to be offered on a call.
    /// </summary>
    public string? PreferredCodecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "PreferredCodecs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("PreferredCodecs", value);
        }
    }

    /// <summary>
    /// Whether to record the entire participant's call leg. Defaults to `false`.
    /// </summary>
    public bool? Record {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "Record"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Record", value);
        }
    }

    /// <summary>
    /// The number of channels in the final recording. Defaults to `mono`.
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
    /// The URL the recording callbacks will be sent to.
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
    /// HTTP request type used for `RecordingStatusCallback`. Defaults to `POST`.
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
    /// The password to use for SIP authentication.
    /// </summary>
    public string? SipAuthPassword {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "SipAuthPassword"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("SipAuthPassword", value);
        }
    }

    /// <summary>
    /// The username to use for SIP authentication.
    /// </summary>
    public string? SipAuthUsername {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "SipAuthUsername"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("SipAuthUsername", value);
        }
    }

    /// <summary>
    /// Whether to start the conference when the participant enters. Defaults to `true`.
    /// </summary>
    public bool? StartConferenceOnEnter {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "StartConferenceOnEnter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("StartConferenceOnEnter", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send status callback events to for the call.
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
    /// The changes to the call's state that should generate a call to `StatusCallback`.
    /// Can be: `initiated`, `ringing`, `answered`, and `completed`. Separate multiple
    /// values with a space. The default value is `completed`.
    /// </summary>
    public string? StatusCallbackEvent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "StatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("StatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `StatusCallback`.
    /// </summary>
    public ApiEnum<string, StatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StatusCallbackMethod>>(
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
    /// The maximum duration of the call in seconds.
    /// </summary>
    public long? TimeLimit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "TimeLimit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("TimeLimit", value);
        }
    }

    /// <summary>
    /// The number of seconds that we should allow the phone to ring before assuming
    /// there is no answer. Can be an integer between 5 and 120, inclusive. The default
    /// value is 30.
    /// </summary>
    public long? TimeoutSeconds {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "Timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Timeout", value);
        }
    }

    /// <summary>
    /// The phone number of the called party. Phone numbers are formatted with a `+`
    /// and country code.
    /// </summary>
    public string? To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "To"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("To", value);
        }
    }

    /// <summary>
    /// Whether to trim any leading and trailing silence from the recording. Defaults
    /// to `trim-silence`.
    /// </summary>
    public ApiEnum<string, Trim>? Trim {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Trim>>(
                "Trim"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Trim", value);
        }
    }

    /// <summary>
    /// The URL to call for an audio file to play while the participant is waiting
    /// for the conference to start.
    /// </summary>
    public string? WaitUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "WaitUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("WaitUrl", value);
        }
    }

    public ParticipantParticipantsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParticipantParticipantsParams (
        ParticipantParticipantsParams participantParticipantsParams
    ) : base(participantParticipantsParams)
    {
        this.AccountSid = participantParticipantsParams.AccountSid;
        this.ConferenceSid = participantParticipantsParams.ConferenceSid;

        this._rawBodyData = new(participantParticipantsParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ParticipantParticipantsParams (
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
    ParticipantParticipantsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string conferenceSid
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AccountSid = accountSid;
        this.ConferenceSid = conferenceSid;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ParticipantParticipantsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string accountSid,
        string conferenceSid
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            accountSid,
            conferenceSid
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["ConferenceSid"] = JsonSerializer.SerializeToElement(this.ConferenceSid),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ParticipantParticipantsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.AccountSid.Equals(other.AccountSid)&&(this.ConferenceSid?.Equals(other.ConferenceSid) ?? other.ConferenceSid == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Conferences/{1}/Participants",
            this.AccountSid,
            this.ConferenceSid)
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
/// HTTP request type used for `AmdStatusCallback`. Defaults to `POST`.
/// </summary>
[JsonConverter(typeof(AmdStatusCallbackMethodConverter))]
public enum AmdStatusCallbackMethod
{
    Get, Post
}

sealed class AmdStatusCallbackMethodConverter : JsonConverter<AmdStatusCallbackMethod>
{
    public override AmdStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>AmdStatusCallbackMethod.Get,
            "POST"=>AmdStatusCallbackMethod.Post,
            _ =>(AmdStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmdStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AmdStatusCallbackMethod.Get=>"GET",
            AmdStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Whether to play a notification beep to the conference when the participant enters
/// and exits.
/// </summary>
[JsonConverter(typeof(BeepConverter))]
public enum Beep
{
    True, False, OnEnter, OnExit
}

sealed class BeepConverter : JsonConverter<Beep>
{
    public override Beep Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true"=>Beep.True,
            "false"=>Beep.False,
            "onEnter"=>Beep.OnEnter,
            "onExit"=>Beep.OnExit,
            _ =>(Beep)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Beep value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Beep.True=>"true",
            Beep.False=>"false",
            Beep.OnEnter=>"onEnter",
            Beep.OnExit=>"onExit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Whether to record the conference the participant is joining. Defualts to `do-not-record`.
/// The boolean values `true` and `false` are synonymous with `record-from-start`
/// and `do-not-record` respectively.
/// </summary>
[JsonConverter(typeof(ConferenceRecordConverter))]
public enum ConferenceRecord
{
    True, False, RecordFromStart, DoNotRecord
}

sealed class ConferenceRecordConverter : JsonConverter<ConferenceRecord>
{
    public override ConferenceRecord Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true"=>ConferenceRecord.True,
            "false"=>ConferenceRecord.False,
            "record-from-start"=>ConferenceRecord.RecordFromStart,
            "do-not-record"=>ConferenceRecord.DoNotRecord,
            _ =>(ConferenceRecord)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceRecord value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceRecord.True=>"true",
            ConferenceRecord.False=>"false",
            ConferenceRecord.RecordFromStart=>"record-from-start",
            ConferenceRecord.DoNotRecord=>"do-not-record",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `ConferenceRecordingStatusCallback`. Defaults to `POST`.
/// </summary>
[JsonConverter(typeof(ConferenceRecordingStatusCallbackMethodConverter))]
public enum ConferenceRecordingStatusCallbackMethod
{
    Get, Post
}

sealed class ConferenceRecordingStatusCallbackMethodConverter : JsonConverter<ConferenceRecordingStatusCallbackMethod>
{
    public override ConferenceRecordingStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>ConferenceRecordingStatusCallbackMethod.Get,
            "POST"=>ConferenceRecordingStatusCallbackMethod.Post,
            _ =>(ConferenceRecordingStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceRecordingStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceRecordingStatusCallbackMethod.Get=>"GET",
            ConferenceRecordingStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `ConferenceStatusCallback`. Defaults to `POST`.
/// </summary>
[JsonConverter(typeof(ConferenceStatusCallbackMethodConverter))]
public enum ConferenceStatusCallbackMethod
{
    Get, Post
}

sealed class ConferenceStatusCallbackMethodConverter : JsonConverter<ConferenceStatusCallbackMethod>
{
    public override ConferenceStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>ConferenceStatusCallbackMethod.Get,
            "POST"=>ConferenceStatusCallbackMethod.Post,
            _ =>(ConferenceStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceStatusCallbackMethod.Get=>"GET",
            ConferenceStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Whether to trim any leading and trailing silence from the conference recording.
/// Defaults to `trim-silence`.
/// </summary>
[JsonConverter(typeof(ConferenceTrimConverter))]
public enum ConferenceTrim
{
    TrimSilence, DoNotTrim
}

sealed class ConferenceTrimConverter : JsonConverter<ConferenceTrim>
{
    public override ConferenceTrim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trim-silence"=>ConferenceTrim.TrimSilence,
            "do-not-trim"=>ConferenceTrim.DoNotTrim,
            _ =>(ConferenceTrim)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceTrim value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceTrim.TrimSilence=>"trim-silence",
            ConferenceTrim.DoNotTrim=>"do-not-trim",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<CustomHeader, CustomHeaderFromRaw>))]
public sealed record class CustomHeader : JsonModel
{
    /// <summary>
    /// The name of the custom header
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The value of the custom header
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public CustomHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomHeader (CustomHeader customHeader) : base(customHeader)
    {  }
    #pragma warning restore CS8618

    public CustomHeader (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomHeaderFromRaw.FromRawUnchecked"/>
    public static CustomHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomHeaderFromRaw : IFromRawJson<CustomHeader>
{
    /// <inheritdoc/>
    public CustomHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomHeader.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether to detect if a human or an answering machine picked up the call. Use `Enable`
/// if you would like to ne notified as soon as the called party is identified. Use
/// `DetectMessageEnd`, if you would like to leave a message on an answering machine.
/// </summary>
[JsonConverter(typeof(MachineDetectionConverter))]
public enum MachineDetection
{
    Enable, DetectMessageEnd
}

sealed class MachineDetectionConverter : JsonConverter<MachineDetection>
{
    public override MachineDetection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Enable"=>MachineDetection.Enable,
            "DetectMessageEnd"=>MachineDetection.DetectMessageEnd,
            _ =>(MachineDetection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MachineDetection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MachineDetection.Enable=>"Enable",
            MachineDetection.DetectMessageEnd=>"DetectMessageEnd",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Selects which detectors must validate a beep. `both` requires the amplitude and
/// frequency detectors to agree. `freq_only` uses the frequency detector alone,
/// for beeps whose volume is too unsteady for the default profile. Only used when
/// MachineDetection is enabled.
/// </summary>
[JsonConverter(typeof(MachineDetectionBeepProfileConverter))]
public enum MachineDetectionBeepProfile
{
    Both, FreqOnly
}

sealed class MachineDetectionBeepProfileConverter : JsonConverter<MachineDetectionBeepProfile>
{
    public override MachineDetectionBeepProfile Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>MachineDetectionBeepProfile.Both,
            "freq_only"=>MachineDetectionBeepProfile.FreqOnly,
            _ =>(MachineDetectionBeepProfile)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MachineDetectionBeepProfile value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MachineDetectionBeepProfile.Both=>"both",
            MachineDetectionBeepProfile.FreqOnly=>"freq_only",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The number of channels in the final recording. Defaults to `mono`.
/// </summary>
[JsonConverter(typeof(RecordingChannelsConverter))]
public enum RecordingChannels
{
    Mono, Dual
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
            "mono"=>RecordingChannels.Mono,
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
            RecordingChannels.Mono=>"mono",
            RecordingChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `RecordingStatusCallback`. Defaults to `POST`.
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

/// <summary>
/// HTTP request type used for `StatusCallback`.
/// </summary>
[JsonConverter(typeof(StatusCallbackMethodConverter))]
public enum StatusCallbackMethod
{
    Get, Post
}

sealed class StatusCallbackMethodConverter : JsonConverter<StatusCallbackMethod>
{
    public override StatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>StatusCallbackMethod.Get,
            "POST"=>StatusCallbackMethod.Post,
            _ =>(StatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StatusCallbackMethod.Get=>"GET",
            StatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Whether to trim any leading and trailing silence from the recording. Defaults
/// to `trim-silence`.
/// </summary>
[JsonConverter(typeof(TrimConverter))]
public enum Trim
{
    TrimSilence, DoNotTrim
}

sealed class TrimConverter : JsonConverter<Trim>
{
    public override Trim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trim-silence"=>Trim.TrimSilence,
            "do-not-trim"=>Trim.DoNotTrim,
            _ =>(Trim)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Trim value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Trim.TrimSilence=>"trim-silence",
            Trim.DoNotTrim=>"do-not-trim",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}