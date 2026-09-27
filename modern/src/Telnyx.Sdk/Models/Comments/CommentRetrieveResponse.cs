using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Comments;

[JsonConverter(typeof(JsonModelConverter<CommentRetrieveResponse, CommentRetrieveResponseFromRaw>))]
public sealed record class CommentRetrieveResponse : JsonModel
{
    public CommentRetrieveResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommentRetrieveResponseData>(
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

    public CommentRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommentRetrieveResponse (
        CommentRetrieveResponse commentRetrieveResponse
    ) : base(commentRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public CommentRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CommentRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CommentRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CommentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CommentRetrieveResponseFromRaw : IFromRawJson<CommentRetrieveResponse>
{
    /// <inheritdoc/>
    public CommentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CommentRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CommentRetrieveResponseData, CommentRetrieveResponseDataFromRaw>))]
public sealed record class CommentRetrieveResponseData : JsonModel
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
        CommentRetrieveResponseData commentRetrieveResponseData
    )=> new() {
        ID = commentRetrieveResponseData.ID,
        Body = commentRetrieveResponseData.Body,
        CommentRecordID = commentRetrieveResponseData.CommentRecordID,
        CommentRecordType = commentRetrieveResponseData.CommentRecordType,
        Commenter = commentRetrieveResponseData.Commenter,
        CommenterType = commentRetrieveResponseData.CommenterType,
        CreatedAt = commentRetrieveResponseData.CreatedAt,
        ReadAt = commentRetrieveResponseData.ReadAt,
        UpdatedAt = commentRetrieveResponseData.UpdatedAt
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

    public CommentRetrieveResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommentRetrieveResponseData (
        CommentRetrieveResponseData commentRetrieveResponseData
    ) : base(commentRetrieveResponseData)
    {  }
    #pragma warning restore CS8618

    public CommentRetrieveResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CommentRetrieveResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CommentRetrieveResponseDataFromRaw.FromRawUnchecked"/>
    public static CommentRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CommentRetrieveResponseDataFromRaw : IFromRawJson<CommentRetrieveResponseData>
{
    /// <inheritdoc/>
    public CommentRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CommentRetrieveResponseData.FromRawUnchecked(rawData);
}