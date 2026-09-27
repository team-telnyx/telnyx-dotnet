using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStartAIAssistantResponse, ActionStartAIAssistantResponseFromRaw>))]
public sealed record class ActionStartAIAssistantResponse : JsonModel
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

    public ActionStartAIAssistantResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartAIAssistantResponse (
        ActionStartAIAssistantResponse actionStartAIAssistantResponse
    ) : base(actionStartAIAssistantResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStartAIAssistantResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartAIAssistantResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStartAIAssistantResponseFromRaw.FromRawUnchecked"/>
    public static ActionStartAIAssistantResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStartAIAssistantResponseFromRaw : IFromRawJson<ActionStartAIAssistantResponse>
{
    /// <inheritdoc/>
    public ActionStartAIAssistantResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStartAIAssistantResponse.FromRawUnchecked(rawData);
}