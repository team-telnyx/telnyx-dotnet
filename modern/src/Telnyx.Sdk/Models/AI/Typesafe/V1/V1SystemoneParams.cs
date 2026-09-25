using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Typesafe.V1;

/// <summary>
/// **Beta API.** Choose telnyx/decision-flash for the lowest cost and latency, or
/// telnyx/decision-pro for decisions that require long context, including inputs
/// beyond Jev’s 32k per-decision limit. Omitted model defaults to telnyx/decision-flash.
///
/// <para>Evaluate shared context using named choice, noul (yes/no), and score questions.
/// Returns TypeSafe System One-compatible answer shapes, the selected public model
/// alias, and token usage. See the [decision model guide](https://developers.telnyx.com/docs/inference/decision-models)
/// for examples and compatibility limits.</para>
///
/// <para>The supported request subset requires instructions for every question, string
/// descriptions for criteria (or null for choice descriptions), 1–64 questions,
/// and 2–64 options for choice and score questions. The model field accepts only
/// telnyx/decision-flash or telnyx/decision-pro. Unsupported model values and unknown
/// fields are rejected. The endpoint is synchronous and does not stream.</para>
///
/// <para>Use the TypeSafe Python SDK with base_url set to https://api.telnyx.com/v2/ai/typesafe
/// and a Telnyx API key. The SDK appends /v1/systemone; explicitly set model to a
/// supported Telnyx alias because its own default model is not supported. Compatibility
/// covers this operation and the documented request subset; it does not include
/// TypeSafe model listing. Scores describe relative preference, not calibrated correctness.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class V1SystemoneParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public Generic::IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Between 1 and 64 named questions. Each key identifies the corresponding answer.
    /// </summary>
    public required Generic::IReadOnlyDictionary<string, Question> Questions {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<FrozenDictionary<string, Question>>(
                "questions"
            );
        }
        init {
            this._rawBodyData.Set<FrozenDictionary<string, Question>>(
                "questions",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Shared context evaluated by every question.
    /// </summary>
    public required State State {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<State>(
                "state"
            );
        }
        init { this._rawBodyData.Set("state", value); }
    }

    /// <summary>
    /// Public model alias. telnyx/decision-flash offers the lowest cost and latency;
    /// telnyx/decision-pro supports decisions that require long context, including
    /// inputs beyond Jev’s 32k per-decision limit. Applies to every question in the
    /// request. Other values are rejected.
    /// </summary>
    public ApiEnum<string, Model>? Model {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Model>>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("model", value);
        }
    }

    public V1SystemoneParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SystemoneParams (V1SystemoneParams v1SystemoneParams) : base(
        v1SystemoneParams
    )
    { this._rawBodyData = new(v1SystemoneParams._rawBodyData); }
    #pragma warning restore CS8618

    public V1SystemoneParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SystemoneParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static V1SystemoneParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(V1SystemoneParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/typesafe/v1/systemone"
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
/// A choice, yes/no, or ordered-score question.
/// </summary>
[JsonConverter(typeof(QuestionConverter))]
public record class Question : ModelBase
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
            return Match(choice: ( x )=>x.Type,
            noul: ( x )=>x.Type,
            score: ( x )=>x.Type);
        }
    }

    public Question (Choice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Question (Noul value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Question (Score value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Question (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Choice"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickChoice(out var value)) {
///     // `value` is of type `Choice`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickChoice([NotNullWhen(true)] out Choice? value)
    {
        value =this.Value as Choice ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Noul"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickNoul(out var value)) {
///     // `value` is of type `Noul`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickNoul([NotNullWhen(true)] out Noul? value)
    {
        value =this.Value as Noul ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Score"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickScore(out var value)) {
///     // `value` is of type `Score`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickScore([NotNullWhen(true)] out Score? value)
    {
        value =this.Value as Score ;
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
///     (Choice value) =&gt; {...},
///     (Noul value) =&gt; {...},
///     (Score value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Choice> choice,
        System::Action<Noul> noul,
        System::Action<Score> score
    )
    {
        switch (this.Value)
        {
            case Choice value:
                choice(value);
                break;
            case Noul value:
                noul(value);
                break;
            case Score value:
                score(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Question");

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
///     (Choice value) =&gt; {...},
///     (Noul value) =&gt; {...},
///     (Score value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Choice, T> choice,
        System::Func<Noul, T> noul,
        System::Func<Score, T> score
    )
    {
        return this.Value switch
        {
            Choice value=>choice(value),
            Noul value=>noul(value),
            Score value=>score(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Question")
        } ;
    }

    public static implicit operator Question (Choice value)=> new(value) ;

    public static implicit operator Question (Noul value)=> new(value) ;

    public static implicit operator Question (Score value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Question");
        }
        this.Switch((choice) => choice.Validate(),
        (noul) => noul.Validate(),
        (score) => score.Validate());
    }

    public virtual bool Equals(Question? other)
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
        { Choice _=>0, Noul _=>1, Score _=>2, _ =>-1 } ;
    }
}

sealed class QuestionConverter : JsonConverter<Question>
{
    public override Question? Read(
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
            case "choice":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Choice>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "noul":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Noul>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "score":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Score>(element, options);
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
                { return new Question(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Question value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Select one of the supplied options.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Choice, ChoiceFromRaw>))]
public sealed record class Choice : JsonModel
{
    /// <summary>
    /// Between 2 and 64 option keys mapped to description strings or null. A null
    /// description uses the option key as its text.
    /// </summary>
    public required Generic::IReadOnlyDictionary<string, string?> Criteria {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string?>>(
                "criteria"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, string?>>(
                "criteria",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Required instructions describing what to decide about the shared state.
    /// </summary>
    public required Instructions Instructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Instructions>(
                "instructions"
            );
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// Question type.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Criteria;
        this.Instructions.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("choice")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Choice ()
    { this.Type = JsonSerializer.SerializeToElement("choice"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Choice (Choice choice) : base(choice)
    {  }
    #pragma warning restore CS8618

    public Choice (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("choice");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Choice (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ChoiceFromRaw.FromRawUnchecked"/>
    public static Choice FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ChoiceFromRaw : IFromRawJson<Choice>
{
    /// <inheritdoc/>
    public Choice FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Choice.FromRawUnchecked(rawData);
}

/// <summary>
/// Required instructions describing what to decide about the shared state.
/// </summary>
[JsonConverter(typeof(InstructionsConverter))]
public record class Instructions : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Instructions (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Instructions (
        Generic::IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public Instructions (
        Generic::IReadOnlyList<JsonElement> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Instructions (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, JsonElement> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements1(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements1(
        [NotNullWhen(true)] out Generic::IReadOnlyList<JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<JsonElement> ;
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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyDictionary<string, JsonElement>> jsonElements,
        System::Action<Generic::IReadOnlyList<JsonElement>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case Generic::IReadOnlyList<JsonElement> value:
                jsonElements1(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Instructions");

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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        System::Func<Generic::IReadOnlyList<JsonElement>, T> jsonElements1
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyDictionary<string, JsonElement> value=>jsonElements(value),
            Generic::IReadOnlyList<JsonElement> value=>jsonElements1(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Instructions")
        } ;
    }

    public static implicit operator Instructions (string value)=> new(value) ;

    public static implicit operator Instructions (
        Generic::Dictionary<string, JsonElement> value
    )=> new((Generic::IReadOnlyDictionary<string, JsonElement>)value) ;

    public static implicit operator Instructions (
        Generic::List<JsonElement> value
    )=> new((Generic::IReadOnlyList<JsonElement>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Instructions");
        }
    }

    public virtual bool Equals(Instructions? other)
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
            string _=>0,
            Generic::IReadOnlyDictionary<string, JsonElement> _=>1,
            Generic::IReadOnlyList<JsonElement> _=>2,
            _ =>-1
        } ;
    }
}

sealed class InstructionsConverter : JsonConverter<Instructions>
{
    public override Instructions? Read(
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
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyDictionary<string, JsonElement>>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<JsonElement>>(element, options);
            if (deserialized != null) {

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
        Utf8JsonWriter writer, Instructions value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Evaluate a yes/no question. Omit criteria to use Yes and No descriptions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Noul, NoulFromRaw>))]
public sealed record class Noul : JsonModel
{
    /// <summary>
    /// Required instructions describing what to decide about the shared state.
    /// </summary>
    public required NoulInstructions Instructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NoulInstructions>(
                "instructions"
            );
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// Question type.
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
    /// Optional descriptions for the positive and negative outcomes. Descriptions
    /// must be strings.
    /// </summary>
    public Criteria? Criteria {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Criteria>(
                "criteria"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("criteria", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Instructions.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("noul")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        this.Criteria?.Validate();
    }

    public Noul ()
    { this.Type = JsonSerializer.SerializeToElement("noul"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Noul (Noul noul) : base(noul)
    {  }
    #pragma warning restore CS8618

    public Noul (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("noul");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Noul (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NoulFromRaw.FromRawUnchecked"/>
    public static Noul FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Noul (NoulInstructions instructions) : this()
    { this.Instructions = instructions; }
}

class NoulFromRaw : IFromRawJson<Noul>
{
    /// <inheritdoc/>
    public Noul FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Noul.FromRawUnchecked(rawData);
}

/// <summary>
/// Required instructions describing what to decide about the shared state.
/// </summary>
[JsonConverter(typeof(NoulInstructionsConverter))]
public record class NoulInstructions : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public NoulInstructions (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public NoulInstructions (
        Generic::IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public NoulInstructions (
        Generic::IReadOnlyList<JsonElement> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public NoulInstructions (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, JsonElement> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements1(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements1(
        [NotNullWhen(true)] out Generic::IReadOnlyList<JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<JsonElement> ;
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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyDictionary<string, JsonElement>> jsonElements,
        System::Action<Generic::IReadOnlyList<JsonElement>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case Generic::IReadOnlyList<JsonElement> value:
                jsonElements1(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of NoulInstructions");

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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        System::Func<Generic::IReadOnlyList<JsonElement>, T> jsonElements1
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyDictionary<string, JsonElement> value=>jsonElements(value),
            Generic::IReadOnlyList<JsonElement> value=>jsonElements1(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of NoulInstructions")
        } ;
    }

    public static implicit operator NoulInstructions (
        string value
    )=> new(value) ;

    public static implicit operator NoulInstructions (
        Generic::Dictionary<string, JsonElement> value
    )=> new((Generic::IReadOnlyDictionary<string, JsonElement>)value) ;

    public static implicit operator NoulInstructions (
        Generic::List<JsonElement> value
    )=> new((Generic::IReadOnlyList<JsonElement>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of NoulInstructions");
        }
    }

    public virtual bool Equals(NoulInstructions? other)
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
            string _=>0,
            Generic::IReadOnlyDictionary<string, JsonElement> _=>1,
            Generic::IReadOnlyList<JsonElement> _=>2,
            _ =>-1
        } ;
    }
}

sealed class NoulInstructionsConverter : JsonConverter<NoulInstructions>
{
    public override NoulInstructions? Read(
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
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyDictionary<string, JsonElement>>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<JsonElement>>(element, options);
            if (deserialized != null) {

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
        NoulInstructions value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Optional descriptions for the positive and negative outcomes. Descriptions must
/// be strings.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Criteria, CriteriaFromRaw>))]
public sealed record class Criteria : JsonModel
{
    /// <summary>
    /// Description of the negative outcome.
    /// </summary>
    public string? False {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "false"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("false", value);
        }
    }

    /// <summary>
    /// Description of the positive outcome.
    /// </summary>
    public string? True {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "true"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("true", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.False;
        _ = this.True;
    }

    public Criteria ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Criteria (Criteria criteria) : base(criteria)
    {  }
    #pragma warning restore CS8618

    public Criteria (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Criteria (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CriteriaFromRaw.FromRawUnchecked"/>
    public static Criteria FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CriteriaFromRaw : IFromRawJson<Criteria>
{
    /// <inheritdoc/>
    public Criteria FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Criteria.FromRawUnchecked(rawData);
}

/// <summary>
/// Rate the state against an ordered rubric.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Score, ScoreFromRaw>))]
public sealed record class Score : JsonModel
{
    /// <summary>
    /// Between 2 and 64 description strings in ascending score order. Indices start
    /// at zero.
    /// </summary>
    public required Generic::IReadOnlyList<string> Criteria {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "criteria"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "criteria",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Required instructions describing what to decide about the shared state.
    /// </summary>
    public required ScoreInstructions Instructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ScoreInstructions>(
                "instructions"
            );
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// Question type.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Criteria;
        this.Instructions.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("score")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Score ()
    { this.Type = JsonSerializer.SerializeToElement("score"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Score (Score score) : base(score)
    {  }
    #pragma warning restore CS8618

    public Score (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("score");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Score (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ScoreFromRaw.FromRawUnchecked"/>
    public static Score FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ScoreFromRaw : IFromRawJson<Score>
{
    /// <inheritdoc/>
    public Score FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Score.FromRawUnchecked(rawData);
}

/// <summary>
/// Required instructions describing what to decide about the shared state.
/// </summary>
[JsonConverter(typeof(ScoreInstructionsConverter))]
public record class ScoreInstructions : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ScoreInstructions (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ScoreInstructions (
        Generic::IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public ScoreInstructions (
        Generic::IReadOnlyList<JsonElement> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ScoreInstructions (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, JsonElement> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements1(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements1(
        [NotNullWhen(true)] out Generic::IReadOnlyList<JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<JsonElement> ;
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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyDictionary<string, JsonElement>> jsonElements,
        System::Action<Generic::IReadOnlyList<JsonElement>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case Generic::IReadOnlyList<JsonElement> value:
                jsonElements1(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ScoreInstructions");

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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        System::Func<Generic::IReadOnlyList<JsonElement>, T> jsonElements1
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyDictionary<string, JsonElement> value=>jsonElements(value),
            Generic::IReadOnlyList<JsonElement> value=>jsonElements1(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ScoreInstructions")
        } ;
    }

    public static implicit operator ScoreInstructions (
        string value
    )=> new(value) ;

    public static implicit operator ScoreInstructions (
        Generic::Dictionary<string, JsonElement> value
    )=> new((Generic::IReadOnlyDictionary<string, JsonElement>)value) ;

    public static implicit operator ScoreInstructions (
        Generic::List<JsonElement> value
    )=> new((Generic::IReadOnlyList<JsonElement>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of ScoreInstructions");
        }
    }

    public virtual bool Equals(ScoreInstructions? other)
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
            string _=>0,
            Generic::IReadOnlyDictionary<string, JsonElement> _=>1,
            Generic::IReadOnlyList<JsonElement> _=>2,
            _ =>-1
        } ;
    }
}

sealed class ScoreInstructionsConverter : JsonConverter<ScoreInstructions>
{
    public override ScoreInstructions? Read(
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
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyDictionary<string, JsonElement>>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<JsonElement>>(element, options);
            if (deserialized != null) {

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
        ScoreInstructions value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Shared context evaluated by every question.
/// </summary>
[JsonConverter(typeof(StateConverter))]
public record class State : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public State (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public State (
        Generic::IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public State (
        Generic::IReadOnlyList<JsonElement> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public State (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, JsonElement> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements1(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements1(
        [NotNullWhen(true)] out Generic::IReadOnlyList<JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<JsonElement> ;
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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<Generic::IReadOnlyDictionary<string, JsonElement>> jsonElements,
        System::Action<Generic::IReadOnlyList<JsonElement>> jsonElements1
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case Generic::IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case Generic::IReadOnlyList<JsonElement> value:
                jsonElements1(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of State");

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
///     (string value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<Generic::IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        System::Func<Generic::IReadOnlyList<JsonElement>, T> jsonElements1
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            Generic::IReadOnlyDictionary<string, JsonElement> value=>jsonElements(value),
            Generic::IReadOnlyList<JsonElement> value=>jsonElements1(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of State")
        } ;
    }

    public static implicit operator State (string value)=> new(value) ;

    public static implicit operator State (
        Generic::Dictionary<string, JsonElement> value
    )=> new((Generic::IReadOnlyDictionary<string, JsonElement>)value) ;

    public static implicit operator State (
        Generic::List<JsonElement> value
    )=> new((Generic::IReadOnlyList<JsonElement>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of State");
        }
    }

    public virtual bool Equals(State? other)
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
            string _=>0,
            Generic::IReadOnlyDictionary<string, JsonElement> _=>1,
            Generic::IReadOnlyList<JsonElement> _=>2,
            _ =>-1
        } ;
    }
}

sealed class StateConverter : JsonConverter<State>
{
    public override State? Read(
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
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyDictionary<string, JsonElement>>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<JsonElement>>(element, options);
            if (deserialized != null) {

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
        Utf8JsonWriter writer, State value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Public model alias. telnyx/decision-flash offers the lowest cost and latency;
/// telnyx/decision-pro supports decisions that require long context, including inputs
/// beyond Jev’s 32k per-decision limit. Applies to every question in the request.
/// Other values are rejected.
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public enum Model
{
    TelnyxDecisionFlash, TelnyxDecisionPro
}

sealed class ModelConverter : JsonConverter<Model>
{
    public override Model Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx/decision-flash"=>Model.TelnyxDecisionFlash,
            "telnyx/decision-pro"=>Model.TelnyxDecisionPro,
            _ =>(Model)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Model value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Model.TelnyxDecisionFlash=>"telnyx/decision-flash",
            Model.TelnyxDecisionPro=>"telnyx/decision-pro",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}