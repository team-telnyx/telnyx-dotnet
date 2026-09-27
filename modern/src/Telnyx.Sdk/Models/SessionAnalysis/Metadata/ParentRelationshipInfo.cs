using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SessionAnalysis.Metadata;

[JsonConverter(typeof(JsonModelConverter<ParentRelationshipInfo, ParentRelationshipInfoFromRaw>))]
public sealed record class ParentRelationshipInfo : JsonModel
{
    public required bool CostRollup {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "cost_rollup"
            );
        }
        init { this._rawData.Set("cost_rollup", value); }
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

    public required string ParentEvent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "parent_event"
            );
        }
        init { this._rawData.Set("parent_event", value); }
    }

    public required string ParentProduct {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "parent_product"
            );
        }
        init { this._rawData.Set("parent_product", value); }
    }

    public required string ParentRecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "parent_record_type"
            );
        }
        init { this._rawData.Set("parent_record_type", value); }
    }

    public required string RelationshipType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "relationship_type"
            );
        }
        init { this._rawData.Set("relationship_type", value); }
    }

    public required bool TraversalEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "traversal_enabled"
            );
        }
        init { this._rawData.Set("traversal_enabled", value); }
    }

    public required MetadataFieldMapping Via {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MetadataFieldMapping>(
                "via"
            );
        }
        init { this._rawData.Set("via", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CostRollup;
        _ = this.Description;
        _ = this.ParentEvent;
        _ = this.ParentProduct;
        _ = this.ParentRecordType;
        _ = this.RelationshipType;
        _ = this.TraversalEnabled;
        this.Via.Validate();
    }

    public ParentRelationshipInfo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParentRelationshipInfo (
        ParentRelationshipInfo parentRelationshipInfo
    ) : base(parentRelationshipInfo)
    {  }
    #pragma warning restore CS8618

    public ParentRelationshipInfo (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ParentRelationshipInfo (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ParentRelationshipInfoFromRaw.FromRawUnchecked"/>
    public static ParentRelationshipInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ParentRelationshipInfoFromRaw : IFromRawJson<ParentRelationshipInfo>
{
    /// <inheritdoc/>
    public ParentRelationshipInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ParentRelationshipInfo.FromRawUnchecked(rawData);
}