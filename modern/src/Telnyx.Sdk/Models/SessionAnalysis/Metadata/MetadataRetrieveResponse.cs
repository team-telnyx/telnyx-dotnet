using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SessionAnalysis.Metadata;

[JsonConverter(typeof(JsonModelConverter<MetadataRetrieveResponse, MetadataRetrieveResponseFromRaw>))]
public sealed record class MetadataRetrieveResponse : JsonModel
{
    public required Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <summary>
    /// Map of supported query parameter names to their definitions.
    /// </summary>
    public required IReadOnlyDictionary<string, QueryParametersItem> QueryParameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, QueryParametersItem>>(
                "query_parameters"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, QueryParametersItem>>(
                "query_parameters",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required IReadOnlyList<RecordType> RecordTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RecordType>>(
                "record_types"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<RecordType>>(
                "record_types",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Meta.Validate();
        foreach (var item in this.QueryParameters.Values)
        {
            item.Validate();
        }
        foreach (var item in this.RecordTypes)
        {
            item.Validate();
        }
    }

    public MetadataRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetadataRetrieveResponse (
        MetadataRetrieveResponse metadataRetrieveResponse
    ) : base(metadataRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MetadataRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MetadataRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetadataRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MetadataRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MetadataRetrieveResponseFromRaw : IFromRawJson<MetadataRetrieveResponse>
{
    /// <inheritdoc/>
    public MetadataRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MetadataRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public required DateTimeOffset LastUpdated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "last_updated"
            );
        }
        init { this._rawData.Set("last_updated", value); }
    }

    public required long TotalRecordTypes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_record_types"
            );
        }
        init { this._rawData.Set("total_record_types", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LastUpdated;
        _ = this.TotalRecordTypes;
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
}[JsonConverter(typeof(JsonModelConverter<QueryParametersItem, QueryParametersItemFromRaw>))]
public sealed record class QueryParametersItem : JsonModel
{
    public required string Default {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "default"
            );
        }
        init { this._rawData.Set("default", value); }
    }

    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    public required string Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<string>? EnumValues {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "enum_values"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>?>(
                "enum_values",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? Max {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max"
            );
        }
        init { this._rawData.Set("max", value); }
    }

    public long? Min {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "min"
            );
        }
        init { this._rawData.Set("min", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Default;
        _ = this.Description;
        _ = this.Type;
        _ = this.EnumValues;
        _ = this.Max;
        _ = this.Min;
    }

    public QueryParametersItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public QueryParametersItem (QueryParametersItem queryParametersItem) : base(
        queryParametersItem
    )
    {  }
    #pragma warning restore CS8618

    public QueryParametersItem (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    QueryParametersItem (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="QueryParametersItemFromRaw.FromRawUnchecked"/>
    public static QueryParametersItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class QueryParametersItemFromRaw : IFromRawJson<QueryParametersItem>
{
    /// <inheritdoc/>
    public QueryParametersItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>QueryParametersItem.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<RecordType, RecordTypeFromRaw>))]
public sealed record class RecordType : JsonModel
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

    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
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

    public required string RecordTypeValue {
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
        _ = this.Description;
        _ = this.Event;
        foreach (var item in this.ParentRelationships)
        {
            item.Validate();
        }
        _ = this.Product;
        _ = this.RecordTypeValue;
    }

    public RecordType ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordType (RecordType recordType) : base(recordType)
    {  }
    #pragma warning restore CS8618

    public RecordType (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordType (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordTypeFromRaw.FromRawUnchecked"/>
    public static RecordType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RecordTypeFromRaw : IFromRawJson<RecordType>
{
    /// <inheritdoc/>
    public RecordType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordType.FromRawUnchecked(rawData);
}