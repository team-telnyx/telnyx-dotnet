using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Collections.Sources;

[JsonConverter(typeof(JsonModelConverter<CollectionsSource, CollectionsSourceFromRaw>))]
public sealed record class CollectionsSource : JsonModel
{
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The Telnyx Storage bucket name. Present only for `bucket` sources.
    /// </summary>
    public string? BucketID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bucket_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bucket_id", value);
        }
    }

    public string? CollectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "collection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("collection_id", value);
        }
    }

    /// <summary>
    /// Identifies the record type. Always `ai_collection_source`.
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

    /// <summary>
    /// The type of Telnyx data attached as a source. `bucket` requires an additional
    /// `bucket_id`. Only `voice` is searchable today; `meeting_bot`, `message`, and
    /// `bucket` attach but are not yet searchable (Coming soon).
    /// </summary>
    public ApiEnum<string, SourceType>? SourceType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SourceType>>(
                "source_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source_type", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BucketID;
        _ = this.CollectionID;
        _ = this.RecordType;
        this.SourceType?.Validate();
        _ = this.Status;
    }

    public CollectionsSource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionsSource (CollectionsSource collectionsSource) : base(
        collectionsSource
    )
    {  }
    #pragma warning restore CS8618

    public CollectionsSource (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionsSource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CollectionsSourceFromRaw.FromRawUnchecked"/>
    public static CollectionsSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CollectionsSourceFromRaw : IFromRawJson<CollectionsSource>
{
    /// <inheritdoc/>
    public CollectionsSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CollectionsSource.FromRawUnchecked(rawData);
}