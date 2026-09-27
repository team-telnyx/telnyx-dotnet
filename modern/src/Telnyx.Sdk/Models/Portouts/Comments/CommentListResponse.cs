using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Portouts.Comments;

[JsonConverter(typeof(JsonModelConverter<CommentListResponse, CommentListResponseFromRaw>))]
public sealed record class CommentListResponse : JsonModel
{
    public IReadOnlyList<PortoutComment>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortoutComment>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortoutComment>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Metadata? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metadata>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public CommentListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommentListResponse (CommentListResponse commentListResponse) : base(
        commentListResponse
    )
    {  }
    #pragma warning restore CS8618

    public CommentListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CommentListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CommentListResponseFromRaw.FromRawUnchecked"/>
    public static CommentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CommentListResponseFromRaw : IFromRawJson<CommentListResponse>
{
    /// <inheritdoc/>
    public CommentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CommentListResponse.FromRawUnchecked(rawData);
}