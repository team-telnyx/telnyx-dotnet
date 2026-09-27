using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<TelephonySettings, TelephonySettingsFromRaw>))]
public sealed record class TelephonySettings : JsonModel
{
    /// <summary>
    /// Default Texml App used for voice calls with your assistant. This will be created
    /// automatically on assistant creation.
    /// </summary>
    public string? DefaultTexmlAppID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "default_texml_app_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_texml_app_id", value);
        }
    }

    /// <summary>
    /// Disable inbound DTMF for the entire call. Must be set to true if a 'pay' tool
    /// is configured anywhere on the assistant — on the main tool array or on any
    /// workflow node — enforced at write time.
    /// </summary>
    public bool? DisableDtmf {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "disable_dtmf"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("disable_dtmf", value);
        }
    }

    /// <summary>
    /// Destination number or SIP URI to transfer the caller to when the AI conversation
    /// ends abnormally, for example because of an assistant-side error, so the caller
    /// is not left in dead air. This only fires for abnormal ends: it does not fire
    /// when the conversation ends on purpose (the caller hung up, the assistant
    /// completed normally, the caller hung up after a relay handoff, or voicemail
    /// was detected), and it does not fire when the assistant already transferred
    /// or bridged the call.
    /// </summary>
    public string? FallbackDestination {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "fallback_destination"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fallback_destination", value);
        }
    }

    /// <summary>
    /// The noise suppression engine to use. 'aicoustics' is STT-optimized and recommended
    /// for AI assistants (configure through noise_suppression_config). Use 'disabled'
    /// to turn off noise suppression.
    /// </summary>
    public ApiEnum<string, NoiseSuppression>? NoiseSuppression {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NoiseSuppression>>(
                "noise_suppression"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("noise_suppression", value);
        }
    }

    /// <summary>
    /// Configuration for noise suppression. Applicable fields depend on the engine:
    /// 'attenuation_limit' and 'mode' only when noise_suppression is 'deepfilternet';
    /// 'family', 'size' and 'enhancement_level' only when noise_suppression is 'aicoustics'.
    /// </summary>
    public NoiseSuppressionConfig? NoiseSuppressionConfig {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NoiseSuppressionConfig>(
                "noise_suppression_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("noise_suppression_config", value);
        }
    }

    /// <summary>
    /// Configuration for call recording format and channel settings.
    /// </summary>
    public RecordingSettings? RecordingSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecordingSettings>(
                "recording_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_settings", value);
        }
    }

    /// <summary>
    /// Whether the assistant sends a `call.ai_gather.message_history_updated` webhook
    /// with the full message history every time the conversation history changes.
    /// Leave unset to inherit the `send_message_history_updates` value from the `ai_assistant_start`
    /// or `gather_using_ai` command that started the conversation. Setting it here
    /// is authoritative: `true` turns the webhooks on even when the start command
    /// did not request them, and `false` turns them off even when it did. Messages
    /// exchanged during a private warm transfer acceptance phase are never included.
    /// </summary>
    public bool? SendMessageHistoryUpdates {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "send_message_history_updates"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("send_message_history_updates", value);
        }
    }

    /// <summary>
    /// When enabled, allows users to interact with your AI assistant directly from
    /// your website without requiring authentication. This is required for FE widgets
    /// that work with assistants that have telephony enabled.
    /// </summary>
    public bool? SupportsUnauthenticatedWebCalls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "supports_unauthenticated_web_calls"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("supports_unauthenticated_web_calls", value);
        }
    }

    /// <summary>
    /// Maximum duration in seconds for the AI assistant to participate on the call.
    /// When this limit is reached the assistant will be stopped. This limit does
    /// not apply to portions of a call without an active assistant (for instance,
    /// a call transferred to a human representative).
    /// </summary>
    public long? TimeLimitSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "time_limit_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("time_limit_secs", value);
        }
    }

    /// <summary>
    /// Duration in seconds of end user silence before the assistant checks in on
    /// the user. When this limit is reached the assistant will prompt the user to
    /// respond. This is distinct from user_idle_timeout_secs which stops the assistant entirely.
    /// </summary>
    public long? UserIdleReplySecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "user_idle_reply_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_idle_reply_secs", value);
        }
    }

    /// <summary>
    /// Maximum duration in seconds of end user silence on the call. When this limit
    /// is reached the assistant will be stopped. This limit does not apply to portions
    /// of a call without an active assistant (for instance, a call transferred to
    /// a human representative).
    /// </summary>
    public long? UserIdleTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "user_idle_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_idle_timeout_secs", value);
        }
    }

    /// <summary>
    /// Configuration for voicemail detection (AMD - Answering Machine Detection)
    /// on outgoing calls. These settings only apply if AMD is enabled on the Dial
    /// command. See [TeXML Dial documentation](https://developers.telnyx.com/api-reference/texml-rest-commands/initiate-an-outbound-call)
    /// for enabling AMD. Recommended settings: MachineDetection=Enable, AsyncAmd=true, DetectionMode=Premium.
    /// </summary>
    public TelephonySettingsVoicemailDetection? VoicemailDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TelephonySettingsVoicemailDetection>(
                "voicemail_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voicemail_detection", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DefaultTexmlAppID;
        _ = this.DisableDtmf;
        _ = this.FallbackDestination;
        this.NoiseSuppression?.Validate();
        this.NoiseSuppressionConfig?.Validate();
        this.RecordingSettings?.Validate();
        _ = this.SendMessageHistoryUpdates;
        _ = this.SupportsUnauthenticatedWebCalls;
        _ = this.TimeLimitSecs;
        _ = this.UserIdleReplySecs;
        _ = this.UserIdleTimeoutSecs;
        this.VoicemailDetection?.Validate();
    }

    public TelephonySettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonySettings (TelephonySettings telephonySettings) : base(
        telephonySettings
    )
    {  }
    #pragma warning restore CS8618

    public TelephonySettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonySettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonySettingsFromRaw.FromRawUnchecked"/>
    public static TelephonySettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelephonySettingsFromRaw : IFromRawJson<TelephonySettings>
{
    /// <inheritdoc/>
    public TelephonySettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonySettings.FromRawUnchecked(rawData);
}

