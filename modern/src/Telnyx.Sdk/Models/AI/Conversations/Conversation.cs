using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations;

[JsonConverter(typeof(JsonModelConverter<Conversation, ConversationFromRaw>))]
public sealed record class Conversation : JsonModel
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

    /// <summary>
    /// The datetime the conversation was created.
    /// </summary>
    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The datetime of the latest message in the conversation.
    /// </summary>
    public required DateTimeOffset LastMessageAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "last_message_at"
            );
        }
        init { this._rawData.Set("last_message_at", value); }
    }

    /// <summary>
    /// Metadata associated with the conversation. Telnyx provides several pieces
    /// of metadata, but customers can also add their own. The reserved field `ai_disabled`
    /// (boolean) can be set to `true` to prevent AI-generated responses on this
    /// conversation. When `ai_disabled` is `true`, calls to the chat endpoint will
    /// return a 400 error. Set to `false` or remove the field to re-enable AI responses.
    /// This is useful when a human agent needs to take over the conversation mid-stream
    /// (e.g., a technician stepping in while AI was messaging a resident).
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>(
                "metadata"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.LastMessageAt;
        _ = this.Metadata;
        _ = this.Name;
    }

    public Conversation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Conversation (Conversation conversation) : base(conversation)
    {  }
    #pragma warning restore CS8618

    public Conversation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Conversation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationFromRaw.FromRawUnchecked"/>
    public static Conversation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConversationFromRaw : IFromRawJson<Conversation>
{
    /// <inheritdoc/>
    public Conversation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Conversation.FromRawUnchecked(rawData);
}