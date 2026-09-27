using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Clusters;

[JsonConverter(typeof(JsonModelConverter<RecursiveCluster, RecursiveClusterFromRaw>))]
public sealed record class RecursiveCluster : JsonModel
{
    public required string ClusterID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "cluster_id"
            );
        }
        init { this._rawData.Set("cluster_id", value); }
    }

    public required string ClusterSummary {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "cluster_summary"
            );
        }
        init { this._rawData.Set("cluster_summary", value); }
    }

    public required long TotalNumberOfNodes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_number_of_nodes"
            );
        }
        init { this._rawData.Set("total_number_of_nodes", value); }
    }

    public string? ClusterHeader {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cluster_header"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cluster_header", value);
        }
    }

    public IReadOnlyList<Node>? Nodes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Node>>(
                "nodes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Node>?>(
                "nodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<RecursiveCluster>? Subclusters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RecursiveCluster>>(
                "subclusters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RecursiveCluster>?>(
                "subclusters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClusterID;
        _ = this.ClusterSummary;
        _ = this.TotalNumberOfNodes;
        _ = this.ClusterHeader;
        foreach (var item in this.Nodes ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Subclusters ?? [])
        {
            item.Validate();
        }
    }

    public RecursiveCluster ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecursiveCluster (RecursiveCluster recursiveCluster) : base(
        recursiveCluster
    )
    {  }
    #pragma warning restore CS8618

    public RecursiveCluster (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecursiveCluster (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecursiveClusterFromRaw.FromRawUnchecked"/>
    public static RecursiveCluster FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecursiveClusterFromRaw : IFromRawJson<RecursiveCluster>
{
    /// <inheritdoc/>
    public RecursiveCluster FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecursiveCluster.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Node, NodeFromRaw>))]
public sealed record class Node : JsonModel
{
    /// <summary>
    /// The corresponding source file of your embedded storage bucket that the node
    /// is from.
    /// </summary>
    public required string Filename {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "filename"
            );
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// The text of the node.
    /// </summary>
    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Filename;
        _ = this.Text;
    }

    public Node ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Node (Node node) : base(node)
    {  }
    #pragma warning restore CS8618

    public Node (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Node (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NodeFromRaw.FromRawUnchecked"/>
    public static Node FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NodeFromRaw : IFromRawJson<Node>
{
    /// <inheritdoc/>
    public Node FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Node.FromRawUnchecked(rawData);
}