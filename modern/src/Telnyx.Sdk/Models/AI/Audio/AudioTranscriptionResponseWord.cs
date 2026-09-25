using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Audio;

/// <summary>
/// Word-level timing detail. Only present when using a `deepgram/*` model with `model_config`
/// options that enable word timestamps.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AudioTranscriptionResponseWord, AudioTranscriptionResponseWordFromRaw>))]
public sealed record class AudioTranscriptionResponseWord : JsonModel
{
    /// <summary>
    /// End time of the word in seconds.
    /// </summary>
    public required double End {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "end"
            );
        }
        init { this._rawData.Set("end", value); }
    }

    /// <summary>
    /// Start time of the word in seconds.
    /// </summary>
    public required double Start {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "start"
            );
        }
        init { this._rawData.Set("start", value); }
    }

    /// <summary>
    /// The transcribed word.
    /// </summary>
    public required string Word {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "word"
            );
        }
        init { this._rawData.Set("word", value); }
    }

    /// <summary>
    /// Confidence score for the word (0.0 to 1.0).
    /// </summary>
    public double? Confidence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "confidence"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// The transcribed word with punctuation and capitalisation applied. Only present
    /// when `punctuate` or `smart_format` is enabled via `model_config`.
    /// </summary>
    public string? PunctuatedWord {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "punctuated_word"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("punctuated_word", value);
        }
    }

    /// <summary>
    /// Speaker index. Only present when diarization is enabled via `model_config`.
    /// </summary>
    public long? Speaker {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "speaker"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speaker", value);
        }
    }

    /// <summary>
    /// Confidence score for the speaker assignment (0.0 to 1.0). Only present when
    /// diarization is enabled via `model_config`.
    /// </summary>
    public double? SpeakerConfidence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "speaker_confidence"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speaker_confidence", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.Start;
        _ = this.Word;
        _ = this.Confidence;
        _ = this.PunctuatedWord;
        _ = this.Speaker;
        _ = this.SpeakerConfidence;
    }

    public AudioTranscriptionResponseWord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudioTranscriptionResponseWord (
        AudioTranscriptionResponseWord audioTranscriptionResponseWord
    ) : base(audioTranscriptionResponseWord)
    {  }
    #pragma warning restore CS8618

    public AudioTranscriptionResponseWord (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioTranscriptionResponseWord (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AudioTranscriptionResponseWordFromRaw.FromRawUnchecked"/>
    public static AudioTranscriptionResponseWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AudioTranscriptionResponseWordFromRaw : IFromRawJson<AudioTranscriptionResponseWord>
{
    /// <inheritdoc/>
    public AudioTranscriptionResponseWord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AudioTranscriptionResponseWord.FromRawUnchecked(rawData);
}