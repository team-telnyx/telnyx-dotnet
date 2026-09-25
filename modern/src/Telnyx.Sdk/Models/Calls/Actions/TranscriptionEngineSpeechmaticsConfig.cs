using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineSpeechmaticsConfig, TranscriptionEngineSpeechmaticsConfigFromRaw>))]
public sealed record class TranscriptionEngineSpeechmaticsConfig : JsonModel
{
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
    public ApiEnum<string, TranscriptionEngineSpeechmaticsConfigLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineSpeechmaticsConfigLanguage>>(
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
    /// Engine identifier for Speechmatics transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineSpeechmaticsConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineSpeechmaticsConfigTranscriptionEngine>>(
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
    /// The model to use for transcription.
    /// </summary>
    public ApiEnum<string, TranscriptionEngineSpeechmaticsConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineSpeechmaticsConfigTranscriptionModel>>(
                "transcription_model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_model", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InterimResults;
        this.Language?.Validate();
        this.TranscriptionEngine?.Validate();
        this.TranscriptionModel?.Validate();
    }

    public TranscriptionEngineSpeechmaticsConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineSpeechmaticsConfig (
        TranscriptionEngineSpeechmaticsConfig transcriptionEngineSpeechmaticsConfig
    ) : base(transcriptionEngineSpeechmaticsConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineSpeechmaticsConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineSpeechmaticsConfig (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineSpeechmaticsConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineSpeechmaticsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineSpeechmaticsConfigFromRaw : IFromRawJson<TranscriptionEngineSpeechmaticsConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineSpeechmaticsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineSpeechmaticsConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Language to use for speech recognition
/// </summary>
[JsonConverter(typeof(TranscriptionEngineSpeechmaticsConfigLanguageConverter))]
public enum TranscriptionEngineSpeechmaticsConfigLanguage
{
    En,
    Ba,
    Eu,
    Gl,
    Ga,
    Mt,
    Mn,
    Sw,
    Ug,
    Cy,
    ArEn,
    CmnEn,
    EnMs,
    EnTa,
    Tl,
    EsBilingualEn,
    CmnEnMsTa
}sealed class TranscriptionEngineSpeechmaticsConfigLanguageConverter : JsonConverter<TranscriptionEngineSpeechmaticsConfigLanguage>
{
    public override TranscriptionEngineSpeechmaticsConfigLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "en"=>TranscriptionEngineSpeechmaticsConfigLanguage.En,
            "ba"=>TranscriptionEngineSpeechmaticsConfigLanguage.Ba,
            "eu"=>TranscriptionEngineSpeechmaticsConfigLanguage.Eu,
            "gl"=>TranscriptionEngineSpeechmaticsConfigLanguage.Gl,
            "ga"=>TranscriptionEngineSpeechmaticsConfigLanguage.Ga,
            "mt"=>TranscriptionEngineSpeechmaticsConfigLanguage.Mt,
            "mn"=>TranscriptionEngineSpeechmaticsConfigLanguage.Mn,
            "sw"=>TranscriptionEngineSpeechmaticsConfigLanguage.Sw,
            "ug"=>TranscriptionEngineSpeechmaticsConfigLanguage.Ug,
            "cy"=>TranscriptionEngineSpeechmaticsConfigLanguage.Cy,
            "ar_en"=>TranscriptionEngineSpeechmaticsConfigLanguage.ArEn,
            "cmn_en"=>TranscriptionEngineSpeechmaticsConfigLanguage.CmnEn,
            "en_ms"=>TranscriptionEngineSpeechmaticsConfigLanguage.EnMs,
            "en_ta"=>TranscriptionEngineSpeechmaticsConfigLanguage.EnTa,
            "tl"=>TranscriptionEngineSpeechmaticsConfigLanguage.Tl,
            "es-bilingual-en"=>TranscriptionEngineSpeechmaticsConfigLanguage.EsBilingualEn,
            "cmn_en_ms_ta"=>TranscriptionEngineSpeechmaticsConfigLanguage.CmnEnMsTa,
            _ =>(TranscriptionEngineSpeechmaticsConfigLanguage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineSpeechmaticsConfigLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineSpeechmaticsConfigLanguage.En=>"en",
            TranscriptionEngineSpeechmaticsConfigLanguage.Ba=>"ba",
            TranscriptionEngineSpeechmaticsConfigLanguage.Eu=>"eu",
            TranscriptionEngineSpeechmaticsConfigLanguage.Gl=>"gl",
            TranscriptionEngineSpeechmaticsConfigLanguage.Ga=>"ga",
            TranscriptionEngineSpeechmaticsConfigLanguage.Mt=>"mt",
            TranscriptionEngineSpeechmaticsConfigLanguage.Mn=>"mn",
            TranscriptionEngineSpeechmaticsConfigLanguage.Sw=>"sw",
            TranscriptionEngineSpeechmaticsConfigLanguage.Ug=>"ug",
            TranscriptionEngineSpeechmaticsConfigLanguage.Cy=>"cy",
            TranscriptionEngineSpeechmaticsConfigLanguage.ArEn=>"ar_en",
            TranscriptionEngineSpeechmaticsConfigLanguage.CmnEn=>"cmn_en",
            TranscriptionEngineSpeechmaticsConfigLanguage.EnMs=>"en_ms",
            TranscriptionEngineSpeechmaticsConfigLanguage.EnTa=>"en_ta",
            TranscriptionEngineSpeechmaticsConfigLanguage.Tl=>"tl",
            TranscriptionEngineSpeechmaticsConfigLanguage.EsBilingualEn=>"es-bilingual-en",
            TranscriptionEngineSpeechmaticsConfigLanguage.CmnEnMsTa=>"cmn_en_ms_ta",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Engine identifier for Speechmatics transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineSpeechmaticsConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineSpeechmaticsConfigTranscriptionEngine
{
    Speechmatics
}sealed class TranscriptionEngineSpeechmaticsConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineSpeechmaticsConfigTranscriptionEngine>
{
    public override TranscriptionEngineSpeechmaticsConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Speechmatics"=>TranscriptionEngineSpeechmaticsConfigTranscriptionEngine.Speechmatics,
            _ =>(TranscriptionEngineSpeechmaticsConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineSpeechmaticsConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineSpeechmaticsConfigTranscriptionEngine.Speechmatics=>"Speechmatics",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineSpeechmaticsConfigTranscriptionModelConverter))]
public enum TranscriptionEngineSpeechmaticsConfigTranscriptionModel
{
    SpeechmaticsStandard
}sealed class TranscriptionEngineSpeechmaticsConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineSpeechmaticsConfigTranscriptionModel>
{
    public override TranscriptionEngineSpeechmaticsConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "speechmatics/standard"=>TranscriptionEngineSpeechmaticsConfigTranscriptionModel.SpeechmaticsStandard,
            _ =>(TranscriptionEngineSpeechmaticsConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineSpeechmaticsConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineSpeechmaticsConfigTranscriptionModel.SpeechmaticsStandard=>"speechmatics/standard",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}