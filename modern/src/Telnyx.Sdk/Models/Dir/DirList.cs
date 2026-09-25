using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CallReasons;

namespace Telnyx.Sdk.Models.Dir;

[JsonConverter(typeof(JsonModelConverter<DirList, DirListFromRaw>))]
public sealed record class DirList : JsonModel
{
    public required IReadOnlyList<DirDir> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DirDir>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<DirDir>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// JSON:API pagination metadata returned with every paginated list response.
    /// Page numbering is 1-based. `page_size` reports the number of items actually
    /// returned in `data` for this page; the requested size is taken from the `page[size]`
    /// query parameter.
    /// </summary>
    public required BrandedCallingPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrandedCallingPaginationMeta>(
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

    public DirList ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirList (DirList dirList) : base(dirList)
    {  }
    #pragma warning restore CS8618

    public DirList (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DirList (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DirListFromRaw.FromRawUnchecked"/>
    public static DirList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DirListFromRaw : IFromRawJson<DirList>
{
    /// <inheritdoc/>
    public DirList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DirList.FromRawUnchecked(rawData);
}