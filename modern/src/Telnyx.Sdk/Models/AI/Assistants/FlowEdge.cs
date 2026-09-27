using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Directed transition from one node to a target, gated by a condition.
///
/// <para>The target is either another node in the same flow (`NodeTarget`) or a different
/// assistant (`AssistantTarget`). Multiple edges may share a `start_node_id`. On
/// calls, `expression` conditions are evaluated before the model turn and take precedence
/// over `llm` conditions regardless of declaration order, while `llm` conditions
/// are offered to the assistant's model as transition tools and fire when the model
/// selects one. On chat channels, an `expression` condition that is true when the
/// turn begins routes before the reply is generated; all conditioned edges that
/// remain are considered together in declaration order after the reply, and the
/// first true one wins.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FlowEdge, FlowEdgeFromRaw>))]
public sealed record class FlowEdge : JsonModel
{
    /// <summary>
    /// Caller-supplied unique identifier for this edge within the flow.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Condition that gates the transition. Discriminated by `type`: `llm`, `expression`.
    /// </summary>
    public required Condition Condition {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Condition>(
                "condition"
            );
        }
        init { this._rawData.Set("condition", value); }
    }

    /// <summary>
    /// ID of the node this edge transitions away from.
    /// </summary>
    public required string StartNodeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "start_node_id"
            );
        }
        init { this._rawData.Set("start_node_id", value); }
    }

    /// <summary>
    /// Destination of the transition. Discriminated by `type`: `node` (jump to another
    /// node in this flow) or `assistant` (hand off to a different assistant).
    /// </summary>
    public required FlowEdgeTarget Target {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FlowEdgeTarget>(
                "target"
            );
        }
        init { this._rawData.Set("target", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Condition.Validate();
        _ = this.StartNodeID;
        this.Target.Validate();
    }

    public FlowEdge ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowEdge (FlowEdge flowEdge) : base(flowEdge)
    {  }
    #pragma warning restore CS8618

    public FlowEdge (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowEdge (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FlowEdgeFromRaw.FromRawUnchecked"/>
    public static FlowEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FlowEdgeFromRaw : IFromRawJson<FlowEdge>
{
    /// <inheritdoc/>
    public FlowEdge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FlowEdge.FromRawUnchecked(rawData);
}

/// <summary>
/// Condition that gates the transition. Discriminated by `type`: `llm`, `expression`.
/// </summary>
[JsonConverter(typeof(ConditionConverter))]
public record class Condition : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public JsonElement? Type {
        get {
            return Match<JsonElement?>(llm: ( x )=>x.Type,
            expression: ( x )=>x.Type,
            default_: ( _ )=>null);
        }
    }

    public Condition (Llm value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Condition (ConditionExpression value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Condition (DefaultCondition value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Condition (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Llm"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickLlm(out var value)) {
///     // `value` is of type `Llm`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickLlm([NotNullWhen(true)] out Llm? value)
    {
        value =this.Value as Llm ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConditionExpression"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickExpression(out var value)) {
///     // `value` is of type `ConditionExpression`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickExpression(
        [NotNullWhen(true)] out ConditionExpression? value
    )
    {
        value =this.Value as ConditionExpression ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="DefaultCondition"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDefault(out var value)) {
///     // `value` is of type `DefaultCondition`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDefault([NotNullWhen(true)] out DefaultCondition? value)
    {
        value =this.Value as DefaultCondition ;
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
///     (Llm value) =&gt; {...},
///     (ConditionExpression value) =&gt; {...},
///     (DefaultCondition value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Llm> llm,
        System::Action<ConditionExpression> expression,
        System::Action<DefaultCondition> default_
    )
    {
        switch (this.Value)
        {
            case Llm value:
                llm(value);
                break;
            case ConditionExpression value:
                expression(value);
                break;
            case DefaultCondition value:
                default_(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Condition");

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
///     (Llm value) =&gt; {...},
///     (ConditionExpression value) =&gt; {...},
///     (DefaultCondition value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Llm, T> llm,
        System::Func<ConditionExpression, T> expression,
        System::Func<DefaultCondition, T> default_
    )
    {
        return this.Value switch
        {
            Llm value=>llm(value),
            ConditionExpression value=>expression(value),
            DefaultCondition value=>default_(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Condition")
        } ;
    }

    public static implicit operator Condition (Llm value)=> new(value) ;

    public static implicit operator Condition (
        ConditionExpression value
    )=> new(value) ;

    public static implicit operator Condition (
        DefaultCondition value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Condition");
        }
        this.Switch((llm) => llm.Validate(),
        (expression) => expression.Validate(),
        (default_) => default_.Validate());
    }

    public virtual bool Equals(Condition? other)
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
        { Llm _=>0, ConditionExpression _=>1, DefaultCondition _=>2, _ =>-1 } ;
    }
}sealed class ConditionConverter : JsonConverter<Condition>
{
    public override Condition? Read(
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
            case "llm":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Llm>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "expression":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ConditionExpression>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "default":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DefaultCondition>(element, options);
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
                { return new Condition(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Condition value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// Edge condition routed by the assistant's LLM from a natural-language prompt.
///
/// <para>How the edge is decided depends on the channel. On calls, each outgoing
/// `llm` condition is offered to the assistant's model as a transition tool alongside
/// the assistant's tools, and the edge fires when the model selects it; the platform
/// does not evaluate the prompt itself, and instructions that forbid or discourage
/// tool calls can stop these edges from firing. On chat channels, the edge prompts
/// are evaluated in a separate model call after the reply, which does not use the
/// assistant's instructions. Use this for fuzzy intents that aren't expressible as
/// a deterministic expression (e.g. 'user wants to escalate to a human').</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Llm, LlmFromRaw>))]
public sealed record class Llm : JsonModel
{
    /// <summary>
    /// Natural-language criterion the model routes on. On calls this is offered to
    /// the model as the transition tool's description; on chat channels it is judged
    /// as a statement in the post-reply evaluation call.
    /// </summary>
    public required string Prompt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "prompt"
            );
        }
        init { this._rawData.Set("prompt", value); }
    }

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
        _ = this.Prompt;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("llm")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Llm ()
    { this.Type = JsonSerializer.SerializeToElement("llm"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Llm (Llm llm) : base(llm)
    {  }
    #pragma warning restore CS8618

    public Llm (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("llm");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Llm (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LlmFromRaw.FromRawUnchecked"/>
    public static Llm FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Llm (string prompt) : this()
    { this.Prompt = prompt; }
}class LlmFromRaw : IFromRawJson<Llm>
{
    /// <inheritdoc/>
    public Llm FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Llm.FromRawUnchecked(rawData);
}/// <summary>
/// Edge condition evaluated as a deterministic expression AST.
///
/// <para>The expression is computed against runtime dynamic variables and must evaluate
/// to a boolean. Prefer this over `LLMCondition` when the rule is a clean function
/// of known variables — it's cheaper and predictable.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConditionExpression, ConditionExpressionFromRaw>))]
public sealed record class ConditionExpression : JsonModel
{
    /// <summary>
    /// Root of the expression AST; evaluates to a boolean. Typed as free-form JSON
    /// to avoid an uncompilable by-value self-reference; see the Expression schema
    /// for the variant structure.
    /// </summary>
    public required JsonElement Expression {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotAbsentElement(
                "expression"
            );
        }
        init { this._rawData.Set("expression", value); }
    }

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
        _ = this.Expression;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("expression")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public ConditionExpression ()
    { this.Type = JsonSerializer.SerializeToElement("expression"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConditionExpression (ConditionExpression conditionExpression) : base(
        conditionExpression
    )
    {  }
    #pragma warning restore CS8618

    public ConditionExpression (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("expression");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConditionExpression (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConditionExpressionFromRaw.FromRawUnchecked"/>
    public static ConditionExpression FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConditionExpression (JsonElement expression) : this()
    { this.Expression = expression; }
}class ConditionExpressionFromRaw : IFromRawJson<ConditionExpression>
{
    /// <inheritdoc/>
    public ConditionExpression FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConditionExpression.FromRawUnchecked(rawData);
}/// <summary>
/// Fallback edge condition: fires only when no other edge's condition is true.
///
/// <para>Evaluated after every conditioned (`llm` / `expression`) edge regardless
/// of declaration order, so it routes the flow whenever none of the node's other
/// outgoing edges match. Valid **only** on edges leaving a `tool` or `speak` node,
/// where the deterministic step auto-advances and must always have somewhere to go.
/// A tool/speak node with any outgoing edge is required to carry exactly one `default`
/// edge so it never dead-ends; a tool/speak node with no outgoing edges is a valid
/// terminal step. Carries no parameters.</para>
/// </summary>
[JsonConverter(typeof(DefaultConditionConverter))]
public record class DefaultCondition
{
    public JsonElement Element { get; private init; }

    public DefaultCondition ()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "default"
            }
            """
        );
    }

    internal DefaultCondition (JsonElement element)
    { Element = element; }

    /// <summary>
/// Validates that the instance's underlying value is the expected constant.
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public void Validate()
    {
        if (this != new DefaultCondition())
        {
            throw new TelnyxInvalidDataException("Invalid value given for 'DefaultCondition'");
        }
    }

    public override int GetHashCode()
    { return 0; }

    public virtual bool Equals(DefaultCondition? other)
    {
        if(other == null)
        {
            return false;
        }

        return JsonElementEquality.DeepEquals(this.Element, other.Element);
    }
}class DefaultConditionConverter : JsonConverter<DefaultCondition>
{
    public override DefaultCondition? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(
            JsonSerializer.Deserialize<JsonElement>(ref reader, options)
        );
    }public override void Write(
        Utf8JsonWriter writer,
        DefaultCondition value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Element, options); }
}/// <summary>
/// Destination of the transition. Discriminated by `type`: `node` (jump to another
/// node in this flow) or `assistant` (hand off to a different assistant).
/// </summary>
[JsonConverter(typeof(FlowEdgeTargetConverter))]
public record class FlowEdgeTarget : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public JsonElement Type {
        get { return Match(node: ( x )=>x.Type, assistant: ( x )=>x.Type); }
    }

    public FlowEdgeTarget (
        FlowEdgeTargetNode value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FlowEdgeTarget (
        FlowEdgeTargetAssistant value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FlowEdgeTarget (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FlowEdgeTargetNode"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickNode(out var value)) {
///     // `value` is of type `FlowEdgeTargetNode`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickNode([NotNullWhen(true)] out FlowEdgeTargetNode? value)
    {
        value =this.Value as FlowEdgeTargetNode ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FlowEdgeTargetAssistant"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAssistant(out var value)) {
///     // `value` is of type `FlowEdgeTargetAssistant`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAssistant(
        [NotNullWhen(true)] out FlowEdgeTargetAssistant? value
    )
    {
        value =this.Value as FlowEdgeTargetAssistant ;
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
///     (FlowEdgeTargetNode value) =&gt; {...},
///     (FlowEdgeTargetAssistant value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<FlowEdgeTargetNode> node,
        System::Action<FlowEdgeTargetAssistant> assistant
    )
    {
        switch (this.Value)
        {
            case FlowEdgeTargetNode value:
                node(value);
                break;
            case FlowEdgeTargetAssistant value:
                assistant(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of FlowEdgeTarget");

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
///     (FlowEdgeTargetNode value) =&gt; {...},
///     (FlowEdgeTargetAssistant value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<FlowEdgeTargetNode, T> node,
        System::Func<FlowEdgeTargetAssistant, T> assistant
    )
    {
        return this.Value switch
        {
            FlowEdgeTargetNode value=>node(value),
            FlowEdgeTargetAssistant value=>assistant(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of FlowEdgeTarget")
        } ;
    }

    public static implicit operator FlowEdgeTarget (
        FlowEdgeTargetNode value
    )=> new(value) ;

    public static implicit operator FlowEdgeTarget (
        FlowEdgeTargetAssistant value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of FlowEdgeTarget");
        }
        this.Switch((node) => node.Validate(),
        (assistant) => assistant.Validate());
    }

    public virtual bool Equals(FlowEdgeTarget? other)
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
        { FlowEdgeTargetNode _=>0, FlowEdgeTargetAssistant _=>1, _ =>-1 } ;
    }
}sealed class FlowEdgeTargetConverter : JsonConverter<FlowEdgeTarget>
{
    public override FlowEdgeTarget? Read(
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
            case "node":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FlowEdgeTargetNode>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "assistant":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FlowEdgeTargetAssistant>(element, options);
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
                { return new FlowEdgeTarget(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlowEdgeTarget value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// Edge target referencing another node within the same flow.
///
/// <para>The runtime transitions the active node to `node_id` and continues processing
/// within the current assistant's flow.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FlowEdgeTargetNode, FlowEdgeTargetNodeFromRaw>))]
public sealed record class FlowEdgeTargetNode : JsonModel
{
    /// <summary>
    /// ID of the node this edge transitions into.
    /// </summary>
    public required string NodeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "node_id"
            );
        }
        init { this._rawData.Set("node_id", value); }
    }

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
        _ = this.NodeID;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("node")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public FlowEdgeTargetNode ()
    { this.Type = JsonSerializer.SerializeToElement("node"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowEdgeTargetNode (FlowEdgeTargetNode flowEdgeTargetNode) : base(
        flowEdgeTargetNode
    )
    {  }
    #pragma warning restore CS8618

    public FlowEdgeTargetNode (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("node");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowEdgeTargetNode (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FlowEdgeTargetNodeFromRaw.FromRawUnchecked"/>
    public static FlowEdgeTargetNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public FlowEdgeTargetNode (string nodeID) : this()
    { this.NodeID = nodeID; }
}class FlowEdgeTargetNodeFromRaw : IFromRawJson<FlowEdgeTargetNode>
{
    /// <inheritdoc/>
    public FlowEdgeTargetNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FlowEdgeTargetNode.FromRawUnchecked(rawData);
}/// <summary>
/// Edge target referencing a different assistant.
///
/// <para>When the edge fires, the conversation hands off to `assistant_id`: the active
/// assistant on the conversation row is rewritten and the new assistant's flow starts
/// at its own `start_node_id`. The current turn's LLM response is delivered to the
/// user as-is; subsequent turns route to the new assistant.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FlowEdgeTargetAssistant, FlowEdgeTargetAssistantFromRaw>))]
public sealed record class FlowEdgeTargetAssistant : JsonModel
{
    /// <summary>
    /// ID of the assistant the conversation transitions to.
    /// </summary>
    public required string AssistantID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "assistant_id"
            );
        }
        init { this._rawData.Set("assistant_id", value); }
    }

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
    /// Optional canvas coordinates for rendering the target assistant as a node in
    /// authoring UIs. Pure presentation — the runtime ignores it; round-trips so
    /// frontends can persist graph layout across reloads. When multiple edges target
    /// the same assistant, each edge's `position` is independent (frontends typically
    /// use the first non-null one).
    /// </summary>
    public NodePosition? Position {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NodePosition>(
                "position"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("position", value);
        }
    }

    /// <summary>
    /// Voice behavior when handing off to the target assistant, mirroring the handoff
    /// tool's `voice_mode`. `unified` (default) keeps the current voice across the
    /// handoff; `distinct` lets the target assistant speak with its own configured
    /// voice. Only applies to assistant targets — node targets override voice via
    /// the node's own `voice_settings`.
    /// </summary>
    public ApiEnum<string, FlowEdgeTargetAssistantVoiceMode>? VoiceMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FlowEdgeTargetAssistantVoiceMode>>(
                "voice_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AssistantID;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("assistant")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        this.Position?.Validate();
        this.VoiceMode?.Validate();
    }

    public FlowEdgeTargetAssistant ()
    { this.Type = JsonSerializer.SerializeToElement("assistant"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowEdgeTargetAssistant (
        FlowEdgeTargetAssistant flowEdgeTargetAssistant
    ) : base(flowEdgeTargetAssistant)
    {  }
    #pragma warning restore CS8618

    public FlowEdgeTargetAssistant (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("assistant");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowEdgeTargetAssistant (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FlowEdgeTargetAssistantFromRaw.FromRawUnchecked"/>
    public static FlowEdgeTargetAssistant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public FlowEdgeTargetAssistant (string assistantID) : this()
    { this.AssistantID = assistantID; }
}class FlowEdgeTargetAssistantFromRaw : IFromRawJson<FlowEdgeTargetAssistant>
{
    /// <inheritdoc/>
    public FlowEdgeTargetAssistant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FlowEdgeTargetAssistant.FromRawUnchecked(rawData);
}/// <summary>
/// Voice behavior when handing off to the target assistant, mirroring the handoff
/// tool's `voice_mode`. `unified` (default) keeps the current voice across the handoff;
/// `distinct` lets the target assistant speak with its own configured voice. Only
/// applies to assistant targets — node targets override voice via the node's own `voice_settings`.
/// </summary>
[JsonConverter(typeof(FlowEdgeTargetAssistantVoiceModeConverter))]
public enum FlowEdgeTargetAssistantVoiceMode
{
    Unified, Distinct
}sealed class FlowEdgeTargetAssistantVoiceModeConverter : JsonConverter<FlowEdgeTargetAssistantVoiceMode>
{
    public override FlowEdgeTargetAssistantVoiceMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unified"=>FlowEdgeTargetAssistantVoiceMode.Unified,
            "distinct"=>FlowEdgeTargetAssistantVoiceMode.Distinct,
            _ =>(FlowEdgeTargetAssistantVoiceMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlowEdgeTargetAssistantVoiceMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FlowEdgeTargetAssistantVoiceMode.Unified=>"unified",
            FlowEdgeTargetAssistantVoiceMode.Distinct=>"distinct",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}