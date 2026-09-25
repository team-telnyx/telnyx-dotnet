using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PortingOrders.Comments;

[JsonConverter(typeof(JsonModelConverter<CommentListPageResponse, CommentListPageResponseFromRaw>))]
public sealed record class CommentListPageResponse : JsonModel
{
    public IReadOnlyList<PortingOrdersComment>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingOrdersComment>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingOrdersComment>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
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

    public CommentListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommentListPageResponse (
        CommentListPageResponse commentListPageResponse
    ) : base(commentListPageResponse)
    {  }
    #pragma warning restore CS8618

    public CommentListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CommentListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CommentListPageResponseFromRaw.FromRawUnchecked"/>
    public static CommentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CommentListPageResponseFromRaw : IFromRawJson<CommentListPageResponse>
{
    /// <inheritdoc/>
    public CommentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CommentListPageResponse.FromRawUnchecked(rawData);
}