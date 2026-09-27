using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<TranscriptionSettingsConfig, TranscriptionSettingsConfigFromRaw>))]
public sealed record class TranscriptionSettingsConfig : JsonModel
{
    /// <summary>
    /// Available only for soniox/stt-rt-v4 and soniox/stt-rt-v5. A comma-separated
    /// list of terms to boost for recognition during transcription, for staff names,
    /// building names, or other domain-specific vocabulary. This field may be templated
    /// with [dynamic variables](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables)
    /// using mustache syntax (e.g. `Telnyx,{{customer_name}},VoIP`). Variables are
    /// resolved at call time before the value is sent to Soniox.
    /// </summary>
    public string? Context {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "context"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("context", value);
        }
    }

    /// <summary>
    /// Available only for deepgram/flux. Confidence threshold for eager end of turn
    /// detection. Must be lower than or equal to eot_threshold. Setting this equal
    /// to eot_threshold effectively disables eager end of turn.
    /// </summary>
    public double? EagerEotThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "eager_eot_threshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eager_eot_threshold", value);
        }
    }

    /// <summary>
    /// Available only for soniox/stt-rt-v4 and soniox/stt-rt-v5. When true, Soniox
    /// emits end-of-utterance events at the cadence configured by `max_endpoint_delay_ms`.
    /// </summary>
    public bool? EnableEndpointDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_endpoint_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_endpoint_detection", value);
        }
    }

    /// <summary>
    /// Available only for assemblyai/universal-3-5-pro (and its legacy alias assemblyai/universal-streaming).
    /// Confidence level required to trigger an end of turn. Higher values require
    /// more certainty before ending a turn.
    /// </summary>
    public double? EndOfTurnConfidenceThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "end_of_turn_confidence_threshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_of_turn_confidence_threshold", value);
        }
    }

    /// <summary>
    /// Available only for deepgram/flux. Confidence required to trigger an end of
    /// turn. Higher values = more reliable turn detection but slightly increased latency.
    /// </summary>
    public double? EotThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "eot_threshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eot_threshold", value);
        }
    }

    /// <summary>
    /// Available only for deepgram/flux. Maximum milliseconds of silence before forcing
    /// an end of turn, regardless of confidence.
    /// </summary>
    public long? EotTimeoutMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "eot_timeout_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eot_timeout_ms", value);
        }
    }

    /// <summary>
    /// Available only for soniox/stt-rt-v4 and soniox/stt-rt-v5. When true, Soniox
    /// streams interim (non-final) results in addition to finalized transcripts.
    /// </summary>
    public bool? InterimResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "interim_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("interim_results", value);
        }
    }

    /// <summary>
    /// Available only for deepgram/nova-3 and deepgram/flux. A comma-separated list
    /// of key terms to boost for recognition during transcription. Helps improve
    /// accuracy for domain-specific terminology, proper nouns, or uncommon words.
    /// This field may be templated with [dynamic variables](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables)
    /// using mustache syntax (e.g. `Telnyx,{{customer_name}},VoIP`). Variables are
    /// resolved at call time before the value is sent to the speech-to-text engine.
    /// </summary>
    public string? Keyterm {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "keyterm"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("keyterm", value);
        }
    }

    /// <summary>
    /// Available only for soniox/stt-rt-v4 and soniox/stt-rt-v5. A list of ISO 639-1
    /// language codes (e.g. `["nl", "fr"]`) to pin recognition to multiple languages
    /// at once, overriding the single hint derived from `language`.
    /// </summary>
    public IReadOnlyList<string>? LanguageHints {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "language_hints"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "language_hints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Available only for soniox/stt-rt-v4 and soniox/stt-rt-v5. Maximum silence
    /// (in milliseconds) before Soniox emits an end-of-utterance event. Only honored
    /// when `enable_endpoint_detection` is true.
    /// </summary>
    public long? MaxEndpointDelayMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_endpoint_delay_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_endpoint_delay_ms", value);
        }
    }

    /// <summary>
    /// Available only for assemblyai/universal-3-5-pro (and its legacy alias assemblyai/universal-streaming).
    /// Maximum duration of silence in milliseconds before forcing an end of turn.
    /// </summary>
    public long? MaxTurnSilence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_turn_silence"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_turn_silence", value);
        }
    }

    /// <summary>
    /// Available only for assemblyai/universal-3-5-pro (and its legacy alias assemblyai/universal-streaming).
    /// Minimum duration of silence in milliseconds before a turn can end. Must be
    /// less than or equal to max_turn_silence.
    /// </summary>
    public long? MinTurnSilence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "min_turn_silence"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("min_turn_silence", value);
        }
    }

    public bool? Numerals {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "numerals"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("numerals", value);
        }
    }

    public bool? SmartFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "smart_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("smart_format", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Context;
        _ = this.EagerEotThreshold;
        _ = this.EnableEndpointDetection;
        _ = this.EndOfTurnConfidenceThreshold;
        _ = this.EotThreshold;
        _ = this.EotTimeoutMs;
        _ = this.InterimResults;
        _ = this.Keyterm;
        _ = this.LanguageHints;
        _ = this.MaxEndpointDelayMs;
        _ = this.MaxTurnSilence;
        _ = this.MinTurnSilence;
        _ = this.Numerals;
        _ = this.SmartFormat;
    }

    public TranscriptionSettingsConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionSettingsConfig (
        TranscriptionSettingsConfig transcriptionSettingsConfig
    ) : base(transcriptionSettingsConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionSettingsConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionSettingsConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionSettingsConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionSettingsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionSettingsConfigFromRaw : IFromRawJson<TranscriptionSettingsConfig>
{
    /// <inheritdoc/>
    public TranscriptionSettingsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionSettingsConfig.FromRawUnchecked(rawData);
}