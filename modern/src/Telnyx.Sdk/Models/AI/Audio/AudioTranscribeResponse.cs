using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Audio;

/// <summary>
/// Response fields vary by model. `distil-whisper/distil-large-v2` returns `text`,
/// `duration`, and `segments` in `verbose_json` mode. `openai/whisper-large-v3-turbo`
/// returns `text` only. The `deepgram/*` models return `text` and, depending on
/// `model_config`, may include `words` with per-word timestamps and speaker labels.
/// The Parakeet models (`nvidia/parakeet-v3`, `omi-health/omi-med-stt-v1`) return
/// `text` only.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AudioTranscribeResponse, AudioTranscribeResponseFromRaw>))]
public sealed record class AudioTranscribeResponse : JsonModel
{
    /// <summary>
    /// The transcribed text for the audio file.
    /// </summary>
    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// The duration of the audio file in seconds. Returned by `distil-whisper/distil-large-v2`
    /// and the `deepgram/*` models when `response_format` is `verbose_json`. Not
    /// returned by `openai/whisper-large-v3-turbo`.
    /// </summary>
    public double? Duration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "duration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    /// <summary>
    /// Segments of the transcribed text and their corresponding details. Returned
    /// by `distil-whisper/distil-large-v2` and the `deepgram/*` models when `response_format`
    /// is `verbose_json`; Deepgram segments also carry nested `words` and `speakers`.
    /// Not returned by `openai/whisper-large-v3-turbo`.
    /// </summary>
    public IReadOnlyList<Segment>? Segments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Segment>>(
                "segments"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Segment>?>(
                "segments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Word-level timestamps and optional speaker labels. Only returned by the `deepgram/*`
    /// models when word-level output is enabled via `model_config`.
    /// </summary>
    public IReadOnlyList<AudioTranscriptionResponseWord>? Words {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AudioTranscriptionResponseWord>>(
                "words"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AudioTranscriptionResponseWord>?>(
                "words",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Duration;
        foreach (var item in this.Segments ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Words ?? [])
        {
            item.Validate();
        }
    }

    public AudioTranscribeResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudioTranscribeResponse (
        AudioTranscribeResponse audioTranscribeResponse
    ) : base(audioTranscribeResponse)
    {  }
    #pragma warning restore CS8618

    public AudioTranscribeResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioTranscribeResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AudioTranscribeResponseFromRaw.FromRawUnchecked"/>
    public static AudioTranscribeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AudioTranscribeResponse (string text) : this()
    { this.Text = text; }
}

class AudioTranscribeResponseFromRaw : IFromRawJson<AudioTranscribeResponse>
{
    /// <inheritdoc/>
    public AudioTranscribeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AudioTranscribeResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Segment, SegmentFromRaw>))]
public sealed record class Segment : JsonModel
{
    /// <summary>
    /// Unique identifier of the segment.
    /// </summary>
    public required double ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// End time of the segment in seconds.
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
    /// Start time of the segment in seconds.
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
    /// Text content of the segment.
    /// </summary>
    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Speaker indices heard in this segment. Returned by the `deepgram/*` models
    /// when `diarize` is enabled via `model_config`.
    /// </summary>
    public IReadOnlyList<long>? Speakers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>(
                "speakers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "speakers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Word-level timing detail for this segment. Returned by the `deepgram/*` models
    /// when word-level output is enabled via `model_config`.
    /// </summary>
    public IReadOnlyList<AudioTranscriptionResponseWord>? Words {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AudioTranscriptionResponseWord>>(
                "words"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AudioTranscriptionResponseWord>?>(
                "words",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.End;
        _ = this.Start;
        _ = this.Text;
        _ = this.Speakers;
        foreach (var item in this.Words ?? [])
        {
            item.Validate();
        }
    }

    public Segment ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Segment (Segment segment) : base(segment)
    {  }
    #pragma warning restore CS8618

    public Segment (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Segment (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SegmentFromRaw.FromRawUnchecked"/>
    public static Segment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SegmentFromRaw : IFromRawJson<Segment>
{
    /// <inheritdoc/>
    public Segment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Segment.FromRawUnchecked(rawData);
}