using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir.Comments;

[JsonConverter(typeof(JsonModelConverter<CommentCreateResponse, CommentCreateResponseFromRaw>))]
public sealed record class CommentCreateResponse : JsonModel
{
    public required DirComment Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DirComment>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public CommentCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommentCreateResponse (
        CommentCreateResponse commentCreateResponse
    ) : base(commentCreateResponse)
    {  }
    #pragma warning restore CS8618

    public CommentCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CommentCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CommentCreateResponseFromRaw.FromRawUnchecked"/>
    public static CommentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public CommentCreateResponse (DirComment data) : this()
    { this.Data = data; }
}

class CommentCreateResponseFromRaw : IFromRawJson<CommentCreateResponse>
{
    /// <inheritdoc/>
    public CommentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CommentCreateResponse.FromRawUnchecked(rawData);
}