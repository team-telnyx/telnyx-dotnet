using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<AssistantSendSmsResponse, AssistantSendSmsResponseFromRaw>))]
public sealed record class AssistantSendSmsResponse : JsonModel
{
    public string? ConversationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conversation_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.ConversationID; }

    public AssistantSendSmsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantSendSmsResponse (
        AssistantSendSmsResponse assistantSendSmsResponse
    ) : base(assistantSendSmsResponse)
    {  }
    #pragma warning restore CS8618

    public AssistantSendSmsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantSendSmsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantSendSmsResponseFromRaw.FromRawUnchecked"/>
    public static AssistantSendSmsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssistantSendSmsResponseFromRaw : IFromRawJson<AssistantSendSmsResponse>
{
    /// <inheritdoc/>
    public AssistantSendSmsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssistantSendSmsResponse.FromRawUnchecked(rawData);
}