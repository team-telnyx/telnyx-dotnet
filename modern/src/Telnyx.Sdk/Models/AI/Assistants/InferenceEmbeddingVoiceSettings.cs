using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<InferenceEmbeddingVoiceSettings, InferenceEmbeddingVoiceSettingsFromRaw>))]
public sealed record class InferenceEmbeddingVoiceSettings : JsonModel
{
    /// <summary>
    /// The voice to be used by the voice assistant. Check the full list of [available
    /// voices](https://developers.telnyx.com/docs/tts-stt/tts-available-voices)
    /// via our voices API. To use ElevenLabs, you must reference your ElevenLabs
    /// API key as an integration secret under the `api_key_ref` field. See [integration
    /// secrets documentation](https://developers.telnyx.com/api-reference/integration-secrets/create-a-secret)
    /// for details. For Telnyx voices, use `Telnyx.&lt;model_id&gt;.&lt;voice_id&gt;`
    /// (e.g. Telnyx.KokoroTTS.af_heart). For Soniox voices, use `Soniox.tts-rt-v2.&lt;voice_id&gt;`
    /// (e.g. Soniox.tts-rt-v2.Emma); every Soniox voice speaks all supported languages.
    /// The voice portion of the identifier supports [dynamic variables](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables)
    /// using mustache syntax (e.g. `Telnyx.Ultra.{{voice_id}}`). The variable is
    /// resolved at call time from your dynamic variables webhook, allowing you to
    /// select the voice dynamically per call.
    /// </summary>
    public required string Voice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "voice"
            );
        }
        init { this._rawData.Set("voice", value); }
    }

    /// <summary>
    /// The `identifier` for an integration secret [/v2/integration_secrets](https://developers.telnyx.com/api-reference/integration-secrets/create-a-secret)
    /// that refers to your ElevenLabs API key. Warning: Free plans are unlikely to
    /// work with this integration.
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
    /// Optional background audio to play on the call. Use a predefined media bed,
    /// or supply a looped MP3 URL. If a media URL is chosen in the portal, customers
    /// can preview it before saving.
    /// </summary>
    public BackgroundAudio? BackgroundAudio {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BackgroundAudio>(
                "background_audio"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("background_audio", value);
        }
    }

    /// <summary>
    /// Enables emotionally expressive speech using SSML emotion tags. When enabled,
    /// the assistant uses audio tags like angry, excited, content, and sad to add
    /// emotional nuance. Only supported for Telnyx Ultra voices.
    /// </summary>
    public bool? ExpressiveMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "expressive_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expressive_mode", value);
        }
    }

    /// <summary>
    /// Enhances recognition for specific languages and dialects during MiniMax TTS
    /// synthesis. Default is null (no boost). Set to 'auto' for automatic language
    /// detection. Only applicable when using MiniMax voices.
    /// </summary>
    public ApiEnum<string, LanguageBoost>? LanguageBoost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LanguageBoost>>(
                "language_boost"
            );
        }
        init { this._rawData.Set("language_boost", value); }
    }

    /// <summary>
    /// Determines how closely the AI should adhere to the original voice when attempting
    /// to replicate it. Only applicable when using ElevenLabs.
    /// </summary>
    public double? SimilarityBoost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "similarity_boost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("similarity_boost", value);
        }
    }

    /// <summary>
    /// Adjusts speech velocity. 1.0 is default speed; values less than 1.0 slow
    /// speech; values greater than 1.0 accelerate it. Only applicable when using ElevenLabs.
    /// </summary>
    public double? Speed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "speed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speed", value);
        }
    }

    /// <summary>
    /// Determines the style exaggeration of the voice. Amplifies speaker style but
    /// consumes additional resources when set above 0. Only applicable when using ElevenLabs.
    /// </summary>
    public double? Style {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "style"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("style", value);
        }
    }

    /// <summary>
    /// Determines how stable the voice is and the randomness between each generation.
    /// Lower values create a broader emotional range; higher values produce more
    /// consistent, monotonous output. Only applicable when using ElevenLabs.
    /// </summary>
    public double? Temperature {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "temperature"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("temperature", value);
        }
    }

    /// <summary>
    /// Amplifies similarity to the original speaker voice. Increases computational
    /// load and latency slightly. Only applicable when using ElevenLabs.
    /// </summary>
    public bool? UseSpeakerBoost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "use_speaker_boost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("use_speaker_boost", value);
        }
    }

    /// <summary>
    /// The speed of the voice in the range [0.25, 2.0]. 1.0 is deafult speed. Larger
    /// numbers make the voice faster, smaller numbers make it slower. This is only
    /// applicable for Telnyx Natural voices and Soniox voices (0.7 to 1.3 for Soniox).
    /// </summary>
    public double? VoiceSpeed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "voice_speed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_speed", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Voice;
        _ = this.ApiKeyRef;
        this.BackgroundAudio?.Validate();
        _ = this.ExpressiveMode;
        this.LanguageBoost?.Validate();
        _ = this.SimilarityBoost;
        _ = this.Speed;
        _ = this.Style;
        _ = this.Temperature;
        _ = this.UseSpeakerBoost;
        _ = this.VoiceSpeed;
    }

    public InferenceEmbeddingVoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InferenceEmbeddingVoiceSettings (
        InferenceEmbeddingVoiceSettings inferenceEmbeddingVoiceSettings
    ) : base(inferenceEmbeddingVoiceSettings)
    {  }
    #pragma warning restore CS8618

    public InferenceEmbeddingVoiceSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InferenceEmbeddingVoiceSettings (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InferenceEmbeddingVoiceSettingsFromRaw.FromRawUnchecked"/>
    public static InferenceEmbeddingVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InferenceEmbeddingVoiceSettings (string voice) : this()
    { this.Voice = voice; }
}

