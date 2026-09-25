using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Cloudfs;

[JsonConverter(typeof(JsonModelConverter<CloudfListPageResponse, CloudfListPageResponseFromRaw>))]
public sealed record class CloudfListPageResponse : JsonModel
{
    public IReadOnlyList<CloudfListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CloudfListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CloudfListResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Meta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public CloudfListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudfListPageResponse (
        CloudfListPageResponse cloudfListPageResponse
    ) : base(cloudfListPageResponse)
    {  }
    #pragma warning restore CS8618

    public CloudfListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudfListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CloudfListPageResponseFromRaw.FromRawUnchecked"/>
    public static CloudfListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CloudfListPageResponseFromRaw : IFromRawJson<CloudfListPageResponse>
{
    /// <inheritdoc/>
    public CloudfListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CloudfListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Opaque cursors for the adjacent pages. Empty when there are no adjacent pages.
    /// </summary>
    public Cursors? Cursors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cursors>(
                "cursors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cursors", value);
        }
    }

    /// <summary>
    /// Relative URL (path and query) of the next page. Omitted when there are no
    /// further results.
    /// </summary>
    public string? Next {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "next"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("next", value);
        }
    }

    /// <summary>
    /// Relative URL (path and query) of the previous page. Omitted on the first page.
    /// </summary>
    public string? Previous {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "previous"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("previous", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cursors?.Validate();
        _ = this.Next;
        _ = this.Previous;
    }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}/// <summary>
/// Opaque cursors for the adjacent pages. Empty when there are no adjacent pages.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cursors, CursorsFromRaw>))]
public sealed record class Cursors : JsonModel
{
    /// <summary>
    /// Cursor for the next page; pass it as `page[after]`. Omitted on the last page.
    /// </summary>
    public string? After {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "after"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// Cursor for the previous page; pass it as `page[before]`. Omitted on the first page.
    /// </summary>
    public string? Before {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "before"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public Cursors ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cursors (Cursors cursors) : base(cursors)
    {  }
    #pragma warning restore CS8618

    public Cursors (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cursors (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CursorsFromRaw.FromRawUnchecked"/>
    public static Cursors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CursorsFromRaw : IFromRawJson<Cursors>
{
    /// <inheritdoc/>
    public Cursors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Cursors.FromRawUnchecked(rawData);
}