using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Comments;

[JsonConverter(typeof(JsonModelConverter<Comment, CommentFromRaw>))]
public sealed record class Comment : JsonModel
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
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    public System::DateTimeOffset? ReadAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    public Comment ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Comment (Comment comment) : base(comment)
    {  }
    #pragma warning restore CS8618

    public Comment (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Comment (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CommentFromRaw.FromRawUnchecked"/>
    public static Comment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CommentFromRaw : IFromRawJson<Comment>
{
    /// <inheritdoc/>
    public Comment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Comment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CommentCommentRecordTypeConverter))]
public enum CommentCommentRecordType
{
    SubNumberOrder, RequirementGroup
}sealed class CommentCommentRecordTypeConverter : JsonConverter<CommentCommentRecordType>
{
    public override CommentCommentRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sub_number_order"=>CommentCommentRecordType.SubNumberOrder,
            "requirement_group"=>CommentCommentRecordType.RequirementGroup,
            _ =>(CommentCommentRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CommentCommentRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CommentCommentRecordType.SubNumberOrder=>"sub_number_order",
            CommentCommentRecordType.RequirementGroup=>"requirement_group",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(CommenterTypeConverter))]
public enum CommenterType
{
    Admin, User
}sealed class CommenterTypeConverter : JsonConverter<CommenterType>
{
    public override CommenterType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "admin"=>CommenterType.Admin,
            "user"=>CommenterType.User,
            _ =>(CommenterType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CommenterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CommenterType.Admin=>"admin",
            CommenterType.User=>"user",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}