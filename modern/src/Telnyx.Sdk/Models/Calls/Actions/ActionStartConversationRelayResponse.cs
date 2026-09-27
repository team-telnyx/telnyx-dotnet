using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionStartConversationRelayResponse, ActionStartConversationRelayResponseFromRaw>))]
public sealed record class ActionStartConversationRelayResponse : JsonModel
{
    public ActionStartConversationRelayResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActionStartConversationRelayResponseData>(
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

    public ActionStartConversationRelayResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartConversationRelayResponse (
        ActionStartConversationRelayResponse actionStartConversationRelayResponse
    ) : base(actionStartConversationRelayResponse)
    {  }
    #pragma warning restore CS8618

    public ActionStartConversationRelayResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartConversationRelayResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStartConversationRelayResponseFromRaw.FromRawUnchecked"/>
    public static ActionStartConversationRelayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionStartConversationRelayResponseFromRaw : IFromRawJson<ActionStartConversationRelayResponse>
{
    /// <inheritdoc/>
    public ActionStartConversationRelayResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStartConversationRelayResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ActionStartConversationRelayResponseData, ActionStartConversationRelayResponseDataFromRaw>))]
public sealed record class ActionStartConversationRelayResponseData : JsonModel
{
    /// <summary>
    /// The ID of the Conversation Relay session created by the command.
    /// </summary>
    public string? ConversationRelayID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conversation_relay_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_relay_id", value);
        }
    }

    public string? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("result", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConversationRelayID;
        _ = this.Result;
    }

    public ActionStartConversationRelayResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartConversationRelayResponseData (
        ActionStartConversationRelayResponseData actionStartConversationRelayResponseData
    ) : base(actionStartConversationRelayResponseData)
    {  }
    #pragma warning restore CS8618

    public ActionStartConversationRelayResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionStartConversationRelayResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionStartConversationRelayResponseDataFromRaw.FromRawUnchecked"/>
    public static ActionStartConversationRelayResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ActionStartConversationRelayResponseDataFromRaw : IFromRawJson<ActionStartConversationRelayResponseData>
{
    /// <inheritdoc/>
    public ActionStartConversationRelayResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionStartConversationRelayResponseData.FromRawUnchecked(rawData);
}