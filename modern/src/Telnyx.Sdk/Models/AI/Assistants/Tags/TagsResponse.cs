using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.Tags;

[JsonConverter(typeof(JsonModelConverter<TagsResponse, TagsResponseFromRaw>))]
public sealed record class TagsResponse : JsonModel
{
    public required IReadOnlyList<string> Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "tags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Tags; }

    public TagsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TagsResponse (TagsResponse tagsResponse) : base(tagsResponse)
    {  }
    #pragma warning restore CS8618

    public TagsResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TagsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TagsResponseFromRaw.FromRawUnchecked"/>
    public static TagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TagsResponse (IReadOnlyList<string> tags) : this()
    { this.Tags = tags; }
}

class TagsResponseFromRaw : IFromRawJson<TagsResponse>
{
    /// <inheritdoc/>
    public TagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TagsResponse.FromRawUnchecked(rawData);
}