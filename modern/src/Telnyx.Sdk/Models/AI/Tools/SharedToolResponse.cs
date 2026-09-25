using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Tools;

[JsonConverter(typeof(JsonModelConverter<SharedToolResponse, SharedToolResponseFromRaw>))]
public sealed record class SharedToolResponse : JsonModel
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

    public required IReadOnlyDictionary<string, JsonElement> ToolDefinition {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "tool_definition"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "tool_definition",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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

    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("display_name", value);
        }
    }

    public long? TimeoutMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "timeout_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timeout_ms", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ToolDefinition;
        _ = this.Type;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.TimeoutMs;
    }

    public SharedToolResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SharedToolResponse (SharedToolResponse sharedToolResponse) : base(
        sharedToolResponse
    )
    {  }
    #pragma warning restore CS8618

    public SharedToolResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedToolResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SharedToolResponseFromRaw.FromRawUnchecked"/>
    public static SharedToolResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SharedToolResponseFromRaw : IFromRawJson<SharedToolResponse>
{
    /// <inheritdoc/>
    public SharedToolResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SharedToolResponse.FromRawUnchecked(rawData);
}