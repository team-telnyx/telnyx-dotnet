using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<VoiceSettings, VoiceSettingsFromRaw>))]
public sealed record class VoiceSettings : JsonModel
{
    /// <summary>
    /// The voice to be used by the voice assistant. Check the full list of [available
    /// voices](https://developers.telnyx.com/docs/tts-stt/tts-available-voices)
    /// via our voices API. To use ElevenLabs, you must reference your ElevenLabs
    /// API key as an integration secret under the `api_key_ref` field. See [integration
    /// secrets documentation](https://developers.telnyx.com/api-reference/integration-secrets/create-a-secret)
    /// for details. For Telnyx voices, use `Telnyx.&lt;model_id&gt;.&lt;voice_id&gt;`
    /// (e.g. Telnyx.KokoroTTS.af_heart). The voice portion of the identifier supports
    /// [dynamic variables](https://developers.telnyx.com/docs/inference/ai-assistants/dynamic-variables)
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
    public VoiceSettingsBackgroundAudio? BackgroundAudio {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceSettingsBackgroundAudio>(
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
    public ApiEnum<string, VoiceSettingsLanguageBoost>? LanguageBoost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceSettingsLanguageBoost>>(
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
    /// applicable for Telnyx Natural voices.
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

    public VoiceSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceSettings (VoiceSettings voiceSettings) : base(voiceSettings)
    {  }
    #pragma warning restore CS8618

    public VoiceSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceSettingsFromRaw.FromRawUnchecked"/>
    public static VoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public VoiceSettings (string voice) : this()
    { this.Voice = voice; }
}

class VoiceSettingsFromRaw : IFromRawJson<VoiceSettings>
{
    /// <inheritdoc/>
    public VoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional background audio to play on the call. Use a predefined media bed, or
/// supply a looped MP3 URL. If a media URL is chosen in the portal, customers can
/// preview it before saving.
/// </summary>
[JsonConverter(typeof(VoiceSettingsBackgroundAudioConverter))]
public record class VoiceSettingsBackgroundAudio : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public JsonElement Type {
        get {
            return Match(predefinedMedia: ( x )=>x.Type,
            mediaUrl: ( x )=>x.Type,
            mediaName: ( x )=>x.Type);
        }
    }

    public VoiceSettingsBackgroundAudio (
        PredefinedMedia value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettingsBackgroundAudio (
        MediaUrl value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettingsBackgroundAudio (
        MediaName value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceSettingsBackgroundAudio (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PredefinedMedia"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPredefinedMedia(out var value)) {
///     // `value` is of type `PredefinedMedia`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPredefinedMedia(
        [NotNullWhen(true)] out PredefinedMedia? value
    )
    {
        value =this.Value as PredefinedMedia ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MediaUrl"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMediaUrl(out var value)) {
///     // `value` is of type `MediaUrl`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMediaUrl([NotNullWhen(true)] out MediaUrl? value)
    {
        value =this.Value as MediaUrl ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MediaName"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMediaName(out var value)) {
///     // `value` is of type `MediaName`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMediaName([NotNullWhen(true)] out MediaName? value)
    {
        value =this.Value as MediaName ;
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
///     (PredefinedMedia value) =&gt; {...},
///     (MediaUrl value) =&gt; {...},
///     (MediaName value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<PredefinedMedia> predefinedMedia,
        System::Action<MediaUrl> mediaUrl,
        System::Action<MediaName> mediaName
    )
    {
        switch (this.Value)
        {
            case PredefinedMedia value:
                predefinedMedia(value);
                break;
            case MediaUrl value:
                mediaUrl(value);
                break;
            case MediaName value:
                mediaName(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of VoiceSettingsBackgroundAudio");

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
///     (PredefinedMedia value) =&gt; {...},
///     (MediaUrl value) =&gt; {...},
///     (MediaName value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<PredefinedMedia, T> predefinedMedia,
        System::Func<MediaUrl, T> mediaUrl,
        System::Func<MediaName, T> mediaName
    )
    {
        return this.Value switch
        {
            PredefinedMedia value=>predefinedMedia(value),
            MediaUrl value=>mediaUrl(value),
            MediaName value=>mediaName(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of VoiceSettingsBackgroundAudio")
        } ;
    }

    public static implicit operator VoiceSettingsBackgroundAudio (
        PredefinedMedia value
    )=> new(value) ;

    public static implicit operator VoiceSettingsBackgroundAudio (
        MediaUrl value
    )=> new(value) ;

    public static implicit operator VoiceSettingsBackgroundAudio (
        MediaName value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of VoiceSettingsBackgroundAudio");
        }
        this.Switch((predefinedMedia) => predefinedMedia.Validate(),
        (mediaUrl) => mediaUrl.Validate(),
        (mediaName) => mediaName.Validate());
    }

    public virtual bool Equals(VoiceSettingsBackgroundAudio? other)
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
        { PredefinedMedia _=>0, MediaUrl _=>1, MediaName _=>2, _ =>-1 } ;
    }
}sealed class VoiceSettingsBackgroundAudioConverter : JsonConverter<VoiceSettingsBackgroundAudio>
{
    public override VoiceSettingsBackgroundAudio? Read(
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
            case "predefined_media":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PredefinedMedia>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "media_url":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MediaUrl>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "media_name":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MediaName>(element, options);
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
                { return new VoiceSettingsBackgroundAudio(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceSettingsBackgroundAudio value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<PredefinedMedia, PredefinedMediaFromRaw>))]
public sealed record class PredefinedMedia : JsonModel
{
    /// <summary>
    /// Select from predefined media options.
    /// </summary>
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The predefined media to use. `silence` disables background audio.
    /// </summary>
    public required ApiEnum<string, PredefinedMediaValue> Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PredefinedMediaValue>>(
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
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("predefined_media")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        this.Value.Validate();
        _ = this.Volume;
    }

    public PredefinedMedia ()
    { this.Type = JsonSerializer.SerializeToElement("predefined_media"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PredefinedMedia (PredefinedMedia predefinedMedia) : base(
        predefinedMedia
    )
    {  }
    #pragma warning restore CS8618

    public PredefinedMedia (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("predefined_media");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PredefinedMedia (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PredefinedMediaFromRaw.FromRawUnchecked"/>
    public static PredefinedMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PredefinedMedia (ApiEnum<string, PredefinedMediaValue> value) : this(

    )
    { this.Value = value; }
}class PredefinedMediaFromRaw : IFromRawJson<PredefinedMedia>
{
    /// <inheritdoc/>
    public PredefinedMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PredefinedMedia.FromRawUnchecked(rawData);
}/// <summary>
/// The predefined media to use. `silence` disables background audio.
/// </summary>
[JsonConverter(typeof(PredefinedMediaValueConverter))]
public enum PredefinedMediaValue
{
    Silence, Office
}sealed class PredefinedMediaValueConverter : JsonConverter<PredefinedMediaValue>
{
    public override PredefinedMediaValue Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "silence"=>PredefinedMediaValue.Silence,
            "office"=>PredefinedMediaValue.Office,
            _ =>(PredefinedMediaValue)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PredefinedMediaValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PredefinedMediaValue.Silence=>"silence",
            PredefinedMediaValue.Office=>"office",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<MediaUrl, MediaUrlFromRaw>))]
public sealed record class MediaUrl : JsonModel
{
    /// <summary>
    /// Provide a direct URL to an MP3 file. The audio will loop during the call.
    /// </summary>
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
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
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("media_url")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public MediaUrl ()
    { this.Type = JsonSerializer.SerializeToElement("media_url"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaUrl (MediaUrl mediaUrl) : base(mediaUrl)
    {  }
    #pragma warning restore CS8618

    public MediaUrl (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("media_url");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaUrl (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MediaUrlFromRaw.FromRawUnchecked"/>
    public static MediaUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MediaUrl (string value) : this()
    { this.Value = value; }
}class MediaUrlFromRaw : IFromRawJson<MediaUrl>
{
    /// <inheritdoc/>
    public MediaUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MediaUrl.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MediaName, MediaNameFromRaw>))]
public sealed record class MediaName : JsonModel
{
    /// <summary>
    /// Reference a previously uploaded media by its name from Telnyx Media Storage.
    /// </summary>
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
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
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("media_name")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public MediaName ()
    { this.Type = JsonSerializer.SerializeToElement("media_name"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaName (MediaName mediaName) : base(mediaName)
    {  }
    #pragma warning restore CS8618

    public MediaName (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("media_name");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaName (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MediaNameFromRaw.FromRawUnchecked"/>
    public static MediaName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MediaName (string value) : this()
    { this.Value = value; }
}class MediaNameFromRaw : IFromRawJson<MediaName>
{
    /// <inheritdoc/>
    public MediaName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MediaName.FromRawUnchecked(rawData);
}/// <summary>
/// Enhances recognition for specific languages and dialects during MiniMax TTS synthesis.
/// Default is null (no boost). Set to 'auto' for automatic language detection. Only
/// applicable when using MiniMax voices.
/// </summary>
[JsonConverter(typeof(VoiceSettingsLanguageBoostConverter))]
public enum VoiceSettingsLanguageBoost
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
}sealed class VoiceSettingsLanguageBoostConverter : JsonConverter<VoiceSettingsLanguageBoost>
{
    public override VoiceSettingsLanguageBoost Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto"=>VoiceSettingsLanguageBoost.Auto,
            "Chinese"=>VoiceSettingsLanguageBoost.Chinese,
            "Chinese,Yue"=>VoiceSettingsLanguageBoost.ChineseYue,
            "English"=>VoiceSettingsLanguageBoost.English,
            "Arabic"=>VoiceSettingsLanguageBoost.Arabic,
            "Russian"=>VoiceSettingsLanguageBoost.Russian,
            "Spanish"=>VoiceSettingsLanguageBoost.Spanish,
            "French"=>VoiceSettingsLanguageBoost.French,
            "Portuguese"=>VoiceSettingsLanguageBoost.Portuguese,
            "German"=>VoiceSettingsLanguageBoost.German,
            "Turkish"=>VoiceSettingsLanguageBoost.Turkish,
            "Dutch"=>VoiceSettingsLanguageBoost.Dutch,
            "Ukrainian"=>VoiceSettingsLanguageBoost.Ukrainian,
            "Vietnamese"=>VoiceSettingsLanguageBoost.Vietnamese,
            "Indonesian"=>VoiceSettingsLanguageBoost.Indonesian,
            "Japanese"=>VoiceSettingsLanguageBoost.Japanese,
            "Italian"=>VoiceSettingsLanguageBoost.Italian,
            "Korean"=>VoiceSettingsLanguageBoost.Korean,
            "Thai"=>VoiceSettingsLanguageBoost.Thai,
            "Polish"=>VoiceSettingsLanguageBoost.Polish,
            "Romanian"=>VoiceSettingsLanguageBoost.Romanian,
            "Greek"=>VoiceSettingsLanguageBoost.Greek,
            "Czech"=>VoiceSettingsLanguageBoost.Czech,
            "Finnish"=>VoiceSettingsLanguageBoost.Finnish,
            "Hindi"=>VoiceSettingsLanguageBoost.Hindi,
            "Bulgarian"=>VoiceSettingsLanguageBoost.Bulgarian,
            "Danish"=>VoiceSettingsLanguageBoost.Danish,
            "Hebrew"=>VoiceSettingsLanguageBoost.Hebrew,
            "Malay"=>VoiceSettingsLanguageBoost.Malay,
            "Persian"=>VoiceSettingsLanguageBoost.Persian,
            "Slovak"=>VoiceSettingsLanguageBoost.Slovak,
            "Swedish"=>VoiceSettingsLanguageBoost.Swedish,
            "Croatian"=>VoiceSettingsLanguageBoost.Croatian,
            "Filipino"=>VoiceSettingsLanguageBoost.Filipino,
            "Hungarian"=>VoiceSettingsLanguageBoost.Hungarian,
            "Norwegian"=>VoiceSettingsLanguageBoost.Norwegian,
            "Slovenian"=>VoiceSettingsLanguageBoost.Slovenian,
            "Catalan"=>VoiceSettingsLanguageBoost.Catalan,
            "Nynorsk"=>VoiceSettingsLanguageBoost.Nynorsk,
            "Tamil"=>VoiceSettingsLanguageBoost.Tamil,
            "Afrikaans"=>VoiceSettingsLanguageBoost.Afrikaans,
            _ =>(VoiceSettingsLanguageBoost)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceSettingsLanguageBoost value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceSettingsLanguageBoost.Auto=>"auto",
            VoiceSettingsLanguageBoost.Chinese=>"Chinese",
            VoiceSettingsLanguageBoost.ChineseYue=>"Chinese,Yue",
            VoiceSettingsLanguageBoost.English=>"English",
            VoiceSettingsLanguageBoost.Arabic=>"Arabic",
            VoiceSettingsLanguageBoost.Russian=>"Russian",
            VoiceSettingsLanguageBoost.Spanish=>"Spanish",
            VoiceSettingsLanguageBoost.French=>"French",
            VoiceSettingsLanguageBoost.Portuguese=>"Portuguese",
            VoiceSettingsLanguageBoost.German=>"German",
            VoiceSettingsLanguageBoost.Turkish=>"Turkish",
            VoiceSettingsLanguageBoost.Dutch=>"Dutch",
            VoiceSettingsLanguageBoost.Ukrainian=>"Ukrainian",
            VoiceSettingsLanguageBoost.Vietnamese=>"Vietnamese",
            VoiceSettingsLanguageBoost.Indonesian=>"Indonesian",
            VoiceSettingsLanguageBoost.Japanese=>"Japanese",
            VoiceSettingsLanguageBoost.Italian=>"Italian",
            VoiceSettingsLanguageBoost.Korean=>"Korean",
            VoiceSettingsLanguageBoost.Thai=>"Thai",
            VoiceSettingsLanguageBoost.Polish=>"Polish",
            VoiceSettingsLanguageBoost.Romanian=>"Romanian",
            VoiceSettingsLanguageBoost.Greek=>"Greek",
            VoiceSettingsLanguageBoost.Czech=>"Czech",
            VoiceSettingsLanguageBoost.Finnish=>"Finnish",
            VoiceSettingsLanguageBoost.Hindi=>"Hindi",
            VoiceSettingsLanguageBoost.Bulgarian=>"Bulgarian",
            VoiceSettingsLanguageBoost.Danish=>"Danish",
            VoiceSettingsLanguageBoost.Hebrew=>"Hebrew",
            VoiceSettingsLanguageBoost.Malay=>"Malay",
            VoiceSettingsLanguageBoost.Persian=>"Persian",
            VoiceSettingsLanguageBoost.Slovak=>"Slovak",
            VoiceSettingsLanguageBoost.Swedish=>"Swedish",
            VoiceSettingsLanguageBoost.Croatian=>"Croatian",
            VoiceSettingsLanguageBoost.Filipino=>"Filipino",
            VoiceSettingsLanguageBoost.Hungarian=>"Hungarian",
            VoiceSettingsLanguageBoost.Norwegian=>"Norwegian",
            VoiceSettingsLanguageBoost.Slovenian=>"Slovenian",
            VoiceSettingsLanguageBoost.Catalan=>"Catalan",
            VoiceSettingsLanguageBoost.Nynorsk=>"Nynorsk",
            VoiceSettingsLanguageBoost.Tamil=>"Tamil",
            VoiceSettingsLanguageBoost.Afrikaans=>"Afrikaans",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}