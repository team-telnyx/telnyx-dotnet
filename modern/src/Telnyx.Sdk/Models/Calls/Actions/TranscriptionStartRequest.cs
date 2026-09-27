using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<TranscriptionStartRequest, TranscriptionStartRequestFromRaw>))]
public sealed record class TranscriptionStartRequest : JsonModel
{
    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
    /// </summary>
    public string? ClientState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Use this field to avoid duplicate commands. Telnyx will ignore any command
    /// with the same `command_id` for the same `call_control_id`.
    /// </summary>
    public string? CommandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("command_id", value);
        }
    }

    /// <summary>
    /// Engine to use for speech recognition. Legacy values `A` - `Google`, `B` -
    /// `Telnyx` are supported for backward compatibility.
    /// </summary>
    public ApiEnum<string, TranscriptionStartRequestTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TranscriptionStartRequestTranscriptionEngine>>(
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

    public TranscriptionStartRequestTranscriptionEngineConfig? TranscriptionEngineConfig {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TranscriptionStartRequestTranscriptionEngineConfig>(
                "transcription_engine_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_engine_config", value);
        }
    }

    /// <summary>
    /// Indicates which leg of the call will be transcribed. Use `inbound` for the
    /// leg that requested the transcription, `outbound` for the other leg, and `both`
    /// for both legs of the call. Will default to `inbound`.
    /// </summary>
    public string? TranscriptionTracks {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "transcription_tracks"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_tracks", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientState;
        _ = this.CommandID;
        this.TranscriptionEngine?.Validate();
        this.TranscriptionEngineConfig?.Validate();
        _ = this.TranscriptionTracks;
    }

    public TranscriptionStartRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TranscriptionStartRequest (
        TranscriptionStartRequest transcriptionStartRequest
    ) : base(transcriptionStartRequest)
    {  }
    #pragma warning restore CS8618

    public TranscriptionStartRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TranscriptionStartRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptionStartRequestFromRaw.FromRawUnchecked"/>
    public static TranscriptionStartRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TranscriptionStartRequestFromRaw : IFromRawJson<TranscriptionStartRequest>
{
    /// <inheritdoc/>
    public TranscriptionStartRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TranscriptionStartRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Engine to use for speech recognition. Legacy values `A` - `Google`, `B` - `Telnyx`
/// are supported for backward compatibility.
/// </summary>
[JsonConverter(typeof(TranscriptionStartRequestTranscriptionEngineConverter))]
public enum TranscriptionStartRequestTranscriptionEngine
{
    Google,
    Telnyx,
    Deepgram,
    Azure,
    XAI,
    AssemblyAI,
    Speechmatics,
    Soniox,
    Parakeet,
    Humain,
    Reson8,
    Cohere,
    A,
    B
}sealed class TranscriptionStartRequestTranscriptionEngineConverter : JsonConverter<TranscriptionStartRequestTranscriptionEngine>
{
    public override TranscriptionStartRequestTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Google"=>TranscriptionStartRequestTranscriptionEngine.Google,
            "Telnyx"=>TranscriptionStartRequestTranscriptionEngine.Telnyx,
            "Deepgram"=>TranscriptionStartRequestTranscriptionEngine.Deepgram,
            "Azure"=>TranscriptionStartRequestTranscriptionEngine.Azure,
            "xAI"=>TranscriptionStartRequestTranscriptionEngine.XAI,
            "AssemblyAI"=>TranscriptionStartRequestTranscriptionEngine.AssemblyAI,
            "Speechmatics"=>TranscriptionStartRequestTranscriptionEngine.Speechmatics,
            "Soniox"=>TranscriptionStartRequestTranscriptionEngine.Soniox,
            "Parakeet"=>TranscriptionStartRequestTranscriptionEngine.Parakeet,
            "Humain"=>TranscriptionStartRequestTranscriptionEngine.Humain,
            "Reson8"=>TranscriptionStartRequestTranscriptionEngine.Reson8,
            "Cohere"=>TranscriptionStartRequestTranscriptionEngine.Cohere,
            "A"=>TranscriptionStartRequestTranscriptionEngine.A,
            "B"=>TranscriptionStartRequestTranscriptionEngine.B,
            _ =>(TranscriptionStartRequestTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionStartRequestTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TranscriptionStartRequestTranscriptionEngine.Google=>"Google",
            TranscriptionStartRequestTranscriptionEngine.Telnyx=>"Telnyx",
            TranscriptionStartRequestTranscriptionEngine.Deepgram=>"Deepgram",
            TranscriptionStartRequestTranscriptionEngine.Azure=>"Azure",
            TranscriptionStartRequestTranscriptionEngine.XAI=>"xAI",
            TranscriptionStartRequestTranscriptionEngine.AssemblyAI=>"AssemblyAI",
            TranscriptionStartRequestTranscriptionEngine.Speechmatics=>"Speechmatics",
            TranscriptionStartRequestTranscriptionEngine.Soniox=>"Soniox",
            TranscriptionStartRequestTranscriptionEngine.Parakeet=>"Parakeet",
            TranscriptionStartRequestTranscriptionEngine.Humain=>"Humain",
            TranscriptionStartRequestTranscriptionEngine.Reson8=>"Reson8",
            TranscriptionStartRequestTranscriptionEngine.Cohere=>"Cohere",
            TranscriptionStartRequestTranscriptionEngine.A=>"A",
            TranscriptionStartRequestTranscriptionEngine.B=>"B",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(TranscriptionStartRequestTranscriptionEngineConfigConverter))]
public record class TranscriptionStartRequestTranscriptionEngineConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public bool? EnableSpeakerDiarization {
        get {
            return Match<bool?>(google: ( x )=>x.EnableSpeakerDiarization,
            telnyx: ( _ )=>null,
            azure: ( _ )=>null,
            xai: ( _ )=>null,
            assemblyai: ( _ )=>null,
            speechmatics: ( _ )=>null,
            soniox: ( _ )=>null,
            parakeet: ( _ )=>null,
            humain: ( _ )=>null,
            reson8: ( _ )=>null,
            cohere: ( _ )=>null,
            a: ( x )=>x.EnableSpeakerDiarization,
            b: ( _ )=>null,
            deepgramNova2: ( _ )=>null,
            deepgramNova3: ( _ )=>null);
        }
    }

    public bool? InterimResults {
        get {
            return Match<bool?>(google: ( x )=>x.InterimResults,
            telnyx: ( _ )=>null,
            azure: ( _ )=>null,
            xai: ( x )=>x.InterimResults,
            assemblyai: ( x )=>x.InterimResults,
            speechmatics: ( x )=>x.InterimResults,
            soniox: ( x )=>x.InterimResults,
            parakeet: ( x )=>x.InterimResults,
            humain: ( _ )=>null,
            reson8: ( _ )=>null,
            cohere: ( _ )=>null,
            a: ( x )=>x.InterimResults,
            b: ( _ )=>null,
            deepgramNova2: ( x )=>x.InterimResults,
            deepgramNova3: ( x )=>x.InterimResults);
        }
    }

    public int? MaxSpeakerCount {
        get {
            return Match<int?>(google: ( x )=>x.MaxSpeakerCount,
            telnyx: ( _ )=>null,
            azure: ( _ )=>null,
            xai: ( _ )=>null,
            assemblyai: ( _ )=>null,
            speechmatics: ( _ )=>null,
            soniox: ( _ )=>null,
            parakeet: ( _ )=>null,
            humain: ( _ )=>null,
            reson8: ( _ )=>null,
            cohere: ( _ )=>null,
            a: ( x )=>x.MaxSpeakerCount,
            b: ( _ )=>null,
            deepgramNova2: ( _ )=>null,
            deepgramNova3: ( _ )=>null);
        }
    }

    public int? MinSpeakerCount {
        get {
            return Match<int?>(google: ( x )=>x.MinSpeakerCount,
            telnyx: ( _ )=>null,
            azure: ( _ )=>null,
            xai: ( _ )=>null,
            assemblyai: ( _ )=>null,
            speechmatics: ( _ )=>null,
            soniox: ( _ )=>null,
            parakeet: ( _ )=>null,
            humain: ( _ )=>null,
            reson8: ( _ )=>null,
            cohere: ( _ )=>null,
            a: ( x )=>x.MinSpeakerCount,
            b: ( _ )=>null,
            deepgramNova2: ( _ )=>null,
            deepgramNova3: ( _ )=>null);
        }
    }

    public bool? ProfanityFilter {
        get {
            return Match<bool?>(google: ( x )=>x.ProfanityFilter,
            telnyx: ( _ )=>null,
            azure: ( _ )=>null,
            xai: ( _ )=>null,
            assemblyai: ( _ )=>null,
            speechmatics: ( _ )=>null,
            soniox: ( _ )=>null,
            parakeet: ( _ )=>null,
            humain: ( _ )=>null,
            reson8: ( _ )=>null,
            cohere: ( _ )=>null,
            a: ( x )=>x.ProfanityFilter,
            b: ( _ )=>null,
            deepgramNova2: ( _ )=>null,
            deepgramNova3: ( _ )=>null);
        }
    }

    public bool? UseEnhanced {
        get {
            return Match<bool?>(google: ( x )=>x.UseEnhanced,
            telnyx: ( _ )=>null,
            azure: ( _ )=>null,
            xai: ( _ )=>null,
            assemblyai: ( _ )=>null,
            speechmatics: ( _ )=>null,
            soniox: ( _ )=>null,
            parakeet: ( _ )=>null,
            humain: ( _ )=>null,
            reson8: ( _ )=>null,
            cohere: ( _ )=>null,
            a: ( x )=>x.UseEnhanced,
            b: ( _ )=>null,
            deepgramNova2: ( _ )=>null,
            deepgramNova3: ( _ )=>null);
        }
    }

    public bool? SmartFormat {
        get {
            return Match<bool?>(google: ( _ )=>null,
            telnyx: ( _ )=>null,
            azure: ( _ )=>null,
            xai: ( _ )=>null,
            assemblyai: ( _ )=>null,
            speechmatics: ( _ )=>null,
            soniox: ( _ )=>null,
            parakeet: ( _ )=>null,
            humain: ( _ )=>null,
            reson8: ( _ )=>null,
            cohere: ( _ )=>null,
            a: ( _ )=>null,
            b: ( _ )=>null,
            deepgramNova2: ( x )=>x.SmartFormat,
            deepgramNova3: ( x )=>x.SmartFormat);
        }
    }

    public long? UtteranceEndMs {
        get {
            return Match<long?>(google: ( _ )=>null,
            telnyx: ( _ )=>null,
            azure: ( _ )=>null,
            xai: ( _ )=>null,
            assemblyai: ( _ )=>null,
            speechmatics: ( _ )=>null,
            soniox: ( _ )=>null,
            parakeet: ( _ )=>null,
            humain: ( _ )=>null,
            reson8: ( _ )=>null,
            cohere: ( _ )=>null,
            a: ( _ )=>null,
            b: ( _ )=>null,
            deepgramNova2: ( x )=>x.UtteranceEndMs,
            deepgramNova3: ( x )=>x.UtteranceEndMs);
        }
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineGoogleConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineTelnyxConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineAzureConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineXaiConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineAssemblyaiConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineSpeechmaticsConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineSonioxConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineParakeetConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineHumainConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineReson8Config value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineCohereConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineAConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineBConfig value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        DeepgramNova2Config value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        DeepgramNova3Config value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionStartRequestTranscriptionEngineConfig (
        JsonElement element
    )
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineGoogleConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickGoogle(out var value)) {
///     // `value` is of type `TranscriptionEngineGoogleConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickGoogle(
        [NotNullWhen(true)] out TranscriptionEngineGoogleConfig? value
    )
    {
        value =this.Value as TranscriptionEngineGoogleConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineTelnyxConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTelnyx(out var value)) {
///     // `value` is of type `TranscriptionEngineTelnyxConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTelnyx(
        [NotNullWhen(true)] out TranscriptionEngineTelnyxConfig? value
    )
    {
        value =this.Value as TranscriptionEngineTelnyxConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineAzureConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAzure(out var value)) {
///     // `value` is of type `TranscriptionEngineAzureConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAzure(
        [NotNullWhen(true)] out TranscriptionEngineAzureConfig? value
    )
    {
        value =this.Value as TranscriptionEngineAzureConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineXaiConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickXai(out var value)) {
///     // `value` is of type `TranscriptionEngineXaiConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickXai(
        [NotNullWhen(true)] out TranscriptionEngineXaiConfig? value
    )
    {
        value =this.Value as TranscriptionEngineXaiConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineAssemblyaiConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAssemblyai(out var value)) {
///     // `value` is of type `TranscriptionEngineAssemblyaiConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAssemblyai(
        [NotNullWhen(true)] out TranscriptionEngineAssemblyaiConfig? value
    )
    {
        value =this.Value as TranscriptionEngineAssemblyaiConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineSpeechmaticsConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSpeechmatics(out var value)) {
///     // `value` is of type `TranscriptionEngineSpeechmaticsConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSpeechmatics(
        [NotNullWhen(true)] out TranscriptionEngineSpeechmaticsConfig? value
    )
    {
        value =this.Value as TranscriptionEngineSpeechmaticsConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineSonioxConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSoniox(out var value)) {
///     // `value` is of type `TranscriptionEngineSonioxConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSoniox(
        [NotNullWhen(true)] out TranscriptionEngineSonioxConfig? value
    )
    {
        value =this.Value as TranscriptionEngineSonioxConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineParakeetConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickParakeet(out var value)) {
///     // `value` is of type `TranscriptionEngineParakeetConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickParakeet(
        [NotNullWhen(true)] out TranscriptionEngineParakeetConfig? value
    )
    {
        value =this.Value as TranscriptionEngineParakeetConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineHumainConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickHumain(out var value)) {
///     // `value` is of type `TranscriptionEngineHumainConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickHumain(
        [NotNullWhen(true)] out TranscriptionEngineHumainConfig? value
    )
    {
        value =this.Value as TranscriptionEngineHumainConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineReson8Config"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickReson8(out var value)) {
///     // `value` is of type `TranscriptionEngineReson8Config`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickReson8(
        [NotNullWhen(true)] out TranscriptionEngineReson8Config? value
    )
    {
        value =this.Value as TranscriptionEngineReson8Config ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineCohereConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCohere(out var value)) {
///     // `value` is of type `TranscriptionEngineCohereConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCohere(
        [NotNullWhen(true)] out TranscriptionEngineCohereConfig? value
    )
    {
        value =this.Value as TranscriptionEngineCohereConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineAConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickA(out var value)) {
///     // `value` is of type `TranscriptionEngineAConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickA(
        [NotNullWhen(true)] out TranscriptionEngineAConfig? value
    )
    {
        value =this.Value as TranscriptionEngineAConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TranscriptionEngineBConfig"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickB(out var value)) {
///     // `value` is of type `TranscriptionEngineBConfig`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickB(
        [NotNullWhen(true)] out TranscriptionEngineBConfig? value
    )
    {
        value =this.Value as TranscriptionEngineBConfig ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="DeepgramNova2Config"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDeepgramNova2(out var value)) {
///     // `value` is of type `DeepgramNova2Config`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDeepgramNova2(
        [NotNullWhen(true)] out DeepgramNova2Config? value
    )
    {
        value =this.Value as DeepgramNova2Config ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="DeepgramNova3Config"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDeepgramNova3(out var value)) {
///     // `value` is of type `DeepgramNova3Config`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDeepgramNova3(
        [NotNullWhen(true)] out DeepgramNova3Config? value
    )
    {
        value =this.Value as DeepgramNova3Config ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (TranscriptionEngineGoogleConfig value) =&gt; {...},
///     (TranscriptionEngineTelnyxConfig value) =&gt; {...},
///     (TranscriptionEngineAzureConfig value) =&gt; {...},
///     (TranscriptionEngineXaiConfig value) =&gt; {...},
///     (TranscriptionEngineAssemblyaiConfig value) =&gt; {...},
///     (TranscriptionEngineSpeechmaticsConfig value) =&gt; {...},
///     (TranscriptionEngineSonioxConfig value) =&gt; {...},
///     (TranscriptionEngineParakeetConfig value) =&gt; {...},
///     (TranscriptionEngineHumainConfig value) =&gt; {...},
///     (TranscriptionEngineReson8Config value) =&gt; {...},
///     (TranscriptionEngineCohereConfig value) =&gt; {...},
///     (TranscriptionEngineAConfig value) =&gt; {...},
///     (TranscriptionEngineBConfig value) =&gt; {...},
///     (DeepgramNova2Config value) =&gt; {...},
///     (DeepgramNova3Config value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<TranscriptionEngineGoogleConfig> google,
        System::Action<TranscriptionEngineTelnyxConfig> telnyx,
        System::Action<TranscriptionEngineAzureConfig> azure,
        System::Action<TranscriptionEngineXaiConfig> xai,
        System::Action<TranscriptionEngineAssemblyaiConfig> assemblyai,
        System::Action<TranscriptionEngineSpeechmaticsConfig> speechmatics,
        System::Action<TranscriptionEngineSonioxConfig> soniox,
        System::Action<TranscriptionEngineParakeetConfig> parakeet,
        System::Action<TranscriptionEngineHumainConfig> humain,
        System::Action<TranscriptionEngineReson8Config> reson8,
        System::Action<TranscriptionEngineCohereConfig> cohere,
        System::Action<TranscriptionEngineAConfig> a,
        System::Action<TranscriptionEngineBConfig> b,
        System::Action<DeepgramNova2Config> deepgramNova2,
        System::Action<DeepgramNova3Config> deepgramNova3
    )
    {
        switch (this.Value)
        {
            case TranscriptionEngineGoogleConfig value:
                google(value);
                break;
            case TranscriptionEngineTelnyxConfig value:
                telnyx(value);
                break;
            case TranscriptionEngineAzureConfig value:
                azure(value);
                break;
            case TranscriptionEngineXaiConfig value:
                xai(value);
                break;
            case TranscriptionEngineAssemblyaiConfig value:
                assemblyai(value);
                break;
            case TranscriptionEngineSpeechmaticsConfig value:
                speechmatics(value);
                break;
            case TranscriptionEngineSonioxConfig value:
                soniox(value);
                break;
            case TranscriptionEngineParakeetConfig value:
                parakeet(value);
                break;
            case TranscriptionEngineHumainConfig value:
                humain(value);
                break;
            case TranscriptionEngineReson8Config value:
                reson8(value);
                break;
            case TranscriptionEngineCohereConfig value:
                cohere(value);
                break;
            case TranscriptionEngineAConfig value:
                a(value);
                break;
            case TranscriptionEngineBConfig value:
                b(value);
                break;
            case DeepgramNova2Config value:
                deepgramNova2(value);
                break;
            case DeepgramNova3Config value:
                deepgramNova3(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of TranscriptionStartRequestTranscriptionEngineConfig");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (TranscriptionEngineGoogleConfig value) =&gt; {...},
///     (TranscriptionEngineTelnyxConfig value) =&gt; {...},
///     (TranscriptionEngineAzureConfig value) =&gt; {...},
///     (TranscriptionEngineXaiConfig value) =&gt; {...},
///     (TranscriptionEngineAssemblyaiConfig value) =&gt; {...},
///     (TranscriptionEngineSpeechmaticsConfig value) =&gt; {...},
///     (TranscriptionEngineSonioxConfig value) =&gt; {...},
///     (TranscriptionEngineParakeetConfig value) =&gt; {...},
///     (TranscriptionEngineHumainConfig value) =&gt; {...},
///     (TranscriptionEngineReson8Config value) =&gt; {...},
///     (TranscriptionEngineCohereConfig value) =&gt; {...},
///     (TranscriptionEngineAConfig value) =&gt; {...},
///     (TranscriptionEngineBConfig value) =&gt; {...},
///     (DeepgramNova2Config value) =&gt; {...},
///     (DeepgramNova3Config value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<TranscriptionEngineGoogleConfig, T> google,
        System::Func<TranscriptionEngineTelnyxConfig, T> telnyx,
        System::Func<TranscriptionEngineAzureConfig, T> azure,
        System::Func<TranscriptionEngineXaiConfig, T> xai,
        System::Func<TranscriptionEngineAssemblyaiConfig, T> assemblyai,
        System::Func<TranscriptionEngineSpeechmaticsConfig, T> speechmatics,
        System::Func<TranscriptionEngineSonioxConfig, T> soniox,
        System::Func<TranscriptionEngineParakeetConfig, T> parakeet,
        System::Func<TranscriptionEngineHumainConfig, T> humain,
        System::Func<TranscriptionEngineReson8Config, T> reson8,
        System::Func<TranscriptionEngineCohereConfig, T> cohere,
        System::Func<TranscriptionEngineAConfig, T> a,
        System::Func<TranscriptionEngineBConfig, T> b,
        System::Func<DeepgramNova2Config, T> deepgramNova2,
        System::Func<DeepgramNova3Config, T> deepgramNova3
    )
    {
        return this.Value switch
        {
            TranscriptionEngineGoogleConfig value=>google(value),
            TranscriptionEngineTelnyxConfig value=>telnyx(value),
            TranscriptionEngineAzureConfig value=>azure(value),
            TranscriptionEngineXaiConfig value=>xai(value),
            TranscriptionEngineAssemblyaiConfig value=>assemblyai(value),
            TranscriptionEngineSpeechmaticsConfig value=>speechmatics(value),
            TranscriptionEngineSonioxConfig value=>soniox(value),
            TranscriptionEngineParakeetConfig value=>parakeet(value),
            TranscriptionEngineHumainConfig value=>humain(value),
            TranscriptionEngineReson8Config value=>reson8(value),
            TranscriptionEngineCohereConfig value=>cohere(value),
            TranscriptionEngineAConfig value=>a(value),
            TranscriptionEngineBConfig value=>b(value),
            DeepgramNova2Config value=>deepgramNova2(value),
            DeepgramNova3Config value=>deepgramNova3(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of TranscriptionStartRequestTranscriptionEngineConfig")
        } ;
    }

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineGoogleConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineTelnyxConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineAzureConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineXaiConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineAssemblyaiConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineSpeechmaticsConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineSonioxConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineParakeetConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineHumainConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineReson8Config value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineCohereConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineAConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        TranscriptionEngineBConfig value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        DeepgramNova2Config value
    )=> new(value) ;

    public static implicit operator TranscriptionStartRequestTranscriptionEngineConfig (
        DeepgramNova3Config value
    )=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of TranscriptionStartRequestTranscriptionEngineConfig");
        }
        this.Switch((google) => google.Validate(),
        (telnyx) => telnyx.Validate(),
        (azure) => azure.Validate(),
        (xai) => xai.Validate(),
        (assemblyai) => assemblyai.Validate(),
        (speechmatics) => speechmatics.Validate(),
        (soniox) => soniox.Validate(),
        (parakeet) => parakeet.Validate(),
        (humain) => humain.Validate(),
        (reson8) => reson8.Validate(),
        (cohere) => cohere.Validate(),
        (a) => a.Validate(),
        (b) => b.Validate(),
        (deepgramNova2) => deepgramNova2.Validate(),
        (deepgramNova3) => deepgramNova3.Validate());
    }

    public virtual bool Equals(
        TranscriptionStartRequestTranscriptionEngineConfig? other
    )
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            TranscriptionEngineGoogleConfig _=>0,
            TranscriptionEngineTelnyxConfig _=>1,
            TranscriptionEngineAzureConfig _=>2,
            TranscriptionEngineXaiConfig _=>3,
            TranscriptionEngineAssemblyaiConfig _=>4,
            TranscriptionEngineSpeechmaticsConfig _=>5,
            TranscriptionEngineSonioxConfig _=>6,
            TranscriptionEngineParakeetConfig _=>7,
            TranscriptionEngineHumainConfig _=>8,
            TranscriptionEngineReson8Config _=>9,
            TranscriptionEngineCohereConfig _=>10,
            TranscriptionEngineAConfig _=>11,
            TranscriptionEngineBConfig _=>12,
            DeepgramNova2Config _=>13,
            DeepgramNova3Config _=>14,
            _ =>-1
        } ;
    }
}sealed class TranscriptionStartRequestTranscriptionEngineConfigConverter : JsonConverter<TranscriptionStartRequestTranscriptionEngineConfig>
{
    public override TranscriptionStartRequestTranscriptionEngineConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? transcriptionEngine;
        try {
            transcriptionEngine = element.GetProperty("transcription_engine").GetString();
        } catch {
            transcriptionEngine = null;
        }

        switch (transcriptionEngine)
        {
            case "Google":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineGoogleConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "Telnyx":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineTelnyxConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "Azure":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineAzureConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "xAI":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineXaiConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "AssemblyAI":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineAssemblyaiConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "Speechmatics":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineSpeechmaticsConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "Soniox":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineSonioxConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "Parakeet":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineParakeetConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "Humain":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineHumainConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "Reson8":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineReson8Config>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "Cohere":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineCohereConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "A":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineAConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "B":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TranscriptionEngineBConfig>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "deepgram/nova-2":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DeepgramNova2Config>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "deepgram/nova-3":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DeepgramNova3Config>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                {
                    return new TranscriptionStartRequestTranscriptionEngineConfig(element);
                }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionStartRequestTranscriptionEngineConfig value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}