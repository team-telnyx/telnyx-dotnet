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

namespace Telnyx.Sdk.Models.Texml;

/// <summary>
/// Initiate an outbound AI call with warm-up support. Validates parameters, builds
/// an internal TeXML with an AI Assistant configuration, encodes instructions into
/// client state, and calls the dial API. The Twiml, Texml, and Url parameters are
/// not allowed and will result in a 422 error.
///
/// <para>**Expected callback events:**</para>
///
/// <para>Status callbacks: `initiated`, `ringing`, `answered`, one terminal status
/// (`completed`, `no-answer`, `busy`, `canceled`, or `failed`), then `analyzed`
/// after post-call processing completes.</para>
///
/// <para>Conversation callbacks: `conversation_created` and `conversation_ended`.</para>
///
/// <para>Recording, AMD, transcription, and deepfake detection callbacks are only
/// sent when those features are enabled.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TexmlInitiateAICallParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ConnectionID { get; init; }

    /// <summary>
    /// The ID of the AI assistant to use for the call.
    /// </summary>
    public required string AIAssistantID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "AIAssistantId"
            );
        }
        init { this._rawBodyData.Set("AIAssistantId", value); }
    }

    /// <summary>
    /// The phone number of the party initiating the call. Phone numbers are formatted
    /// with a `+` and country code.
    /// </summary>
    public required string From {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "From"
            );
        }
        init { this._rawBodyData.Set("From", value); }
    }

    /// <summary>
    /// The phone number of the called party. Phone numbers are formatted with a `+`
    /// and country code.
    /// </summary>
    public required string To {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "To"
            );
        }
        init { this._rawBodyData.Set("To", value); }
    }

    /// <summary>
    /// Key-value map of dynamic variables to pass to the AI assistant.
    /// </summary>
    public IReadOnlyDictionary<string, string>? AIAssistantDynamicVariables {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>(
                "AIAssistantDynamicVariables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "AIAssistantDynamicVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The version of the AI assistant to use.
    /// </summary>
    public string? AIAssistantVersion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "AIAssistantVersion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("AIAssistantVersion", value);
        }
    }

    /// <summary>
    /// Select whether to perform answering machine detection in the background.
    /// By default execution is blocked until Answering Machine Detection is completed.
    /// </summary>
    public bool? AsyncAmd {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "AsyncAmd"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("AsyncAmd", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send AMD callback events to for the call.
    /// </summary>
    public string? AsyncAmdStatusCallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "AsyncAmdStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("AsyncAmdStatusCallback", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `AsyncAmdStatusCallback`.
    /// </summary>
    public ApiEnum<string, AsyncAmdStatusCallbackMethod>? AsyncAmdStatusCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AsyncAmdStatusCallbackMethod>>(
                "AsyncAmdStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("AsyncAmdStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// To be used as the caller id name (SIP From Display Name) presented to the
    /// destination (`To` number). The string should have a maximum of 128 characters,
    /// containing only letters, numbers, spaces, and `-_~!.+` special characters.
    /// If omitted, the display name will be the same as the number in the `From` field.
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
    /// URL destination for Telnyx to send AI conversation callback events for this
    /// call. Events include `conversation_created` and `conversation_ended`.
    /// </summary>
    public string? ConversationCallback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ConversationCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConversationCallback", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `ConversationCallback` and `ConversationCallbacks`.
    /// </summary>
    public ApiEnum<string, ConversationCallbackMethod>? ConversationCallbackMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConversationCallbackMethod>>(
                "ConversationCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ConversationCallbackMethod", value);
        }
    }

    /// <summary>
    /// Array of URL destinations for AI conversation callback events for this call.
    /// Events include `conversation_created` and `conversation_ended`.
    /// </summary>
    public IReadOnlyList<string>? ConversationCallbacks {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "ConversationCallbacks"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "ConversationCallbacks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
    /// Allows you to choose between Regular, Premium, and PremiumCallScreening detections.
    /// See https://developers.telnyx.com/docs/voice/programmable-voice/answering-machine-detection
    /// </summary>
    public ApiEnum<string, DetectionMode>? DetectionMode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, DetectionMode>>(
                "DetectionMode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("DetectionMode", value);
        }
    }

    /// <summary>
    /// Enables Answering Machine Detection.
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
    /// Silence duration threshold after a call screening prompt before ending prompt
    /// detection, in milliseconds. Used when `DetectionMode` is `PremiumCallScreening`.
    /// </summary>
    public long? MachineDetectionPromptEndTimeout {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "MachineDetectionPromptEndTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("MachineDetectionPromptEndTimeout", value);
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
    /// Maximum timeout threshold in milliseconds for overall detection.
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
    /// A string of passport identifiers to associate with the call.
    /// </summary>
    public string? Passports {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "Passports"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("Passports", value);
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
    /// The changes to the recording's state that should generate a call to `RecordingStatusCallback`.
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
    /// The number of seconds that Telnyx will wait for the recording to be stopped
    /// if silence is detected. The timer only starts when the speech is detected.
    /// The minimum value is 0. The default value is 0 (infinite).
    /// </summary>
    public long? RecordingTimeout {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "RecordingTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("RecordingTimeout", value);
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
    /// Defines the SIP region to be used for the call.
    /// </summary>
    public ApiEnum<string, SipRegion>? SipRegion {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, SipRegion>>(
                "SipRegion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("SipRegion", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send status callback events for this AI call.
    /// When provided, this per-call value overrides the status callback URL configured
    /// on the TeXML application/connection.
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
    /// The status callback events for which Telnyx should send a webhook for this
    /// AI call. Multiple events can be defined when separated by a space. Valid
    /// values: initiated, ringing, answered, completed, no-answer, busy, canceled,
    /// failed, analyzed. When provided, this per-call value overrides the status
    /// callback events configured on the TeXML application/connection.
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
    /// HTTP request type used for `StatusCallback` and `StatusCallbacks` for this
    /// AI call. When provided, this per-call value overrides the status callback
    /// method configured on the TeXML application/connection.
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
    /// Array of URL destinations for Telnyx to send status callback events for this
    /// AI call. When provided, these per-call values override the status callback
    /// URL configured on the TeXML application/connection.
    /// </summary>
    public IReadOnlyList<string>? StatusCallbacks {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "StatusCallbacks"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "StatusCallbacks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The maximum duration of the call in seconds. The minimum value is 30 and
    /// the maximum value is 14400 (4 hours). Default is 14400 seconds.
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
    /// The number of seconds to wait for the called party to answer the call before
    /// the call is canceled. The minimum value is 5 and the maximum value is 120.
    /// Default is 30 seconds.
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

    public TexmlInitiateAICallParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlInitiateAICallParams (
        TexmlInitiateAICallParams texmlInitiateAICallParams
    ) : base(texmlInitiateAICallParams)
    {
        this.ConnectionID = texmlInitiateAICallParams.ConnectionID;

        this._rawBodyData = new(texmlInitiateAICallParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public TexmlInitiateAICallParams (
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
    TexmlInitiateAICallParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string connectionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ConnectionID = connectionID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TexmlInitiateAICallParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string connectionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            connectionID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ConnectionID"] = JsonSerializer.SerializeToElement(this.ConnectionID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(TexmlInitiateAICallParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ConnectionID?.Equals(other.ConnectionID) ?? other.ConnectionID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/ai_calls/{0}",
            EncodePathSegment(this.ConnectionID))
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
/// HTTP request type used for `AsyncAmdStatusCallback`.
/// </summary>
[JsonConverter(typeof(AsyncAmdStatusCallbackMethodConverter))]
public enum AsyncAmdStatusCallbackMethod
{
    Get, Post
}

sealed class AsyncAmdStatusCallbackMethodConverter : JsonConverter<AsyncAmdStatusCallbackMethod>
{
    public override AsyncAmdStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>AsyncAmdStatusCallbackMethod.Get,
            "POST"=>AsyncAmdStatusCallbackMethod.Post,
            _ =>(AsyncAmdStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AsyncAmdStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AsyncAmdStatusCallbackMethod.Get=>"GET",
            AsyncAmdStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `ConversationCallback` and `ConversationCallbacks`.
/// </summary>
[JsonConverter(typeof(ConversationCallbackMethodConverter))]
public enum ConversationCallbackMethod
{
    Get, Post
}

sealed class ConversationCallbackMethodConverter : JsonConverter<ConversationCallbackMethod>
{
    public override ConversationCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>ConversationCallbackMethod.Get,
            "POST"=>ConversationCallbackMethod.Post,
            _ =>(ConversationCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversationCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConversationCallbackMethod.Get=>"GET",
            ConversationCallbackMethod.Post=>"POST",
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
/// Allows you to choose between Regular, Premium, and PremiumCallScreening detections.
/// See https://developers.telnyx.com/docs/voice/programmable-voice/answering-machine-detection
/// </summary>
[JsonConverter(typeof(DetectionModeConverter))]
public enum DetectionMode
{
    Premium, Regular, PremiumCallScreening
}

sealed class DetectionModeConverter : JsonConverter<DetectionMode>
{
    public override DetectionMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Premium"=>DetectionMode.Premium,
            "Regular"=>DetectionMode.Regular,
            "PremiumCallScreening"=>DetectionMode.PremiumCallScreening,
            _ =>(DetectionMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DetectionMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DetectionMode.Premium=>"Premium",
            DetectionMode.Regular=>"Regular",
            DetectionMode.PremiumCallScreening=>"PremiumCallScreening",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Enables Answering Machine Detection.
/// </summary>
[JsonConverter(typeof(MachineDetectionConverter))]
public enum MachineDetection
{
    Enable, Disable, DetectMessageEnd
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
            "Disable"=>MachineDetection.Disable,
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
            MachineDetection.Disable=>"Disable",
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
/// HTTP request type used for `StatusCallback` and `StatusCallbacks` for this AI
/// call. When provided, this per-call value overrides the status callback method
/// configured on the TeXML application/connection.
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