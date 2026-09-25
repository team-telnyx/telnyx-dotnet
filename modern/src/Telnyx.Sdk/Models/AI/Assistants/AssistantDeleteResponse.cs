using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Aligns with the OpenAI API: https://platform.openai.com/docs/api-reference/assistants/deleteAssistant
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AssistantDeleteResponse, AssistantDeleteResponseFromRaw>))]
public sealed record class AssistantDeleteResponse : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required bool Deleted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "deleted"
            );
        }
        init { this._rawData.Set("deleted", value); }
    }

    public required string Object {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "object"
            );
        }
        init { this._rawData.Set("object", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Deleted;
        _ = this.Object;
    }

    public AssistantDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantDeleteResponse (
        AssistantDeleteResponse assistantDeleteResponse
    ) : base(assistantDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public AssistantDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantDeleteResponseFromRaw.FromRawUnchecked"/>
    public static AssistantDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssistantDeleteResponseFromRaw : IFromRawJson<AssistantDeleteResponse>
{
    /// <inheritdoc/>
    public AssistantDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssistantDeleteResponse.FromRawUnchecked(rawData);
}