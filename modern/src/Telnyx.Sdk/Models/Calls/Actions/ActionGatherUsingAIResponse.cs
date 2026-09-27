using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionGatherUsingAIResponse, ActionGatherUsingAIResponseFromRaw>))]
public sealed record class ActionGatherUsingAIResponse : JsonModel
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

    public ActionGatherUsingAIResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGatherUsingAIResponse (
        ActionGatherUsingAIResponse actionGatherUsingAIResponse
    ) : base(actionGatherUsingAIResponse)
    {  }
    #pragma warning restore CS8618

    public ActionGatherUsingAIResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionGatherUsingAIResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionGatherUsingAIResponseFromRaw.FromRawUnchecked"/>
    public static ActionGatherUsingAIResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionGatherUsingAIResponseFromRaw : IFromRawJson<ActionGatherUsingAIResponse>
{
    /// <inheritdoc/>
    public ActionGatherUsingAIResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionGatherUsingAIResponse.FromRawUnchecked(rawData);
}