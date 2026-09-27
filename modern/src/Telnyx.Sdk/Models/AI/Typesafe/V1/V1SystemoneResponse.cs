using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Typesafe.V1;

/// <summary>
/// A complete synchronous evaluation. Answers are returned directly without a data wrapper.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<V1SystemoneResponse, V1SystemoneResponseFromRaw>))]
public sealed record class V1SystemoneResponse : JsonModel
{
    /// <summary>
    /// Answers keyed by exactly the question IDs in the request. Each answer type
    /// matches its question.
    /// </summary>
    public required IReadOnlyDictionary<string, Answer> Answers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, Answer>>(
                "answers"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, Answer>>(
                "answers",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public model alias used to evaluate the request. Returns telnyx/decision-flash
    /// when model was omitted. The underlying model is managed by Telnyx.
    /// </summary>
    public required ApiEnum<string, V1SystemoneResponseModel> Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, V1SystemoneResponseModel>>(
                "model"
            );
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// Token usage for the completed evaluation.
    /// </summary>
    public required Usage Usage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Usage>(
                "usage"
            );
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Answers.Values)
        {
            item.Validate();
        }
        this.Model.Validate();
        this.Usage.Validate();
    }

    public V1SystemoneResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public V1SystemoneResponse (V1SystemoneResponse v1SystemoneResponse) : base(
        v1SystemoneResponse
    )
    {  }
    #pragma warning restore CS8618

