using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStopConversationRelayResponse, ActionStopConversationRelayResponseFromRaw>))]
public sealed record class ActionStopConversationRelayResponse : JsonModel
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

    public ActionStopConversationRelayResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStopConversationRelayResponse (
        ActionStopConversationRelayResponse actionStopConversationRelayResponse
    ) : base(actionStopConversationRelayResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStopConversationRelayResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStopConversationRelayResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStopConversationRelayResponseFromRaw.FromRawUnchecked"/>
    public static ActionStopConversationRelayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStopConversationRelayResponseFromRaw : IFromRawJson<ActionStopConversationRelayResponse>
{
    /// <inheritdoc/>
    public ActionStopConversationRelayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStopConversationRelayResponse.FromRawUnchecked(rawData);
}