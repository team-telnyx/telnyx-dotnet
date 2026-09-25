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
[JsonConverter(typeof(JsonModelConverter<DeveloperMessage, DeveloperMessageFromRaw>))]
public sealed record class DeveloperMessage : JsonModel
{
    /// <summary>
    /// The contents of the developer message.
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
    /// The role of the messages author, in this case developer.
    /// </summary>
    public required ApiEnum<string, DeveloperMessageRole> Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeveloperMessageRole>>(
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

    public DeveloperMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeveloperMessage (DeveloperMessage developerMessage) : base(
        developerMessage
    )
    {  }
    #pragma warning restore CS8618

    public DeveloperMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DeveloperMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DeveloperMessageFromRaw.FromRawUnchecked"/>
    public static DeveloperMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DeveloperMessageFromRaw : IFromRawJson<DeveloperMessage>
{
    /// <inheritdoc/>
    public DeveloperMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DeveloperMessage.FromRawUnchecked(rawData);
}

/// <summary>
/// The role of the messages author, in this case developer.
/// </summary>
[JsonConverter(typeof(DeveloperMessageRoleConverter))]
public enum DeveloperMessageRole
{
    Developer
}sealed class DeveloperMessageRoleConverter : JsonConverter<DeveloperMessageRole>
{
    public override DeveloperMessageRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "developer"=>DeveloperMessageRole.Developer,
            _ =>(DeveloperMessageRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeveloperMessageRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeveloperMessageRole.Developer=>"developer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}