using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionJoinAIAssistantResponse, ActionJoinAIAssistantResponseFromRaw>))]
public sealed record class ActionJoinAIAssistantResponse : JsonModel
{
    public CallControlCommandResultWithConversationID? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallControlCommandResultWithConversationID>(
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

    public ActionJoinAIAssistantResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionJoinAIAssistantResponse (
        ActionJoinAIAssistantResponse actionJoinAIAssistantResponse
    ) : base(actionJoinAIAssistantResponse)
    {  }
    #pragma warning restore CS8618

    public ActionJoinAIAssistantResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionJoinAIAssistantResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionJoinAIAssistantResponseFromRaw.FromRawUnchecked"/>
    public static ActionJoinAIAssistantResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionJoinAIAssistantResponseFromRaw : IFromRawJson<ActionJoinAIAssistantResponse>
{
    /// <inheritdoc/>
    public ActionJoinAIAssistantResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionJoinAIAssistantResponse.FromRawUnchecked(rawData);
}