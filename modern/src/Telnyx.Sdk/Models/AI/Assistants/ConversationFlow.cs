using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Conversation flow as returned by the API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConversationFlow, ConversationFlowFromRaw>))]
public sealed record class ConversationFlow : JsonModel
{
    /// <summary>
    /// All nodes in the flow.
    /// </summary>
    public required IReadOnlyList<Node> Nodes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Node>>(
                "nodes"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Node>>(
                "nodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ID of the node where the conversation begins.
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
    /// Directed transitions between nodes.
    /// </summary>
    public IReadOnlyList<FlowEdge>? Edges {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FlowEdge>>(
                "edges"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FlowEdge>?>(
                "edges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Nodes)
        {
            item.Validate();
        }
        _ = this.StartNodeID;
        foreach (var item in this.Edges ?? [])
        {
            item.Validate();
        }
    }

    public ConversationFlow ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationFlow (ConversationFlow conversationFlow) : base(
        conversationFlow
    )
    {  }
    #pragma warning restore CS8618

    public ConversationFlow (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationFlow (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationFlowFromRaw.FromRawUnchecked"/>
    public static ConversationFlow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConversationFlowFromRaw : IFromRawJson<ConversationFlow>
{
    /// <inheritdoc/>
    public ConversationFlow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationFlow.FromRawUnchecked(rawData);
}

/// <summary>
/// One step in a conversation flow, as returned by the API.
/// </summary>
[JsonConverter(typeof(NodeConverter))]
public record class Node : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string ID {
        get {
            return Match(flow: ( x )=>x.ID,
            tool: ( x )=>x.ID,
            speak: ( x )=>x.ID);
        }
    }

    public string? Name {
        get {
            return Match<string?>(flow: ( x )=>x.Name,
            tool: ( x )=>x.Name,
            speak: ( x )=>x.Name);
        }
    }

    public NodePosition? Position {
        get {
            return Match<NodePosition?>(flow: ( x )=>x.Position,
            tool: ( x )=>x.Position,
            speak: ( x )=>x.Position);
        }
    }

    public Node (FlowNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Node (ToolNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Node (SpeakNode value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Node (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FlowNode"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickFlow(out var value)) {
///     // `value` is of type `FlowNode`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickFlow([NotNullWhen(true)] out FlowNode? value)
    {
        value =this.Value as FlowNode ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ToolNode"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTool(out var value)) {
///     // `value` is of type `ToolNode`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTool([NotNullWhen(true)] out ToolNode? value)
    {
        value =this.Value as ToolNode ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="SpeakNode"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSpeak(out var value)) {
///     // `value` is of type `SpeakNode`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSpeak([NotNullWhen(true)] out SpeakNode? value)
    {
        value =this.Value as SpeakNode ;
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
///     (FlowNode value) =&gt; {...},
///     (ToolNode value) =&gt; {...},
///     (SpeakNode value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<FlowNode> flow,
        System::Action<ToolNode> tool,
        System::Action<SpeakNode> speak
    )
    {
        switch (this.Value)
        {
            case FlowNode value:
                flow(value);
                break;
            case ToolNode value:
                tool(value);
                break;
            case SpeakNode value:
                speak(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Node");

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
///     (FlowNode value) =&gt; {...},
///     (ToolNode value) =&gt; {...},
///     (SpeakNode value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<FlowNode, T> flow,
        System::Func<ToolNode, T> tool,
        System::Func<SpeakNode, T> speak
    )
    {
        return this.Value switch
        {
            FlowNode value=>flow(value),
            ToolNode value=>tool(value),
            SpeakNode value=>speak(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Node")
        } ;
    }

    public static implicit operator Node (FlowNode value)=> new(value) ;

    public static implicit operator Node (ToolNode value)=> new(value) ;

    public static implicit operator Node (SpeakNode value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Node");
        }
        this.Switch((flow) => flow.Validate(),
        (tool) => tool.Validate(),
        (speak) => speak.Validate());
    }

    public virtual bool Equals(Node? other)
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
        { FlowNode _=>0, ToolNode _=>1, SpeakNode _=>2, _ =>-1 } ;
    }
}sealed class NodeConverter : JsonConverter<Node>
{
    public override Node? Read(
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
            case "prompt":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FlowNode>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "tool":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolNode>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "speak":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SpeakNode>(element, options);
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
                { return new Node(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Node value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}