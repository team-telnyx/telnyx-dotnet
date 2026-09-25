using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.McpServers;

[JsonConverter(typeof(JsonModelConverter<McpServer, McpServerFromRaw>))]
public sealed record class McpServer : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public required string Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    public IReadOnlyList<string>? AllowedTools {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "allowed_tools"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_key_ref"
            );
        }
        init { this._rawData.Set("api_key_ref", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.Type;
        _ = this.Url;
        _ = this.AllowedTools;
        _ = this.ApiKeyRef;
    }

    public McpServer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpServer (McpServer mcpServer) : base(mcpServer)
    {  }
    #pragma warning restore CS8618

    public McpServer (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    McpServer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="McpServerFromRaw.FromRawUnchecked"/>
    public static McpServer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class McpServerFromRaw : IFromRawJson<McpServer>
{
    /// <inheritdoc/>
    public McpServer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>McpServer.FromRawUnchecked(rawData);
}