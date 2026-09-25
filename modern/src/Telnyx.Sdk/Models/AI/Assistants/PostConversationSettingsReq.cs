using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Configuration for post-conversation processing. When enabled, the assistant receives
/// one additional LLM turn after the conversation ends, allowing it to execute final
/// tool calls such as sending a summary or updating a record via webhook or function
/// tools. Integration and MCP server tools are not available post-conversation; call-control
/// tools (e.g. hangup, transfer) are also unavailable. Beta feature.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PostConversationSettingsReq, PostConversationSettingsReqFromRaw>))]
public sealed record class PostConversationSettingsReq : JsonModel
{
    /// <summary>
    /// Whether post-conversation processing is enabled. When true, the assistant
    /// will be invoked after the conversation ends to perform any final tool calls.
    /// Defaults to false.
    /// </summary>
    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Enabled; }

    public PostConversationSettingsReq ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostConversationSettingsReq (
        PostConversationSettingsReq postConversationSettingsReq
    ) : base(postConversationSettingsReq)
    {  }
    #pragma warning restore CS8618

    public PostConversationSettingsReq (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PostConversationSettingsReq (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PostConversationSettingsReqFromRaw.FromRawUnchecked"/>
    public static PostConversationSettingsReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PostConversationSettingsReqFromRaw : IFromRawJson<PostConversationSettingsReq>
{
    /// <inheritdoc/>
    public PostConversationSettingsReq FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PostConversationSettingsReq.FromRawUnchecked(rawData);
}