using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Sources = Telnyx.Sdk.Models.AI.Collections.Sources;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Sources;

[JsonConverter(typeof(JsonModelConverter<SourceListPageResponse, SourceListPageResponseFromRaw>))]
public sealed record class SourceListPageResponse : JsonModel
{
    public required IReadOnlyList<Sources::Source> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Sources::Source>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Sources::Source>>(
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

    public SourceListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SourceListPageResponse (
        SourceListPageResponse sourceListPageResponse
    ) : base(sourceListPageResponse)
    {  }
    #pragma warning restore CS8618

    public SourceListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SourceListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceListPageResponseFromRaw.FromRawUnchecked"/>
    public static SourceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SourceListPageResponseFromRaw : IFromRawJson<SourceListPageResponse>
{
    /// <inheritdoc/>
    public SourceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SourceListPageResponse.FromRawUnchecked(rawData);
}