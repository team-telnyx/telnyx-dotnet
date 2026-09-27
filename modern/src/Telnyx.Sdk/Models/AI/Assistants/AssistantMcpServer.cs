using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Reference to an MCP server attached to an assistant. Create and manage MCP servers
/// with the `/ai/mcp_servers` endpoints, then attach them to assistants by ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AssistantMcpServer, AssistantMcpServerFromRaw>))]
public sealed record class AssistantMcpServer : JsonModel
{
    /// <summary>
    /// ID of the MCP server to attach. This must be the `id` of an MCP server returned
    /// by the `/ai/mcp_servers` endpoints.
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
    /// Optional per-assistant allowlist of MCP tool names. When omitted, the assistant
    /// uses the MCP server's configured `allowed_tools`.
    /// </summary>
    public IReadOnlyList<string>? AllowedTools {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "allowed_tools"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AllowedTools;
    }

    public AssistantMcpServer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantMcpServer (AssistantMcpServer assistantMcpServer) : base(
        assistantMcpServer
    )
    {  }
    #pragma warning restore CS8618

    public AssistantMcpServer (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantMcpServer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantMcpServerFromRaw.FromRawUnchecked"/>
    public static AssistantMcpServer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AssistantMcpServer (string id) : this()
    { this.ID = id; }
}

class AssistantMcpServerFromRaw : IFromRawJson<AssistantMcpServer>
{
    /// <inheritdoc/>
    public AssistantMcpServer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssistantMcpServer.FromRawUnchecked(rawData);
}