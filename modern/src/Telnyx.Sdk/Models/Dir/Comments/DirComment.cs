using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir.Comments;

[JsonConverter(typeof(JsonModelConverter<DirComment, DirCommentFromRaw>))]
public sealed record class DirComment : JsonModel
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

    /// <summary>
    /// Display name of the author. May be `null`.
    /// </summary>
    public string? AuthorName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "author_name"
            );
        }
        init { this._rawData.Set("author_name", value); }
    }

    /// <summary>
    /// Who wrote the comment. `admin` covers the Telnyx vetting team.
    /// </summary>
    public ApiEnum<string, AuthorRole>? AuthorRole {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AuthorRole>>(
                "author_role"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("author_role", value);
        }
    }

    /// <summary>
    /// Comment categorisation. Customers post `customer_inquiry`. The Telnyx team
    /// posts `vetting_comment`, `rejection_reason`, `notification`, `status_update`,
    /// or `admin_response`. `internal_note` is filtered out of customer-visible responses.
    /// </summary>
    public ApiEnum<string, CommentType>? CommentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CommentType>>(
                "comment_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("comment_type", value);
        }
    }

    public string? Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

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
    /// Resource the comment is attached to. Always `dir` on this endpoint.
    /// </summary>
    public ApiEnum<string, EntityType>? EntityType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EntityType>>(
                "entity_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("entity_type", value);
        }
    }

    /// <summary>
    /// Always `customer` on this endpoint - internal-only comments are filtered out.
    /// </summary>
    public ApiEnum<string, Visibility>? Visibility {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Visibility>>(
                "visibility"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("visibility", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AuthorName;
        this.AuthorRole?.Validate();
        this.CommentType?.Validate();
        _ = this.Content;
        _ = this.CreatedAt;
        this.EntityType?.Validate();
        this.Visibility?.Validate();
    }

    public DirComment ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirComment (DirComment dirComment) : base(dirComment)
    {  }
    #pragma warning restore CS8618

    public DirComment (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DirComment (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DirCommentFromRaw.FromRawUnchecked"/>
    public static DirComment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DirCommentFromRaw : IFromRawJson<DirComment>
{
    /// <inheritdoc/>
    public DirComment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DirComment.FromRawUnchecked(rawData);
}

/// <summary>
/// Who wrote the comment. `admin` covers the Telnyx vetting team.
/// </summary>
[JsonConverter(typeof(AuthorRoleConverter))]
public enum AuthorRole
{
    Customer, Admin
}sealed class AuthorRoleConverter : JsonConverter<AuthorRole>
{
    public override AuthorRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "customer"=>AuthorRole.Customer,
            "admin"=>AuthorRole.Admin,
            _ =>(AuthorRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, AuthorRole value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AuthorRole.Customer=>"customer",
            AuthorRole.Admin=>"admin",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Resource the comment is attached to. Always `dir` on this endpoint.
/// </summary>
[JsonConverter(typeof(EntityTypeConverter))]
public enum EntityType
{
    Dir
}sealed class EntityTypeConverter : JsonConverter<EntityType>
{
    public override EntityType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "dir"=>EntityType.Dir, _ =>(EntityType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, EntityType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EntityType.Dir=>"dir",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Always `customer` on this endpoint - internal-only comments are filtered out.
/// </summary>
[JsonConverter(typeof(VisibilityConverter))]
public enum Visibility
{
    Customer
}sealed class VisibilityConverter : JsonConverter<Visibility>
{
    public override Visibility Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "customer"=>Visibility.Customer, _ =>(Visibility)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Visibility value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Visibility.Customer=>"customer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}