/// <summary>
/// The noise suppression engine to use. 'aicoustics' is STT-optimized and recommended
/// for AI assistants (configure through noise_suppression_config). Use 'disabled'
/// to turn off noise suppression.
/// </summary>
[JsonConverter(typeof(NoiseSuppressionConverter))]
public enum NoiseSuppression
{
    Aicoustics, Krisp, Deepfilternet, Disabled
}sealed class NoiseSuppressionConverter : JsonConverter<NoiseSuppression>
{
    public override NoiseSuppression Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aicoustics"=>NoiseSuppression.Aicoustics,
            "krisp"=>NoiseSuppression.Krisp,
            "deepfilternet"=>NoiseSuppression.Deepfilternet,
            "disabled"=>NoiseSuppression.Disabled,
            _ =>(NoiseSuppression)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NoiseSuppression value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NoiseSuppression.Aicoustics=>"aicoustics",
            NoiseSuppression.Krisp=>"krisp",
            NoiseSuppression.Deepfilternet=>"deepfilternet",
            NoiseSuppression.Disabled=>"disabled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Configuration for noise suppression. Applicable fields depend on the engine:
/// 'attenuation_limit' and 'mode' only when noise_suppression is 'deepfilternet';
/// 'family', 'size' and 'enhancement_level' only when noise_suppression is 'aicoustics'.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NoiseSuppressionConfig, NoiseSuppressionConfigFromRaw>))]
public sealed record class NoiseSuppressionConfig : JsonModel
{
    /// <summary>
    /// Attenuation limit for noise suppression. Range: 0-100. Only applicable when
    /// noise_suppression is 'deepfilternet'.
    /// </summary>
    public long? AttenuationLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "attenuation_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attenuation_limit", value);
        }
    }

    /// <summary>
    /// AiCoustics enhancement intensity. Range: 0-1. Only applicable when noise_suppression
    /// is 'aicoustics'.
    /// </summary>
    public double? EnhancementLevel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "enhancement_level"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enhancement_level", value);
        }
    }

    /// <summary>
    /// AiCoustics model family optimized for Voice AI and STT. Only applicable when
    /// noise_suppression is 'aicoustics'.
    /// </summary>
    public ApiEnum<string, Family>? Family {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Family>>(
                "family"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("family", value);
        }
    }

    /// <summary>
    /// Mode for noise suppression configuration. Only applicable when noise_suppression
    /// is 'deepfilternet'.
    /// </summary>
    public ApiEnum<string, Mode>? Mode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Mode>>(
                "mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <summary>
    /// AiCoustics model size. 'vf' tracks the latest model release; 'vf_2_0_l' is
    /// pinned to version 2.0 for consistent, predictable behavior. Only applicable
    /// when noise_suppression is 'aicoustics'.
    /// </summary>
    public ApiEnum<string, Size>? Size {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Size>>(
                "size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("size", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttenuationLimit;
        _ = this.EnhancementLevel;
        this.Family?.Validate();
        this.Mode?.Validate();
        this.Size?.Validate();
    }

    public NoiseSuppressionConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoiseSuppressionConfig (
        NoiseSuppressionConfig noiseSuppressionConfig
    ) : base(noiseSuppressionConfig)
    {  }
    #pragma warning restore CS8618

    public NoiseSuppressionConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NoiseSuppressionConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NoiseSuppressionConfigFromRaw.FromRawUnchecked"/>
    public static NoiseSuppressionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NoiseSuppressionConfigFromRaw : IFromRawJson<NoiseSuppressionConfig>
{
    /// <inheritdoc/>
    public NoiseSuppressionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NoiseSuppressionConfig.FromRawUnchecked(rawData);
}/// <summary>
/// AiCoustics model family optimized for Voice AI and STT. Only applicable when
/// noise_suppression is 'aicoustics'.
/// </summary>
[JsonConverter(typeof(FamilyConverter))]
public enum Family
{
    Quail
}sealed class FamilyConverter : JsonConverter<Family>
{
    public override Family Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "quail"=>Family.Quail, _ =>(Family)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Family value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Family.Quail=>"quail",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Mode for noise suppression configuration. Only applicable when noise_suppression
/// is 'deepfilternet'.
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Advanced
}sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "advanced"=>Mode.Advanced, _ =>(Mode)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Mode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Mode.Advanced=>"advanced",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// AiCoustics model size. 'vf' tracks the latest model release; 'vf_2_0_l' is pinned
/// to version 2.0 for consistent, predictable behavior. Only applicable when noise_suppression
/// is 'aicoustics'.
/// </summary>
[JsonConverter(typeof(SizeConverter))]
public enum Size
{
    Vf, Vf2_0L
}sealed class SizeConverter : JsonConverter<Size>
{
    public override Size Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "vf"=>Size.Vf, "vf_2_0_l"=>Size.Vf2_0L, _ =>(Size)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Size value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Size.Vf=>"vf",
            Size.Vf2_0L=>"vf_2_0_l",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Configuration for call recording format and channel settings.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RecordingSettings, RecordingSettingsFromRaw>))]
