using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.Comments;

[JsonConverter(typeof(JsonModelConverter<PortingOrdersComment, PortingOrdersCommentFromRaw>))]
public sealed record class PortingOrdersComment : JsonModel
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
    /// Body of comment
    /// </summary>
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

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
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

    public string? PortingOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "porting_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_order_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// Indicates whether this comment was created by a Telnyx Admin, user, or system
    /// </summary>
    public ApiEnum<string, UserType>? UserType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UserType>>(
                "user_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Body;
        _ = this.CreatedAt;
        _ = this.PortingOrderID;
        _ = this.RecordType;
        this.UserType?.Validate();
    }

    public PortingOrdersComment ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrdersComment (
        PortingOrdersComment portingOrdersComment
    ) : base(portingOrdersComment)
    {  }
    #pragma warning restore CS8618

    public PortingOrdersComment (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrdersComment (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrdersCommentFromRaw.FromRawUnchecked"/>
    public static PortingOrdersComment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrdersCommentFromRaw : IFromRawJson<PortingOrdersComment>
{
    /// <inheritdoc/>
    public PortingOrdersComment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrdersComment.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates whether this comment was created by a Telnyx Admin, user, or system
/// </summary>
[JsonConverter(typeof(UserTypeConverter))]
public enum UserType
{
    Admin, User, System
}sealed class UserTypeConverter : JsonConverter<UserType>
{
    public override UserType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "admin"=>UserType.Admin,
            "user"=>UserType.User,
            "system"=>UserType.System,
            _ =>(UserType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, UserType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UserType.Admin=>"admin",
            UserType.User=>"user",
            UserType.System=>"system",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}