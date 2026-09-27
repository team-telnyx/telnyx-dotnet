using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Conversations;

[JsonConverter(typeof(JsonModelConverter<ConversationUpdateResponse, ConversationUpdateResponseFromRaw>))]
public sealed record class ConversationUpdateResponse : JsonModel
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

    public ConversationUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationUpdateResponse (
        ConversationUpdateResponse conversationUpdateResponse
    ) : base(conversationUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public ConversationUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ConversationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConversationUpdateResponseFromRaw : IFromRawJson<ConversationUpdateResponse>
{
    /// <inheritdoc/>
    public ConversationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationUpdateResponse.FromRawUnchecked(rawData);
}