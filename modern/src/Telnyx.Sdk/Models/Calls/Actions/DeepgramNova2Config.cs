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

[JsonConverter(typeof(JsonModelConverter<DeepgramNova2Config, DeepgramNova2ConfigFromRaw>))]
public sealed record class DeepgramNova2Config : JsonModel
{
    public required ApiEnum<string, DeepgramNova2ConfigTranscriptionEngine> TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeepgramNova2ConfigTranscriptionEngine>>(
                "transcription_engine"
            );
        }
        init { this._rawData.Set("transcription_engine", value); }
    }

    public required ApiEnum<string, TranscriptionModel> TranscriptionModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TranscriptionModel>>(
                "transcription_model"
            );
        }
        init { this._rawData.Set("transcription_model", value); }
    }

    /// <summary>
    /// Nova-2 keyword biasing without intensifiers. Up to 100 terms to bias recognition
    /// toward. For weighted biasing, use `keywords_boosting` instead. Nova-2-only;
    /// use `keyterms` on Nova-3.
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
    /// Language to use for speech recognition with nova-2 model
    /// </summary>
    public ApiEnum<string, DeepgramNova2ConfigLanguage>? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DeepgramNova2ConfigLanguage>>(
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
        _ = this.Hints;
        _ = this.InterimResults;
        _ = this.KeywordsBoosting;
        this.Language?.Validate();
        _ = this.SmartFormat;
        _ = this.UtteranceEndMs;
    }

    public DeepgramNova2Config ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeepgramNova2Config (DeepgramNova2Config deepgramNova2Config) : base(
        deepgramNova2Config
    )
    {  }
    #pragma warning restore CS8618

    public DeepgramNova2Config (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DeepgramNova2Config (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DeepgramNova2ConfigFromRaw.FromRawUnchecked"/>
    public static DeepgramNova2Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DeepgramNova2ConfigFromRaw : IFromRawJson<DeepgramNova2Config>
{
    /// <inheritdoc/>
    public DeepgramNova2Config FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DeepgramNova2Config.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DeepgramNova2ConfigTranscriptionEngineConverter))]
