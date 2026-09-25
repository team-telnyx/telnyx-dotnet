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
/// A standalone tool step in a conversation flow, as supplied by clients.
///
/// <para>Unlike a prompt node, a tool node has no instructions or model — it isn't
/// an LLM turn. Reaching it deterministically runs one shared tool (arguments filled
/// from matching dynamic variables by name), then routes on the result via outgoing
/// `tool_result` edges.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ToolNodeReq, ToolNodeReqFromRaw>))]
public sealed record class ToolNodeReq : JsonModel
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
    /// Node kind discriminator. Always `tool` for a tool node.
    /// </summary>
    public ApiEnum<string, ToolNodeReqType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ToolNodeReqType>>(
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
        this.Type?.Validate();
    }

    public ToolNodeReq ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolNodeReq (ToolNodeReq toolNodeReq) : base(toolNodeReq)
    {  }
    #pragma warning restore CS8618

    public ToolNodeReq (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolNodeReq (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ToolNodeReqFromRaw.FromRawUnchecked"/>
    public static ToolNodeReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ToolNodeReqFromRaw : IFromRawJson<ToolNodeReq>
{
    /// <inheritdoc/>
    public ToolNodeReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ToolNodeReq.FromRawUnchecked(rawData);
}

/// <summary>
/// Node kind discriminator. Always `tool` for a tool node.
/// </summary>
[JsonConverter(typeof(ToolNodeReqTypeConverter))]
public enum ToolNodeReqType
{
    Tool
}sealed class ToolNodeReqTypeConverter : JsonConverter<ToolNodeReqType>
{
    public override ToolNodeReqType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "tool"=>ToolNodeReqType.Tool, _ =>(ToolNodeReqType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolNodeReqType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ToolNodeReqType.Tool=>"tool",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}