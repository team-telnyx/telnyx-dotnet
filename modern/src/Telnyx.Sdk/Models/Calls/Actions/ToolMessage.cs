using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ToolMessage, ToolMessageFromRaw>))]
public sealed record class ToolMessage : JsonModel
{
    /// <summary>
    /// The contents of the tool message.
    /// </summary>
    public required string Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// The role of the messages author, in this case `tool`.
    /// </summary>
    public required ApiEnum<string, ToolMessageRole> Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ToolMessageRole>>(
                "role"
            );
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// Tool call that this message is responding to.
    /// </summary>
    public required string ToolCallID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "tool_call_id"
            );
        }
        init { this._rawData.Set("tool_call_id", value); }
    }

    /// <summary>
    /// Metadata to add to the message
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Role.Validate();
        _ = this.ToolCallID;
        _ = this.Metadata;
    }

    public ToolMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolMessage (ToolMessage toolMessage) : base(toolMessage)
    {  }
    #pragma warning restore CS8618

    public ToolMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ToolMessageFromRaw.FromRawUnchecked"/>
    public static ToolMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ToolMessageFromRaw : IFromRawJson<ToolMessage>
{
    /// <inheritdoc/>
    public ToolMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ToolMessage.FromRawUnchecked(rawData);
}

/// <summary>
/// The role of the messages author, in this case `tool`.
/// </summary>
[JsonConverter(typeof(ToolMessageRoleConverter))]
public enum ToolMessageRole
{
    Tool
}sealed class ToolMessageRoleConverter : JsonConverter<ToolMessageRole>
{
    public override ToolMessageRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "tool"=>ToolMessageRole.Tool, _ =>(ToolMessageRole)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolMessageRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ToolMessageRole.Tool=>"tool",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}