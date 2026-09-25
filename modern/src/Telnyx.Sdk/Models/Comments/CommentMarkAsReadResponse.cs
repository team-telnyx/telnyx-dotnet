using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Comments;

[JsonConverter(typeof(JsonModelConverter<CommentMarkAsReadResponse, CommentMarkAsReadResponseFromRaw>))]
public sealed record class CommentMarkAsReadResponse : JsonModel
{
    public CommentMarkAsReadResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommentMarkAsReadResponseData>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public CommentMarkAsReadResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommentMarkAsReadResponse (
        CommentMarkAsReadResponse commentMarkAsReadResponse
    ) : base(commentMarkAsReadResponse)
    {  }
    #pragma warning restore CS8618

    public CommentMarkAsReadResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CommentMarkAsReadResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CommentMarkAsReadResponseFromRaw.FromRawUnchecked"/>
    public static CommentMarkAsReadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CommentMarkAsReadResponseFromRaw : IFromRawJson<CommentMarkAsReadResponse>
{
    /// <inheritdoc/>
    public CommentMarkAsReadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CommentMarkAsReadResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CommentMarkAsReadResponseData, CommentMarkAsReadResponseDataFromRaw>))]
public sealed record class CommentMarkAsReadResponseData : JsonModel
{
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? Body {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("body", value);
        }
    }

    public string? CommentRecordID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "comment_record_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("comment_record_id", value);
        }
    }

    public ApiEnum<string, CommentCommentRecordType>? CommentRecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CommentCommentRecordType>>(
                "comment_record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("comment_record_type", value);
        }
    }

    public string? Commenter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "commenter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("commenter", value);
        }
    }

    public ApiEnum<string, CommenterType>? CommenterType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CommenterType>>(
                "commenter_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("commenter_type", value);
        }
    }

    /// <summary>
    /// An ISO 8901 datetime string denoting when the comment was created.
    /// </summary>
    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// An ISO 8901 datetime string for when the comment was read.
    /// </summary>
    public DateTimeOffset? ReadAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "read_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("read_at", value);
        }
    }

    /// <summary>
    /// An ISO 8901 datetime string for when the comment was updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    public static implicit operator Comment (
        CommentMarkAsReadResponseData commentMarkAsReadResponseData
    )=> new() {
        ID = commentMarkAsReadResponseData.ID,
        Body = commentMarkAsReadResponseData.Body,
        CommentRecordID = commentMarkAsReadResponseData.CommentRecordID,
        CommentRecordType = commentMarkAsReadResponseData.CommentRecordType,
        Commenter = commentMarkAsReadResponseData.Commenter,
        CommenterType = commentMarkAsReadResponseData.CommenterType,
        CreatedAt = commentMarkAsReadResponseData.CreatedAt,
        ReadAt = commentMarkAsReadResponseData.ReadAt,
        UpdatedAt = commentMarkAsReadResponseData.UpdatedAt
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Body;
        _ = this.CommentRecordID;
        this.CommentRecordType?.Validate();
        _ = this.Commenter;
        this.CommenterType?.Validate();
        _ = this.CreatedAt;
        _ = this.ReadAt;
        _ = this.UpdatedAt;
    }

    public CommentMarkAsReadResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommentMarkAsReadResponseData (
        CommentMarkAsReadResponseData commentMarkAsReadResponseData
    ) : base(commentMarkAsReadResponseData)
    {  }
    #pragma warning restore CS8618

    public CommentMarkAsReadResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CommentMarkAsReadResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CommentMarkAsReadResponseDataFromRaw.FromRawUnchecked"/>
    public static CommentMarkAsReadResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CommentMarkAsReadResponseDataFromRaw : IFromRawJson<CommentMarkAsReadResponseData>
{
    /// <inheritdoc/>
    public CommentMarkAsReadResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CommentMarkAsReadResponseData.FromRawUnchecked(rawData);
}