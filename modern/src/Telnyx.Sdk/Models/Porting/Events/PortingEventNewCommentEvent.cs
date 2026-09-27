using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Porting.Events;

[JsonConverter(typeof(JsonModelConverter<PortingEventNewCommentEvent, PortingEventNewCommentEventFromRaw>))]
public sealed record class PortingEventNewCommentEvent : JsonModel
{
    /// <summary>
    /// Uniquely identifies the event.
    /// </summary>
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
    /// Indicates the notification methods used.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, PortingEventNewCommentEventAvailableNotificationMethod>>? AvailableNotificationMethods {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, PortingEventNewCommentEventAvailableNotificationMethod>>>(
                "available_notification_methods"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, PortingEventNewCommentEventAvailableNotificationMethod>>?>(
                "available_notification_methods",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    /// <summary>
    /// Identifies the event type
    /// </summary>
    public ApiEnum<string, PortingEventNewCommentEventEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventNewCommentEventEventType>>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    /// <summary>
    /// The webhook payload for the porting_order.new_comment event
    /// </summary>
    public PortingEventNewCommentEventPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingEventNewCommentEventPayload>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload", value);
        }
    }

    /// <summary>
    /// The status of the payload generation.
    /// </summary>
    public ApiEnum<string, PortingEventNewCommentEventPayloadStatus>? PayloadStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingEventNewCommentEventPayloadStatus>>(
                "payload_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload_status", value);
        }
    }

    /// <summary>
    /// Identifies the porting order associated with the event.
    /// </summary>
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
    /// ISO 8601 formatted date indicating when the resource was updated.
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
        foreach (var item in this.AvailableNotificationMethods ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        this.EventType?.Validate();
        this.Payload?.Validate();
        this.PayloadStatus?.Validate();
        _ = this.PortingOrderID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public PortingEventNewCommentEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventNewCommentEvent (
        PortingEventNewCommentEvent portingEventNewCommentEvent
    ) : base(portingEventNewCommentEvent)
    {  }
    #pragma warning restore CS8618

    public PortingEventNewCommentEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventNewCommentEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventNewCommentEventFromRaw.FromRawUnchecked"/>
    public static PortingEventNewCommentEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingEventNewCommentEventFromRaw : IFromRawJson<PortingEventNewCommentEvent>
{
    /// <inheritdoc/>
    public PortingEventNewCommentEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventNewCommentEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PortingEventNewCommentEventAvailableNotificationMethodConverter))]
public enum PortingEventNewCommentEventAvailableNotificationMethod
{
    Email, Webhook, WebhookV1
}sealed class PortingEventNewCommentEventAvailableNotificationMethodConverter : JsonConverter<PortingEventNewCommentEventAvailableNotificationMethod>
{
    public override PortingEventNewCommentEventAvailableNotificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email"=>PortingEventNewCommentEventAvailableNotificationMethod.Email,
            "webhook"=>PortingEventNewCommentEventAvailableNotificationMethod.Webhook,
            "webhook_v1"=>PortingEventNewCommentEventAvailableNotificationMethod.WebhookV1,
            _ =>(PortingEventNewCommentEventAvailableNotificationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventNewCommentEventAvailableNotificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventNewCommentEventAvailableNotificationMethod.Email=>"email",
            PortingEventNewCommentEventAvailableNotificationMethod.Webhook=>"webhook",
            PortingEventNewCommentEventAvailableNotificationMethod.WebhookV1=>"webhook_v1",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the event type
/// </summary>
[JsonConverter(typeof(PortingEventNewCommentEventEventTypeConverter))]
public enum PortingEventNewCommentEventEventType
{
    PortingOrderNewComment
}sealed class PortingEventNewCommentEventEventTypeConverter : JsonConverter<PortingEventNewCommentEventEventType>
{
    public override PortingEventNewCommentEventEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "porting_order.new_comment"=>PortingEventNewCommentEventEventType.PortingOrderNewComment,
            _ =>(PortingEventNewCommentEventEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventNewCommentEventEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventNewCommentEventEventType.PortingOrderNewComment=>"porting_order.new_comment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The webhook payload for the porting_order.new_comment event
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingEventNewCommentEventPayload, PortingEventNewCommentEventPayloadFromRaw>))]
public sealed record class PortingEventNewCommentEventPayload : JsonModel
{
    /// <summary>
    /// The comment that was added to the porting order.
    /// </summary>
    public Comment? Comment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Comment>(
                "comment"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("comment", value);
        }
    }

    /// <summary>
    /// Identifies the porting order that the comment was added to.
    /// </summary>
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
    /// Identifies the support key associated with the porting order.
    /// </summary>
    public string? SupportKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "support_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("support_key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Comment?.Validate();
        _ = this.PortingOrderID;
        _ = this.SupportKey;
    }

    public PortingEventNewCommentEventPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingEventNewCommentEventPayload (
        PortingEventNewCommentEventPayload portingEventNewCommentEventPayload
    ) : base(portingEventNewCommentEventPayload)
    {  }
    #pragma warning restore CS8618

    public PortingEventNewCommentEventPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingEventNewCommentEventPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingEventNewCommentEventPayloadFromRaw.FromRawUnchecked"/>
    public static PortingEventNewCommentEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingEventNewCommentEventPayloadFromRaw : IFromRawJson<PortingEventNewCommentEventPayload>
{
    /// <inheritdoc/>
    public PortingEventNewCommentEventPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingEventNewCommentEventPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The comment that was added to the porting order.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Comment, CommentFromRaw>))]
public sealed record class Comment : JsonModel
{
    /// <summary>
    /// Identifies the comment.
    /// </summary>
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
    /// The body of the comment.
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
    /// ISO 8601 formatted date indicating when the comment was created.
    /// </summary>
    public System::DateTimeOffset? InsertedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "inserted_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inserted_at", value);
        }
    }

    /// <summary>
    /// Identifies the user that create the comment.
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the user that created the comment.
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
        _ = this.InsertedAt;
        _ = this.UserID;
        this.UserType?.Validate();
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
}class CommentFromRaw : IFromRawJson<Comment>
{
    /// <inheritdoc/>
    public Comment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Comment.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the user that created the comment.
/// </summary>
[JsonConverter(typeof(UserTypeConverter))]
public enum UserType
{
    User, Admin, System
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
            "user"=>UserType.User,
            "admin"=>UserType.Admin,
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
            UserType.User=>"user",
            UserType.Admin=>"admin",
            UserType.System=>"system",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of the payload generation.
/// </summary>
[JsonConverter(typeof(PortingEventNewCommentEventPayloadStatusConverter))]
public enum PortingEventNewCommentEventPayloadStatus
{
    Created, Completed
}sealed class PortingEventNewCommentEventPayloadStatusConverter : JsonConverter<PortingEventNewCommentEventPayloadStatus>
{
    public override PortingEventNewCommentEventPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>PortingEventNewCommentEventPayloadStatus.Created,
            "completed"=>PortingEventNewCommentEventPayloadStatus.Completed,
            _ =>(PortingEventNewCommentEventPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingEventNewCommentEventPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingEventNewCommentEventPayloadStatus.Created=>"created",
            PortingEventNewCommentEventPayloadStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}