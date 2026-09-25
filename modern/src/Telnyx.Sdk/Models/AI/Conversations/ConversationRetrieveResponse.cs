using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations;

[JsonConverter(typeof(JsonModelConverter<ConversationRetrieveResponse, ConversationRetrieveResponseFromRaw>))]
public sealed record class ConversationRetrieveResponse : JsonModel
{
    public Conversation? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Conversation>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public ConversationRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationRetrieveResponse (
        ConversationRetrieveResponse conversationRetrieveResponse
    ) : base(conversationRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ConversationRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ConversationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConversationRetrieveResponseFromRaw : IFromRawJson<ConversationRetrieveResponse>
{
    /// <inheritdoc/>
    public ConversationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationRetrieveResponse.FromRawUnchecked(rawData);
}