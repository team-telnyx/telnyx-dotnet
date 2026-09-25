using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionAddAIAssistantMessagesResponse, ActionAddAIAssistantMessagesResponseFromRaw>))]
public sealed record class ActionAddAIAssistantMessagesResponse : JsonModel
{
    public CallControlCommandResult? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallControlCommandResult>(
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

    public ActionAddAIAssistantMessagesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionAddAIAssistantMessagesResponse (
        ActionAddAIAssistantMessagesResponse actionAddAIAssistantMessagesResponse
    ) : base(actionAddAIAssistantMessagesResponse)
    {  }
    #pragma warning restore CS8618

    public ActionAddAIAssistantMessagesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionAddAIAssistantMessagesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionAddAIAssistantMessagesResponseFromRaw.FromRawUnchecked"/>
    public static ActionAddAIAssistantMessagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionAddAIAssistantMessagesResponseFromRaw : IFromRawJson<ActionAddAIAssistantMessagesResponse>
{
    /// <inheritdoc/>
    public ActionAddAIAssistantMessagesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionAddAIAssistantMessagesResponse.FromRawUnchecked(rawData);
}