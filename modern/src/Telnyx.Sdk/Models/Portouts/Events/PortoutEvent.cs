using System = System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Portouts.Events;

[JsonConverter(typeof(PortoutEventConverter))]
public record class PortoutEvent : ModelBase
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
            return Match<string?>(webhookPortoutStatusChanged: ( x )=>x.ID,
            webhookPortoutNewComment: ( x )=>x.ID,
            webhookPortoutFocDateChanged: ( x )=>x.ID);
        }
    }

    public System::DateTimeOffset? CreatedAt {
        get {
            return Match<System::DateTimeOffset?>(webhookPortoutStatusChanged: ( x )=>x.CreatedAt,
            webhookPortoutNewComment: ( x )=>x.CreatedAt,
            webhookPortoutFocDateChanged: ( x )=>x.CreatedAt);
        }
    }

    public string? PortoutID {
        get {
            return Match<string?>(webhookPortoutStatusChanged: ( x )=>x.PortoutID,
            webhookPortoutNewComment: ( x )=>x.PortoutID,
            webhookPortoutFocDateChanged: ( x )=>x.PortoutID);
        }
    }

    public string? RecordType {
        get {
            return Match<string?>(webhookPortoutStatusChanged: ( x )=>x.RecordType,
            webhookPortoutNewComment: ( x )=>x.RecordType,
            webhookPortoutFocDateChanged: ( x )=>x.RecordType);
        }
    }

    public System::DateTimeOffset? UpdatedAt {
        get {
            return Match<System::DateTimeOffset?>(webhookPortoutStatusChanged: ( x )=>x.UpdatedAt,
            webhookPortoutNewComment: ( x )=>x.UpdatedAt,
            webhookPortoutFocDateChanged: ( x )=>x.UpdatedAt);
        }
    }

    public PortoutEvent (
        WebhookPortoutStatusChanged value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PortoutEvent (
        WebhookPortoutNewComment value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PortoutEvent (
        WebhookPortoutFocDateChanged value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PortoutEvent (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WebhookPortoutStatusChanged"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWebhookPortoutStatusChanged(out var value)) {
///     // `value` is of type `WebhookPortoutStatusChanged`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWebhookPortoutStatusChanged(
        [NotNullWhen(true)] out WebhookPortoutStatusChanged? value
    )
    {
        value =this.Value as WebhookPortoutStatusChanged ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WebhookPortoutNewComment"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWebhookPortoutNewComment(out var value)) {
///     // `value` is of type `WebhookPortoutNewComment`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWebhookPortoutNewComment(
        [NotNullWhen(true)] out WebhookPortoutNewComment? value
    )
    {
        value =this.Value as WebhookPortoutNewComment ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WebhookPortoutFocDateChanged"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWebhookPortoutFocDateChanged(out var value)) {
///     // `value` is of type `WebhookPortoutFocDateChanged`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWebhookPortoutFocDateChanged(
        [NotNullWhen(true)] out WebhookPortoutFocDateChanged? value
    )
    {
        value =this.Value as WebhookPortoutFocDateChanged ;
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
///     (WebhookPortoutStatusChanged value) =&gt; {...},
///     (WebhookPortoutNewComment value) =&gt; {...},
///     (WebhookPortoutFocDateChanged value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<WebhookPortoutStatusChanged> webhookPortoutStatusChanged,
        System::Action<WebhookPortoutNewComment> webhookPortoutNewComment,
        System::Action<WebhookPortoutFocDateChanged> webhookPortoutFocDateChanged
    )
    {
        switch (this.Value)
        {
            case WebhookPortoutStatusChanged value:
                webhookPortoutStatusChanged(value);
                break;
            case WebhookPortoutNewComment value:
                webhookPortoutNewComment(value);
                break;
            case WebhookPortoutFocDateChanged value:
                webhookPortoutFocDateChanged(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of PortoutEvent");

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
///     (WebhookPortoutStatusChanged value) =&gt; {...},
///     (WebhookPortoutNewComment value) =&gt; {...},
///     (WebhookPortoutFocDateChanged value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<WebhookPortoutStatusChanged, T> webhookPortoutStatusChanged,
        System::Func<WebhookPortoutNewComment, T> webhookPortoutNewComment,
        System::Func<WebhookPortoutFocDateChanged, T> webhookPortoutFocDateChanged
    )
    {
        return this.Value switch
        {
            WebhookPortoutStatusChanged value=>webhookPortoutStatusChanged(value),
            WebhookPortoutNewComment value=>webhookPortoutNewComment(value),
            WebhookPortoutFocDateChanged value=>webhookPortoutFocDateChanged(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of PortoutEvent")
        } ;
    }

    public static implicit operator PortoutEvent (
        WebhookPortoutStatusChanged value
    )=> new(value) ;

    public static implicit operator PortoutEvent (
        WebhookPortoutNewComment value
    )=> new(value) ;

    public static implicit operator PortoutEvent (
        WebhookPortoutFocDateChanged value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of PortoutEvent");
        }
        this.Switch((webhookPortoutStatusChanged) => webhookPortoutStatusChanged.Validate(),
        (webhookPortoutNewComment) => webhookPortoutNewComment.Validate(),
        (webhookPortoutFocDateChanged) => webhookPortoutFocDateChanged.Validate());
    }

    public virtual bool Equals(PortoutEvent? other)
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
            WebhookPortoutStatusChanged _=>0,
            WebhookPortoutNewComment _=>1,
            WebhookPortoutFocDateChanged _=>2,
            _ =>-1
        } ;
    }
}

sealed class PortoutEventConverter : JsonConverter<PortoutEvent>
{
    public override PortoutEvent? Read(
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
            default:
                {
                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<WebhookPortoutStatusChanged>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<WebhookPortoutNewComment>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<WebhookPortoutFocDateChanged>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    return new(element);
                }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, PortoutEvent value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}