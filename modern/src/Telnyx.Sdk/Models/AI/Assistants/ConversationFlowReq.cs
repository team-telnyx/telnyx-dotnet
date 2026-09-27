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
/// Conversation flow as supplied by API clients (create / update).
///
/// <para>A directed graph of `FlowNodeReq` connected by `FlowEdge`s. Validation enforces
/// unique node/edge IDs, that `start_node_id` references a real node, and that every
/// edge's endpoints reference real nodes.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConversationFlowReq, ConversationFlowReqFromRaw>))]
public sealed record class ConversationFlowReq : JsonModel
{
    /// <summary>
    /// All nodes in the flow. Must contain `start_node_id`. Each node is a prompt
    /// node (`type: prompt`) or a tool node (`type: tool`).
    /// </summary>
    public required IReadOnlyList<ConversationFlowReqNode> Nodes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ConversationFlowReqNode>>(
                "nodes"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ConversationFlowReqNode>>(
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
    /// Directed transitions between nodes. May be empty for a single-node flow.
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

    public ConversationFlowReq ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationFlowReq (ConversationFlowReq conversationFlowReq) : base(
        conversationFlowReq
    )
    {  }
    #pragma warning restore CS8618

    public ConversationFlowReq (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationFlowReq (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationFlowReqFromRaw.FromRawUnchecked"/>
    public static ConversationFlowReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConversationFlowReqFromRaw : IFromRawJson<ConversationFlowReq>
{
    /// <inheritdoc/>
    public ConversationFlowReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationFlowReq.FromRawUnchecked(rawData);
}

/// <summary>
/// One step in a conversation flow, as supplied by API clients.
///
/// <para>Each node carries the prompt, tool scope, and optional overrides for model/voice/transcription.
/// Unset overrides cascade from the assistant.</para>
/// </summary>
[JsonConverter(typeof(ConversationFlowReqNodeConverter))]
public record class ConversationFlowReqNode : ModelBase
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
            return Match(flowNodeReq: ( x )=>x.ID,
            toolNodeReq: ( x )=>x.ID,
            speakNodeReq: ( x )=>x.ID);
        }
    }

    public string? Name {
        get {
            return Match<string?>(flowNodeReq: ( x )=>x.Name,
            toolNodeReq: ( x )=>x.Name,
            speakNodeReq: ( x )=>x.Name);
        }
    }

    public NodePosition? Position {
        get {
            return Match<NodePosition?>(flowNodeReq: ( x )=>x.Position,
            toolNodeReq: ( x )=>x.Position,
            speakNodeReq: ( x )=>x.Position);
        }
    }

    public ConversationFlowReqNode (
        FlowNodeReq value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationFlowReqNode (
        ToolNodeReq value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationFlowReqNode (
        SpeakNodeReq value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationFlowReqNode (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FlowNodeReq"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickFlowNodeReq(out var value)) {
///     // `value` is of type `FlowNodeReq`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickFlowNodeReq([NotNullWhen(true)] out FlowNodeReq? value)
    {
        value =this.Value as FlowNodeReq ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ToolNodeReq"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickToolNodeReq(out var value)) {
///     // `value` is of type `ToolNodeReq`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickToolNodeReq([NotNullWhen(true)] out ToolNodeReq? value)
    {
        value =this.Value as ToolNodeReq ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="SpeakNodeReq"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSpeakNodeReq(out var value)) {
///     // `value` is of type `SpeakNodeReq`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSpeakNodeReq([NotNullWhen(true)] out SpeakNodeReq? value)
    {
        value =this.Value as SpeakNodeReq ;
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
///     (FlowNodeReq value) =&gt; {...},
///     (ToolNodeReq value) =&gt; {...},
///     (SpeakNodeReq value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<FlowNodeReq> flowNodeReq,
        System::Action<ToolNodeReq> toolNodeReq,
        System::Action<SpeakNodeReq> speakNodeReq
    )
    {
        switch (this.Value)
        {
            case FlowNodeReq value:
                flowNodeReq(value);
                break;
            case ToolNodeReq value:
                toolNodeReq(value);
                break;
            case SpeakNodeReq value:
                speakNodeReq(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ConversationFlowReqNode");

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
///     (FlowNodeReq value) =&gt; {...},
///     (ToolNodeReq value) =&gt; {...},
///     (SpeakNodeReq value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<FlowNodeReq, T> flowNodeReq,
        System::Func<ToolNodeReq, T> toolNodeReq,
        System::Func<SpeakNodeReq, T> speakNodeReq
    )
    {
        return this.Value switch
        {
            FlowNodeReq value=>flowNodeReq(value),
            ToolNodeReq value=>toolNodeReq(value),
            SpeakNodeReq value=>speakNodeReq(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ConversationFlowReqNode")
        } ;
    }

    public static implicit operator ConversationFlowReqNode (
        FlowNodeReq value
    )=> new(value) ;

    public static implicit operator ConversationFlowReqNode (
        ToolNodeReq value
    )=> new(value) ;

    public static implicit operator ConversationFlowReqNode (
        SpeakNodeReq value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ConversationFlowReqNode");
        }
        this.Switch((flowNodeReq) => flowNodeReq.Validate(),
        (toolNodeReq) => toolNodeReq.Validate(),
        (speakNodeReq) => speakNodeReq.Validate());
    }

    public virtual bool Equals(ConversationFlowReqNode? other)
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
        { FlowNodeReq _=>0, ToolNodeReq _=>1, SpeakNodeReq _=>2, _ =>-1 } ;
    }
}sealed class ConversationFlowReqNodeConverter : JsonConverter<ConversationFlowReqNode>
{
    public override ConversationFlowReqNode? Read(
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
                    var deserialized = JsonSerializer.Deserialize<FlowNodeReq>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<ToolNodeReq>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<SpeakNodeReq>(element, options);
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
                { return new ConversationFlowReqNode(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversationFlowReqNode value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}