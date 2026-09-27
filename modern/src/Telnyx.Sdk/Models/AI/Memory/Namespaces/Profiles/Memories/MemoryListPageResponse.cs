using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Memories;

[JsonConverter(typeof(JsonModelConverter<MemoryListPageResponse, MemoryListPageResponseFromRaw>))]
public sealed record class MemoryListPageResponse : JsonModel
{
    public required IReadOnlyList<MemoryListResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MemoryListResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MemoryListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Where a listing's page sits in the whole.
    ///
    /// <para>A page is a snapshot: the counts it reports and the order it is drawn
    /// in both move as writes land, so paging through a busy namespace can repeat
    /// or miss an entry at a page boundary.</para>
    /// </summary>
    public required PageMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public MemoryListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryListPageResponse (
        MemoryListPageResponse memoryListPageResponse
    ) : base(memoryListPageResponse)
    {  }
    #pragma warning restore CS8618

    public MemoryListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MemoryListPageResponseFromRaw.FromRawUnchecked"/>
    public static MemoryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MemoryListPageResponseFromRaw : IFromRawJson<MemoryListPageResponse>
{
    /// <inheritdoc/>
    public MemoryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MemoryListPageResponse.FromRawUnchecked(rawData);
}