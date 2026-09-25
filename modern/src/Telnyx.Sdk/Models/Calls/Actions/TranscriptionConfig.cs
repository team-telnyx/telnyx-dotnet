using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// The settings associated with speech to text for the voice assistant. This is only
/// relevant if the assistant uses a text-to-text language model. Any assistant using
/// a model with native audio support (e.g. `fixie-ai/ultravox-v0_4`) will ignore
/// this field.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TranscriptionConfig, TranscriptionConfigFromRaw>))]
public sealed record class TranscriptionConfig : JsonModel
{
    /// <summary>
    /// The language of the audio to be transcribed. If not set, or if set to `auto`,
    /// supported models will automatically detect the language. Supported and meaningful
    /// values depend on the selected transcription `model`. For `deepgram/flux`,
    /// supported values are: `auto` (Telnyx language detection controls the language
    /// hint), `multi` (no language hint), and language-specific hints `en`, `es`,
    /// `fr`, `de`, `hi`, `ru`, `pt`, `ja`, `it`, and `nl`. For `soniox/stt-rt-v4`,
    /// `auto` omits the language hint and lets Soniox auto-detect; ISO 639-1 codes
    /// (e.g. `en`, `es`) bias detection toward that language. For `assemblyai/universal-3-5-pro`
    /// (and its legacy alias `assemblyai/universal-streaming`), `auto` (or unset)
    /// enables native multilingual code-switching; ISO 639-1 codes (`en`, `es`, `de`,
    /// `fr`, `pt`, `it`, `tr`, `nl`, `sv`, `no`, `da`, `fi`, `hi`, `vi`, `ar`, `he`,
    /// `ja`, `zh`) bias the session to that language. For `humain/realtime`, supported
    /// values are `ar`, `en`, `codeswitch` (Arabic/English code-switching), and
    /// `auto` (resolves server-side to code-switching). Unlike other models, `humain/realtime`
    /// does not fall back to `auto` when `language` is omitted — omitting it applies
    /// `en` instead. For `reson8/turns`, supported values are `auto` (or unset) for
    /// automatic language detection, and the language codes `nl`, `en`, `fr`, `fy`,
    /// `de`, `it`, `pl`, `pt`, `es`, and `sv` to fix the transcription language.
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
    /// The speech to text model to be used by the voice assistant. Supported models include:
    ///
    /// <para>- `deepgram/flux` (or `flux`) for live streaming turn-taking. - `deepgram/nova-3`
    /// and `deepgram/nova-2` for live streaming transcription. - `speechmatics/standard`
    /// and `speechmatics/enhanced` for live streaming transcription. - `assemblyai/universal-3-5-pro`
    /// for live streaming transcription. The legacy alias `assemblyai/universal-streaming`
    /// is still accepted and resolves to the same model. - `xai/grok-stt` for live
    /// streaming transcription. - `soniox/stt-rt-v4` for live streaming multilingual
    /// transcription with automatic language detection. - `nvidia/parakeet-v3` for
    /// multilingual transcription with automatic language detection. - `omi-health/omi-med-stt-v1`
    /// for English-only medical transcription (Parakeet-based). - `humain/realtime`
    /// for live streaming transcription with native Arabic and Arabic/English code-switching
    /// support. - `reson8/turns` for live streaming turn-based transcription of 10
    /// European languages with automatic language detection. - `cohere/ar-stt` for
    /// non-streaming Arabic and English transcription. - `azure/fast` and `azure/realtime`;
    /// Azure models require `region`, and unsupported regions require `api_key_ref`.
    /// - `google/latest_long` for non-streaming multilingual transcription. - `distil-whisper/distil-large-v2`
    /// for lower-latency English-only non-streaming transcription. - `openai/whisper-large-v3-turbo`
    /// for multilingual non-streaming transcription with automatic language detection.</para>
    /// </summary>
    public ApiEnum<string, TranscriptionConfigModel>? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionConfigModel>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Language;
        this.Model?.Validate();
    }

    public TranscriptionConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionConfig (TranscriptionConfig transcriptionConfig) : base(
        transcriptionConfig
    )
    {  }
    #pragma warning restore CS8618

    public TranscriptionConfig (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionConfigFromRaw.FromRawUnchecked"/>
    public static TranscriptionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionConfigFromRaw : IFromRawJson<TranscriptionConfig>
{
    /// <inheritdoc/>
    public TranscriptionConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The speech to text model to be used by the voice assistant. Supported models include:
///
/// <para>- `deepgram/flux` (or `flux`) for live streaming turn-taking. - `deepgram/nova-3`
/// and `deepgram/nova-2` for live streaming transcription. - `speechmatics/standard`
/// and `speechmatics/enhanced` for live streaming transcription. - `assemblyai/universal-3-5-pro`
/// for live streaming transcription. The legacy alias `assemblyai/universal-streaming`
/// is still accepted and resolves to the same model. - `xai/grok-stt` for live streaming
/// transcription. - `soniox/stt-rt-v4` for live streaming multilingual transcription
/// with automatic language detection. - `nvidia/parakeet-v3` for multilingual transcription
/// with automatic language detection. - `omi-health/omi-med-stt-v1` for English-only
/// medical transcription (Parakeet-based). - `humain/realtime` for live streaming
/// transcription with native Arabic and Arabic/English code-switching support. -
/// `reson8/turns` for live streaming turn-based transcription of 10 European languages
/// with automatic language detection. - `cohere/ar-stt` for non-streaming Arabic
/// and English transcription. - `azure/fast` and `azure/realtime`; Azure models
/// require `region`, and unsupported regions require `api_key_ref`. - `google/latest_long`
/// for non-streaming multilingual transcription. - `distil-whisper/distil-large-v2`
/// for lower-latency English-only non-streaming transcription. - `openai/whisper-large-v3-turbo`
/// for multilingual non-streaming transcription with automatic language detection.</para>
/// </summary>
[JsonConverter(typeof(TranscriptionConfigModelConverter))]
public enum TranscriptionConfigModel
{
    DeepgramFlux,
    Flux,
    DeepgramNova3,
    DeepgramNova2,
    SpeechmaticsStandard,
    SpeechmaticsEnhanced,
    AssemblyaiUniversal3_5Pro,
    AssemblyaiUniversalStreaming,
    XaiGrokStt,
    SonioxSttRtV4,
    NvidiaParakeetV3,
    OmiHealthOmiMedSttV1,
    HumainRealtime,
    Reson8Turns,
    CohereArStt,
    AzureFast,
    AzureRealtime,
    GoogleLatestLong,
    DistilWhisperDistilLargeV2,
    OpenAIWhisperLargeV3Turbo
}sealed class TranscriptionConfigModelConverter : JsonConverter<TranscriptionConfigModel>
{
    public override TranscriptionConfigModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deepgram/flux"=>TranscriptionConfigModel.DeepgramFlux,
            "flux"=>TranscriptionConfigModel.Flux,
            "deepgram/nova-3"=>TranscriptionConfigModel.DeepgramNova3,
            "deepgram/nova-2"=>TranscriptionConfigModel.DeepgramNova2,
            "speechmatics/standard"=>TranscriptionConfigModel.SpeechmaticsStandard,
            "speechmatics/enhanced"=>TranscriptionConfigModel.SpeechmaticsEnhanced,
            "assemblyai/universal-3-5-pro"=>TranscriptionConfigModel.AssemblyaiUniversal3_5Pro,
            "assemblyai/universal-streaming"=>TranscriptionConfigModel.AssemblyaiUniversalStreaming,
            "xai/grok-stt"=>TranscriptionConfigModel.XaiGrokStt,
            "soniox/stt-rt-v4"=>TranscriptionConfigModel.SonioxSttRtV4,
            "nvidia/parakeet-v3"=>TranscriptionConfigModel.NvidiaParakeetV3,
            "omi-health/omi-med-stt-v1"=>TranscriptionConfigModel.OmiHealthOmiMedSttV1,
            "humain/realtime"=>TranscriptionConfigModel.HumainRealtime,
            "reson8/turns"=>TranscriptionConfigModel.Reson8Turns,
            "cohere/ar-stt"=>TranscriptionConfigModel.CohereArStt,
            "azure/fast"=>TranscriptionConfigModel.AzureFast,
            "azure/realtime"=>TranscriptionConfigModel.AzureRealtime,
            "google/latest_long"=>TranscriptionConfigModel.GoogleLatestLong,
            "distil-whisper/distil-large-v2"=>TranscriptionConfigModel.DistilWhisperDistilLargeV2,
            "openai/whisper-large-v3-turbo"=>TranscriptionConfigModel.OpenAIWhisperLargeV3Turbo,
            _ =>(TranscriptionConfigModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionConfigModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionConfigModel.DeepgramFlux=>"deepgram/flux",
            TranscriptionConfigModel.Flux=>"flux",
            TranscriptionConfigModel.DeepgramNova3=>"deepgram/nova-3",
            TranscriptionConfigModel.DeepgramNova2=>"deepgram/nova-2",
            TranscriptionConfigModel.SpeechmaticsStandard=>"speechmatics/standard",
            TranscriptionConfigModel.SpeechmaticsEnhanced=>"speechmatics/enhanced",
            TranscriptionConfigModel.AssemblyaiUniversal3_5Pro=>"assemblyai/universal-3-5-pro",
            TranscriptionConfigModel.AssemblyaiUniversalStreaming=>"assemblyai/universal-streaming",
            TranscriptionConfigModel.XaiGrokStt=>"xai/grok-stt",
            TranscriptionConfigModel.SonioxSttRtV4=>"soniox/stt-rt-v4",
            TranscriptionConfigModel.NvidiaParakeetV3=>"nvidia/parakeet-v3",
            TranscriptionConfigModel.OmiHealthOmiMedSttV1=>"omi-health/omi-med-stt-v1",
            TranscriptionConfigModel.HumainRealtime=>"humain/realtime",
            TranscriptionConfigModel.Reson8Turns=>"reson8/turns",
            TranscriptionConfigModel.CohereArStt=>"cohere/ar-stt",
            TranscriptionConfigModel.AzureFast=>"azure/fast",
            TranscriptionConfigModel.AzureRealtime=>"azure/realtime",
            TranscriptionConfigModel.GoogleLatestLong=>"google/latest_long",
            TranscriptionConfigModel.DistilWhisperDistilLargeV2=>"distil-whisper/distil-large-v2",
            TranscriptionConfigModel.OpenAIWhisperLargeV3Turbo=>"openai/whisper-large-v3-turbo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}