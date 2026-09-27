using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineXaiConfig, TranscriptionEngineXaiConfigFromRaw>))]
public sealed record class TranscriptionEngineXaiConfig : JsonModel
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
    public ApiEnum<string, TranscriptionEngineXaiConfigLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineXaiConfigLanguage>>(
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
    /// Engine identifier for xAI transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineXaiConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineXaiConfigTranscriptionEngine>>(
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
    public ApiEnum<string, TranscriptionEngineXaiConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineXaiConfigTranscriptionModel>>(
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

    public TranscriptionEngineXaiConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineXaiConfig (
        TranscriptionEngineXaiConfig transcriptionEngineXaiConfig
    ) : base(transcriptionEngineXaiConfig)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineXaiConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineXaiConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineXaiConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineXaiConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineXaiConfigFromRaw : IFromRawJson<TranscriptionEngineXaiConfig>
{
    /// <inheritdoc/>
    public TranscriptionEngineXaiConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineXaiConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Language to use for speech recognition
/// </summary>
[JsonConverter(typeof(TranscriptionEngineXaiConfigLanguageConverter))]
public enum TranscriptionEngineXaiConfigLanguage
{
    Ar,
    Cs,
    Da,
    De,
    En,
    Es,
    Fa,
    Fil,
    Fr,
    Hi,
    ID,
    It,
    Ja,
    Ko,
    Mk,
    Ms,
    Nl,
    Pl,
    Pt,
    Ro,
    Ru,
    Sv,
    Th,
    Tr,
    Vi
}sealed class TranscriptionEngineXaiConfigLanguageConverter : JsonConverter<TranscriptionEngineXaiConfigLanguage>
{
    public override TranscriptionEngineXaiConfigLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ar"=>TranscriptionEngineXaiConfigLanguage.Ar,
            "cs"=>TranscriptionEngineXaiConfigLanguage.Cs,
            "da"=>TranscriptionEngineXaiConfigLanguage.Da,
            "de"=>TranscriptionEngineXaiConfigLanguage.De,
            "en"=>TranscriptionEngineXaiConfigLanguage.En,
            "es"=>TranscriptionEngineXaiConfigLanguage.Es,
            "fa"=>TranscriptionEngineXaiConfigLanguage.Fa,
            "fil"=>TranscriptionEngineXaiConfigLanguage.Fil,
            "fr"=>TranscriptionEngineXaiConfigLanguage.Fr,
            "hi"=>TranscriptionEngineXaiConfigLanguage.Hi,
            "id"=>TranscriptionEngineXaiConfigLanguage.ID,
            "it"=>TranscriptionEngineXaiConfigLanguage.It,
            "ja"=>TranscriptionEngineXaiConfigLanguage.Ja,
            "ko"=>TranscriptionEngineXaiConfigLanguage.Ko,
            "mk"=>TranscriptionEngineXaiConfigLanguage.Mk,
            "ms"=>TranscriptionEngineXaiConfigLanguage.Ms,
            "nl"=>TranscriptionEngineXaiConfigLanguage.Nl,
            "pl"=>TranscriptionEngineXaiConfigLanguage.Pl,
            "pt"=>TranscriptionEngineXaiConfigLanguage.Pt,
            "ro"=>TranscriptionEngineXaiConfigLanguage.Ro,
            "ru"=>TranscriptionEngineXaiConfigLanguage.Ru,
            "sv"=>TranscriptionEngineXaiConfigLanguage.Sv,
            "th"=>TranscriptionEngineXaiConfigLanguage.Th,
            "tr"=>TranscriptionEngineXaiConfigLanguage.Tr,
            "vi"=>TranscriptionEngineXaiConfigLanguage.Vi,
            _ =>(TranscriptionEngineXaiConfigLanguage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineXaiConfigLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineXaiConfigLanguage.Ar=>"ar",
            TranscriptionEngineXaiConfigLanguage.Cs=>"cs",
            TranscriptionEngineXaiConfigLanguage.Da=>"da",
            TranscriptionEngineXaiConfigLanguage.De=>"de",
            TranscriptionEngineXaiConfigLanguage.En=>"en",
            TranscriptionEngineXaiConfigLanguage.Es=>"es",
            TranscriptionEngineXaiConfigLanguage.Fa=>"fa",
            TranscriptionEngineXaiConfigLanguage.Fil=>"fil",
            TranscriptionEngineXaiConfigLanguage.Fr=>"fr",
            TranscriptionEngineXaiConfigLanguage.Hi=>"hi",
            TranscriptionEngineXaiConfigLanguage.ID=>"id",
            TranscriptionEngineXaiConfigLanguage.It=>"it",
            TranscriptionEngineXaiConfigLanguage.Ja=>"ja",
            TranscriptionEngineXaiConfigLanguage.Ko=>"ko",
            TranscriptionEngineXaiConfigLanguage.Mk=>"mk",
            TranscriptionEngineXaiConfigLanguage.Ms=>"ms",
            TranscriptionEngineXaiConfigLanguage.Nl=>"nl",
            TranscriptionEngineXaiConfigLanguage.Pl=>"pl",
            TranscriptionEngineXaiConfigLanguage.Pt=>"pt",
            TranscriptionEngineXaiConfigLanguage.Ro=>"ro",
            TranscriptionEngineXaiConfigLanguage.Ru=>"ru",
            TranscriptionEngineXaiConfigLanguage.Sv=>"sv",
            TranscriptionEngineXaiConfigLanguage.Th=>"th",
            TranscriptionEngineXaiConfigLanguage.Tr=>"tr",
            TranscriptionEngineXaiConfigLanguage.Vi=>"vi",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Engine identifier for xAI transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineXaiConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineXaiConfigTranscriptionEngine
{
    XAI
}sealed class TranscriptionEngineXaiConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineXaiConfigTranscriptionEngine>
{
    public override TranscriptionEngineXaiConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "xAI"=>TranscriptionEngineXaiConfigTranscriptionEngine.XAI,
            _ =>(TranscriptionEngineXaiConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineXaiConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineXaiConfigTranscriptionEngine.XAI=>"xAI",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineXaiConfigTranscriptionModelConverter))]
public enum TranscriptionEngineXaiConfigTranscriptionModel
{
    XaiGrokStt
}sealed class TranscriptionEngineXaiConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineXaiConfigTranscriptionModel>
{
    public override TranscriptionEngineXaiConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "xai/grok-stt"=>TranscriptionEngineXaiConfigTranscriptionModel.XaiGrokStt,
            _ =>(TranscriptionEngineXaiConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineXaiConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineXaiConfigTranscriptionModel.XaiGrokStt=>"xai/grok-stt",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}