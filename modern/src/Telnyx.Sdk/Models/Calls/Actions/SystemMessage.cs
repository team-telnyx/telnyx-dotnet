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
/// Developer-provided instructions that the model should follow, regardless of messages
/// sent by the user.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SystemMessage, SystemMessageFromRaw>))]
public sealed record class SystemMessage : JsonModel
{
    /// <summary>
    /// The contents of the system message.
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
    /// The role of the messages author, in this case `system`.
    /// </summary>
    public required ApiEnum<string, SystemMessageRole> Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SystemMessageRole>>(
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

    public SystemMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SystemMessage (SystemMessage systemMessage) : base(systemMessage)
    {  }
    #pragma warning restore CS8618

    public SystemMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SystemMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SystemMessageFromRaw.FromRawUnchecked"/>
    public static SystemMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SystemMessageFromRaw : IFromRawJson<SystemMessage>
{
    /// <inheritdoc/>
    public SystemMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SystemMessage.FromRawUnchecked(rawData);
}

/// <summary>
/// The role of the messages author, in this case `system`.
/// </summary>
[JsonConverter(typeof(SystemMessageRoleConverter))]
public enum SystemMessageRole
{
    System
}sealed class SystemMessageRoleConverter : JsonConverter<SystemMessageRole>
{
    public override SystemMessageRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "system"=>SystemMessageRole.System, _ =>(SystemMessageRole)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SystemMessageRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SystemMessageRole.System=>"system",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}