public sealed record class RecordingSettings : JsonModel
{
    /// <summary>
    /// The number of channels for the recording. 'single' for mono, 'dual' for stereo.
    /// </summary>
    public ApiEnum<string, Channels>? Channels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Channels>>(
                "channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    /// <summary>
    /// Whether call recording is enabled. When set to false, calls will not be recorded
    /// regardless of other recording configuration.
    /// </summary>
    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// The format of the recording file.
    /// </summary>
    public ApiEnum<string, Format>? Format {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Format>>(
                "format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("format", value);
        }
    }

    /// <summary>
    /// When enabled, the call recording will stop when the conversation ends (for
    /// example, when the assistant hangs up or the call is transferred). When disabled,
    /// recording continues until the call itself ends.
    /// </summary>
    public bool? StopOnConversationEnd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "stop_on_conversation_end"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stop_on_conversation_end", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Channels?.Validate();
        _ = this.Enabled;
        this.Format?.Validate();
        _ = this.StopOnConversationEnd;
    }

    public RecordingSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingSettings (RecordingSettings recordingSettings) : base(
        recordingSettings
    )
    {  }
    #pragma warning restore CS8618

    public RecordingSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingSettingsFromRaw.FromRawUnchecked"/>
    public static RecordingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RecordingSettingsFromRaw : IFromRawJson<RecordingSettings>
{
    /// <inheritdoc/>
    public RecordingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingSettings.FromRawUnchecked(rawData);
}/// <summary>
/// The number of channels for the recording. 'single' for mono, 'dual' for stereo.
/// </summary>
[JsonConverter(typeof(ChannelsConverter))]
public enum Channels
{
    Single, Dual
}sealed class ChannelsConverter : JsonConverter<Channels>
{
    public override Channels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "single"=>Channels.Single, "dual"=>Channels.Dual, _ =>(Channels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Channels value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Channels.Single=>"single",
            Channels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The format of the recording file.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Wav, Mp3
}sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "wav"=>Format.Wav, "mp3"=>Format.Mp3, _ =>(Format)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Format value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Format.Wav=>"wav",
            Format.Mp3=>"mp3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Configuration for voicemail detection (AMD - Answering Machine Detection) on
/// outgoing calls. These settings only apply if AMD is enabled on the Dial command.
/// See [TeXML Dial documentation](https://developers.telnyx.com/api-reference/texml-rest-commands/initiate-an-outbound-call)
/// for enabling AMD. Recommended settings: MachineDetection=Enable, AsyncAmd=true, DetectionMode=Premium.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TelephonySettingsVoicemailDetection, TelephonySettingsVoicemailDetectionFromRaw>))]
public sealed record class TelephonySettingsVoicemailDetection : JsonModel
{
    /// <summary>
    /// Action to take when voicemail is detected.
    /// </summary>
    public TelephonySettingsVoicemailDetectionOnVoicemailDetected? OnVoicemailDetected {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TelephonySettingsVoicemailDetectionOnVoicemailDetected>(
                "on_voicemail_detected"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_voicemail_detected", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.OnVoicemailDetected?.Validate(); }

    public TelephonySettingsVoicemailDetection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonySettingsVoicemailDetection (
        TelephonySettingsVoicemailDetection telephonySettingsVoicemailDetection
    ) : base(telephonySettingsVoicemailDetection)
    {  }
    #pragma warning restore CS8618

    public TelephonySettingsVoicemailDetection (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonySettingsVoicemailDetection (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonySettingsVoicemailDetectionFromRaw.FromRawUnchecked"/>
    public static TelephonySettingsVoicemailDetection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TelephonySettingsVoicemailDetectionFromRaw : IFromRawJson<TelephonySettingsVoicemailDetection>
{
    /// <inheritdoc/>
    public TelephonySettingsVoicemailDetection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonySettingsVoicemailDetection.FromRawUnchecked(rawData);
}/// <summary>
/// Action to take when voicemail is detected.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TelephonySettingsVoicemailDetectionOnVoicemailDetected, TelephonySettingsVoicemailDetectionOnVoicemailDetectedFromRaw>))]
public sealed record class TelephonySettingsVoicemailDetectionOnVoicemailDetected : JsonModel
{
    /// <summary>
    /// The action to take when voicemail is detected.
    /// </summary>
    public ApiEnum<string, TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction>? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction>>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    /// <summary>
    /// Configuration for the voicemail message to leave. Only applicable when action
    /// is 'leave_message_and_stop_assistant'.
    /// </summary>
    public TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage? VoicemailMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage>(
                "voicemail_message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voicemail_message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action?.Validate();
        this.VoicemailMessage?.Validate();
    }

    public TelephonySettingsVoicemailDetectionOnVoicemailDetected ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonySettingsVoicemailDetectionOnVoicemailDetected (
        TelephonySettingsVoicemailDetectionOnVoicemailDetected telephonySettingsVoicemailDetectionOnVoicemailDetected
    ) : base(telephonySettingsVoicemailDetectionOnVoicemailDetected)
    {  }
    #pragma warning restore CS8618

    public TelephonySettingsVoicemailDetectionOnVoicemailDetected (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonySettingsVoicemailDetectionOnVoicemailDetected (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonySettingsVoicemailDetectionOnVoicemailDetectedFromRaw.FromRawUnchecked"/>
    public static TelephonySettingsVoicemailDetectionOnVoicemailDetected FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TelephonySettingsVoicemailDetectionOnVoicemailDetectedFromRaw : IFromRawJson<TelephonySettingsVoicemailDetectionOnVoicemailDetected>
{
    /// <inheritdoc/>
    public TelephonySettingsVoicemailDetectionOnVoicemailDetected FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonySettingsVoicemailDetectionOnVoicemailDetected.FromRawUnchecked(rawData);
}/// <summary>
/// The action to take when voicemail is detected.
/// </summary>
[JsonConverter(typeof(TelephonySettingsVoicemailDetectionOnVoicemailDetectedActionConverter))]
public enum TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction
{
    StopAssistant, LeaveMessageAndStopAssistant, ContinueAssistant
}sealed class TelephonySettingsVoicemailDetectionOnVoicemailDetectedActionConverter : JsonConverter<TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction>
{
    public override TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stop_assistant"=>TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction.StopAssistant,
            "leave_message_and_stop_assistant"=>TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction.LeaveMessageAndStopAssistant,
            "continue_assistant"=>TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction.ContinueAssistant,
            _ =>(TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction.StopAssistant=>"stop_assistant",
            TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction.LeaveMessageAndStopAssistant=>"leave_message_and_stop_assistant",
            TelephonySettingsVoicemailDetectionOnVoicemailDetectedAction.ContinueAssistant=>"continue_assistant",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Configuration for the voicemail message to leave. Only applicable when action
/// is 'leave_message_and_stop_assistant'.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage, TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageFromRaw>))]
public sealed record class TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage : JsonModel
{
    /// <summary>
    /// The specific message to leave as voicemail. Only applicable when type is 'message'.
    /// </summary>
    public string? Message {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <summary>
    /// The prompt to use for generating the voicemail message. Only applicable when
    /// type is 'prompt'.
    /// </summary>
    public string? Prompt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "prompt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("prompt", value);
        }
    }

    /// <summary>
    /// The type of voicemail message. Use 'prompt' to have the assistant generate
    /// a message based on a prompt, or 'message' to leave a specific message.
    /// </summary>
    public ApiEnum<string, TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Prompt;
        this.Type?.Validate();
    }

    public TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage (

    )
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage (
        TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage telephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage
    ) : base(
        telephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage
    )
    {  }
    #pragma warning restore CS8618

    public TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageFromRaw.FromRawUnchecked"/>
    public static TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageFromRaw : IFromRawJson<TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage>
{
    /// <inheritdoc/>
    public TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessage.FromRawUnchecked(rawData);
}/// <summary>
/// The type of voicemail message. Use 'prompt' to have the assistant generate a message
/// based on a prompt, or 'message' to leave a specific message.
/// </summary>
[JsonConverter(typeof(TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageTypeConverter))]
public enum TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType
{
    Prompt, Message
}sealed class TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageTypeConverter : JsonConverter<TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType>
{
    public override TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "prompt"=>TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType.Prompt,
            "message"=>TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType.Message,
            _ =>(TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType.Prompt=>"prompt",
            TelephonySettingsVoicemailDetectionOnVoicemailDetectedVoicemailMessageType.Message=>"message",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}