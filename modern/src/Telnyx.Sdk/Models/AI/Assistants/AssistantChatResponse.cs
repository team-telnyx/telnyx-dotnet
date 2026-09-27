using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<AssistantChatResponse, AssistantChatResponseFromRaw>))]
public sealed record class AssistantChatResponse : JsonModel
{
    /// <summary>
    /// The assistant's generated response based on the input message and context.
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

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Content; }

    public AssistantChatResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantChatResponse (
        AssistantChatResponse assistantChatResponse
    ) : base(assistantChatResponse)
    {  }
    #pragma warning restore CS8618

    public AssistantChatResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantChatResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantChatResponseFromRaw.FromRawUnchecked"/>
    public static AssistantChatResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AssistantChatResponse (string content) : this()
    { this.Content = content; }
}

class AssistantChatResponseFromRaw : IFromRawJson<AssistantChatResponse>
{
    /// <inheritdoc/>
    public AssistantChatResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssistantChatResponse.FromRawUnchecked(rawData);
}