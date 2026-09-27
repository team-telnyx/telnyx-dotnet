using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Endpointing thresholds used to decide when the user has finished speaking. Applies
/// to non turn-taking transcription models. For `deepgram/flux`, use `transcription.settings.eot_threshold`
/// / `eot_timeout_ms` / `eager_eot_threshold`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TranscriptionEndpointingPlan, TranscriptionEndpointingPlanFromRaw>))]
public sealed record class TranscriptionEndpointingPlan : JsonModel
{
    /// <summary>
    /// Seconds to wait after the transcript ends without punctuation.
    /// </summary>
    public float? OnNoPunctuationSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "on_no_punctuation_seconds"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_no_punctuation_seconds", value);
        }
    }

    /// <summary>
    /// Seconds to wait after the transcript ends with a number.
    /// </summary>
    public float? OnNumberSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "on_number_seconds"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_number_seconds", value);
        }
    }

    /// <summary>
    /// Seconds to wait after the transcript ends with punctuation.
    /// </summary>
    public float? OnPunctuationSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "on_punctuation_seconds"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_punctuation_seconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OnNoPunctuationSeconds;
        _ = this.OnNumberSeconds;
        _ = this.OnPunctuationSeconds;
    }

    public TranscriptionEndpointingPlan ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEndpointingPlan (
        TranscriptionEndpointingPlan transcriptionEndpointingPlan
    ) : base(transcriptionEndpointingPlan)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEndpointingPlan (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEndpointingPlan (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEndpointingPlanFromRaw.FromRawUnchecked"/>
    public static TranscriptionEndpointingPlan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEndpointingPlanFromRaw : IFromRawJson<TranscriptionEndpointingPlan>
{
    /// <inheritdoc/>
    public TranscriptionEndpointingPlan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEndpointingPlan.FromRawUnchecked(rawData);
}