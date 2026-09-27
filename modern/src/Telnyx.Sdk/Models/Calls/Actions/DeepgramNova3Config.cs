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

[JsonConverter(typeof(JsonModelConverter<DeepgramNova3Config, DeepgramNova3ConfigFromRaw>))]
public sealed record class DeepgramNova3Config : JsonModel
{
    public required ApiEnum<string, DeepgramNova3ConfigTranscriptionEngine> TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeepgramNova3ConfigTranscriptionEngine>>(
                "transcription_engine"
            );
        }
        init { this._rawData.Set("transcription_engine", value); }
    }

    public required ApiEnum<string, DeepgramNova3ConfigTranscriptionModel> TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeepgramNova3ConfigTranscriptionModel>>(
                "transcription_model"
            );
        }
        init { this._rawData.Set("transcription_model", value); }
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
    /// Nova-3 keyterm prompting. Up to 100 domain-specific terms or brand names to
    /// bias recognition toward. Nova-3-only; use `hints` on Nova-2.
    /// </summary>
    public IReadOnlyList<string>? Keyterms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "keyterms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "keyterms",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Keywords and their respective intensifiers (boosting values) to improve transcription
    /// accuracy for specific words or phrases. The intensifier should be a numeric
    /// value. Example: `{"snuffleupagus": 5, "systrom": 2, "krieger": 1}`.
    /// </summary>
    public IReadOnlyDictionary<string, double>? KeywordsBoosting {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, double>>(
                "keywords_boosting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, double>?>(
                "keywords_boosting",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Language to use for speech recognition with nova-3 model
    /// </summary>
    public ApiEnum<string, DeepgramNova3ConfigLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DeepgramNova3ConfigLanguage>>(
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
    /// Enable Deepgram's smart formatting (capitalization, punctuation, and digit
    /// normalization). Note: Telnyx defaults this to `true`, overriding Deepgram's
    /// underlying default of `false` — omit the field to get a smart-formatted transcript,
    /// or set it to `false` to receive the raw lowercase transcript without punctuation.
    /// </summary>
    public bool? SmartFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "smart_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("smart_format", value);
        }
    }

    /// <summary>
    /// Number of milliseconds of silence to consider an utterance ended. Ranges from
    /// 0 to 5000 ms.
    /// </summary>
    public long? UtteranceEndMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "utterance_end_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("utterance_end_ms", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.TranscriptionEngine.Validate();
        this.TranscriptionModel.Validate();
        _ = this.InterimResults;
        _ = this.Keyterms;
        _ = this.KeywordsBoosting;
        this.Language?.Validate();
        _ = this.SmartFormat;
        _ = this.UtteranceEndMs;
    }

    public DeepgramNova3Config ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeepgramNova3Config (DeepgramNova3Config deepgramNova3Config) : base(
        deepgramNova3Config
    )
    {  }
    #pragma warning restore CS8618

    public DeepgramNova3Config (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DeepgramNova3Config (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DeepgramNova3ConfigFromRaw.FromRawUnchecked"/>
    public static DeepgramNova3Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DeepgramNova3ConfigFromRaw : IFromRawJson<DeepgramNova3Config>
{
    /// <inheritdoc/>
    public DeepgramNova3Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DeepgramNova3Config.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DeepgramNova3ConfigTranscriptionEngineConverter))]
