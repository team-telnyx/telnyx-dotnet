using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<TranscriptionSettings, TranscriptionSettingsFromRaw>))]
public sealed record class TranscriptionSettings : JsonModel
{
    /// <summary>
    /// Integration secret identifier for the transcription provider API key. Currently
    /// used for Azure transcription regions that require a customer-provided API key.
    /// </summary>
    public string? ApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("api_key_ref", value);
        }
    }

    /// <summary>
    /// The language of the audio to be transcribed. If not set, or if set to `auto`,
    /// supported models will automatically detect the language. For `deepgram/flux`,
    /// supported values are: `auto` (Telnyx language detection controls the language
    /// hint), `multi` (no language hint), and language-specific hints `en`, `es`,
    /// `fr`, `de`, `hi`, `ru`, `pt`, `ja`, `it`, and `nl`. For `soniox/stt-rt-v4`
    /// and `soniox/stt-rt-v5`, `auto` omits the language hint and lets Soniox auto-detect;
    /// ISO 639-1 codes (e.g. `en`, `es`) bias detection toward that language; `settings.language_hints`
    /// can pin multiple languages at once instead. For `humain/realtime`, supported
    /// values are `ar`, `en`, `codeswitch` (Arabic/English code-switching), and `auto`
    /// (resolves server-side to code-switching). Unlike other models, `humain/realtime`
    /// does not fall back to `auto` when `language` is omitted — omitting it applies
    /// `en` instead. For `reson8/turns`, supported values are `auto` (or unset)
    /// for automatic language detection, and the language codes `nl`, `en`, `fr`,
    /// `fy`, `de`, `it`, `pl`, `pt`, `es`, and `sv` to fix the transcription language.
    /// For `cohere/ar-stt`, supported values are `ar` and `en`; unlike other models,
    /// this model does not auto-detect and defaults to `ar` when `language` is omitted.
    /// </summary>
    public string? Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// The speech to text model to be used by the voice assistant. All Deepgram
    /// models are run on-premise.
    ///
    /// <para>- `deepgram/flux` is optimized for turn-taking with multilingual language
    /// hints. - `deepgram/nova-3` is multilingual with automatic language detection.
    /// - `deepgram/nova-2` is Deepgram's previous-generation multilingual model.
    /// - `azure/fast` is a multilingual Azure transcription model. - `assemblyai/universal-3-5-pro`
    /// is a multilingual streaming model with configurable turn detection. The legacy
    /// alias `assemblyai/universal-streaming` is still accepted and resolves to
    /// the same model. - `xai/grok-stt` is a multilingual Grok STT model. - `soniox/stt-rt-v4`
    /// and `soniox/stt-rt-v5` are multilingual streaming models with automatic language
    /// detection, configurable endpointing, term biasing (`context`), and `language_hints`.
    /// - `nvidia/parakeet-v3` is a multilingual transcription model with automatic
    /// language detection. - `omi-health/omi-med-stt-v1` is an English-only medical
    /// transcription model (Parakeet-based). - `humain/realtime` is a streaming model
    /// with native Arabic and Arabic/English code-switching support. - `reson8/turns`
    /// is a turn-based streaming model covering 10 European languages with automatic
    /// language detection. - `cohere/ar-stt` is a non-streaming Arabic and English
    /// transcription model.</para>
    /// </summary>
    public ApiEnum<string, Model>? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Model>>(
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
    /// Region on third party cloud providers (currently Azure) if using one of their
    /// models. Some regions require `api_key_ref`.
    /// </summary>
    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    public TranscriptionSettingsConfig? Settings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TranscriptionSettingsConfig>(
                "settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("settings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKeyRef;
        _ = this.Language;
        this.Model?.Validate();
        _ = this.Region;
        this.Settings?.Validate();
    }

    public TranscriptionSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionSettings (
        TranscriptionSettings transcriptionSettings
    ) : base(transcriptionSettings)
    {  }
    #pragma warning restore CS8618

    public TranscriptionSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionSettingsFromRaw.FromRawUnchecked"/>
    public static TranscriptionSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionSettingsFromRaw : IFromRawJson<TranscriptionSettings>
{
    /// <inheritdoc/>
    public TranscriptionSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// The speech to text model to be used by the voice assistant. All Deepgram models
/// are run on-premise.
///
/// <para>- `deepgram/flux` is optimized for turn-taking with multilingual language
/// hints. - `deepgram/nova-3` is multilingual with automatic language detection.
/// - `deepgram/nova-2` is Deepgram's previous-generation multilingual model. - `azure/fast`
/// is a multilingual Azure transcription model. - `assemblyai/universal-3-5-pro`
/// is a multilingual streaming model with configurable turn detection. The legacy
/// alias `assemblyai/universal-streaming` is still accepted and resolves to the same
/// model. - `xai/grok-stt` is a multilingual Grok STT model. - `soniox/stt-rt-v4`
/// and `soniox/stt-rt-v5` are multilingual streaming models with automatic language
/// detection, configurable endpointing, term biasing (`context`), and `language_hints`.
/// - `nvidia/parakeet-v3` is a multilingual transcription model with automatic language
/// detection. - `omi-health/omi-med-stt-v1` is an English-only medical transcription
/// model (Parakeet-based). - `humain/realtime` is a streaming model with native
/// Arabic and Arabic/English code-switching support. - `reson8/turns` is a turn-based
/// streaming model covering 10 European languages with automatic language detection.
/// - `cohere/ar-stt` is a non-streaming Arabic and English transcription model.</para>
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public enum Model
{
    DeepgramFlux,
    DeepgramNova3,
    DeepgramNova2,
    AzureFast,
    AssemblyaiUniversal3_5Pro,
    AssemblyaiUniversalStreaming,
    XaiGrokStt,
    SonioxSttRtV4,
    SonioxSttRtV5,
    NvidiaParakeetV3,
    OmiHealthOmiMedSttV1,
    HumainRealtime,
    Reson8Turns,
    CohereArStt,
    DistilWhisperDistilLargeV2,
    OpenAIWhisperLargeV3Turbo
}sealed class ModelConverter : JsonConverter<Model>
{
    public override Model Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deepgram/flux"=>Model.DeepgramFlux,
            "deepgram/nova-3"=>Model.DeepgramNova3,
            "deepgram/nova-2"=>Model.DeepgramNova2,
            "azure/fast"=>Model.AzureFast,
            "assemblyai/universal-3-5-pro"=>Model.AssemblyaiUniversal3_5Pro,
            "assemblyai/universal-streaming"=>Model.AssemblyaiUniversalStreaming,
            "xai/grok-stt"=>Model.XaiGrokStt,
            "soniox/stt-rt-v4"=>Model.SonioxSttRtV4,
            "soniox/stt-rt-v5"=>Model.SonioxSttRtV5,
            "nvidia/parakeet-v3"=>Model.NvidiaParakeetV3,
            "omi-health/omi-med-stt-v1"=>Model.OmiHealthOmiMedSttV1,
            "humain/realtime"=>Model.HumainRealtime,
            "reson8/turns"=>Model.Reson8Turns,
            "cohere/ar-stt"=>Model.CohereArStt,
            "distil-whisper/distil-large-v2"=>Model.DistilWhisperDistilLargeV2,
            "openai/whisper-large-v3-turbo"=>Model.OpenAIWhisperLargeV3Turbo,
            _ =>(Model)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Model value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Model.DeepgramFlux=>"deepgram/flux",
            Model.DeepgramNova3=>"deepgram/nova-3",
            Model.DeepgramNova2=>"deepgram/nova-2",
            Model.AzureFast=>"azure/fast",
            Model.AssemblyaiUniversal3_5Pro=>"assemblyai/universal-3-5-pro",
            Model.AssemblyaiUniversalStreaming=>"assemblyai/universal-streaming",
            Model.XaiGrokStt=>"xai/grok-stt",
            Model.SonioxSttRtV4=>"soniox/stt-rt-v4",
            Model.SonioxSttRtV5=>"soniox/stt-rt-v5",
            Model.NvidiaParakeetV3=>"nvidia/parakeet-v3",
            Model.OmiHealthOmiMedSttV1=>"omi-health/omi-med-stt-v1",
            Model.HumainRealtime=>"humain/realtime",
            Model.Reson8Turns=>"reson8/turns",
            Model.CohereArStt=>"cohere/ar-stt",
            Model.DistilWhisperDistilLargeV2=>"distil-whisper/distil-large-v2",
            Model.OpenAIWhisperLargeV3Turbo=>"openai/whisper-large-v3-turbo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}