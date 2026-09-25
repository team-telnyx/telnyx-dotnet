using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Controls when the assistant starts speaking after the user stops. These thresholds
/// primarily apply to non turn-taking transcription models. For turn-taking models
/// like `deepgram/flux`, end-of-turn detection is driven by the transcription end-of-turn
/// settings under `transcription.settings` instead.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StartSpeakingPlan, StartSpeakingPlanFromRaw>))]
public sealed record class StartSpeakingPlan : JsonModel
{
    /// <summary>
    /// Endpointing thresholds used to decide when the user has finished speaking.
    /// Applies to non turn-taking transcription models. For `deepgram/flux`, use
    /// `transcription.settings.eot_threshold` / `eot_timeout_ms` / `eager_eot_threshold`.
    /// </summary>
    public TranscriptionEndpointingPlan? TranscriptionEndpointingPlan {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TranscriptionEndpointingPlan>(
                "transcription_endpointing_plan"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_endpointing_plan", value);
        }
    }

    /// <summary>
    /// Minimum seconds to wait before the assistant starts speaking.
    /// </summary>
    public float? WaitSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "wait_seconds"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wait_seconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.TranscriptionEndpointingPlan?.Validate();
        _ = this.WaitSeconds;
    }

    public StartSpeakingPlan ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StartSpeakingPlan (StartSpeakingPlan startSpeakingPlan) : base(
        startSpeakingPlan
    )
    {  }
    #pragma warning restore CS8618

    public StartSpeakingPlan (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StartSpeakingPlan (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StartSpeakingPlanFromRaw.FromRawUnchecked"/>
    public static StartSpeakingPlan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StartSpeakingPlanFromRaw : IFromRawJson<StartSpeakingPlan>
{
    /// <inheritdoc/>
    public StartSpeakingPlan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StartSpeakingPlan.FromRawUnchecked(rawData);
}