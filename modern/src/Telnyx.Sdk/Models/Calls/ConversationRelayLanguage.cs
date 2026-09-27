using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Calls.Actions;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Language-specific TTS and transcription settings for Conversation Relay.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConversationRelayLanguage, ConversationRelayLanguageFromRaw>))]
public sealed record class ConversationRelayLanguage : JsonModel
{
    /// <summary>
    /// BCP 47 language tag for this language configuration.
    /// </summary>
    public required string Language {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "language"
            );
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// Conversation Relay speech model. Prefer `transcription_engine_config.transcription_model`
    /// when configuring speech-to-text.
    /// </summary>
    public string? SpeechModel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "speech_model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speech_model", value);
        }
    }

    /// <summary>
    /// Engine to use for speech recognition. Legacy values `A` - `Google`, `B` -
    /// `Telnyx` are supported for backward compatibility. When provided in a Conversation
    /// Relay language entry, Telnyx derives `transcription_provider` and `speech_model`
    /// for that language.
    /// </summary>
    public ApiEnum<string, ConversationRelayLanguageTranscriptionEngine>? TranscriptionEngine {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConversationRelayLanguageTranscriptionEngine>>(
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
    /// Engine-specific transcription settings for Conversation Relay. This accepts
    /// the same provider-specific options used by the Call Transcription Start command,
    /// such as `transcription_model`, without requiring the engine discriminator
    /// to be repeated inside this object.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? TranscriptionEngineConfig {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "transcription_engine_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "transcription_engine_config",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Conversation Relay transcription provider name. Prefer `transcription_engine`
    /// when configuring speech-to-text.
    /// </summary>
    public string? TranscriptionProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "transcription_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription_provider", value);
        }
    }

    /// <summary>
    /// Text-to-speech provider for this language. If omitted and `voice` is provided,
    /// Telnyx derives the provider from the voice identifier.
    /// </summary>
    public string? TtsProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tts_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tts_provider", value);
        }
    }

    /// <summary>
    /// Voice identifier for this language.
    /// </summary>
    public string? Voice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "voice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice", value);
        }
    }

    /// <summary>
    /// The settings associated with the voice selected
    /// </summary>
    public ConversationRelayLanguageVoiceSettings? VoiceSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationRelayLanguageVoiceSettings>(
                "voice_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_settings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Language;
        _ = this.SpeechModel;
        this.TranscriptionEngine?.Validate();
        _ = this.TranscriptionEngineConfig;
        _ = this.TranscriptionProvider;
        _ = this.TtsProvider;
        _ = this.Voice;
        this.VoiceSettings?.Validate();
    }

    public ConversationRelayLanguage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationRelayLanguage (
        ConversationRelayLanguage conversationRelayLanguage
    ) : base(conversationRelayLanguage)
    {  }
    #pragma warning restore CS8618

    public ConversationRelayLanguage (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationRelayLanguage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationRelayLanguageFromRaw.FromRawUnchecked"/>
    public static ConversationRelayLanguage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConversationRelayLanguage (string language) : this()
    { this.Language = language; }
}

class ConversationRelayLanguageFromRaw : IFromRawJson<ConversationRelayLanguage>
{
    /// <inheritdoc/>
    public ConversationRelayLanguage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationRelayLanguage.FromRawUnchecked(rawData);
}

