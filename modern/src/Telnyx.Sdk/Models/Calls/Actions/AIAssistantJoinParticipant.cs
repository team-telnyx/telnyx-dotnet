using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<AIAssistantJoinParticipant, AIAssistantJoinParticipantFromRaw>))]
public sealed record class AIAssistantJoinParticipant : JsonModel
{
    /// <summary>
    /// The call_control_id of the participant to add to the conversation.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The role of the participant in the conversation.
    /// </summary>
    public required ApiEnum<string, AIAssistantJoinParticipantRole> Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AIAssistantJoinParticipantRole>>(
                "role"
            );
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// Display name for the participant.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Determines what happens to the conversation when this participant hangs up.
    /// </summary>
    public ApiEnum<string, OnHangup>? OnHangup {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OnHangup>>(
                "on_hangup"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_hangup", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Role.Validate();
        _ = this.Name;
        this.OnHangup?.Validate();
    }

    public AIAssistantJoinParticipant ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AIAssistantJoinParticipant (
        AIAssistantJoinParticipant aiAssistantJoinParticipant
    ) : base(aiAssistantJoinParticipant)
    {  }
    #pragma warning restore CS8618

    public AIAssistantJoinParticipant (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AIAssistantJoinParticipant (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AIAssistantJoinParticipantFromRaw.FromRawUnchecked"/>
    public static AIAssistantJoinParticipant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AIAssistantJoinParticipantFromRaw : IFromRawJson<AIAssistantJoinParticipant>
{
    /// <inheritdoc/>
    public AIAssistantJoinParticipant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AIAssistantJoinParticipant.FromRawUnchecked(rawData);
}

/// <summary>
/// The role of the participant in the conversation.
/// </summary>
[JsonConverter(typeof(AIAssistantJoinParticipantRoleConverter))]
public enum AIAssistantJoinParticipantRole
{
    User
}sealed class AIAssistantJoinParticipantRoleConverter : JsonConverter<AIAssistantJoinParticipantRole>
{
    public override AIAssistantJoinParticipantRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user"=>AIAssistantJoinParticipantRole.User,
            _ =>(AIAssistantJoinParticipantRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIAssistantJoinParticipantRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AIAssistantJoinParticipantRole.User=>"user",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Determines what happens to the conversation when this participant hangs up.
/// </summary>
[JsonConverter(typeof(OnHangupConverter))]
public enum OnHangup
{
    ContinueConversation, EndConversation
}sealed class OnHangupConverter : JsonConverter<OnHangup>
{
    public override OnHangup Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "continue_conversation"=>OnHangup.ContinueConversation,
            "end_conversation"=>OnHangup.EndConversation,
            _ =>(OnHangup)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, OnHangup value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OnHangup.ContinueConversation=>"continue_conversation",
            OnHangup.EndConversation=>"end_conversation",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}