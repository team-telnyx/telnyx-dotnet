using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.WebhookDeliveries;

/// <summary>
/// Record of all attempts to deliver a webhook.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookDelivery, WebhookDeliveryFromRaw>))]
public sealed record class WebhookDelivery : JsonModel
{
    /// <summary>
    /// Uniquely identifies the webhook_delivery record.
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
    /// Detailed delivery attempts, ordered by most recent.
    /// </summary>
    public IReadOnlyList<Attempt>? Attempts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Attempt>>(
                "attempts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Attempt>?>(
                "attempts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 timestamp indicating when the last webhook response has been received.
    /// </summary>
    public System::DateTimeOffset? FinishedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "finished_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("finished_at", value);
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
    /// ISO 8601 timestamp indicating when the first request attempt was initiated.
    /// </summary>
    public System::DateTimeOffset? StartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "started_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("started_at", value);
        }
    }

    /// <summary>
    /// Delivery status: 'delivered' when successfuly delivered or 'failed' if all
    /// attempts have failed.
    /// </summary>
    public ApiEnum<string, WebhookDeliveryStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookDeliveryStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Uniquely identifies the user that owns the webhook_delivery record.
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
    /// Original webhook JSON data. Payload fields vary according to event type.
    /// </summary>
    public WebhookDeliveryWebhook? Webhook {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookDeliveryWebhook>(
                "webhook"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Attempts ?? [])
        {
            item.Validate();
        }
        _ = this.FinishedAt;
        _ = this.RecordType;
        _ = this.StartedAt;
        this.Status?.Validate();
        _ = this.UserID;
        this.Webhook?.Validate();
    }

    public WebhookDelivery ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookDelivery (WebhookDelivery webhookDelivery) : base(
        webhookDelivery
    )
    {  }
    #pragma warning restore CS8618

    public WebhookDelivery (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookDelivery (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookDeliveryFromRaw.FromRawUnchecked"/>
    public static WebhookDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WebhookDeliveryFromRaw : IFromRawJson<WebhookDelivery>
{
    /// <inheritdoc/>
    public WebhookDelivery FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookDelivery.FromRawUnchecked(rawData);
}

/// <summary>
/// Delivery status: 'delivered' when successfuly delivered or 'failed' if all attempts
/// have failed.
/// </summary>
[JsonConverter(typeof(WebhookDeliveryStatusConverter))]
public enum WebhookDeliveryStatus
{
    Delivered, Failed
}sealed class WebhookDeliveryStatusConverter : JsonConverter<WebhookDeliveryStatus>
{
    public override WebhookDeliveryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delivered"=>WebhookDeliveryStatus.Delivered,
            "failed"=>WebhookDeliveryStatus.Failed,
            _ =>(WebhookDeliveryStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookDeliveryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebhookDeliveryStatus.Delivered=>"delivered",
            WebhookDeliveryStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Original webhook JSON data. Payload fields vary according to event type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookDeliveryWebhook, WebhookDeliveryWebhookFromRaw>))]
public sealed record class WebhookDeliveryWebhook : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
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
    /// The type of event being delivered.
    /// </summary>
    public string? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// ISO 8601 datetime of when the event occurred.
    /// </summary>
    public System::DateTimeOffset? OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "payload",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.EventType;
        _ = this.OccurredAt;
        _ = this.Payload;
        this.RecordType?.Validate();
    }

    public WebhookDeliveryWebhook ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookDeliveryWebhook (
        WebhookDeliveryWebhook webhookDeliveryWebhook
    ) : base(webhookDeliveryWebhook)
    {  }
    #pragma warning restore CS8618

    public WebhookDeliveryWebhook (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookDeliveryWebhook (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookDeliveryWebhookFromRaw.FromRawUnchecked"/>
    public static WebhookDeliveryWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookDeliveryWebhookFromRaw : IFromRawJson<WebhookDeliveryWebhook>
{
    /// <inheritdoc/>
    public WebhookDeliveryWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookDeliveryWebhook.FromRawUnchecked(rawData);
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Event
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "event"=>RecordType.Event, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}