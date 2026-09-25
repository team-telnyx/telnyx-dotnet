using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Kvs.Keys;

[JsonConverter(typeof(JsonModelConverter<KeyListPageResponse, KeyListPageResponseFromRaw>))]
public sealed record class KeyListPageResponse : JsonModel
{
    public IReadOnlyList<KeyListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<KeyListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<KeyListResponse>?>(
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

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
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
        _ = this.RecordType;
    }

    public KeyListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public KeyListPageResponse (KeyListPageResponse keyListPageResponse) : base(
        keyListPageResponse
    )
    {  }
    #pragma warning restore CS8618

    public KeyListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    KeyListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="KeyListPageResponseFromRaw.FromRawUnchecked"/>
    public static KeyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class KeyListPageResponseFromRaw : IFromRawJson<KeyListPageResponse>
{
    /// <inheritdoc/>
    public KeyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>KeyListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Opaque cursor for the next page; pass it back as the `cursor` query parameter.
    /// Omitted when there are no further results.
    /// </summary>
    public string? Cursor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cursor"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Whether more results are available on a following page.
    /// </summary>
    public bool? HasMore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "has_more"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("has_more", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cursor;
        _ = this.HasMore;
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
}