/// <summary>
/// Engine to use for speech recognition. Legacy values `A` - `Google`, `B` - `Telnyx`
/// are supported for backward compatibility. When provided in a Conversation Relay
/// language entry, Telnyx derives `transcription_provider` and `speech_model` for
/// that language.
/// </summary>
[JsonConverter(typeof(ConversationRelayLanguageTranscriptionEngineConverter))]
public enum ConversationRelayLanguageTranscriptionEngine
{
    Google, Telnyx, Deepgram, Azure, XAI, AssemblyAI, Speechmatics, Soniox, A, B
}sealed class ConversationRelayLanguageTranscriptionEngineConverter : JsonConverter<ConversationRelayLanguageTranscriptionEngine>
{
    public override ConversationRelayLanguageTranscriptionEngine Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Google"=>ConversationRelayLanguageTranscriptionEngine.Google,
            "Telnyx"=>ConversationRelayLanguageTranscriptionEngine.Telnyx,
            "Deepgram"=>ConversationRelayLanguageTranscriptionEngine.Deepgram,
            "Azure"=>ConversationRelayLanguageTranscriptionEngine.Azure,
            "xAI"=>ConversationRelayLanguageTranscriptionEngine.XAI,
            "AssemblyAI"=>ConversationRelayLanguageTranscriptionEngine.AssemblyAI,
            "Speechmatics"=>ConversationRelayLanguageTranscriptionEngine.Speechmatics,
            "Soniox"=>ConversationRelayLanguageTranscriptionEngine.Soniox,
            "A"=>ConversationRelayLanguageTranscriptionEngine.A,
            "B"=>ConversationRelayLanguageTranscriptionEngine.B,
            _ =>(ConversationRelayLanguageTranscriptionEngine)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversationRelayLanguageTranscriptionEngine value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConversationRelayLanguageTranscriptionEngine.Google=>"Google",
            ConversationRelayLanguageTranscriptionEngine.Telnyx=>"Telnyx",
            ConversationRelayLanguageTranscriptionEngine.Deepgram=>"Deepgram",
            ConversationRelayLanguageTranscriptionEngine.Azure=>"Azure",
            ConversationRelayLanguageTranscriptionEngine.XAI=>"xAI",
            ConversationRelayLanguageTranscriptionEngine.AssemblyAI=>"AssemblyAI",
            ConversationRelayLanguageTranscriptionEngine.Speechmatics=>"Speechmatics",
            ConversationRelayLanguageTranscriptionEngine.Soniox=>"Soniox",
            ConversationRelayLanguageTranscriptionEngine.A=>"A",
            ConversationRelayLanguageTranscriptionEngine.B=>"B",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The settings associated with the voice selected
/// </summary>
[JsonConverter(typeof(ConversationRelayLanguageVoiceSettingsConverter))]
public record class ConversationRelayLanguageVoiceSettings : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string? ApiKeyRef {
        get {
            return Match<string?>(elevenLabs: ( x )=>x.ApiKeyRef,
            telnyx: ( _ )=>null,
            aws: ( _ )=>null,
            minimax: ( _ )=>null,
            azure: ( x )=>x.ApiKeyRef,
            resemble: ( _ )=>null,
            inworld: ( _ )=>null,
            xai: ( _ )=>null,
            soniox: ( _ )=>null);
        }
    }

    public float? Speed {
        get {
            return Match<float?>(elevenLabs: ( _ )=>null,
            telnyx: ( _ )=>null,
            aws: ( _ )=>null,
            minimax: ( x )=>x.Speed,
            azure: ( _ )=>null,
            resemble: ( _ )=>null,
            inworld: ( _ )=>null,
            xai: ( _ )=>null,
            soniox: ( x )=>x.Speed);
        }
    }

    public ConversationRelayLanguageVoiceSettings (
        ElevenLabsVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationRelayLanguageVoiceSettings (
        TelnyxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationRelayLanguageVoiceSettings (
        AwsVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationRelayLanguageVoiceSettings (
        MinimaxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationRelayLanguageVoiceSettings (
        AzureVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationRelayLanguageVoiceSettings (
        ResembleVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationRelayLanguageVoiceSettings (
        InworldVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationRelayLanguageVoiceSettings (
        XaiVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationRelayLanguageVoiceSettings (
        SonioxVoiceSettings value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationRelayLanguageVoiceSettings (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ElevenLabsVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickElevenLabs(out var value)) {
///     // `value` is of type `ElevenLabsVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickElevenLabs(
        [NotNullWhen(true)] out ElevenLabsVoiceSettings? value
    )
    {
        value =this.Value as ElevenLabsVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TelnyxVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTelnyx(out var value)) {
///     // `value` is of type `TelnyxVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTelnyx(
        [NotNullWhen(true)] out TelnyxVoiceSettings? value
    )
    {
        value =this.Value as TelnyxVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AwsVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAws(out var value)) {
///     // `value` is of type `AwsVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAws([NotNullWhen(true)] out AwsVoiceSettings? value)
    {
        value =this.Value as AwsVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MinimaxVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMinimax(out var value)) {
///     // `value` is of type `MinimaxVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMinimax(
        [NotNullWhen(true)] out MinimaxVoiceSettings? value
    )
    {
        value =this.Value as MinimaxVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AzureVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAzure(out var value)) {
///     // `value` is of type `AzureVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAzure([NotNullWhen(true)] out AzureVoiceSettings? value)
    {
        value =this.Value as AzureVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ResembleVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickResemble(out var value)) {
///     // `value` is of type `ResembleVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickResemble(
        [NotNullWhen(true)] out ResembleVoiceSettings? value
    )
    {
        value =this.Value as ResembleVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="InworldVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickInworld(out var value)) {
///     // `value` is of type `InworldVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickInworld(
        [NotNullWhen(true)] out InworldVoiceSettings? value
    )
    {
        value =this.Value as InworldVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="XaiVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickXai(out var value)) {
///     // `value` is of type `XaiVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickXai([NotNullWhen(true)] out XaiVoiceSettings? value)
    {
        value =this.Value as XaiVoiceSettings ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="SonioxVoiceSettings"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSoniox(out var value)) {
///     // `value` is of type `SonioxVoiceSettings`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSoniox(
        [NotNullWhen(true)] out SonioxVoiceSettings? value
    )
    {
        value =this.Value as SonioxVoiceSettings ;
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
///     (ElevenLabsVoiceSettings value) =&gt; {...},
///     (TelnyxVoiceSettings value) =&gt; {...},
///     (AwsVoiceSettings value) =&gt; {...},
///     (MinimaxVoiceSettings value) =&gt; {...},
///     (AzureVoiceSettings value) =&gt; {...},
///     (ResembleVoiceSettings value) =&gt; {...},
///     (InworldVoiceSettings value) =&gt; {...},
///     (XaiVoiceSettings value) =&gt; {...},
///     (SonioxVoiceSettings value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ElevenLabsVoiceSettings> elevenLabs,
        System::Action<TelnyxVoiceSettings> telnyx,
        System::Action<AwsVoiceSettings> aws,
        System::Action<MinimaxVoiceSettings> minimax,
        System::Action<AzureVoiceSettings> azure,
        System::Action<ResembleVoiceSettings> resemble,
        System::Action<InworldVoiceSettings> inworld,
        System::Action<XaiVoiceSettings> xai,
        System::Action<SonioxVoiceSettings> soniox
    )
    {
        switch (this.Value)
        {
            case ElevenLabsVoiceSettings value:
                elevenLabs(value);
                break;
            case TelnyxVoiceSettings value:
                telnyx(value);
                break;
            case AwsVoiceSettings value:
                aws(value);
                break;
            case MinimaxVoiceSettings value:
                minimax(value);
                break;
            case AzureVoiceSettings value:
                azure(value);
                break;
            case ResembleVoiceSettings value:
                resemble(value);
                break;
            case InworldVoiceSettings value:
                inworld(value);
                break;
            case XaiVoiceSettings value:
                xai(value);
                break;
            case SonioxVoiceSettings value:
                soniox(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ConversationRelayLanguageVoiceSettings");

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
///     (ElevenLabsVoiceSettings value) =&gt; {...},
///     (TelnyxVoiceSettings value) =&gt; {...},
///     (AwsVoiceSettings value) =&gt; {...},
///     (MinimaxVoiceSettings value) =&gt; {...},
///     (AzureVoiceSettings value) =&gt; {...},
///     (ResembleVoiceSettings value) =&gt; {...},
///     (InworldVoiceSettings value) =&gt; {...},
///     (XaiVoiceSettings value) =&gt; {...},
///     (SonioxVoiceSettings value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ElevenLabsVoiceSettings, T> elevenLabs,
        System::Func<TelnyxVoiceSettings, T> telnyx,
        System::Func<AwsVoiceSettings, T> aws,
        System::Func<MinimaxVoiceSettings, T> minimax,
        System::Func<AzureVoiceSettings, T> azure,
        System::Func<ResembleVoiceSettings, T> resemble,
        System::Func<InworldVoiceSettings, T> inworld,
        System::Func<XaiVoiceSettings, T> xai,
        System::Func<SonioxVoiceSettings, T> soniox
    )
    {
        return this.Value switch
        {
            ElevenLabsVoiceSettings value=>elevenLabs(value),
            TelnyxVoiceSettings value=>telnyx(value),
            AwsVoiceSettings value=>aws(value),
            MinimaxVoiceSettings value=>minimax(value),
            AzureVoiceSettings value=>azure(value),
            ResembleVoiceSettings value=>resemble(value),
            InworldVoiceSettings value=>inworld(value),
            XaiVoiceSettings value=>xai(value),
            SonioxVoiceSettings value=>soniox(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ConversationRelayLanguageVoiceSettings")
        } ;
    }

    public static implicit operator ConversationRelayLanguageVoiceSettings (
        ElevenLabsVoiceSettings value
    )=> new(value) ;

    public static implicit operator ConversationRelayLanguageVoiceSettings (
        TelnyxVoiceSettings value
    )=> new(value) ;

    public static implicit operator ConversationRelayLanguageVoiceSettings (
        AwsVoiceSettings value
    )=> new(value) ;

    public static implicit operator ConversationRelayLanguageVoiceSettings (
        MinimaxVoiceSettings value
    )=> new(value) ;

    public static implicit operator ConversationRelayLanguageVoiceSettings (
        AzureVoiceSettings value
    )=> new(value) ;

    public static implicit operator ConversationRelayLanguageVoiceSettings (
        ResembleVoiceSettings value
    )=> new(value) ;

    public static implicit operator ConversationRelayLanguageVoiceSettings (
        InworldVoiceSettings value
    )=> new(value) ;

    public static implicit operator ConversationRelayLanguageVoiceSettings (
        XaiVoiceSettings value
    )=> new(value) ;

    public static implicit operator ConversationRelayLanguageVoiceSettings (
        SonioxVoiceSettings value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ConversationRelayLanguageVoiceSettings");
        }
        this.Switch((elevenLabs) => elevenLabs.Validate(),
        (telnyx) => telnyx.Validate(),
        (aws) => aws.Validate(),
        (minimax) => minimax.Validate(),
        (azure) => azure.Validate(),
        (resemble) => resemble.Validate(),
        (inworld) => inworld.Validate(),
        (xai) => xai.Validate(),
        (soniox) => soniox.Validate());
    }

    public virtual bool Equals(ConversationRelayLanguageVoiceSettings? other)
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
            ElevenLabsVoiceSettings _=>0,
            TelnyxVoiceSettings _=>1,
            AwsVoiceSettings _=>2,
            MinimaxVoiceSettings _=>3,
            AzureVoiceSettings _=>4,
            ResembleVoiceSettings _=>5,
            InworldVoiceSettings _=>6,
            XaiVoiceSettings _=>7,
            SonioxVoiceSettings _=>8,
            _ =>-1
        } ;
    }
}sealed class ConversationRelayLanguageVoiceSettingsConverter : JsonConverter<ConversationRelayLanguageVoiceSettings>
{
    public override ConversationRelayLanguageVoiceSettings? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try {
            type = element.GetProperty("type").GetString();
        } catch {
            type = null;
        }

        switch (type)
        {
            case "elevenlabs":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ElevenLabsVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "telnyx":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TelnyxVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "aws":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AwsVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "minimax":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MinimaxVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "azure":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AzureVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "resemble":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ResembleVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "inworld":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<InworldVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "xai":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<XaiVoiceSettings>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "soniox":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SonioxVoiceSettings>(element, options);
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
                { return new ConversationRelayLanguageVoiceSettings(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversationRelayLanguageVoiceSettings value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}