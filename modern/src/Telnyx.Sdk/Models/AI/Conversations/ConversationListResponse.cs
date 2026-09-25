using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations;

[JsonConverter(typeof(JsonModelConverter<ConversationListResponse, ConversationListResponseFromRaw>))]
public sealed record class ConversationListResponse : JsonModel
{
    public required IReadOnlyList<Conversation> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Conversation>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Conversation>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public ConversationListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListResponse (
        ConversationListResponse conversationListResponse
    ) : base(conversationListResponse)
    {  }
    #pragma warning restore CS8618

    public ConversationListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListResponseFromRaw.FromRawUnchecked"/>
    public static ConversationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConversationListResponse (IReadOnlyList<Conversation> data) : this()
    { this.Data = data; }
}

class ConversationListResponseFromRaw : IFromRawJson<ConversationListResponse>
{
    /// <inheritdoc/>
    public ConversationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationListResponse.FromRawUnchecked(rawData);
}