using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<CallControlCommandResultWithConversationID, CallControlCommandResultWithConversationIDFromRaw>))]
public sealed record class CallControlCommandResultWithConversationID : JsonModel
{
    /// <summary>
    /// The ID of the conversation created by the command.
    /// </summary>
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
        _ = this.ConversationID;
        _ = this.Result;
    }

    public CallControlCommandResultWithConversationID ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlCommandResultWithConversationID (
        CallControlCommandResultWithConversationID callControlCommandResultWithConversationID
    ) : base(callControlCommandResultWithConversationID)
    {  }
    #pragma warning restore CS8618

    public CallControlCommandResultWithConversationID (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlCommandResultWithConversationID (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlCommandResultWithConversationIDFromRaw.FromRawUnchecked"/>
    public static CallControlCommandResultWithConversationID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlCommandResultWithConversationIDFromRaw : IFromRawJson<CallControlCommandResultWithConversationID>
{
    /// <inheritdoc/>
    public CallControlCommandResultWithConversationID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlCommandResultWithConversationID.FromRawUnchecked(rawData);
}