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
/// One step in a conversation flow, as supplied by API clients.
///
/// <para>Each node carries the prompt, tool scope, and optional overrides for model/voice/transcription.
/// Unset overrides cascade from the assistant.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FlowNodeReq, FlowNodeReqFromRaw>))]
public sealed record class FlowNodeReq : JsonModel
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
    /// Prompt that drives the LLM while this node is active. Required.
    /// </summary>
    public required string Instructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "instructions"
            );
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// Override for `Assistant.external_llm` while this node is active. Use this
    /// to route a node's turns to a different external LLM (different `model`, `base_url`,
    /// credentials). Part of the LLM bundle — see `model` for cascade semantics.
    /// Mutually exclusive with `model` on the node (a single LLM identity per node).
    /// </summary>
    public ExternalLlmReq? ExternalLlm {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalLlmReq>(
                "external_llm"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("external_llm", value);
        }
    }

    /// <summary>
    /// How `instructions` combine with the assistant-level instructions. `replace`
    /// (default): the node's instructions are used alone. `append`: the node's instructions
    /// are concatenated after the assistant's instructions.
    /// </summary>
    public ApiEnum<string, FlowNodeReqInstructionsMode>? InstructionsMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FlowNodeReqInstructionsMode>>(
                "instructions_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("instructions_mode", value);
        }
    }

    /// <summary>
    /// Override for `Assistant.llm_api_key_ref` while this node is active. Part of
    /// the LLM bundle — see `model` for cascade semantics.
    /// </summary>
    public string? LlmApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "llm_api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("llm_api_key_ref", value);
        }
    }

    /// <summary>
    /// Override for `Assistant.model` while this node is active. Part of the LLM
    /// bundle (`model` + `llm_api_key_ref` + `external_llm`): when any of the three
    /// is set on the node, all three are taken from the node and the assistant-level
    /// LLM identity is not consulted. When none of the three is set, the assistant's
    /// bundle cascades unchanged.
    /// </summary>
    public string? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model", value);
        }
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
    /// IDs of shared (org-level) tools available at this node. Knowledge bases are
    /// attached the same way — via a shared retrieval tool. Tools not listed here
    /// are not callable while this node is active.
    /// </summary>
    public IReadOnlyList<string>? SharedToolIds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "shared_tool_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "shared_tool_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How `shared_tool_ids` combine with the assistant-level tool set. `replace`
    /// (default): only the node's tools are callable. `append`: the node's tools
    /// are added to the assistant's tools. Ignored when `shared_tool_ids` is null.
    /// </summary>
    public ApiEnum<string, FlowNodeReqToolsMode>? ToolsMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FlowNodeReqToolsMode>>(
                "tools_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tools_mode", value);
        }
    }

    /// <summary>
    /// Per-node transcription override (model/language/region). Unset fields cascade
    /// from the assistant-level transcription.
    /// </summary>
    public TranscriptionSettings? Transcription {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TranscriptionSettings>(
                "transcription"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("transcription", value);
        }
    }

    /// <summary>
    /// Node kind discriminator. `prompt` (default) is an LLM-driven step; `tool`
    /// is a standalone tool execution (see `ToolNodeReq`).
    /// </summary>
    public ApiEnum<string, FlowNodeReqType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FlowNodeReqType>>(
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

    /// <summary>
    /// Per-node voice override. Only fields set here override the assistant-level
    /// voice settings; unset fields cascade.
    /// </summary>
    public InferenceEmbeddingVoiceSettings? VoiceSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InferenceEmbeddingVoiceSettings>(
                "voice_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_settings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Instructions;
        this.ExternalLlm?.Validate();
        this.InstructionsMode?.Validate();
        _ = this.LlmApiKeyRef;
        _ = this.Model;
        _ = this.Name;
        this.Position?.Validate();
        _ = this.SharedToolIds;
        this.ToolsMode?.Validate();
        this.Transcription?.Validate();
        this.Type?.Validate();
        this.VoiceSettings?.Validate();
    }

    public FlowNodeReq ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowNodeReq (FlowNodeReq flowNodeReq) : base(flowNodeReq)
    {  }
    #pragma warning restore CS8618

    public FlowNodeReq (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowNodeReq (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FlowNodeReqFromRaw.FromRawUnchecked"/>
    public static FlowNodeReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FlowNodeReqFromRaw : IFromRawJson<FlowNodeReq>
{
    /// <inheritdoc/>
    public FlowNodeReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FlowNodeReq.FromRawUnchecked(rawData);
}

/// <summary>
/// How `instructions` combine with the assistant-level instructions. `replace` (default):
/// the node's instructions are used alone. `append`: the node's instructions are
/// concatenated after the assistant's instructions.
/// </summary>
[JsonConverter(typeof(FlowNodeReqInstructionsModeConverter))]
public enum FlowNodeReqInstructionsMode
{
    Replace, Append
}sealed class FlowNodeReqInstructionsModeConverter : JsonConverter<FlowNodeReqInstructionsMode>
{
    public override FlowNodeReqInstructionsMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "replace"=>FlowNodeReqInstructionsMode.Replace,
            "append"=>FlowNodeReqInstructionsMode.Append,
            _ =>(FlowNodeReqInstructionsMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlowNodeReqInstructionsMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FlowNodeReqInstructionsMode.Replace=>"replace",
            FlowNodeReqInstructionsMode.Append=>"append",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// How `shared_tool_ids` combine with the assistant-level tool set. `replace` (default):
/// only the node's tools are callable. `append`: the node's tools are added to the
/// assistant's tools. Ignored when `shared_tool_ids` is null.
/// </summary>
[JsonConverter(typeof(FlowNodeReqToolsModeConverter))]
public enum FlowNodeReqToolsMode
{
    Replace, Append
}sealed class FlowNodeReqToolsModeConverter : JsonConverter<FlowNodeReqToolsMode>
{
    public override FlowNodeReqToolsMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "replace"=>FlowNodeReqToolsMode.Replace,
            "append"=>FlowNodeReqToolsMode.Append,
            _ =>(FlowNodeReqToolsMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlowNodeReqToolsMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FlowNodeReqToolsMode.Replace=>"replace",
            FlowNodeReqToolsMode.Append=>"append",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Node kind discriminator. `prompt` (default) is an LLM-driven step; `tool` is a
/// standalone tool execution (see `ToolNodeReq`).
/// </summary>
[JsonConverter(typeof(FlowNodeReqTypeConverter))]
public enum FlowNodeReqType
{
    Prompt
}sealed class FlowNodeReqTypeConverter : JsonConverter<FlowNodeReqType>
{
    public override FlowNodeReqType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "prompt"=>FlowNodeReqType.Prompt, _ =>(FlowNodeReqType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlowNodeReqType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FlowNodeReqType.Prompt=>"prompt",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}