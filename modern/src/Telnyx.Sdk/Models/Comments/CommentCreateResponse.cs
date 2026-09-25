using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Comments;

[JsonConverter(typeof(JsonModelConverter<CommentCreateResponse, CommentCreateResponseFromRaw>))]
public sealed record class CommentCreateResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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
}

class CommentCreateResponseFromRaw : IFromRawJson<CommentCreateResponse>
{
    /// <inheritdoc/>
    public CommentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CommentCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public static implicit operator Comment (Data data)=> new() {
        ID = data.ID,
        Body = data.Body,
        CommentRecordID = data.CommentRecordID,
        CommentRecordType = data.CommentRecordType,
        Commenter = data.Commenter,
        CommenterType = data.CommenterType,
        CreatedAt = data.CreatedAt,
        ReadAt = data.ReadAt,
        UpdatedAt = data.UpdatedAt
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

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}