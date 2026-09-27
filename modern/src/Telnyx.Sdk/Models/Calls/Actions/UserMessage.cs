using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Messages sent by an end user
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserMessage, UserMessageFromRaw>))]
public sealed record class UserMessage : JsonModel
{
    /// <summary>
    /// The contents of the user message.
    /// </summary>
    public required string Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// The role of the messages author, in this case `user`.
    /// </summary>
    public required ApiEnum<string, UserMessageRole> Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserMessageRole>>(
                "role"
            );
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// Metadata to add to the message
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Role.Validate();
        _ = this.Metadata;
    }

    public UserMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserMessage (UserMessage userMessage) : base(userMessage)
    {  }
    #pragma warning restore CS8618

    public UserMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserMessageFromRaw.FromRawUnchecked"/>
    public static UserMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserMessageFromRaw : IFromRawJson<UserMessage>
{
    /// <inheritdoc/>
    public UserMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserMessage.FromRawUnchecked(rawData);
}

/// <summary>
/// The role of the messages author, in this case `user`.
/// </summary>
[JsonConverter(typeof(UserMessageRoleConverter))]
public enum UserMessageRole
{
    User
}sealed class UserMessageRoleConverter : JsonConverter<UserMessageRole>
{
    public override UserMessageRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "user"=>UserMessageRole.User, _ =>(UserMessageRole)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserMessageRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UserMessageRole.User=>"user",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}