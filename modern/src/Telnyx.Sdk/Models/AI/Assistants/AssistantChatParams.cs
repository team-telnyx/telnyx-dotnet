using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// This endpoint allows a client to send a chat message to a specific AI Assistant.
/// The assistant processes the message and returns a relevant reply based on the
/// current conversation context. Refer to the Conversation API to [create a conversation](https://developers.telnyx.com/api-reference/conversations/create-a-conversation),
/// [filter existing conversations](https://developers.telnyx.com/api-reference/conversations/list-conversations),
/// [fetch messages for a conversation](https://developers.telnyx.com/api-reference/conversations/get-conversation-messages),
/// and [manually add messages to a conversation](https://developers.telnyx.com/api-reference/conversations/create-message).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AssistantChatParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AssistantID { get; init; }

    /// <summary>
    /// The message content sent by the client to the assistant
    /// </summary>
    public required string Content {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "content"
            );
        }
        init { this._rawBodyData.Set("content", value); }
    }

    /// <summary>
    /// A unique identifier for the conversation thread, used to maintain context
    /// </summary>
    public required string ConversationID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "conversation_id"
            );
        }
        init { this._rawBodyData.Set("conversation_id", value); }
    }

    /// <summary>
    /// The optional display name of the user sending the message
    /// </summary>
    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// When true, the response is streamed as Server-Sent Events (`text/event-stream`):
    /// `delta` events carry content fragments as they are generated, a final `done`
    /// event carries the full content plus `whatsapp_template`, and a terminal `error`
    /// event reports failures that happen after streaming started. When false (default),
    /// the response is a single JSON object.
    /// </summary>
    public bool? Stream {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "stream"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("stream", value);
        }
    }

    public AssistantChatParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantChatParams (AssistantChatParams assistantChatParams) : base(
        assistantChatParams
    )
    {
        this.AssistantID = assistantChatParams.AssistantID;

        this._rawBodyData = new(assistantChatParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public AssistantChatParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantChatParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string assistantID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AssistantID = assistantID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AssistantChatParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string assistantID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            assistantID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AssistantID"] = JsonSerializer.SerializeToElement(this.AssistantID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AssistantChatParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AssistantID?.Equals(other.AssistantID) ?? other.AssistantID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/assistants/{0}/chat",
            this.AssistantID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}