public enum DeepgramNova3ConfigTranscriptionEngine
{
    DeepgramNova3
}sealed class DeepgramNova3ConfigTranscriptionEngineConverter : JsonConverter<DeepgramNova3ConfigTranscriptionEngine>
{
    public override DeepgramNova3ConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deepgram/nova-3"=>DeepgramNova3ConfigTranscriptionEngine.DeepgramNova3,
            _ =>(DeepgramNova3ConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeepgramNova3ConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeepgramNova3ConfigTranscriptionEngine.DeepgramNova3=>"deepgram/nova-3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(DeepgramNova3ConfigTranscriptionModelConverter))]
public enum DeepgramNova3ConfigTranscriptionModel
{
    DeepgramNova3
}sealed class DeepgramNova3ConfigTranscriptionModelConverter : JsonConverter<DeepgramNova3ConfigTranscriptionModel>
{
    public override DeepgramNova3ConfigTranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deepgram/nova-3"=>DeepgramNova3ConfigTranscriptionModel.DeepgramNova3,
            _ =>(DeepgramNova3ConfigTranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeepgramNova3ConfigTranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeepgramNova3ConfigTranscriptionModel.DeepgramNova3=>"deepgram/nova-3",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Language to use for speech recognition with nova-3 model
/// </summary>
[JsonConverter(typeof(DeepgramNova3ConfigLanguageConverter))]
public enum DeepgramNova3ConfigLanguage
{
    EnUs,
    EnAu,
    EnGB,
    EnIn,
    EnNz,
    De,
    Nl,
    SvSe,
    DaDk,
    Es,
    Es419,
    Fr,
    FrCa,
    PtBr,
    PtPt,
    AutoDetect
}sealed class DeepgramNova3ConfigLanguageConverter : JsonConverter<DeepgramNova3ConfigLanguage>
{
    public override DeepgramNova3ConfigLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "en-US"=>DeepgramNova3ConfigLanguage.EnUs,
            "en-AU"=>DeepgramNova3ConfigLanguage.EnAu,
            "en-GB"=>DeepgramNova3ConfigLanguage.EnGB,
            "en-IN"=>DeepgramNova3ConfigLanguage.EnIn,
            "en-NZ"=>DeepgramNova3ConfigLanguage.EnNz,
            "de"=>DeepgramNova3ConfigLanguage.De,
            "nl"=>DeepgramNova3ConfigLanguage.Nl,
            "sv-SE"=>DeepgramNova3ConfigLanguage.SvSe,
            "da-DK"=>DeepgramNova3ConfigLanguage.DaDk,
            "es"=>DeepgramNova3ConfigLanguage.Es,
            "es-419"=>DeepgramNova3ConfigLanguage.Es419,
            "fr"=>DeepgramNova3ConfigLanguage.Fr,
            "fr-CA"=>DeepgramNova3ConfigLanguage.FrCa,
            "pt-BR"=>DeepgramNova3ConfigLanguage.PtBr,
            "pt-PT"=>DeepgramNova3ConfigLanguage.PtPt,
            "auto_detect"=>DeepgramNova3ConfigLanguage.AutoDetect,
            _ =>(DeepgramNova3ConfigLanguage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeepgramNova3ConfigLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeepgramNova3ConfigLanguage.EnUs=>"en-US",
            DeepgramNova3ConfigLanguage.EnAu=>"en-AU",
            DeepgramNova3ConfigLanguage.EnGB=>"en-GB",
            DeepgramNova3ConfigLanguage.EnIn=>"en-IN",
            DeepgramNova3ConfigLanguage.EnNz=>"en-NZ",
            DeepgramNova3ConfigLanguage.De=>"de",
            DeepgramNova3ConfigLanguage.Nl=>"nl",
            DeepgramNova3ConfigLanguage.SvSe=>"sv-SE",
            DeepgramNova3ConfigLanguage.DaDk=>"da-DK",
            DeepgramNova3ConfigLanguage.Es=>"es",
            DeepgramNova3ConfigLanguage.Es419=>"es-419",
            DeepgramNova3ConfigLanguage.Fr=>"fr",
            DeepgramNova3ConfigLanguage.FrCa=>"fr-CA",
            DeepgramNova3ConfigLanguage.PtBr=>"pt-BR",
            DeepgramNova3ConfigLanguage.PtPt=>"pt-PT",
            DeepgramNova3ConfigLanguage.AutoDetect=>"auto_detect",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}