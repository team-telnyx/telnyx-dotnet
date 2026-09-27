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

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineGoogleConfig, TranscriptionEngineGoogleConfigFromRaw>))]
public sealed record class TranscriptionEngineGoogleConfig : JsonModel
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
    public ApiEnum<string, TranscriptionEngineGoogleConfigModel>? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineGoogleConfigModel>>(
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
    public IReadOnlyList<TranscriptionEngineGoogleConfigSpeechContext>? SpeechContext {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TranscriptionEngineGoogleConfigSpeechContext>>(
                "speech_context"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TranscriptionEngineGoogleConfigSpeechContext>?>(
                "speech_context",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Engine identifier for Google transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineGoogleConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineGoogleConfigTranscriptionEngine>>(
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

    public TranscriptionEngineGoogleConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineGoogleConfig (
        TranscriptionEngineGoogleConfig transcriptionEngineGoogleConfig
    ) : base(transcriptionEngineGoogleConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineGoogleConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineGoogleConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineGoogleConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineGoogleConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineGoogleConfigFromRaw : IFromRawJson<TranscriptionEngineGoogleConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineGoogleConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineGoogleConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineGoogleConfigModelConverter))]
public enum TranscriptionEngineGoogleConfigModel
{
    LatestLong,
    LatestShort,
    CommandAndSearch,
    PhoneCall,
    Video,
    Default,
    MedicalConversation,
    MedicalDictation
}sealed class TranscriptionEngineGoogleConfigModelConverter : JsonConverter<TranscriptionEngineGoogleConfigModel>
{
    public override TranscriptionEngineGoogleConfigModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "latest_long"=>TranscriptionEngineGoogleConfigModel.LatestLong,
            "latest_short"=>TranscriptionEngineGoogleConfigModel.LatestShort,
            "command_and_search"=>TranscriptionEngineGoogleConfigModel.CommandAndSearch,
            "phone_call"=>TranscriptionEngineGoogleConfigModel.PhoneCall,
            "video"=>TranscriptionEngineGoogleConfigModel.Video,
            "default"=>TranscriptionEngineGoogleConfigModel.Default,
            "medical_conversation"=>TranscriptionEngineGoogleConfigModel.MedicalConversation,
            "medical_dictation"=>TranscriptionEngineGoogleConfigModel.MedicalDictation,
            _ =>(TranscriptionEngineGoogleConfigModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineGoogleConfigModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineGoogleConfigModel.LatestLong=>"latest_long",
            TranscriptionEngineGoogleConfigModel.LatestShort=>"latest_short",
            TranscriptionEngineGoogleConfigModel.CommandAndSearch=>"command_and_search",
            TranscriptionEngineGoogleConfigModel.PhoneCall=>"phone_call",
            TranscriptionEngineGoogleConfigModel.Video=>"video",
            TranscriptionEngineGoogleConfigModel.Default=>"default",
            TranscriptionEngineGoogleConfigModel.MedicalConversation=>"medical_conversation",
            TranscriptionEngineGoogleConfigModel.MedicalDictation=>"medical_dictation",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineGoogleConfigSpeechContext, TranscriptionEngineGoogleConfigSpeechContextFromRaw>))]
public sealed record class TranscriptionEngineGoogleConfigSpeechContext : JsonModel
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

    public TranscriptionEngineGoogleConfigSpeechContext ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineGoogleConfigSpeechContext (
        TranscriptionEngineGoogleConfigSpeechContext transcriptionEngineGoogleConfigSpeechContext
    ) : base(transcriptionEngineGoogleConfigSpeechContext)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineGoogleConfigSpeechContext (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineGoogleConfigSpeechContext (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineGoogleConfigSpeechContextFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineGoogleConfigSpeechContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TranscriptionEngineGoogleConfigSpeechContextFromRaw : IFromRawJson<TranscriptionEngineGoogleConfigSpeechContext>
{
    /// <inheritdoc/>
    public TranscriptionEngineGoogleConfigSpeechContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineGoogleConfigSpeechContext.FromRawUnchecked(rawData);
}/// <summary>
/// Engine identifier for Google transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineGoogleConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineGoogleConfigTranscriptionEngine
{
    Google
}sealed class TranscriptionEngineGoogleConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineGoogleConfigTranscriptionEngine>
{
    public override TranscriptionEngineGoogleConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Google"=>TranscriptionEngineGoogleConfigTranscriptionEngine.Google,
            _ =>(TranscriptionEngineGoogleConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineGoogleConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineGoogleConfigTranscriptionEngine.Google=>"Google",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}