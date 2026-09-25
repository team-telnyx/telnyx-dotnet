using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Portouts.Events;

[JsonConverter(typeof(JsonModelConverter<WebhookPortoutNewComment, WebhookPortoutNewCommentFromRaw>))]
public sealed record class WebhookPortoutNewComment : JsonModel
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
    public IReadOnlyList<ApiEnum<string, WebhookPortoutNewCommentAvailableNotificationMethod>>? AvailableNotificationMethods {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, WebhookPortoutNewCommentAvailableNotificationMethod>>>(
                "available_notification_methods"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookPortoutNewCommentAvailableNotificationMethod>>?>(
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
    public ApiEnum<string, WebhookPortoutNewCommentEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookPortoutNewCommentEventType>>(
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
    /// The webhook payload for the portout.new_comment event
    /// </summary>
    public WebhookPortoutNewCommentPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookPortoutNewCommentPayload>(
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
    public ApiEnum<string, WebhookPortoutNewCommentPayloadStatus>? PayloadStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookPortoutNewCommentPayloadStatus>>(
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
    /// Identifies the port-out order associated with the event.
    /// </summary>
    public string? PortoutID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "portout_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("portout_id", value);
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
        _ = this.PortoutID;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public WebhookPortoutNewComment ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookPortoutNewComment (
        WebhookPortoutNewComment webhookPortoutNewComment
    ) : base(webhookPortoutNewComment)
    {  }
    #pragma warning restore CS8618

    public WebhookPortoutNewComment (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookPortoutNewComment (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookPortoutNewCommentFromRaw.FromRawUnchecked"/>
    public static WebhookPortoutNewComment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookPortoutNewCommentFromRaw : IFromRawJson<WebhookPortoutNewComment>
{
    /// <inheritdoc/>
    public WebhookPortoutNewComment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookPortoutNewComment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WebhookPortoutNewCommentAvailableNotificationMethodConverter))]
public enum WebhookPortoutNewCommentAvailableNotificationMethod
{
    Email, Webhook
}sealed class WebhookPortoutNewCommentAvailableNotificationMethodConverter : JsonConverter<WebhookPortoutNewCommentAvailableNotificationMethod>
{
    public override WebhookPortoutNewCommentAvailableNotificationMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email"=>WebhookPortoutNewCommentAvailableNotificationMethod.Email,
            "webhook"=>WebhookPortoutNewCommentAvailableNotificationMethod.Webhook,
            _ =>(WebhookPortoutNewCommentAvailableNotificationMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookPortoutNewCommentAvailableNotificationMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookPortoutNewCommentAvailableNotificationMethod.Email=>"email",
            WebhookPortoutNewCommentAvailableNotificationMethod.Webhook=>"webhook",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Identifies the event type
/// </summary>
[JsonConverter(typeof(WebhookPortoutNewCommentEventTypeConverter))]
public enum WebhookPortoutNewCommentEventType
{
    PortoutStatusChanged, PortoutFocDateChanged, PortoutNewComment
}sealed class WebhookPortoutNewCommentEventTypeConverter : JsonConverter<WebhookPortoutNewCommentEventType>
{
    public override WebhookPortoutNewCommentEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "portout.status_changed"=>WebhookPortoutNewCommentEventType.PortoutStatusChanged,
            "portout.foc_date_changed"=>WebhookPortoutNewCommentEventType.PortoutFocDateChanged,
            "portout.new_comment"=>WebhookPortoutNewCommentEventType.PortoutNewComment,
            _ =>(WebhookPortoutNewCommentEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookPortoutNewCommentEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookPortoutNewCommentEventType.PortoutStatusChanged=>"portout.status_changed",
            WebhookPortoutNewCommentEventType.PortoutFocDateChanged=>"portout.foc_date_changed",
            WebhookPortoutNewCommentEventType.PortoutNewComment=>"portout.new_comment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The webhook payload for the portout.new_comment event
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookPortoutNewCommentPayload, WebhookPortoutNewCommentPayloadFromRaw>))]
public sealed record class WebhookPortoutNewCommentPayload : JsonModel
{
    /// <summary>
    /// Identifies the comment that was added to the port-out order.
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
    public string? Comment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Identifies the port-out order that the comment was added to.
    /// </summary>
    public string? PortoutID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "portout_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("portout_id", value);
        }
    }

    /// <summary>
    /// Identifies the user that added the comment.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Comment;
        _ = this.PortoutID;
        _ = this.UserID;
    }

    public WebhookPortoutNewCommentPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookPortoutNewCommentPayload (
        WebhookPortoutNewCommentPayload webhookPortoutNewCommentPayload
    ) : base(webhookPortoutNewCommentPayload)
    {  }
    #pragma warning restore CS8618

    public WebhookPortoutNewCommentPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookPortoutNewCommentPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookPortoutNewCommentPayloadFromRaw.FromRawUnchecked"/>
    public static WebhookPortoutNewCommentPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookPortoutNewCommentPayloadFromRaw : IFromRawJson<WebhookPortoutNewCommentPayload>
{
    /// <inheritdoc/>
    public WebhookPortoutNewCommentPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookPortoutNewCommentPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The status of the payload generation.
/// </summary>
[JsonConverter(typeof(WebhookPortoutNewCommentPayloadStatusConverter))]
public enum WebhookPortoutNewCommentPayloadStatus
{
    Created, Completed
}sealed class WebhookPortoutNewCommentPayloadStatusConverter : JsonConverter<WebhookPortoutNewCommentPayloadStatus>
{
    public override WebhookPortoutNewCommentPayloadStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>WebhookPortoutNewCommentPayloadStatus.Created,
            "completed"=>WebhookPortoutNewCommentPayloadStatus.Completed,
            _ =>(WebhookPortoutNewCommentPayloadStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookPortoutNewCommentPayloadStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookPortoutNewCommentPayloadStatus.Created=>"created",
            WebhookPortoutNewCommentPayloadStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}