class InferenceEmbeddingVoiceSettingsFromRaw : IFromRawJson<InferenceEmbeddingVoiceSettings>
{
    /// <inheritdoc/>
    public InferenceEmbeddingVoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InferenceEmbeddingVoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional background audio to play on the call. Use a predefined media bed, or
/// supply a looped MP3 URL. If a media URL is chosen in the portal, customers can
/// preview it before saving.
/// </summary>
[JsonConverter(typeof(BackgroundAudioConverter))]
public record class BackgroundAudio : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public BackgroundAudio (UnionMember0 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BackgroundAudio (UnionMember1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BackgroundAudio (UnionMember2 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BackgroundAudio (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="UnionMember0"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickUnionMember0(out var value)) {
///     // `value` is of type `UnionMember0`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickUnionMember0([NotNullWhen(true)] out UnionMember0? value)
    {
        value =this.Value as UnionMember0 ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="UnionMember1"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickUnionMember1(out var value)) {
///     // `value` is of type `UnionMember1`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickUnionMember1([NotNullWhen(true)] out UnionMember1? value)
    {
        value =this.Value as UnionMember1 ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="UnionMember2"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickUnionMember2(out var value)) {
///     // `value` is of type `UnionMember2`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickUnionMember2([NotNullWhen(true)] out UnionMember2? value)
    {
        value =this.Value as UnionMember2 ;
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
///     (UnionMember0 value) =&gt; {...},
///     (UnionMember1 value) =&gt; {...},
///     (UnionMember2 value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<UnionMember0> unionMember0,
        System::Action<UnionMember1> unionMember1,
        System::Action<UnionMember2> unionMember2
    )
    {
        switch (this.Value)
        {
            case UnionMember0 value:
                unionMember0(value);
                break;
            case UnionMember1 value:
                unionMember1(value);
                break;
            case UnionMember2 value:
                unionMember2(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of BackgroundAudio");

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
///     (UnionMember0 value) =&gt; {...},
///     (UnionMember1 value) =&gt; {...},
///     (UnionMember2 value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<UnionMember0, T> unionMember0,
        System::Func<UnionMember1, T> unionMember1,
        System::Func<UnionMember2, T> unionMember2
    )
    {
        return this.Value switch
        {
            UnionMember0 value=>unionMember0(value),
            UnionMember1 value=>unionMember1(value),
            UnionMember2 value=>unionMember2(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of BackgroundAudio")
        } ;
    }

    public static implicit operator BackgroundAudio (
        UnionMember0 value
    )=> new(value) ;

    public static implicit operator BackgroundAudio (
        UnionMember1 value
    )=> new(value) ;

    public static implicit operator BackgroundAudio (
        UnionMember2 value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of BackgroundAudio");
        }
        this.Switch((unionMember0) => unionMember0.Validate(),
        (unionMember1) => unionMember1.Validate(),
        (unionMember2) => unionMember2.Validate());
    }

    public virtual bool Equals(BackgroundAudio? other)
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
        { UnionMember0 _=>0, UnionMember1 _=>1, UnionMember2 _=>2, _ =>-1 } ;
    }
}sealed class BackgroundAudioConverter : JsonConverter<BackgroundAudio>
{
    public override BackgroundAudio? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember2>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BackgroundAudio value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<UnionMember0, UnionMember0FromRaw>))]
public sealed record class UnionMember0 : JsonModel
{
    /// <summary>
    /// Select from predefined media options.
    /// </summary>
    public required ApiEnum<string, UnionMember0Type> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnionMember0Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The predefined media to use. `silence` disables background audio.
    /// </summary>
    public required ApiEnum<string, Value> Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Value>>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// Volume level for the predefined background audio. Supports values from 0.1
    /// to 1.0 in 0.1 increments.
    /// </summary>
    public double? Volume {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "volume"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("volume", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Value.Validate();
        _ = this.Volume;
    }

    public UnionMember0 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember0 (UnionMember0 unionMember0) : base(unionMember0)
    {  }
    #pragma warning restore CS8618

    public UnionMember0 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember0 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember0FromRaw.FromRawUnchecked"/>
    public static UnionMember0 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UnionMember0FromRaw : IFromRawJson<UnionMember0>
{
    /// <inheritdoc/>
    public UnionMember0 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UnionMember0.FromRawUnchecked(rawData);
}/// <summary>
/// Select from predefined media options.
/// </summary>
[JsonConverter(typeof(UnionMember0TypeConverter))]
public enum UnionMember0Type
{
    PredefinedMedia
}sealed class UnionMember0TypeConverter : JsonConverter<UnionMember0Type>
{
    public override UnionMember0Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "predefined_media"=>UnionMember0Type.PredefinedMedia,
            _ =>(UnionMember0Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember0Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UnionMember0Type.PredefinedMedia=>"predefined_media",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The predefined media to use. `silence` disables background audio.
/// </summary>
[JsonConverter(typeof(ValueConverter))]
public enum Value
{
    Silence, Office
}sealed class ValueConverter : JsonConverter<Value>
{
    public override Value Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "silence"=>Value.Silence, "office"=>Value.Office, _ =>(Value)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Value value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Value.Silence=>"silence",
            Value.Office=>"office",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<UnionMember1, UnionMember1FromRaw>))]
public sealed record class UnionMember1 : JsonModel
{
    /// <summary>
    /// Provide a direct URL to an MP3 file. The audio will loop during the call.
    /// </summary>
    public required ApiEnum<string, UnionMember1Type> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnionMember1Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// HTTPS URL to an MP3 file.
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
    }

    public UnionMember1 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember1 (UnionMember1 unionMember1) : base(unionMember1)
    {  }
    #pragma warning restore CS8618

    public UnionMember1 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember1 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember1FromRaw.FromRawUnchecked"/>
    public static UnionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UnionMember1FromRaw : IFromRawJson<UnionMember1>
{
    /// <inheritdoc/>
    public UnionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UnionMember1.FromRawUnchecked(rawData);
}/// <summary>
/// Provide a direct URL to an MP3 file. The audio will loop during the call.
/// </summary>
[JsonConverter(typeof(UnionMember1TypeConverter))]
public enum UnionMember1Type
{
    MediaUrl
}sealed class UnionMember1TypeConverter : JsonConverter<UnionMember1Type>
{
    public override UnionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "media_url"=>UnionMember1Type.MediaUrl, _ =>(UnionMember1Type)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UnionMember1Type.MediaUrl=>"media_url",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<UnionMember2, UnionMember2FromRaw>))]
public sealed record class UnionMember2 : JsonModel
{
    /// <summary>
    /// Reference a previously uploaded media by its name from Telnyx Media Storage.
    /// </summary>
    public required ApiEnum<string, UnionMember2Type> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnionMember2Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The `name` of a media asset created via [Media Storage API](https://developers.telnyx.com/api/media-storage/create-media-storage).
    /// The audio will loop during the call.
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
    }

    public UnionMember2 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnionMember2 (UnionMember2 unionMember2) : base(unionMember2)
    {  }
    #pragma warning restore CS8618

    public UnionMember2 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember2 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UnionMember2FromRaw.FromRawUnchecked"/>
    public static UnionMember2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UnionMember2FromRaw : IFromRawJson<UnionMember2>
{
    /// <inheritdoc/>
    public UnionMember2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UnionMember2.FromRawUnchecked(rawData);
}/// <summary>
/// Reference a previously uploaded media by its name from Telnyx Media Storage.
/// </summary>
[JsonConverter(typeof(UnionMember2TypeConverter))]
public enum UnionMember2Type
{
    MediaName
}sealed class UnionMember2TypeConverter : JsonConverter<UnionMember2Type>
{
    public override UnionMember2Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "media_name"=>UnionMember2Type.MediaName, _ =>(UnionMember2Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember2Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UnionMember2Type.MediaName=>"media_name",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Enhances recognition for specific languages and dialects during MiniMax TTS synthesis.
/// Default is null (no boost). Set to 'auto' for automatic language detection. Only
/// applicable when using MiniMax voices.
/// </summary>
[JsonConverter(typeof(LanguageBoostConverter))]
public enum LanguageBoost
{
    Auto,
    Chinese,
    ChineseYue,
    English,
    Arabic,
    Russian,
    Spanish,
    French,
    Portuguese,
    German,
    Turkish,
    Dutch,
    Ukrainian,
    Vietnamese,
    Indonesian,
    Japanese,
    Italian,
    Korean,
    Thai,
    Polish,
    Romanian,
    Greek,
    Czech,
    Finnish,
    Hindi,
    Bulgarian,
    Danish,
    Hebrew,
    Malay,
    Persian,
    Slovak,
    Swedish,
    Croatian,
    Filipino,
    Hungarian,
    Norwegian,
    Slovenian,
    Catalan,
    Nynorsk,
    Tamil,
    Afrikaans
}sealed class LanguageBoostConverter : JsonConverter<LanguageBoost>
{
    public override LanguageBoost Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto"=>LanguageBoost.Auto,
            "Chinese"=>LanguageBoost.Chinese,
            "Chinese,Yue"=>LanguageBoost.ChineseYue,
            "English"=>LanguageBoost.English,
            "Arabic"=>LanguageBoost.Arabic,
            "Russian"=>LanguageBoost.Russian,
            "Spanish"=>LanguageBoost.Spanish,
            "French"=>LanguageBoost.French,
            "Portuguese"=>LanguageBoost.Portuguese,
            "German"=>LanguageBoost.German,
            "Turkish"=>LanguageBoost.Turkish,
            "Dutch"=>LanguageBoost.Dutch,
            "Ukrainian"=>LanguageBoost.Ukrainian,
            "Vietnamese"=>LanguageBoost.Vietnamese,
            "Indonesian"=>LanguageBoost.Indonesian,
            "Japanese"=>LanguageBoost.Japanese,
            "Italian"=>LanguageBoost.Italian,
            "Korean"=>LanguageBoost.Korean,
            "Thai"=>LanguageBoost.Thai,
            "Polish"=>LanguageBoost.Polish,
            "Romanian"=>LanguageBoost.Romanian,
            "Greek"=>LanguageBoost.Greek,
            "Czech"=>LanguageBoost.Czech,
            "Finnish"=>LanguageBoost.Finnish,
            "Hindi"=>LanguageBoost.Hindi,
            "Bulgarian"=>LanguageBoost.Bulgarian,
            "Danish"=>LanguageBoost.Danish,
            "Hebrew"=>LanguageBoost.Hebrew,
            "Malay"=>LanguageBoost.Malay,
            "Persian"=>LanguageBoost.Persian,
            "Slovak"=>LanguageBoost.Slovak,
            "Swedish"=>LanguageBoost.Swedish,
            "Croatian"=>LanguageBoost.Croatian,
            "Filipino"=>LanguageBoost.Filipino,
            "Hungarian"=>LanguageBoost.Hungarian,
            "Norwegian"=>LanguageBoost.Norwegian,
            "Slovenian"=>LanguageBoost.Slovenian,
            "Catalan"=>LanguageBoost.Catalan,
            "Nynorsk"=>LanguageBoost.Nynorsk,
            "Tamil"=>LanguageBoost.Tamil,
            "Afrikaans"=>LanguageBoost.Afrikaans,
            _ =>(LanguageBoost)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LanguageBoost value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            LanguageBoost.Auto=>"auto",
            LanguageBoost.Chinese=>"Chinese",
            LanguageBoost.ChineseYue=>"Chinese,Yue",
            LanguageBoost.English=>"English",
            LanguageBoost.Arabic=>"Arabic",
            LanguageBoost.Russian=>"Russian",
            LanguageBoost.Spanish=>"Spanish",
            LanguageBoost.French=>"French",
            LanguageBoost.Portuguese=>"Portuguese",
            LanguageBoost.German=>"German",
            LanguageBoost.Turkish=>"Turkish",
            LanguageBoost.Dutch=>"Dutch",
            LanguageBoost.Ukrainian=>"Ukrainian",
            LanguageBoost.Vietnamese=>"Vietnamese",
            LanguageBoost.Indonesian=>"Indonesian",
            LanguageBoost.Japanese=>"Japanese",
            LanguageBoost.Italian=>"Italian",
            LanguageBoost.Korean=>"Korean",
            LanguageBoost.Thai=>"Thai",
            LanguageBoost.Polish=>"Polish",
            LanguageBoost.Romanian=>"Romanian",
            LanguageBoost.Greek=>"Greek",
            LanguageBoost.Czech=>"Czech",
            LanguageBoost.Finnish=>"Finnish",
            LanguageBoost.Hindi=>"Hindi",
            LanguageBoost.Bulgarian=>"Bulgarian",
            LanguageBoost.Danish=>"Danish",
            LanguageBoost.Hebrew=>"Hebrew",
            LanguageBoost.Malay=>"Malay",
            LanguageBoost.Persian=>"Persian",
            LanguageBoost.Slovak=>"Slovak",
            LanguageBoost.Swedish=>"Swedish",
            LanguageBoost.Croatian=>"Croatian",
            LanguageBoost.Filipino=>"Filipino",
            LanguageBoost.Hungarian=>"Hungarian",
            LanguageBoost.Norwegian=>"Norwegian",
            LanguageBoost.Slovenian=>"Slovenian",
            LanguageBoost.Catalan=>"Catalan",
            LanguageBoost.Nynorsk=>"Nynorsk",
            LanguageBoost.Tamil=>"Tamil",
            LanguageBoost.Afrikaans=>"Afrikaans",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}