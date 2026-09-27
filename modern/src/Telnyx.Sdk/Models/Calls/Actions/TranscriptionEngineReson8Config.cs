using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionEngineReson8Config, TranscriptionEngineReson8ConfigFromRaw>))]
public sealed record class TranscriptionEngineReson8Config : JsonModel
{
    /// <summary>
    /// The language of the audio to be transcribed. `auto` (the default, also applied
    /// when `language` is omitted) enables automatic language detection.
    /// </summary>
    public ApiEnum<string, TranscriptionEngineReson8ConfigLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineReson8ConfigLanguage>>(
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
    /// Engine identifier for Reson8 transcription service
    /// </summary>
    public ApiEnum<string, TranscriptionEngineReson8ConfigTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineReson8ConfigTranscriptionEngine>>(
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
    public ApiEnum<string, TranscriptionEngineReson8ConfigTranscriptionModel>? TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionEngineReson8ConfigTranscriptionModel>>(
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
        this.Language?.Validate();
        this.TranscriptionEngine?.Validate();
        this.TranscriptionModel?.Validate();
    }

    public TranscriptionEngineReson8Config ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionEngineReson8Config (
        TranscriptionEngineReson8Config transcriptionEngineReson8Config
    ) : base(transcriptionEngineReson8Config)
    {  }
    #pragma warning restore CS8618

    public TranscriptionEngineReson8Config (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionEngineReson8Config (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionEngineReson8ConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionEngineReson8Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionEngineReson8ConfigFromRaw : IFromRawJson<TranscriptionEngineReson8Config>
{
    /// <inheritdoc/>
    public TranscriptionEngineReson8Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionEngineReson8Config.FromRawUnchecked(rawData);
}

/// <summary>
/// The language of the audio to be transcribed. `auto` (the default, also applied
/// when `language` is omitted) enables automatic language detection.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineReson8ConfigLanguageConverter))]
public enum TranscriptionEngineReson8ConfigLanguage
{
    Auto, Nl, En, Fr, Fy, De, It, Pl, Pt, Es, Sv
}sealed class TranscriptionEngineReson8ConfigLanguageConverter : JsonConverter<TranscriptionEngineReson8ConfigLanguage>
{
    public override TranscriptionEngineReson8ConfigLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto"=>TranscriptionEngineReson8ConfigLanguage.Auto,
            "nl"=>TranscriptionEngineReson8ConfigLanguage.Nl,
            "en"=>TranscriptionEngineReson8ConfigLanguage.En,
            "fr"=>TranscriptionEngineReson8ConfigLanguage.Fr,
            "fy"=>TranscriptionEngineReson8ConfigLanguage.Fy,
            "de"=>TranscriptionEngineReson8ConfigLanguage.De,
            "it"=>TranscriptionEngineReson8ConfigLanguage.It,
            "pl"=>TranscriptionEngineReson8ConfigLanguage.Pl,
            "pt"=>TranscriptionEngineReson8ConfigLanguage.Pt,
            "es"=>TranscriptionEngineReson8ConfigLanguage.Es,
            "sv"=>TranscriptionEngineReson8ConfigLanguage.Sv,
            _ =>(TranscriptionEngineReson8ConfigLanguage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineReson8ConfigLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineReson8ConfigLanguage.Auto=>"auto",
            TranscriptionEngineReson8ConfigLanguage.Nl=>"nl",
            TranscriptionEngineReson8ConfigLanguage.En=>"en",
            TranscriptionEngineReson8ConfigLanguage.Fr=>"fr",
            TranscriptionEngineReson8ConfigLanguage.Fy=>"fy",
            TranscriptionEngineReson8ConfigLanguage.De=>"de",
            TranscriptionEngineReson8ConfigLanguage.It=>"it",
            TranscriptionEngineReson8ConfigLanguage.Pl=>"pl",
            TranscriptionEngineReson8ConfigLanguage.Pt=>"pt",
            TranscriptionEngineReson8ConfigLanguage.Es=>"es",
            TranscriptionEngineReson8ConfigLanguage.Sv=>"sv",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Engine identifier for Reson8 transcription service
/// </summary>
[JsonConverter(typeof(TranscriptionEngineReson8ConfigTranscriptionEngineConverter))]
public enum TranscriptionEngineReson8ConfigTranscriptionEngine
{
    Reson8
}sealed class TranscriptionEngineReson8ConfigTranscriptionEngineConverter : JsonConverter<TranscriptionEngineReson8ConfigTranscriptionEngine>
{
    public override TranscriptionEngineReson8ConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Reson8"=>TranscriptionEngineReson8ConfigTranscriptionEngine.Reson8,
            _ =>(TranscriptionEngineReson8ConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineReson8ConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineReson8ConfigTranscriptionEngine.Reson8=>"Reson8",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The model to use for transcription.
/// </summary>
[JsonConverter(typeof(TranscriptionEngineReson8ConfigTranscriptionModelConverter))]
public enum TranscriptionEngineReson8ConfigTranscriptionModel
{
    Reson8Turns
}sealed class TranscriptionEngineReson8ConfigTranscriptionModelConverter : JsonConverter<TranscriptionEngineReson8ConfigTranscriptionModel>
{
    public override TranscriptionEngineReson8ConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "reson8/turns"=>TranscriptionEngineReson8ConfigTranscriptionModel.Reson8Turns,
            _ =>(TranscriptionEngineReson8ConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineReson8ConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionEngineReson8ConfigTranscriptionModel.Reson8Turns=>"reson8/turns",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}