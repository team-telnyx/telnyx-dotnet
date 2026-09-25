using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Collections.Settings;
using Telnyx.Sdk.Models.AI.Collections.Sources;

namespace Telnyx.Sdk.Models.AI.Collections;

[JsonConverter(typeof(JsonModelConverter<Collection, CollectionFromRaw>))]
public sealed record class Collection : JsonModel
{
    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Identifies the record type. Always `ai_collection`.
    /// </summary>
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

    public RetrievalSettingsWrapper? Settings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RetrievalSettingsWrapper>(
                "settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("settings", value);
        }
    }

    public string? Slug {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "slug"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("slug", value);
        }
    }

    public IReadOnlyList<CollectionsSource>? Sources {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CollectionsSource>>(
                "sources"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CollectionsSource>?>(
                "sources",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    public string? Uuid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "uuid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uuid", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Name;
        _ = this.RecordType;
        this.Settings?.Validate();
        _ = this.Slug;
        foreach (var item in this.Sources ?? [])
        {
            item.Validate();
        }
        _ = this.Status;
        _ = this.UpdatedAt;
        _ = this.Uuid;
    }

    public Collection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Collection (Collection collection) : base(collection)
    {  }
    #pragma warning restore CS8618

    public Collection (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Collection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CollectionFromRaw.FromRawUnchecked"/>
    public static Collection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CollectionFromRaw : IFromRawJson<Collection>
{
    /// <inheritdoc/>
    public Collection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Collection.FromRawUnchecked(rawData);
}