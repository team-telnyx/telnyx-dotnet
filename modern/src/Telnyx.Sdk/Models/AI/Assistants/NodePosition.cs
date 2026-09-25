using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// 2D coordinates for a node, used by authoring UIs to lay out the graph.
///
/// <para>Purely a presentation aid. The runtime ignores `position`; it round-trips
/// through the API so frontends can persist the graph layout customers arrange in
/// the editor.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NodePosition, NodePositionFromRaw>))]
public sealed record class NodePosition : JsonModel
{
    /// <summary>
    /// Horizontal coordinate in the authoring canvas.
    /// </summary>
    public required double X {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "x"
            );
        }
        init { this._rawData.Set("x", value); }
    }

    /// <summary>
    /// Vertical coordinate in the authoring canvas.
    /// </summary>
    public required double Y {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "y"
            );
        }
        init { this._rawData.Set("y", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.X;
        _ = this.Y;
    }

    public NodePosition ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NodePosition (NodePosition nodePosition) : base(nodePosition)
    {  }
    #pragma warning restore CS8618

    public NodePosition (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NodePosition (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NodePositionFromRaw.FromRawUnchecked"/>
    public static NodePosition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NodePositionFromRaw : IFromRawJson<NodePosition>
{
    /// <inheritdoc/>
    public NodePosition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NodePosition.FromRawUnchecked(rawData);
}