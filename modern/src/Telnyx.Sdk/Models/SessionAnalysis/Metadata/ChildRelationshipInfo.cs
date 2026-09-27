using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SessionAnalysis.Metadata;

[JsonConverter(typeof(JsonModelConverter<ChildRelationshipInfo, ChildRelationshipInfoFromRaw>))]
public sealed record class ChildRelationshipInfo : JsonModel
{
    public required string ChildEvent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "child_event"
            );
        }
        init { this._rawData.Set("child_event", value); }
    }

    public required string ChildProduct {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "child_product"
            );
        }
        init { this._rawData.Set("child_product", value); }
    }

    public required string ChildRecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "child_record_type"
            );
        }
        init { this._rawData.Set("child_record_type", value); }
    }

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
        _ = this.ChildEvent;
        _ = this.ChildProduct;
        _ = this.ChildRecordType;
        _ = this.CostRollup;
        _ = this.Description;
        _ = this.RelationshipType;
        _ = this.TraversalEnabled;
        this.Via.Validate();
    }

    public ChildRelationshipInfo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChildRelationshipInfo (
        ChildRelationshipInfo childRelationshipInfo
    ) : base(childRelationshipInfo)
    {  }
    #pragma warning restore CS8618

    public ChildRelationshipInfo (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ChildRelationshipInfo (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ChildRelationshipInfoFromRaw.FromRawUnchecked"/>
    public static ChildRelationshipInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ChildRelationshipInfoFromRaw : IFromRawJson<ChildRelationshipInfo>
{
    /// <inheritdoc/>
    public ChildRelationshipInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ChildRelationshipInfo.FromRawUnchecked(rawData);
}