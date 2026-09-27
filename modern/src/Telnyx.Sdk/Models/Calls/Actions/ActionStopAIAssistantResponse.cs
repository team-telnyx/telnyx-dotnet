using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStopAIAssistantResponse, ActionStopAIAssistantResponseFromRaw>))]
public sealed record class ActionStopAIAssistantResponse : JsonModel
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

    public ActionStopAIAssistantResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStopAIAssistantResponse (
        ActionStopAIAssistantResponse actionStopAIAssistantResponse
    ) : base(actionStopAIAssistantResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStopAIAssistantResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStopAIAssistantResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStopAIAssistantResponseFromRaw.FromRawUnchecked"/>
    public static ActionStopAIAssistantResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStopAIAssistantResponseFromRaw : IFromRawJson<ActionStopAIAssistantResponse>
{
    /// <inheritdoc/>
    public ActionStopAIAssistantResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStopAIAssistantResponse.FromRawUnchecked(rawData);
}