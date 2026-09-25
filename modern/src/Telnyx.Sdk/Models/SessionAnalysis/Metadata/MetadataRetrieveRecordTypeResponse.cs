using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SessionAnalysis.Metadata;

[JsonConverter(typeof(JsonModelConverter<MetadataRetrieveRecordTypeResponse, MetadataRetrieveRecordTypeResponseFromRaw>))]
public sealed record class MetadataRetrieveRecordTypeResponse : JsonModel
{
    public required IReadOnlyList<string> Aliases {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "aliases"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "aliases",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<ChildRelationshipInfo> ChildRelationships {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ChildRelationshipInfo>>(
                "child_relationships"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ChildRelationshipInfo>>(
                "child_relationships",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Event {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "event"
            );
        }
        init { this._rawData.Set("event", value); }
    }

    /// <summary>
    /// Example queries and responses for this record type.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Examples {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "examples"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "examples",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required MetadataRetrieveRecordTypeResponseMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MetadataRetrieveRecordTypeResponseMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    public required IReadOnlyList<ParentRelationshipInfo> ParentRelationships {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ParentRelationshipInfo>>(
                "parent_relationships"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ParentRelationshipInfo>>(
                "parent_relationships",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Product {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "product"
            );
        }
        init { this._rawData.Set("product", value); }
    }

    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Aliases;
        foreach (var item in this.ChildRelationships)
        {
            item.Validate();
        }
        _ = this.Event;
        _ = this.Examples;
        this.Meta.Validate();
        foreach (var item in this.ParentRelationships)
        {
            item.Validate();
        }
        _ = this.Product;
        _ = this.RecordType;
    }

    public MetadataRetrieveRecordTypeResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetadataRetrieveRecordTypeResponse (
        MetadataRetrieveRecordTypeResponse metadataRetrieveRecordTypeResponse
    ) : base(metadataRetrieveRecordTypeResponse)
    {  }
    #pragma warning restore CS8618

    public MetadataRetrieveRecordTypeResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MetadataRetrieveRecordTypeResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetadataRetrieveRecordTypeResponseFromRaw.FromRawUnchecked"/>
    public static MetadataRetrieveRecordTypeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MetadataRetrieveRecordTypeResponseFromRaw : IFromRawJson<MetadataRetrieveRecordTypeResponse>
{
    /// <inheritdoc/>
    public MetadataRetrieveRecordTypeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MetadataRetrieveRecordTypeResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MetadataRetrieveRecordTypeResponseMeta, MetadataRetrieveRecordTypeResponseMetaFromRaw>))]
public sealed record class MetadataRetrieveRecordTypeResponseMeta : JsonModel
{
    public required long MaxRecommendedDepth {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "max_recommended_depth"
            );
        }
        init { this._rawData.Set("max_recommended_depth", value); }
    }

    public required long TotalChildren {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_children"
            );
        }
        init { this._rawData.Set("total_children", value); }
    }

    public required long TotalParents {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_parents"
            );
        }
        init { this._rawData.Set("total_parents", value); }
    }

    public required long TotalSiblings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_siblings"
            );
        }
        init { this._rawData.Set("total_siblings", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxRecommendedDepth;
        _ = this.TotalChildren;
        _ = this.TotalParents;
        _ = this.TotalSiblings;
    }

    public MetadataRetrieveRecordTypeResponseMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetadataRetrieveRecordTypeResponseMeta (
        MetadataRetrieveRecordTypeResponseMeta metadataRetrieveRecordTypeResponseMeta
    ) : base(metadataRetrieveRecordTypeResponseMeta)
    {  }
    #pragma warning restore CS8618

    public MetadataRetrieveRecordTypeResponseMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MetadataRetrieveRecordTypeResponseMeta (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetadataRetrieveRecordTypeResponseMetaFromRaw.FromRawUnchecked"/>
    public static MetadataRetrieveRecordTypeResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetadataRetrieveRecordTypeResponseMetaFromRaw : IFromRawJson<MetadataRetrieveRecordTypeResponseMeta>
{
    /// <inheritdoc/>
    public MetadataRetrieveRecordTypeResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MetadataRetrieveRecordTypeResponseMeta.FromRawUnchecked(rawData);
}