public enum DeepgramNova2ConfigTranscriptionEngine
{
    DeepgramNova2
}sealed class DeepgramNova2ConfigTranscriptionEngineConverter : JsonConverter<DeepgramNova2ConfigTranscriptionEngine>
{
    public override DeepgramNova2ConfigTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deepgram/nova-2"=>DeepgramNova2ConfigTranscriptionEngine.DeepgramNova2,
            _ =>(DeepgramNova2ConfigTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeepgramNova2ConfigTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeepgramNova2ConfigTranscriptionEngine.DeepgramNova2=>"deepgram/nova-2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(TranscriptionModelConverter))]
public enum TranscriptionModel
{
    DeepgramNova2
}sealed class TranscriptionModelConverter : JsonConverter<TranscriptionModel>
{
    public override TranscriptionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deepgram/nova-2"=>TranscriptionModel.DeepgramNova2,
            _ =>(TranscriptionModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionModel.DeepgramNova2=>"deepgram/nova-2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Language to use for speech recognition with nova-2 model
/// </summary>
[JsonConverter(typeof(DeepgramNova2ConfigLanguageConverter))]
public enum DeepgramNova2ConfigLanguage
{
    Bg,
    Ca,
    ZhCn,
    ZhHans,
    ZhTw,
    ZhHant,
    ZhHk,
    Cs,
    DaDk,
    NlBe,
    EnUs,
    EnAu,
    EnGB,
    EnNz,
    EnIn,
    Et,
    Fi,
    Fr,
    FrCa,
    DeCh,
    El,
    Hi,
    Hu,
    ID,
    It,
    Ja,
    KoKr,
    Lv,
    Lt,
    Ms,
    No,
    Pl,
    PtBr,
    PtPt,
    Ro,
    Ru,
    Sk,
    Es419,
    SvSe,
    ThTh,
    Tr,
    Uk,
    Vi,
    AutoDetect
}sealed class DeepgramNova2ConfigLanguageConverter : JsonConverter<DeepgramNova2ConfigLanguage>
{
    public override DeepgramNova2ConfigLanguage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bg"=>DeepgramNova2ConfigLanguage.Bg,
            "ca"=>DeepgramNova2ConfigLanguage.Ca,
            "zh-CN"=>DeepgramNova2ConfigLanguage.ZhCn,
            "zh-Hans"=>DeepgramNova2ConfigLanguage.ZhHans,
            "zh-TW"=>DeepgramNova2ConfigLanguage.ZhTw,
            "zh-Hant"=>DeepgramNova2ConfigLanguage.ZhHant,
            "zh-HK"=>DeepgramNova2ConfigLanguage.ZhHk,
            "cs"=>DeepgramNova2ConfigLanguage.Cs,
            "da-DK"=>DeepgramNova2ConfigLanguage.DaDk,
            "nl-BE"=>DeepgramNova2ConfigLanguage.NlBe,
            "en-US"=>DeepgramNova2ConfigLanguage.EnUs,
            "en-AU"=>DeepgramNova2ConfigLanguage.EnAu,
            "en-GB"=>DeepgramNova2ConfigLanguage.EnGB,
            "en-NZ"=>DeepgramNova2ConfigLanguage.EnNz,
            "en-IN"=>DeepgramNova2ConfigLanguage.EnIn,
            "et"=>DeepgramNova2ConfigLanguage.Et,
            "fi"=>DeepgramNova2ConfigLanguage.Fi,
            "fr"=>DeepgramNova2ConfigLanguage.Fr,
            "fr-CA"=>DeepgramNova2ConfigLanguage.FrCa,
            "de-CH"=>DeepgramNova2ConfigLanguage.DeCh,
            "el"=>DeepgramNova2ConfigLanguage.El,
            "hi"=>DeepgramNova2ConfigLanguage.Hi,
            "hu"=>DeepgramNova2ConfigLanguage.Hu,
            "id"=>DeepgramNova2ConfigLanguage.ID,
            "it"=>DeepgramNova2ConfigLanguage.It,
            "ja"=>DeepgramNova2ConfigLanguage.Ja,
            "ko-KR"=>DeepgramNova2ConfigLanguage.KoKr,
            "lv"=>DeepgramNova2ConfigLanguage.Lv,
            "lt"=>DeepgramNova2ConfigLanguage.Lt,
            "ms"=>DeepgramNova2ConfigLanguage.Ms,
            "no"=>DeepgramNova2ConfigLanguage.No,
            "pl"=>DeepgramNova2ConfigLanguage.Pl,
            "pt-BR"=>DeepgramNova2ConfigLanguage.PtBr,
            "pt-PT"=>DeepgramNova2ConfigLanguage.PtPt,
            "ro"=>DeepgramNova2ConfigLanguage.Ro,
            "ru"=>DeepgramNova2ConfigLanguage.Ru,
            "sk"=>DeepgramNova2ConfigLanguage.Sk,
            "es-419"=>DeepgramNova2ConfigLanguage.Es419,
            "sv-SE"=>DeepgramNova2ConfigLanguage.SvSe,
            "th-TH"=>DeepgramNova2ConfigLanguage.ThTh,
            "tr"=>DeepgramNova2ConfigLanguage.Tr,
            "uk"=>DeepgramNova2ConfigLanguage.Uk,
            "vi"=>DeepgramNova2ConfigLanguage.Vi,
            "auto_detect"=>DeepgramNova2ConfigLanguage.AutoDetect,
            _ =>(DeepgramNova2ConfigLanguage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeepgramNova2ConfigLanguage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeepgramNova2ConfigLanguage.Bg=>"bg",
            DeepgramNova2ConfigLanguage.Ca=>"ca",
            DeepgramNova2ConfigLanguage.ZhCn=>"zh-CN",
            DeepgramNova2ConfigLanguage.ZhHans=>"zh-Hans",
            DeepgramNova2ConfigLanguage.ZhTw=>"zh-TW",
            DeepgramNova2ConfigLanguage.ZhHant=>"zh-Hant",
            DeepgramNova2ConfigLanguage.ZhHk=>"zh-HK",
            DeepgramNova2ConfigLanguage.Cs=>"cs",
            DeepgramNova2ConfigLanguage.DaDk=>"da-DK",
            DeepgramNova2ConfigLanguage.NlBe=>"nl-BE",
            DeepgramNova2ConfigLanguage.EnUs=>"en-US",
            DeepgramNova2ConfigLanguage.EnAu=>"en-AU",
            DeepgramNova2ConfigLanguage.EnGB=>"en-GB",
            DeepgramNova2ConfigLanguage.EnNz=>"en-NZ",
            DeepgramNova2ConfigLanguage.EnIn=>"en-IN",
            DeepgramNova2ConfigLanguage.Et=>"et",
            DeepgramNova2ConfigLanguage.Fi=>"fi",
            DeepgramNova2ConfigLanguage.Fr=>"fr",
            DeepgramNova2ConfigLanguage.FrCa=>"fr-CA",
            DeepgramNova2ConfigLanguage.DeCh=>"de-CH",
            DeepgramNova2ConfigLanguage.El=>"el",
            DeepgramNova2ConfigLanguage.Hi=>"hi",
            DeepgramNova2ConfigLanguage.Hu=>"hu",
            DeepgramNova2ConfigLanguage.ID=>"id",
            DeepgramNova2ConfigLanguage.It=>"it",
            DeepgramNova2ConfigLanguage.Ja=>"ja",
            DeepgramNova2ConfigLanguage.KoKr=>"ko-KR",
            DeepgramNova2ConfigLanguage.Lv=>"lv",
            DeepgramNova2ConfigLanguage.Lt=>"lt",
            DeepgramNova2ConfigLanguage.Ms=>"ms",
            DeepgramNova2ConfigLanguage.No=>"no",
            DeepgramNova2ConfigLanguage.Pl=>"pl",
            DeepgramNova2ConfigLanguage.PtBr=>"pt-BR",
            DeepgramNova2ConfigLanguage.PtPt=>"pt-PT",
            DeepgramNova2ConfigLanguage.Ro=>"ro",
            DeepgramNova2ConfigLanguage.Ru=>"ru",
            DeepgramNova2ConfigLanguage.Sk=>"sk",
            DeepgramNova2ConfigLanguage.Es419=>"es-419",
            DeepgramNova2ConfigLanguage.SvSe=>"sv-SE",
            DeepgramNova2ConfigLanguage.ThTh=>"th-TH",
            DeepgramNova2ConfigLanguage.Tr=>"tr",
            DeepgramNova2ConfigLanguage.Uk=>"uk",
            DeepgramNova2ConfigLanguage.Vi=>"vi",
            DeepgramNova2ConfigLanguage.AutoDetect=>"auto_detect",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}