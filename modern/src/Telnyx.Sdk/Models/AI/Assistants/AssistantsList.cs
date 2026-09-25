using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<AssistantsList, AssistantsListFromRaw>))]
public sealed record class AssistantsList : JsonModel
{
    public required IReadOnlyList<InferenceEmbedding> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InferenceEmbedding>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<InferenceEmbedding>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public AssistantsList ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantsList (AssistantsList assistantsList) : base(assistantsList)
    {  }
    #pragma warning restore CS8618

    public AssistantsList (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantsList (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantsListFromRaw.FromRawUnchecked"/>
    public static AssistantsList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AssistantsList (IReadOnlyList<InferenceEmbedding> data) : this()
    { this.Data = data; }
}

class AssistantsListFromRaw : IFromRawJson<AssistantsList>
{
    /// <inheritdoc/>
    public AssistantsList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssistantsList.FromRawUnchecked(rawData);
}