using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.VoiceClones;

/// <summary>
/// Creates a new voice clone by uploading an audio file directly. Supported formats:
/// WAV, MP3, FLAC, OGG, M4A. For best results, provide 5–60 seconds of clear speech
/// (Ultra accepts up to 60 seconds; Qwen3TTS auto-trims to 10 seconds; Minimax accepts
/// up to 5 minutes). Maximum file size: 5MB for Telnyx, 20MB for Minimax.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VoiceCloneCreateFromUploadParams : ParamsBase
{
    public MultipartJsonElement RawBodyData { get; private init; }

    /// <summary>
    /// Multipart form data for creating a voice clone from a direct audio upload.
    /// Maximum file size: 5MB for Telnyx, 20MB for Minimax.
    /// </summary>
    public required VoiceCloneUploadRequest VoiceCloneUploadRequest {
        get {
            return WrappedMultipartJsonSerializer.GetNotNullClass<VoiceCloneUploadRequest>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public VoiceCloneCreateFromUploadParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCloneCreateFromUploadParams (
        VoiceCloneCreateFromUploadParams voiceCloneCreateFromUploadParams
    ) : base(voiceCloneCreateFromUploadParams)
    { this.RawBodyData = voiceCloneCreateFromUploadParams.RawBodyData; }
    #pragma warning restore CS8618

    public VoiceCloneCreateFromUploadParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        MultipartJsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCloneCreateFromUploadParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        MultipartJsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VoiceCloneCreateFromUploadParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        MultipartJsonElement rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, MultipartJsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(VoiceCloneCreateFromUploadParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this.RawBodyData.Equals(
            other.RawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/voice_clones/from_upload"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    { return MultipartJsonSerializer.Serialize(RawBodyData) ; }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Multipart form data for creating a voice clone from a direct audio upload. Maximum
/// file size: 5MB for Telnyx, 20MB for Minimax.
/// </summary>
[JsonConverter(typeof(VoiceCloneUploadRequestConverter))]
public record class VoiceCloneUploadRequest : ModelBase
{
    public object? Value { get; } = null;

    MultipartJsonElement? _element = null;

    public MultipartJsonElement Json {
        get {
            return this._element ??= MultipartJsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public BinaryContent AudioFile {
        get {
            return Match(telnyxQwen3TtsClone: ( x )=>x.AudioFile,
            telnyxUltraClone: ( x )=>x.AudioFile,
            minimaxClone: ( x )=>x.AudioFile);
        }
    }

    public string Language {
        get {
            return Match(telnyxQwen3TtsClone: ( x )=>x.Language,
            telnyxUltraClone: ( x )=>x.Language,
            minimaxClone: ( x )=>x.Language);
        }
    }

    public string Name {
        get {
            return Match(telnyxQwen3TtsClone: ( x )=>x.Name,
            telnyxUltraClone: ( x )=>x.Name,
            minimaxClone: ( x )=>x.Name);
        }
    }

    public string? Label {
        get {
            return Match<string?>(telnyxQwen3TtsClone: ( x )=>x.Label,
            telnyxUltraClone: ( x )=>x.Label,
            minimaxClone: ( x )=>x.Label);
        }
    }

    public string? RefText {
        get {
            return Match<string?>(telnyxQwen3TtsClone: ( x )=>x.RefText,
            telnyxUltraClone: ( x )=>x.RefText,
            minimaxClone: ( x )=>x.RefText);
        }
    }

    public VoiceCloneUploadRequest (
        TelnyxQwen3TtsClone value, MultipartJsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceCloneUploadRequest (
        TelnyxUltraClone value, MultipartJsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceCloneUploadRequest (
        MinimaxClone value, MultipartJsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceCloneUploadRequest (MultipartJsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TelnyxQwen3TtsClone"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTelnyxQwen3TtsClone(out var value)) {
///     // `value` is of type `TelnyxQwen3TtsClone`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTelnyxQwen3TtsClone(
        [NotNullWhen(true)] out TelnyxQwen3TtsClone? value
    )
    {
        value =this.Value as TelnyxQwen3TtsClone ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TelnyxUltraClone"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTelnyxUltraClone(out var value)) {
///     // `value` is of type `TelnyxUltraClone`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTelnyxUltraClone(
        [NotNullWhen(true)] out TelnyxUltraClone? value
    )
    {
        value =this.Value as TelnyxUltraClone ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MinimaxClone"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMinimaxClone(out var value)) {
///     // `value` is of type `MinimaxClone`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMinimaxClone([NotNullWhen(true)] out MinimaxClone? value)
    {
        value =this.Value as MinimaxClone ;
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
///     (TelnyxQwen3TtsClone value) =&gt; {...},
///     (TelnyxUltraClone value) =&gt; {...},
///     (MinimaxClone value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<TelnyxQwen3TtsClone> telnyxQwen3TtsClone,
        System::Action<TelnyxUltraClone> telnyxUltraClone,
        System::Action<MinimaxClone> minimaxClone
    )
    {
        switch (this.Value)
        {
            case TelnyxQwen3TtsClone value:
                telnyxQwen3TtsClone(value);
                break;
            case TelnyxUltraClone value:
                telnyxUltraClone(value);
                break;
            case MinimaxClone value:
                minimaxClone(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of VoiceCloneUploadRequest");

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
///     (TelnyxQwen3TtsClone value) =&gt; {...},
///     (TelnyxUltraClone value) =&gt; {...},
///     (MinimaxClone value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<TelnyxQwen3TtsClone, T> telnyxQwen3TtsClone,
        System::Func<TelnyxUltraClone, T> telnyxUltraClone,
        System::Func<MinimaxClone, T> minimaxClone
    )
    {
        return this.Value switch
        {
            TelnyxQwen3TtsClone value=>telnyxQwen3TtsClone(value),
            TelnyxUltraClone value=>telnyxUltraClone(value),
            MinimaxClone value=>minimaxClone(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of VoiceCloneUploadRequest")
        } ;
    }

    public static implicit operator VoiceCloneUploadRequest (
        TelnyxQwen3TtsClone value
    )=> new(value) ;

    public static implicit operator VoiceCloneUploadRequest (
        TelnyxUltraClone value
    )=> new(value) ;

    public static implicit operator VoiceCloneUploadRequest (
        MinimaxClone value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of VoiceCloneUploadRequest");
        }
        this.Switch((telnyxQwen3TtsClone) => telnyxQwen3TtsClone.Validate(),
        (telnyxUltraClone) => telnyxUltraClone.Validate(),
        (minimaxClone) => minimaxClone.Validate());
    }

    public virtual bool Equals(VoiceCloneUploadRequest? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    MultipartJsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            TelnyxQwen3TtsClone _=>0,
            TelnyxUltraClone _=>1,
            MinimaxClone _=>2,
            _ =>-1
        } ;
    }
}

sealed class VoiceCloneUploadRequestConverter : JsonConverter<VoiceCloneUploadRequest>
{
    public override VoiceCloneUploadRequest? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<MultipartJsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = MultipartJsonSerializer.Deserialize<TelnyxUltraClone>(element, options);
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
            var deserialized = MultipartJsonSerializer.Deserialize<TelnyxQwen3TtsClone>(element, options);
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
            var deserialized = MultipartJsonSerializer.Deserialize<MinimaxClone>(element, options);
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
        VoiceCloneUploadRequest value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Upload-based voice clone using the Telnyx Qwen3TTS model (default).
/// </summary>
[JsonConverter(typeof(MultipartJsonModelConverter<TelnyxQwen3TtsClone, TelnyxQwen3TtsCloneFromRaw>))]
public sealed record class TelnyxQwen3TtsClone : MultipartJsonModel
{
    /// <summary>
    /// Audio file to clone the voice from. Supported formats: WAV, MP3, FLAC, OGG,
    /// M4A. For best quality, provide 5–10 seconds of clear, uninterrupted speech.
    /// Maximum size: 5MB.
    /// </summary>
    public required BinaryContent AudioFile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BinaryContent>(
                "audio_file"
            );
        }
        init { this._rawData.Set("audio_file", value); }
    }

    /// <summary>
    /// Gender of the voice clone.
    /// </summary>
    public required ApiEnum<string, TelnyxQwen3TtsCloneGender> Gender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TelnyxQwen3TtsCloneGender>>(
                "gender"
            );
        }
        init { this._rawData.Set("gender", value); }
    }

    /// <summary>
    /// ISO 639-1 language code from the Qwen language set.
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
    /// Name for the voice clone.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Voice synthesis provider. Must be `telnyx`.
    /// </summary>
    public required ApiEnum<string, TelnyxQwen3TtsCloneProvider> Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TelnyxQwen3TtsCloneProvider>>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Optional custom label describing the voice style.
    /// </summary>
    public string? Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "label"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    /// <summary>
    /// TTS model identifier. Nullable/omittable — defaults to Qwen3TTS.
    /// </summary>
    public ApiEnum<string, ModelID>? ModelID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ModelID>>(
                "model_id"
            );
        }
        init { this._rawData.Set("model_id", value); }
    }

    /// <summary>
    /// Optional transcript of the audio file. Providing this improves clone quality.
    /// </summary>
    public string? RefText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ref_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ref_text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AudioFile;
        this.Gender.Validate();
        _ = this.Language;
        _ = this.Name;
        this.Provider.Validate();
        _ = this.Label;
        this.ModelID?.Validate();
        _ = this.RefText;
    }

    public TelnyxQwen3TtsClone ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelnyxQwen3TtsClone (TelnyxQwen3TtsClone telnyxQwen3TtsClone) : base(
        telnyxQwen3TtsClone
    )
    {  }
    #pragma warning restore CS8618

    public TelnyxQwen3TtsClone (
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelnyxQwen3TtsClone (FrozenDictionary<string, MultipartJsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelnyxQwen3TtsCloneFromRaw.FromRawUnchecked"/>
    public static TelnyxQwen3TtsClone FromRawUnchecked(
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelnyxQwen3TtsCloneFromRaw : IFromRawMultipartJson<TelnyxQwen3TtsClone>
{
    /// <inheritdoc/>
    public TelnyxQwen3TtsClone FromRawUnchecked(
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    =>TelnyxQwen3TtsClone.FromRawUnchecked(rawData);
}

/// <summary>
/// Gender of the voice clone.
/// </summary>
[JsonConverter(typeof(TelnyxQwen3TtsCloneGenderConverter))]
public enum TelnyxQwen3TtsCloneGender
{
    Male, Female, Neutral
}

sealed class TelnyxQwen3TtsCloneGenderConverter : JsonConverter<TelnyxQwen3TtsCloneGender>
{
    public override TelnyxQwen3TtsCloneGender Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "male"=>TelnyxQwen3TtsCloneGender.Male,
            "female"=>TelnyxQwen3TtsCloneGender.Female,
            "neutral"=>TelnyxQwen3TtsCloneGender.Neutral,
            _ =>(TelnyxQwen3TtsCloneGender)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TelnyxQwen3TtsCloneGender value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TelnyxQwen3TtsCloneGender.Male=>"male",
            TelnyxQwen3TtsCloneGender.Female=>"female",
            TelnyxQwen3TtsCloneGender.Neutral=>"neutral",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Voice synthesis provider. Must be `telnyx`.
/// </summary>
[JsonConverter(typeof(TelnyxQwen3TtsCloneProviderConverter))]
public enum TelnyxQwen3TtsCloneProvider
{
    Telnyx, Minimax
}

sealed class TelnyxQwen3TtsCloneProviderConverter : JsonConverter<TelnyxQwen3TtsCloneProvider>
{
    public override TelnyxQwen3TtsCloneProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>TelnyxQwen3TtsCloneProvider.Telnyx,
            "minimax"=>TelnyxQwen3TtsCloneProvider.Minimax,
            _ =>(TelnyxQwen3TtsCloneProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TelnyxQwen3TtsCloneProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TelnyxQwen3TtsCloneProvider.Telnyx=>"telnyx",
            TelnyxQwen3TtsCloneProvider.Minimax=>"minimax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// TTS model identifier. Nullable/omittable — defaults to Qwen3TTS.
/// </summary>
[JsonConverter(typeof(ModelIDConverter))]
public enum ModelID
{
    Qwen3Tts
}

sealed class ModelIDConverter : JsonConverter<ModelID>
{
    public override ModelID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "Qwen3TTS"=>ModelID.Qwen3Tts, _ =>(ModelID)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, ModelID value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ModelID.Qwen3Tts=>"Qwen3TTS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Upload-based voice clone using the Telnyx Ultra model.
/// </summary>
[JsonConverter(typeof(MultipartJsonModelConverter<TelnyxUltraClone, TelnyxUltraCloneFromRaw>))]
public sealed record class TelnyxUltraClone : MultipartJsonModel
{
    /// <summary>
    /// Audio file to clone the voice from. Supported formats: WAV, MP3, FLAC, OGG,
    /// M4A. For best quality, provide up to 60 seconds of clear, uninterrupted speech.
    /// Maximum size: 5MB.
    /// </summary>
    public required BinaryContent AudioFile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BinaryContent>(
                "audio_file"
            );
        }
        init { this._rawData.Set("audio_file", value); }
    }

    /// <summary>
    /// Gender of the voice clone.
    /// </summary>
    public required ApiEnum<string, TelnyxUltraCloneGender> Gender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TelnyxUltraCloneGender>>(
                "gender"
            );
        }
        init { this._rawData.Set("gender", value); }
    }

    /// <summary>
    /// ISO 639-1 language code from the Ultra language set (40 languages).
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
    /// TTS model identifier. Must be `Ultra`.
    /// </summary>
    public required ApiEnum<string, TelnyxUltraCloneModelID> ModelID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TelnyxUltraCloneModelID>>(
                "model_id"
            );
        }
        init { this._rawData.Set("model_id", value); }
    }

    /// <summary>
    /// Name for the voice clone.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Voice synthesis provider. Must be `telnyx`.
    /// </summary>
    public required ApiEnum<string, TelnyxUltraCloneProvider> Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TelnyxUltraCloneProvider>>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Optional custom label describing the voice style.
    /// </summary>
    public string? Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "label"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    /// <summary>
    /// Optional transcript of the audio file. Providing this improves clone quality.
    /// </summary>
    public string? RefText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ref_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ref_text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AudioFile;
        this.Gender.Validate();
        _ = this.Language;
        this.ModelID.Validate();
        _ = this.Name;
        this.Provider.Validate();
        _ = this.Label;
        _ = this.RefText;
    }

    public TelnyxUltraClone ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelnyxUltraClone (TelnyxUltraClone telnyxUltraClone) : base(
        telnyxUltraClone
    )
    {  }
    #pragma warning restore CS8618

    public TelnyxUltraClone (
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelnyxUltraClone (FrozenDictionary<string, MultipartJsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelnyxUltraCloneFromRaw.FromRawUnchecked"/>
    public static TelnyxUltraClone FromRawUnchecked(
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelnyxUltraCloneFromRaw : IFromRawMultipartJson<TelnyxUltraClone>
{
    /// <inheritdoc/>
    public TelnyxUltraClone FromRawUnchecked(
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    =>TelnyxUltraClone.FromRawUnchecked(rawData);
}

/// <summary>
/// Gender of the voice clone.
/// </summary>
[JsonConverter(typeof(TelnyxUltraCloneGenderConverter))]
public enum TelnyxUltraCloneGender
{
    Male, Female, Neutral
}

sealed class TelnyxUltraCloneGenderConverter : JsonConverter<TelnyxUltraCloneGender>
{
    public override TelnyxUltraCloneGender Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "male"=>TelnyxUltraCloneGender.Male,
            "female"=>TelnyxUltraCloneGender.Female,
            "neutral"=>TelnyxUltraCloneGender.Neutral,
            _ =>(TelnyxUltraCloneGender)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TelnyxUltraCloneGender value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TelnyxUltraCloneGender.Male=>"male",
            TelnyxUltraCloneGender.Female=>"female",
            TelnyxUltraCloneGender.Neutral=>"neutral",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// TTS model identifier. Must be `Ultra`.
/// </summary>
[JsonConverter(typeof(TelnyxUltraCloneModelIDConverter))]
public enum TelnyxUltraCloneModelID
{
    Ultra
}

sealed class TelnyxUltraCloneModelIDConverter : JsonConverter<TelnyxUltraCloneModelID>
{
    public override TelnyxUltraCloneModelID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Ultra"=>TelnyxUltraCloneModelID.Ultra,
            _ =>(TelnyxUltraCloneModelID)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TelnyxUltraCloneModelID value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TelnyxUltraCloneModelID.Ultra=>"Ultra",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Voice synthesis provider. Must be `telnyx`.
/// </summary>
[JsonConverter(typeof(TelnyxUltraCloneProviderConverter))]
public enum TelnyxUltraCloneProvider
{
    Telnyx, Minimax
}

sealed class TelnyxUltraCloneProviderConverter : JsonConverter<TelnyxUltraCloneProvider>
{
    public override TelnyxUltraCloneProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>TelnyxUltraCloneProvider.Telnyx,
            "minimax"=>TelnyxUltraCloneProvider.Minimax,
            _ =>(TelnyxUltraCloneProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TelnyxUltraCloneProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TelnyxUltraCloneProvider.Telnyx=>"telnyx",
            TelnyxUltraCloneProvider.Minimax=>"minimax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Upload-based voice clone using the Minimax provider.
/// </summary>
[JsonConverter(typeof(MultipartJsonModelConverter<MinimaxClone, MinimaxCloneFromRaw>))]
public sealed record class MinimaxClone : MultipartJsonModel
{
    /// <summary>
    /// Audio file to clone the voice from. Supported formats: WAV, MP3, FLAC, OGG,
    /// M4A. For best quality, provide 5–10 seconds of clear, uninterrupted speech.
    /// Maximum size: 20MB.
    /// </summary>
    public required BinaryContent AudioFile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BinaryContent>(
                "audio_file"
            );
        }
        init { this._rawData.Set("audio_file", value); }
    }

    /// <summary>
    /// Gender of the voice clone.
    /// </summary>
    public required ApiEnum<string, MinimaxCloneGender> Gender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MinimaxCloneGender>>(
                "gender"
            );
        }
        init { this._rawData.Set("gender", value); }
    }

    /// <summary>
    /// ISO 639-1 language code from the Minimax language set.
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
    /// Name for the voice clone.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Voice synthesis provider. Must be `minimax`.
    /// </summary>
    public required ApiEnum<string, MinimaxCloneProvider> Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MinimaxCloneProvider>>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Optional custom label describing the voice style.
    /// </summary>
    public string? Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "label"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    /// <summary>
    /// TTS model identifier. Nullable — defaults to speech-2.8-turbo.
    /// </summary>
    public ApiEnum<string, MinimaxCloneModelID>? ModelID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MinimaxCloneModelID>>(
                "model_id"
            );
        }
        init { this._rawData.Set("model_id", value); }
    }

    /// <summary>
    /// Optional transcript of the audio file. Providing this improves clone quality.
    /// </summary>
    public string? RefText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ref_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ref_text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AudioFile;
        this.Gender.Validate();
        _ = this.Language;
        _ = this.Name;
        this.Provider.Validate();
        _ = this.Label;
        this.ModelID?.Validate();
        _ = this.RefText;
    }

    public MinimaxClone ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MinimaxClone (MinimaxClone minimaxClone) : base(minimaxClone)
    {  }
    #pragma warning restore CS8618

    public MinimaxClone (
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimaxClone (FrozenDictionary<string, MultipartJsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MinimaxCloneFromRaw.FromRawUnchecked"/>
    public static MinimaxClone FromRawUnchecked(
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MinimaxCloneFromRaw : IFromRawMultipartJson<MinimaxClone>
{
    /// <inheritdoc/>
    public MinimaxClone FromRawUnchecked(
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    =>MinimaxClone.FromRawUnchecked(rawData);
}

/// <summary>
/// Gender of the voice clone.
/// </summary>
[JsonConverter(typeof(MinimaxCloneGenderConverter))]
public enum MinimaxCloneGender
{
    Male, Female, Neutral
}

sealed class MinimaxCloneGenderConverter : JsonConverter<MinimaxCloneGender>
{
    public override MinimaxCloneGender Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "male"=>MinimaxCloneGender.Male,
            "female"=>MinimaxCloneGender.Female,
            "neutral"=>MinimaxCloneGender.Neutral,
            _ =>(MinimaxCloneGender)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimaxCloneGender value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MinimaxCloneGender.Male=>"male",
            MinimaxCloneGender.Female=>"female",
            MinimaxCloneGender.Neutral=>"neutral",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Voice synthesis provider. Must be `minimax`.
/// </summary>
[JsonConverter(typeof(MinimaxCloneProviderConverter))]
public enum MinimaxCloneProvider
{
    Telnyx, Minimax
}

sealed class MinimaxCloneProviderConverter : JsonConverter<MinimaxCloneProvider>
{
    public override MinimaxCloneProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>MinimaxCloneProvider.Telnyx,
            "minimax"=>MinimaxCloneProvider.Minimax,
            _ =>(MinimaxCloneProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimaxCloneProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MinimaxCloneProvider.Telnyx=>"telnyx",
            MinimaxCloneProvider.Minimax=>"minimax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// TTS model identifier. Nullable — defaults to speech-2.8-turbo.
/// </summary>
[JsonConverter(typeof(MinimaxCloneModelIDConverter))]
public enum MinimaxCloneModelID
{
    Speech2_8Turbo
}

sealed class MinimaxCloneModelIDConverter : JsonConverter<MinimaxCloneModelID>
{
    public override MinimaxCloneModelID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "speech-2.8-turbo"=>MinimaxCloneModelID.Speech2_8Turbo,
            _ =>(MinimaxCloneModelID)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimaxCloneModelID value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MinimaxCloneModelID.Speech2_8Turbo=>"speech-2.8-turbo",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}