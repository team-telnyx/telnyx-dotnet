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
/// A standalone tool step in a conversation flow, as returned by the API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ToolNode, ToolNodeFromRaw>))]
public sealed record class ToolNode : JsonModel
{
    /// <summary>
    /// Caller-supplied unique identifier for this node within the flow.
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
    /// ID of the single shared (org-level) tool this node executes. When the flow
    /// reaches this node the tool runs as a deliberate step (no LLM turn); its outgoing
    /// `tool_result` edges then route on the outcome. Arguments are filled from the
    /// conversation's dynamic variables by name — a dynamic variable whose name matches
    /// one of the tool's parameters supplies that argument. Cross-validated against
    /// the org's shared tools on write.
    /// </summary>
    public required string SharedToolID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "shared_tool_id"
            );
        }
        init { this._rawData.Set("shared_tool_id", value); }
    }

    /// <summary>
    /// Optional human-readable label, displayed in authoring UIs.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Optional canvas coordinates used by authoring UIs to lay out the graph. Ignored
    /// by the runtime; round-trips so frontends can persist graph layout across reloads.
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
    /// Full tool definition resolved from `shared_tool_id` server-side. Populated
    /// on responses so clients can render the node without a follow-up fetch. Ignored
    /// on input — set `shared_tool_id`.
    /// </summary>
    public IReadOnlyList<AssistantTool>? Tool {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AssistantTool>>(
                "tool"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AssistantTool>?>(
                "tool",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Node kind discriminator. Always `tool` for a tool node.
    /// </summary>
    public ApiEnum<string, ToolNodeType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ToolNodeType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.SharedToolID;
        _ = this.Name;
        this.Position?.Validate();
        foreach (var item in this.Tool ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
    }

    public ToolNode ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolNode (ToolNode toolNode) : base(toolNode)
    {  }
    #pragma warning restore CS8618

    public ToolNode (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolNode (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ToolNodeFromRaw.FromRawUnchecked"/>
    public static ToolNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ToolNodeFromRaw : IFromRawJson<ToolNode>
{
    /// <inheritdoc/>
    public ToolNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ToolNode.FromRawUnchecked(rawData);
}

/// <summary>
/// Node kind discriminator. Always `tool` for a tool node.
/// </summary>
[JsonConverter(typeof(ToolNodeTypeConverter))]
public enum ToolNodeType
{
    Tool
}sealed class ToolNodeTypeConverter : JsonConverter<ToolNodeType>
{
    public override ToolNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "tool"=>ToolNodeType.Tool, _ =>(ToolNodeType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, ToolNodeType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ToolNodeType.Tool=>"tool",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}