    public V1SystemoneResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    V1SystemoneResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="V1SystemoneResponseFromRaw.FromRawUnchecked"/>
    public static V1SystemoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class V1SystemoneResponseFromRaw : IFromRawJson<V1SystemoneResponse>
{
    /// <inheritdoc/>
    public V1SystemoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>V1SystemoneResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An answer whose type matches its question.
/// </summary>
[JsonConverter(typeof(AnswerConverter))]
public record class Answer : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public double? Confidence {
        get {
            return Match<double?>(choice: ( x )=>x.Confidence,
            noul: ( _ )=>null,
            score: ( x )=>x.Confidence);
        }
    }

    public JsonElement Type {
        get {
            return Match(choice: ( x )=>x.Type,
            noul: ( x )=>x.Type,
            score: ( x )=>x.Type);
        }
    }

    public Answer (AnswerChoice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Answer (AnswerNoul value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Answer (AnswerScore value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Answer (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AnswerChoice"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickChoice(out var value)) {
///     // `value` is of type `AnswerChoice`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickChoice([NotNullWhen(true)] out AnswerChoice? value)
    {
        value =this.Value as AnswerChoice ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AnswerNoul"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickNoul(out var value)) {
///     // `value` is of type `AnswerNoul`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickNoul([NotNullWhen(true)] out AnswerNoul? value)
    {
        value =this.Value as AnswerNoul ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AnswerScore"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickScore(out var value)) {
///     // `value` is of type `AnswerScore`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickScore([NotNullWhen(true)] out AnswerScore? value)
    {
        value =this.Value as AnswerScore ;
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
///     (AnswerChoice value) =&gt; {...},
///     (AnswerNoul value) =&gt; {...},
///     (AnswerScore value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<AnswerChoice> choice,
        System::Action<AnswerNoul> noul,
        System::Action<AnswerScore> score
    )
    {
        switch (this.Value)
        {
            case AnswerChoice value:
                choice(value);
                break;
            case AnswerNoul value:
                noul(value);
                break;
            case AnswerScore value:
                score(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Answer");

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
///     (AnswerChoice value) =&gt; {...},
///     (AnswerNoul value) =&gt; {...},
///     (AnswerScore value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<AnswerChoice, T> choice,
        System::Func<AnswerNoul, T> noul,
        System::Func<AnswerScore, T> score
    )
    {
        return this.Value switch
        {
            AnswerChoice value=>choice(value),
            AnswerNoul value=>noul(value),
            AnswerScore value=>score(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Answer")
        } ;
    }

    public static implicit operator Answer (AnswerChoice value)=> new(value) ;

    public static implicit operator Answer (AnswerNoul value)=> new(value) ;

    public static implicit operator Answer (AnswerScore value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Answer");
        }
        this.Switch((choice) => choice.Validate(),
        (noul) => noul.Validate(),
        (score) => score.Validate());
    }

    public virtual bool Equals(Answer? other)
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
        { AnswerChoice _=>0, AnswerNoul _=>1, AnswerScore _=>2, _ =>-1 } ;
    }
}sealed class AnswerConverter : JsonConverter<Answer>
{
    public override Answer? Read(
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
                    var deserialized = JsonSerializer.Deserialize<AnswerChoice>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<AnswerNoul>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<AnswerScore>(element, options);
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
                { return new Answer(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Answer value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// A selected option and the distribution across all supplied option keys.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AnswerChoice, AnswerChoiceFromRaw>))]
public sealed record class AnswerChoice : JsonModel
{
    /// <summary>
    /// The option key with the highest relative score. Ties favor the first option
    /// in request order.
    /// </summary>
    public required string Choice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "choice"
            );
        }
        init { this._rawData.Set("choice", value); }
    }

    /// <summary>
    /// Normalized entropy confidence: 1 - H(p) / ln(N), where H(p) = -sum(p * ln(p))
    /// and N is the number of options. Zero indicates a uniform distribution; one
    /// indicates concentration on one option. This is neither the winning probability
    /// nor calibrated correctness.
    /// </summary>
    public required double Confidence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "confidence"
            );
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// Relative scores normalized across the supplied options, summing approximately
    /// to 1. These are not calibrated probabilities of correctness.
    /// </summary>
    public required IReadOnlyDictionary<string, double> Probabilities {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, double>>(
                "probabilities"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, double>>(
                "probabilities",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Answer type.
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
        _ = this.Choice;
        _ = this.Confidence;
        _ = this.Probabilities;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("choice")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public AnswerChoice ()
    { this.Type = JsonSerializer.SerializeToElement("choice"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnswerChoice (AnswerChoice answerChoice) : base(answerChoice)
    {  }
    #pragma warning restore CS8618

    public AnswerChoice (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("choice");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AnswerChoice (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AnswerChoiceFromRaw.FromRawUnchecked"/>
    public static AnswerChoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AnswerChoiceFromRaw : IFromRawJson<AnswerChoice>
{
    /// <inheritdoc/>
    public AnswerChoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AnswerChoice.FromRawUnchecked(rawData);
}/// <summary>
/// A yes/no score with no separate confidence or probabilities fields.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AnswerNoul, AnswerNoulFromRaw>))]
public sealed record class AnswerNoul : JsonModel
{
    /// <summary>
    /// Score of the positive outcome. Values near 1 favor yes; values near 0 favor
    /// no. This is a number, not a Boolean, and is not calibrated correctness.
    /// </summary>
    public required double Noul {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "noul"
            );
        }
        init { this._rawData.Set("noul", value); }
    }

    /// <summary>
    /// Answer type.
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
        _ = this.Noul;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("noul")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public AnswerNoul ()
    { this.Type = JsonSerializer.SerializeToElement("noul"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnswerNoul (AnswerNoul answerNoul) : base(answerNoul)
    {  }
    #pragma warning restore CS8618

    public AnswerNoul (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("noul");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AnswerNoul (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AnswerNoulFromRaw.FromRawUnchecked"/>
    public static AnswerNoul FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AnswerNoul (double noul) : this()
    { this.Noul = noul; }
}class AnswerNoulFromRaw : IFromRawJson<AnswerNoul>
{
    /// <inheritdoc/>
    public AnswerNoul FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AnswerNoul.FromRawUnchecked(rawData);
}/// <summary>
/// An expected rating over the ordered criteria.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AnswerScore, AnswerScoreFromRaw>))]
public sealed record class AnswerScore : JsonModel
{
    /// <summary>
    /// Normalized entropy confidence: 1 - H(p) / ln(N), where H(p) = -sum(p * ln(p))
    /// and N is the number of options. Zero indicates a uniform distribution; one
    /// indicates concentration on one option. This is neither the winning probability
    /// nor calibrated correctness.
    /// </summary>
    public required double Confidence {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "confidence"
            );
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// Criterion descriptions keyed by stringified zero-based indices, such as "0",
    /// "1", and "2".
    /// </summary>
    public required IReadOnlyDictionary<string, string> Legend {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>(
                "legend"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "legend",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Relative scores keyed by the same stringified indices as legend.
    /// </summary>
    public required IReadOnlyDictionary<string, double> Probabilities {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, double>>(
                "probabilities"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, double>>(
                "probabilities",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Expected zero-based criterion index: sum(index * probability). Ranges from
    /// 0 to N-1 for N criteria; fractional values are valid.
    /// </summary>
    public required double Score {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "score"
            );
        }
        init { this._rawData.Set("score", value); }
    }

    /// <summary>
    /// Answer type.
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
        _ = this.Confidence;
        _ = this.Legend;
        _ = this.Probabilities;
        _ = this.Score;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("score")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public AnswerScore ()
    { this.Type = JsonSerializer.SerializeToElement("score"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnswerScore (AnswerScore answerScore) : base(answerScore)
    {  }
    #pragma warning restore CS8618

    public AnswerScore (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("score");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AnswerScore (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AnswerScoreFromRaw.FromRawUnchecked"/>
    public static AnswerScore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AnswerScoreFromRaw : IFromRawJson<AnswerScore>
{
    /// <inheritdoc/>
    public AnswerScore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AnswerScore.FromRawUnchecked(rawData);
}/// <summary>
/// Public model alias used to evaluate the request. Returns telnyx/decision-flash
/// when model was omitted. The underlying model is managed by Telnyx.
/// </summary>
[JsonConverter(typeof(V1SystemoneResponseModelConverter))]
public enum V1SystemoneResponseModel
{
    TelnyxDecisionFlash, TelnyxDecisionPro
}sealed class V1SystemoneResponseModelConverter : JsonConverter<V1SystemoneResponseModel>
{
    public override V1SystemoneResponseModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx/decision-flash"=>V1SystemoneResponseModel.TelnyxDecisionFlash,
            "telnyx/decision-pro"=>V1SystemoneResponseModel.TelnyxDecisionPro,
            _ =>(V1SystemoneResponseModel)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        V1SystemoneResponseModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            V1SystemoneResponseModel.TelnyxDecisionFlash=>"telnyx/decision-flash",
            V1SystemoneResponseModel.TelnyxDecisionPro=>"telnyx/decision-pro",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Token usage for the completed evaluation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    /// <summary>
    /// Input tokens processed, including shared-context preparation and question
    /// evaluation. This can exceed the token count of the unique input text.
    /// </summary>
    public required long InputTokens {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "input_tokens"
            );
        }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <summary>
    /// Output tokens used for the evaluation, including shared-context preparation.
    /// </summary>
    public required long OutputTokens {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "output_tokens"
            );
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InputTokens;
        _ = this.OutputTokens;
    }

    public Usage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Usage (Usage usage) : base(usage)
    {  }
    #pragma warning restore CS8618

    public Usage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Usage.FromRawUnchecked(rawData);
}