using System = System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(TranscriptionEngineDeepgramConfigConverter))]
public record class TranscriptionEngineDeepgramConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public bool? InterimResults {
        get {
            return Match<bool?>(deepgramNova2: ( x )=>x.InterimResults,
            deepgramNova3: ( x )=>x.InterimResults);
        }
    }

    public bool? SmartFormat {
        get {
            return Match<bool?>(deepgramNova2: ( x )=>x.SmartFormat,
            deepgramNova3: ( x )=>x.SmartFormat);
        }
    }

    public long? UtteranceEndMs {
        get {
            return Match<long?>(deepgramNova2: ( x )=>x.UtteranceEndMs,
            deepgramNova3: ( x )=>x.UtteranceEndMs);
        }
    }

    public TranscriptionEngineDeepgramConfig (
        DeepgramNova2Config value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionEngineDeepgramConfig (
        DeepgramNova3Config value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TranscriptionEngineDeepgramConfig (JsonElement element)
    { this._element = element; }

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
///     (DeepgramNova2Config value) =&gt; {...},
///     (DeepgramNova3Config value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<DeepgramNova2Config> deepgramNova2,
        System::Action<DeepgramNova3Config> deepgramNova3
    )
    {
        switch (this.Value)
        {
            case DeepgramNova2Config value:
                deepgramNova2(value);
                break;
            case DeepgramNova3Config value:
                deepgramNova3(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of TranscriptionEngineDeepgramConfig");

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
///     (DeepgramNova2Config value) =&gt; {...},
///     (DeepgramNova3Config value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<DeepgramNova2Config, T> deepgramNova2,
        System::Func<DeepgramNova3Config, T> deepgramNova3
    )
    {
        return this.Value switch
        {
            DeepgramNova2Config value=>deepgramNova2(value),
            DeepgramNova3Config value=>deepgramNova3(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of TranscriptionEngineDeepgramConfig")
        } ;
    }

    public static implicit operator TranscriptionEngineDeepgramConfig (
        DeepgramNova2Config value
    )=> new(value) ;

    public static implicit operator TranscriptionEngineDeepgramConfig (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of TranscriptionEngineDeepgramConfig");
        }
        this.Switch((deepgramNova2) => deepgramNova2.Validate(),
        (deepgramNova3) => deepgramNova3.Validate());
    }

    public virtual bool Equals(TranscriptionEngineDeepgramConfig? other)
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
        { DeepgramNova2Config _=>0, DeepgramNova3Config _=>1, _ =>-1 } ;
    }
}

sealed class TranscriptionEngineDeepgramConfigConverter : JsonConverter<TranscriptionEngineDeepgramConfig>
{
    public override TranscriptionEngineDeepgramConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? transcriptionModel;
        try {
            transcriptionModel = element.GetProperty("transcription_model").GetString();
        } catch {
            transcriptionModel = null;
        }

        switch (transcriptionModel)
        {
            case "deepgram/nova-2":{
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
                { return new TranscriptionEngineDeepgramConfig(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TranscriptionEngineDeepgramConfig value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}