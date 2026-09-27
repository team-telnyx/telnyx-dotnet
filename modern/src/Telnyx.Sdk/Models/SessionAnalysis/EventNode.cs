using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SessionAnalysis;

[JsonConverter(typeof(JsonModelConverter<EventNode, EventNodeFromRaw>))]
public sealed record class EventNode : JsonModel
{
    /// <summary>
    /// Event identifier.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Child events in the session tree.
    /// </summary>
    public required IReadOnlyList<EventNode> Children {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EventNode>>(
                "children"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EventNode>>(
                "children",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Cost Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Cost>(
                "cost"
            );
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Name of the event type.
    /// </summary>
    public required string EventName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "event_name"
            );
        }
        init { this._rawData.Set("event_name", value); }
    }

    public required Links Links {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Links>(
                "links"
            );
        }
        init { this._rawData.Set("links", value); }
    }

    /// <summary>
    /// Product that generated this event.
    /// </summary>
    public required string Product {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "product"
            );
        }
        init { this._rawData.Set("product", value); }
    }

    /// <summary>
    /// The underlying detail record data. Contents vary by record type.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Record {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "record"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "record",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Relationship to the parent node, null for root.
    /// </summary>
    public Relationship? Relationship {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Relationship>(
                "relationship"
            );
        }
        init { this._rawData.Set("relationship", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Children)
        {
            item.Validate();
        }
        this.Cost.Validate();
        _ = this.EventName;
        this.Links.Validate();
        _ = this.Product;
        _ = this.Record;
        this.Relationship?.Validate();
    }

    public EventNode ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventNode (EventNode eventNode) : base(eventNode)
    {  }
    #pragma warning restore CS8618

    public EventNode (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EventNode (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EventNodeFromRaw.FromRawUnchecked"/>
    public static EventNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EventNodeFromRaw : IFromRawJson<EventNode>
{
    /// <inheritdoc/>
    public EventNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EventNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Cost, CostFromRaw>))]
public sealed record class Cost : JsonModel
{
    /// <summary>
    /// Cumulative cost including all descendants.
    /// </summary>
    public required string CumulativeCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "cumulative_cost"
            );
        }
        init { this._rawData.Set("cumulative_cost", value); }
    }

    /// <summary>
    /// ISO 4217 currency code.
    /// </summary>
    public required string Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Cost of this individual event.
    /// </summary>
    public required string EventCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "event_cost"
            );
        }
        init { this._rawData.Set("event_cost", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeCost;
        _ = this.Currency;
        _ = this.EventCost;
    }

    public Cost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cost (Cost cost) : base(cost)
    {  }
    #pragma warning restore CS8618

    public Cost (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostFromRaw.FromRawUnchecked"/>
    public static Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CostFromRaw : IFromRawJson<Cost>
{
    /// <inheritdoc/>
    public Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Cost.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Links, LinksFromRaw>))]
public sealed record class Links : JsonModel
{
    /// <summary>
    /// Link to the underlying detail records.
    /// </summary>
    public required string Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "records"
            );
        }
        init { this._rawData.Set("records", value); }
    }

    /// <summary>
    /// Link to this session analysis node.
    /// </summary>
    public required string Self {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "self"
            );
        }
        init { this._rawData.Set("self", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Records;
        _ = this.Self;
    }

    public Links ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Links (Links links) : base(links)
    {  }
    #pragma warning restore CS8618

    public Links (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Links (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LinksFromRaw.FromRawUnchecked"/>
    public static Links FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class LinksFromRaw : IFromRawJson<Links>
{
    /// <inheritdoc/>
    public Links FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Links.FromRawUnchecked(rawData);
}/// <summary>
/// Relationship to the parent node, null for root.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Relationship, RelationshipFromRaw>))]
public sealed record class Relationship : JsonModel
{
    /// <summary>
    /// Identifier of the parent event.
    /// </summary>
    public required string ParentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "parent_id"
            );
        }
        init { this._rawData.Set("parent_id", value); }
    }

    /// <summary>
    /// Relationship type identifier.
    /// </summary>
    public required string Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public required Via Via {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Via>(
                "via"
            );
        }
        init { this._rawData.Set("via", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ParentID;
        _ = this.Type;
        this.Via.Validate();
    }

    public Relationship ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Relationship (Relationship relationship) : base(relationship)
    {  }
    #pragma warning restore CS8618

    public Relationship (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Relationship (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RelationshipFromRaw.FromRawUnchecked"/>
    public static Relationship FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RelationshipFromRaw : IFromRawJson<Relationship>
{
    /// <inheritdoc/>
    public Relationship FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Relationship.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Via, ViaFromRaw>))]
public sealed record class Via : JsonModel
{
    /// <summary>
    /// Field name on the child record.
    /// </summary>
    public required string LocalField {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "local_field"
            );
        }
        init { this._rawData.Set("local_field", value); }
    }

    /// <summary>
    /// Field name on the parent record.
    /// </summary>
    public required string ParentField {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "parent_field"
            );
        }
        init { this._rawData.Set("parent_field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LocalField;
        _ = this.ParentField;
    }

    public Via ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Via (Via via) : base(via)
    {  }
    #pragma warning restore CS8618

    public Via (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Via (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ViaFromRaw.FromRawUnchecked"/>
    public static Via FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ViaFromRaw : IFromRawJson<Via>
{
    /// <inheritdoc/>
    public Via FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Via.FromRawUnchecked(rawData);
}