using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.VoiceClones;

/// <summary>
/// Creates a new voice clone by capturing the voice identity of an existing voice
/// design. The clone can then be used for text-to-speech synthesis.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VoiceCloneCreateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    /// <summary>
    /// Request body for creating a voice clone from an existing voice design.
    /// </summary>
    public required VoiceCloneRequest VoiceCloneRequest {
        get {
            return WrappedJsonSerializer.GetNotNullClass<VoiceCloneRequest>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public VoiceCloneCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCloneCreateParams (
        VoiceCloneCreateParams voiceCloneCreateParams
    ) : base(voiceCloneCreateParams)
    { this.RawBodyData = voiceCloneCreateParams.RawBodyData; }
    #pragma warning restore CS8618

    public VoiceCloneCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCloneCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VoiceCloneCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(VoiceCloneCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/voice_clones"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

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
/// Request body for creating a voice clone from an existing voice design.
/// </summary>
[JsonConverter(typeof(VoiceCloneRequestConverter))]
public record class VoiceCloneRequest : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string Language {
        get {
            return Match(telnyxDesignClone: ( x )=>x.Language,
            minimaxDesignClone: ( x )=>x.Language);
        }
    }

    public string Name {
        get {
            return Match(telnyxDesignClone: ( x )=>x.Name,
            minimaxDesignClone: ( x )=>x.Name);
        }
    }

    public string VoiceDesignID {
        get {
            return Match(telnyxDesignClone: ( x )=>x.VoiceDesignID,
            minimaxDesignClone: ( x )=>x.VoiceDesignID);
        }
    }

    public VoiceCloneRequest (
        TelnyxDesignClone value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceCloneRequest (
        MinimaxDesignClone value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public VoiceCloneRequest (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TelnyxDesignClone"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTelnyxDesignClone(out var value)) {
///     // `value` is of type `TelnyxDesignClone`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTelnyxDesignClone(
        [NotNullWhen(true)] out TelnyxDesignClone? value
    )
    {
        value =this.Value as TelnyxDesignClone ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MinimaxDesignClone"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMinimaxDesignClone(out var value)) {
///     // `value` is of type `MinimaxDesignClone`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMinimaxDesignClone(
        [NotNullWhen(true)] out MinimaxDesignClone? value
    )
    {
        value =this.Value as MinimaxDesignClone ;
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
///     (TelnyxDesignClone value) =&gt; {...},
///     (MinimaxDesignClone value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<TelnyxDesignClone> telnyxDesignClone,
        System::Action<MinimaxDesignClone> minimaxDesignClone
    )
    {
        switch (this.Value)
        {
            case TelnyxDesignClone value:
                telnyxDesignClone(value);
                break;
            case MinimaxDesignClone value:
                minimaxDesignClone(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of VoiceCloneRequest");

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
///     (TelnyxDesignClone value) =&gt; {...},
///     (MinimaxDesignClone value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<TelnyxDesignClone, T> telnyxDesignClone,
        System::Func<MinimaxDesignClone, T> minimaxDesignClone
    )
    {
        return this.Value switch
        {
            TelnyxDesignClone value=>telnyxDesignClone(value),
            MinimaxDesignClone value=>minimaxDesignClone(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of VoiceCloneRequest")
        } ;
    }

    public static implicit operator VoiceCloneRequest (
        TelnyxDesignClone value
    )=> new(value) ;

    public static implicit operator VoiceCloneRequest (
        MinimaxDesignClone value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of VoiceCloneRequest");
        }
        this.Switch((telnyxDesignClone) => telnyxDesignClone.Validate(),
        (minimaxDesignClone) => minimaxDesignClone.Validate());
    }

    public virtual bool Equals(VoiceCloneRequest? other)
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
        { TelnyxDesignClone _=>0, MinimaxDesignClone _=>1, _ =>-1 } ;
    }
}

sealed class VoiceCloneRequestConverter : JsonConverter<VoiceCloneRequest>
{
    public override VoiceCloneRequest? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? provider;
        try {
            provider = element.GetProperty("provider").GetString();
        } catch {
            provider = null;
        }

        switch (provider)
        {
            default:
                {
                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<MinimaxDesignClone>(element, options);
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
                        var deserialized = JsonSerializer.Deserialize<TelnyxDesignClone>(element, options);
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

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoiceCloneRequest value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Create a voice clone from a voice design using the Telnyx provider.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TelnyxDesignClone, TelnyxDesignCloneFromRaw>))]
public sealed record class TelnyxDesignClone : JsonModel
{
    /// <summary>
    /// Gender of the voice clone.
    /// </summary>
    public required ApiEnum<string, Gender> Gender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Gender>>(
                "gender"
            );
        }
        init { this._rawData.Set("gender", value); }
    }

    /// <summary>
    /// ISO 639-1 language code for the clone. Supports the combined Telnyx language set.
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
    /// UUID of the source voice design to clone.
    /// </summary>
    public required string VoiceDesignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "voice_design_id"
            );
        }
        init { this._rawData.Set("voice_design_id", value); }
    }

    /// <summary>
    /// Voice synthesis provider. Defaults to `telnyx`.
    /// </summary>
    public ApiEnum<string, Provider>? Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Provider>>(
                "provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("provider", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Gender.Validate();
        _ = this.Language;
        _ = this.Name;
        _ = this.VoiceDesignID;
        this.Provider?.Validate();
    }

    public TelnyxDesignClone ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelnyxDesignClone (TelnyxDesignClone telnyxDesignClone) : base(
        telnyxDesignClone
    )
    {  }
    #pragma warning restore CS8618

    public TelnyxDesignClone (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelnyxDesignClone (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelnyxDesignCloneFromRaw.FromRawUnchecked"/>
    public static TelnyxDesignClone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelnyxDesignCloneFromRaw : IFromRawJson<TelnyxDesignClone>
{
    /// <inheritdoc/>
    public TelnyxDesignClone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelnyxDesignClone.FromRawUnchecked(rawData);
}

/// <summary>
/// Gender of the voice clone.
/// </summary>
[JsonConverter(typeof(GenderConverter))]
public enum Gender
{
    Male, Female, Neutral
}

sealed class GenderConverter : JsonConverter<Gender>
{
    public override Gender Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "male"=>Gender.Male,
            "female"=>Gender.Female,
            "neutral"=>Gender.Neutral,
            _ =>(Gender)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Gender value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Gender.Male=>"male",
            Gender.Female=>"female",
            Gender.Neutral=>"neutral",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Voice synthesis provider. Defaults to `telnyx`.
/// </summary>
[JsonConverter(typeof(ProviderConverter))]
public enum Provider
{
    Telnyx, Minimax
}

sealed class ProviderConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>Provider.Telnyx,
            "minimax"=>Provider.Minimax,
            _ =>(Provider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Provider value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Provider.Telnyx=>"telnyx",
            Provider.Minimax=>"minimax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Create a voice clone from a voice design using the Minimax provider.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MinimaxDesignClone, MinimaxDesignCloneFromRaw>))]
public sealed record class MinimaxDesignClone : JsonModel
{
    /// <summary>
    /// Gender of the voice clone.
    /// </summary>
    public required ApiEnum<string, MinimaxDesignCloneGender> Gender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MinimaxDesignCloneGender>>(
                "gender"
            );
        }
        init { this._rawData.Set("gender", value); }
    }

    /// <summary>
    /// ISO 639-1 language code for the clone. Supports the Minimax language set.
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
    public required ApiEnum<string, MinimaxDesignCloneProvider> Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MinimaxDesignCloneProvider>>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// UUID of the source voice design to clone.
    /// </summary>
    public required string VoiceDesignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "voice_design_id"
            );
        }
        init { this._rawData.Set("voice_design_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Gender.Validate();
        _ = this.Language;
        _ = this.Name;
        this.Provider.Validate();
        _ = this.VoiceDesignID;
    }

    public MinimaxDesignClone ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MinimaxDesignClone (MinimaxDesignClone minimaxDesignClone) : base(
        minimaxDesignClone
    )
    {  }
    #pragma warning restore CS8618

    public MinimaxDesignClone (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimaxDesignClone (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MinimaxDesignCloneFromRaw.FromRawUnchecked"/>
    public static MinimaxDesignClone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MinimaxDesignCloneFromRaw : IFromRawJson<MinimaxDesignClone>
{
    /// <inheritdoc/>
    public MinimaxDesignClone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MinimaxDesignClone.FromRawUnchecked(rawData);
}

/// <summary>
/// Gender of the voice clone.
/// </summary>
[JsonConverter(typeof(MinimaxDesignCloneGenderConverter))]
public enum MinimaxDesignCloneGender
{
    Male, Female, Neutral
}

sealed class MinimaxDesignCloneGenderConverter : JsonConverter<MinimaxDesignCloneGender>
{
    public override MinimaxDesignCloneGender Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "male"=>MinimaxDesignCloneGender.Male,
            "female"=>MinimaxDesignCloneGender.Female,
            "neutral"=>MinimaxDesignCloneGender.Neutral,
            _ =>(MinimaxDesignCloneGender)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimaxDesignCloneGender value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MinimaxDesignCloneGender.Male=>"male",
            MinimaxDesignCloneGender.Female=>"female",
            MinimaxDesignCloneGender.Neutral=>"neutral",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Voice synthesis provider. Must be `minimax`.
/// </summary>
[JsonConverter(typeof(MinimaxDesignCloneProviderConverter))]
public enum MinimaxDesignCloneProvider
{
    Telnyx, Minimax
}

sealed class MinimaxDesignCloneProviderConverter : JsonConverter<MinimaxDesignCloneProvider>
{
    public override MinimaxDesignCloneProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>MinimaxDesignCloneProvider.Telnyx,
            "minimax"=>MinimaxDesignCloneProvider.Minimax,
            _ =>(MinimaxDesignCloneProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MinimaxDesignCloneProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MinimaxDesignCloneProvider.Telnyx=>"telnyx",
            MinimaxDesignCloneProvider.Minimax=>"minimax",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}