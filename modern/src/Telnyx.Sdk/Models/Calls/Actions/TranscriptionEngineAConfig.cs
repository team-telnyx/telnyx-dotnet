using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineAConfig, TranscriptionEngineAConfigFromRaw>))]
public sealed record class TranscriptionEngineAConfig : JsonModel
{
    /// <summary>
    /// Enables speaker diarization.
    /// </summary>
    public bool? EnableSpeakerDiarization {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_speaker_diarization"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_speaker_diarization", value);
        }
    }

    /// <summary>
    /// Hints to improve transcription accuracy.
    /// </summary>
    public IReadOnlyList<string>? Hints {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "hints"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "hints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to send also interim results. If set to false, only final results
    /// will be sent.
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
    /// Language to use for speech recognition
    /// </summary>
    public ApiEnum<string, GoogleTranscriptionLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, GoogleTranscriptionLanguage>>(
                "language"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// Defines maximum number of speakers in the conversation.
    /// </summary>
    public int? MaxSpeakerCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "max_speaker_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_speaker_count", value);
        }
    }

    /// <summary>
    /// Defines minimum number of speakers in the conversation.
    /// </summary>
    public int? MinSpeakerCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "min_speaker_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("min_speaker_count", value);
        }
    }

    /// <summary>
    /// The model to use for transcription.
    /// </summary>
    public ApiEnum<string, TranscriptionEngineAConfigModel>? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineAConfigModel>>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Enables profanity_filter.
    /// </summary>
    public bool? ProfanityFilter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "profanity_filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("profanity_filter", value);
        }
    }

    /// <summary>
    /// Speech context to improve transcription accuracy.
    /// </summary>
    public IReadOnlyList<SpeechContext>? SpeechContext {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SpeechContext>>(
                "speech_context"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SpeechContext>?>(
                "speech_context",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Engine identifier for Google transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineAConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineAConfigTranscriptionEngine>>(
                "transcription_engine"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_engine", value);
        }
    }

    /// <summary>
    /// Enables enhanced transcription, this works for models `phone_call` and `video`.
    /// </summary>
    public bool? UseEnhanced {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "use_enhanced"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("use_enhanced", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EnableSpeakerDiarization;
        _ = this.Hints;
        _ = this.InterimResults;
        this.Language?.Validate();
        _ = this.MaxSpeakerCount;
        _ = this.MinSpeakerCount;
        this.Model?.Validate();
        _ = this.ProfanityFilter;
        foreach (var item in this.SpeechContext ?? [])
        {
            item.Validate();
        }
        this.TranscriptionEngine?.Validate();
        _ = this.UseEnhanced;
    }

    public TranscriptionEngineAConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineAConfig (
        TranscriptionEngineAConfig transcriptionEngineAConfig
    ) : base(transcriptionEngineAConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineAConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineAConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineAConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineAConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineAConfigFromRaw : IFromRawJson<TranscriptionEngineAConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineAConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineAConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineAConfigModelConverter))]
public enum TranscriptionEngineAConfigModel
{
    LatestLong,
    LatestShort,
    CommandAndSearch,
    PhoneCall,
    Video,
    Default,
    MedicalConversation,
    MedicalDictation
}sealed class TranscriptionEngineAConfigModelConverter : JsonConverter<TranscriptionEngineAConfigModel>
{
    public override TranscriptionEngineAConfigModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "latest_long"=>TranscriptionEngineAConfigModel.LatestLong,
            "latest_short"=>TranscriptionEngineAConfigModel.LatestShort,
            "command_and_search"=>TranscriptionEngineAConfigModel.CommandAndSearch,
            "phone_call"=>TranscriptionEngineAConfigModel.PhoneCall,
            "video"=>TranscriptionEngineAConfigModel.Video,
            "default"=>TranscriptionEngineAConfigModel.Default,
            "medical_conversation"=>TranscriptionEngineAConfigModel.MedicalConversation,
            "medical_dictation"=>TranscriptionEngineAConfigModel.MedicalDictation,
            _ =>(TranscriptionEngineAConfigModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineAConfigModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineAConfigModel.LatestLong=>"latest_long",
            TranscriptionEngineAConfigModel.LatestShort=>"latest_short",
            TranscriptionEngineAConfigModel.CommandAndSearch=>"command_and_search",
            TranscriptionEngineAConfigModel.PhoneCall=>"phone_call",
            TranscriptionEngineAConfigModel.Video=>"video",
            TranscriptionEngineAConfigModel.Default=>"default",
            TranscriptionEngineAConfigModel.MedicalConversation=>"medical_conversation",
            TranscriptionEngineAConfigModel.MedicalDictation=>"medical_dictation",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<SpeechContext, SpeechContextFromRaw>))]
public sealed record class SpeechContext : JsonModel
{
    /// <summary>
    /// Boost factor for the speech context.
    /// </summary>
    public double? Boost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "boost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("boost", value);
        }
    }

    public IReadOnlyList<string>? Phrases {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "phrases"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "phrases",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Boost;
        _ = this.Phrases;
    }

    public SpeechContext ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechContext (SpeechContext speechContext) : base(speechContext)
    {  }
    #pragma warning restore CS8618

    public SpeechContext (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechContext (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SpeechContextFromRaw.FromRawUnchecked"/>
    public static SpeechContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SpeechContextFromRaw : IFromRawJson<SpeechContext>
{
    /// <inheritdoc/>
    public SpeechContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SpeechContext.FromRawUnchecked(rawData);
}/// <summary>
/// Engine identifier for Google transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineAConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineAConfigTranscriptionEngine
{
    A
}sealed class TranscriptionEngineAConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineAConfigTranscriptionEngine>
{
    public override TranscriptionEngineAConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "A"=>TranscriptionEngineAConfigTranscriptionEngine.A,
            _ =>(TranscriptionEngineAConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineAConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineAConfigTranscriptionEngine.A=>"A",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}