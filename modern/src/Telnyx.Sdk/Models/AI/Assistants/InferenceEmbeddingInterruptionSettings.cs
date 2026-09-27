using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Settings for interruptions and how the assistant decides the user has finished
/// speaking. These timings are most relevant when using non turn-taking transcription
/// models. For turn-taking models like `deepgram/flux`, end-of-turn behavior is
/// controlled by the transcription end-of-turn settings under `transcription.settings`
/// (`eot_threshold`, `eot_timeout_ms`, `eager_eot_threshold`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InferenceEmbeddingInterruptionSettings, InferenceEmbeddingInterruptionSettingsFromRaw>))]
public sealed record class InferenceEmbeddingInterruptionSettings : JsonModel
{
    /// <summary>
    /// When true, disables user interruptions while the assistant greeting is playing.
    /// </summary>
    public bool? DisableGreetingInterruption {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "disable_greeting_interruption"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("disable_greeting_interruption", value);
        }
    }

    /// <summary>
    /// Whether users can interrupt the assistant while it is speaking.
    /// </summary>
    public bool? Enable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable", value);
        }
    }

    /// <summary>
    /// Interrupt-prediction sensitivity, from 0.0 to 1.0. Set to null or 0.0 to
    /// disable interrupt prediction.
    /// </summary>
    public double? InterruptPredictionThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "interrupt_prediction_threshold"
            );
        }
        init { this._rawData.Set("interrupt_prediction_threshold", value); }
    }

    /// <summary>
    /// Controls when the assistant starts speaking after the user stops. These thresholds
    /// primarily apply to non turn-taking transcription models. For turn-taking models
    /// like `deepgram/flux`, end-of-turn detection is driven by the transcription
    /// end-of-turn settings under `transcription.settings` instead.
    /// </summary>
    public StartSpeakingPlan? StartSpeakingPlan {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StartSpeakingPlan>(
                "start_speaking_plan"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_speaking_plan", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisableGreetingInterruption;
        _ = this.Enable;
        _ = this.InterruptPredictionThreshold;
        this.StartSpeakingPlan?.Validate();
    }

    public InferenceEmbeddingInterruptionSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InferenceEmbeddingInterruptionSettings (
        InferenceEmbeddingInterruptionSettings inferenceEmbeddingInterruptionSettings
    ) : base(inferenceEmbeddingInterruptionSettings)
    {  }
    #pragma warning restore CS8618

    public InferenceEmbeddingInterruptionSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InferenceEmbeddingInterruptionSettings (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InferenceEmbeddingInterruptionSettingsFromRaw.FromRawUnchecked"/>
    public static InferenceEmbeddingInterruptionSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InferenceEmbeddingInterruptionSettingsFromRaw : IFromRawJson<InferenceEmbeddingInterruptionSettings>
{
    /// <inheritdoc/>
    public InferenceEmbeddingInterruptionSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InferenceEmbeddingInterruptionSettings.FromRawUnchecked(rawData);
}