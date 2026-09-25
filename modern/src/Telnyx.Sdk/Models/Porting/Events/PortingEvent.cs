using System = System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Porting.Events;

[JsonConverter(typeof(PortingEventConverter))]
public record class PortingEvent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string? ID {
        get {
            return Match<string?>(deletedPayload: ( x )=>x.ID,
            messagingChangedPayload: ( x )=>x.ID,
            statusChanged: ( x )=>x.ID,
            newComment: ( x )=>x.ID,
            split: ( x )=>x.ID,
            withoutWebhook: ( x )=>x.ID);
        }
    }

    public string? PortingOrderID {
        get {
            return Match<string?>(deletedPayload: ( x )=>x.PortingOrderID,
            messagingChangedPayload: ( x )=>x.PortingOrderID,
            statusChanged: ( x )=>x.PortingOrderID,
            newComment: ( x )=>x.PortingOrderID,
            split: ( x )=>x.PortingOrderID,
            withoutWebhook: ( x )=>x.PortingOrderID);
        }
    }

    public System::DateTimeOffset? CreatedAt {
        get {
            return Match<System::DateTimeOffset?>(deletedPayload: ( _ )=>null,
            messagingChangedPayload: ( x )=>x.CreatedAt,
            statusChanged: ( x )=>x.CreatedAt,
            newComment: ( x )=>x.CreatedAt,
            split: ( x )=>x.CreatedAt,
            withoutWebhook: ( x )=>x.CreatedAt);
        }
    }

    public string? RecordType {
        get {
            return Match<string?>(deletedPayload: ( _ )=>null,
            messagingChangedPayload: ( x )=>x.RecordType,
            statusChanged: ( x )=>x.RecordType,
            newComment: ( x )=>x.RecordType,
            split: ( x )=>x.RecordType,
            withoutWebhook: ( x )=>x.RecordType);
        }
    }

    public System::DateTimeOffset? UpdatedAt {
        get {
            return Match<System::DateTimeOffset?>(deletedPayload: ( _ )=>null,
            messagingChangedPayload: ( x )=>x.UpdatedAt,
            statusChanged: ( x )=>x.UpdatedAt,
            newComment: ( x )=>x.UpdatedAt,
            split: ( x )=>x.UpdatedAt,
            withoutWebhook: ( x )=>x.UpdatedAt);
        }
    }

    public PortingEvent (
        PortingEventDeletedPayload value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PortingEvent (
        PortingEventMessagingChangedPayload value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PortingEvent (
        PortingEventStatusChangedEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PortingEvent (
        PortingEventNewCommentEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PortingEvent (
        PortingEventSplitEvent value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PortingEvent (
        PortingEventWithoutWebhook value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PortingEvent (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PortingEventDeletedPayload"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDeletedPayload(out var value)) {
///     // `value` is of type `PortingEventDeletedPayload`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDeletedPayload(
        [NotNullWhen(true)] out PortingEventDeletedPayload? value
    )
    {
        value =this.Value as PortingEventDeletedPayload ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PortingEventMessagingChangedPayload"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMessagingChangedPayload(out var value)) {
///     // `value` is of type `PortingEventMessagingChangedPayload`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMessagingChangedPayload(
        [NotNullWhen(true)] out PortingEventMessagingChangedPayload? value
    )
    {
        value =this.Value as PortingEventMessagingChangedPayload ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PortingEventStatusChangedEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickStatusChanged(out var value)) {
///     // `value` is of type `PortingEventStatusChangedEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickStatusChanged(
        [NotNullWhen(true)] out PortingEventStatusChangedEvent? value
    )
    {
        value =this.Value as PortingEventStatusChangedEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PortingEventNewCommentEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickNewComment(out var value)) {
///     // `value` is of type `PortingEventNewCommentEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickNewComment(
        [NotNullWhen(true)] out PortingEventNewCommentEvent? value
    )
    {
        value =this.Value as PortingEventNewCommentEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PortingEventSplitEvent"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSplit(out var value)) {
///     // `value` is of type `PortingEventSplitEvent`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSplit(
        [NotNullWhen(true)] out PortingEventSplitEvent? value
    )
    {
        value =this.Value as PortingEventSplitEvent ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PortingEventWithoutWebhook"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWithoutWebhook(out var value)) {
///     // `value` is of type `PortingEventWithoutWebhook`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWithoutWebhook(
        [NotNullWhen(true)] out PortingEventWithoutWebhook? value
    )
    {
        value =this.Value as PortingEventWithoutWebhook ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (PortingEventDeletedPayload value) =&gt; {...},
///     (PortingEventMessagingChangedPayload value) =&gt; {...},
///     (PortingEventStatusChangedEvent value) =&gt; {...},
///     (PortingEventNewCommentEvent value) =&gt; {...},
///     (PortingEventSplitEvent value) =&gt; {...},
///     (PortingEventWithoutWebhook value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<PortingEventDeletedPayload> deletedPayload,
        System::Action<PortingEventMessagingChangedPayload> messagingChangedPayload,
        System::Action<PortingEventStatusChangedEvent> statusChanged,
        System::Action<PortingEventNewCommentEvent> newComment,
        System::Action<PortingEventSplitEvent> split,
        System::Action<PortingEventWithoutWebhook> withoutWebhook
    )
    {
        switch (this.Value)
        {
            case PortingEventDeletedPayload value:
                deletedPayload(value);
                break;
            case PortingEventMessagingChangedPayload value:
                messagingChangedPayload(value);
                break;
            case PortingEventStatusChangedEvent value:
                statusChanged(value);
                break;
            case PortingEventNewCommentEvent value:
                newComment(value);
                break;
            case PortingEventSplitEvent value:
                split(value);
                break;
            case PortingEventWithoutWebhook value:
                withoutWebhook(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of PortingEvent");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (PortingEventDeletedPayload value) =&gt; {...},
///     (PortingEventMessagingChangedPayload value) =&gt; {...},
///     (PortingEventStatusChangedEvent value) =&gt; {...},
///     (PortingEventNewCommentEvent value) =&gt; {...},
///     (PortingEventSplitEvent value) =&gt; {...},
///     (PortingEventWithoutWebhook value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<PortingEventDeletedPayload, T> deletedPayload,
        System::Func<PortingEventMessagingChangedPayload, T> messagingChangedPayload,
        System::Func<PortingEventStatusChangedEvent, T> statusChanged,
        System::Func<PortingEventNewCommentEvent, T> newComment,
        System::Func<PortingEventSplitEvent, T> split,
        System::Func<PortingEventWithoutWebhook, T> withoutWebhook
    )
    {
        return this.Value switch
        {
            PortingEventDeletedPayload value=>deletedPayload(value),
            PortingEventMessagingChangedPayload value=>messagingChangedPayload(value),
            PortingEventStatusChangedEvent value=>statusChanged(value),
            PortingEventNewCommentEvent value=>newComment(value),
            PortingEventSplitEvent value=>split(value),
            PortingEventWithoutWebhook value=>withoutWebhook(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of PortingEvent")
        } ;
    }

    public static implicit operator PortingEvent (
        PortingEventDeletedPayload value
    )=> new(value) ;

    public static implicit operator PortingEvent (
        PortingEventMessagingChangedPayload value
    )=> new(value) ;

    public static implicit operator PortingEvent (
        PortingEventStatusChangedEvent value
    )=> new(value) ;

    public static implicit operator PortingEvent (
        PortingEventNewCommentEvent value
    )=> new(value) ;

    public static implicit operator PortingEvent (
        PortingEventSplitEvent value
    )=> new(value) ;

    public static implicit operator PortingEvent (
        PortingEventWithoutWebhook value
    )=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of PortingEvent");
        }
        this.Switch((deletedPayload) => deletedPayload.Validate(),
        (messagingChangedPayload) => messagingChangedPayload.Validate(),
        (statusChanged) => statusChanged.Validate(),
        (newComment) => newComment.Validate(),
        (split) => split.Validate(),
        (withoutWebhook) => withoutWebhook.Validate());
    }

    public virtual bool Equals(PortingEvent? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            PortingEventDeletedPayload _=>0,
            PortingEventMessagingChangedPayload _=>1,
            PortingEventStatusChangedEvent _=>2,
            PortingEventNewCommentEvent _=>3,
            PortingEventSplitEvent _=>4,
            PortingEventWithoutWebhook _=>5,
            _ =>-1
        } ;
    }
}

sealed class PortingEventConverter : JsonConverter<PortingEvent>
{
    public override PortingEvent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? eventType;
        try {
            eventType = element.GetProperty("event_type").GetString();
        } catch {
            eventType = null;
        }

        switch (eventType)
        {
            case "porting_order.deleted":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PortingEventDeletedPayload>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "porting_order.messaging_changed":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PortingEventMessagingChangedPayload>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "porting_order.status_changed":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PortingEventStatusChangedEvent>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "porting_order.new_comment":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PortingEventNewCommentEvent>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "porting_order.split":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PortingEventSplitEvent>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                {
                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<PortingEventWithoutWebhook>(element, options);
                        if (deserialized != null) {

                            return new(deserialized, element);
                        }
                    }
                    catch (JsonException )
                    {
                        // ignore
                    }

                    return new(element);
                }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, PortingEvent value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}