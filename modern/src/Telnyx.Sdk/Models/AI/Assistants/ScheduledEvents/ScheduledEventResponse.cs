using System = System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

/// <summary>
/// Union type for different scheduled event response types
/// </summary>
[JsonConverter(typeof(ScheduledEventResponseConverter))]
public record class ScheduledEventResponse : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string AssistantID {
        get {
            return Match(phoneCall: ( x )=>x.AssistantID,
            sms: ( x )=>x.AssistantID);
        }
    }

    public System::DateTimeOffset ScheduledAtFixedDatetime {
        get {
            return Match(phoneCall: ( x )=>x.ScheduledAtFixedDatetime,
            sms: ( x )=>x.ScheduledAtFixedDatetime);
        }
    }

    public string TelnyxAgentTarget {
        get {
            return Match(phoneCall: ( x )=>x.TelnyxAgentTarget,
            sms: ( x )=>x.TelnyxAgentTarget);
        }
    }

    public ApiEnum<string, ConversationChannelType> TelnyxConversationChannel {
        get {
            return Match(phoneCall: ( x )=>x.TelnyxConversationChannel,
            sms: ( x )=>x.TelnyxConversationChannel);
        }
    }

    public string TelnyxEndUserTarget {
        get {
            return Match(phoneCall: ( x )=>x.TelnyxEndUserTarget,
            sms: ( x )=>x.TelnyxEndUserTarget);
        }
    }

    public string? ConversationID {
        get {
            return Match<string?>(phoneCall: ( x )=>x.ConversationID,
            sms: ( x )=>x.ConversationID);
        }
    }

    public System::DateTimeOffset? CreatedAt {
        get {
            return Match<System::DateTimeOffset?>(phoneCall: ( x )=>x.CreatedAt,
            sms: ( x )=>x.CreatedAt);
        }
    }

    public long? RetryCount {
        get {
            return Match<long?>(phoneCall: ( x )=>x.RetryCount,
            sms: ( x )=>x.RetryCount);
        }
    }

    public string? ScheduledEventID {
        get {
            return Match<string?>(phoneCall: ( x )=>x.ScheduledEventID,
            sms: ( x )=>x.ScheduledEventID);
        }
    }

    public ApiEnum<string, EventStatus>? Status {
        get {
            return Match<ApiEnum<string, EventStatus>?>(phoneCall: ( x )=>x.Status,
            sms: ( x )=>x.Status);
        }
    }

    public ScheduledEventResponse (
        ScheduledPhoneCallEventResponse value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ScheduledEventResponse (
        ScheduledSmsEventResponse value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ScheduledEventResponse (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ScheduledPhoneCallEventResponse"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPhoneCall(out var value)) {
///     // `value` is of type `ScheduledPhoneCallEventResponse`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPhoneCall(
        [NotNullWhen(true)] out ScheduledPhoneCallEventResponse? value
    )
    {
        value =this.Value as ScheduledPhoneCallEventResponse ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ScheduledSmsEventResponse"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSms(out var value)) {
///     // `value` is of type `ScheduledSmsEventResponse`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSms(
        [NotNullWhen(true)] out ScheduledSmsEventResponse? value
    )
    {
        value =this.Value as ScheduledSmsEventResponse ;
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
///     (ScheduledPhoneCallEventResponse value) =&gt; {...},
///     (ScheduledSmsEventResponse value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ScheduledPhoneCallEventResponse> phoneCall,
        System::Action<ScheduledSmsEventResponse> sms
    )
    {
        switch (this.Value)
        {
            case ScheduledPhoneCallEventResponse value:
                phoneCall(value);
                break;
            case ScheduledSmsEventResponse value:
                sms(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ScheduledEventResponse");

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
///     (ScheduledPhoneCallEventResponse value) =&gt; {...},
///     (ScheduledSmsEventResponse value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ScheduledPhoneCallEventResponse, T> phoneCall,
        System::Func<ScheduledSmsEventResponse, T> sms
    )
    {
        return this.Value switch
        {
            ScheduledPhoneCallEventResponse value=>phoneCall(value),
            ScheduledSmsEventResponse value=>sms(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ScheduledEventResponse")
        } ;
    }

    public static implicit operator ScheduledEventResponse (
        ScheduledPhoneCallEventResponse value
    )=> new(value) ;

    public static implicit operator ScheduledEventResponse (
        ScheduledSmsEventResponse value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ScheduledEventResponse");
        }
        this.Switch((phoneCall) => phoneCall.Validate(),
        (sms) => sms.Validate());
    }

    public virtual bool Equals(ScheduledEventResponse? other)
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
            ScheduledPhoneCallEventResponse _=>0,
            ScheduledSmsEventResponse _=>1,
            _ =>-1
        } ;
    }
}

sealed class ScheduledEventResponseConverter : JsonConverter<ScheduledEventResponse>
{
    public override ScheduledEventResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? telnyxConversationChannel;
        try {
            telnyxConversationChannel = element.GetProperty("telnyx_conversation_channel").GetString();
        } catch {
            telnyxConversationChannel = null;
        }

        switch (telnyxConversationChannel)
        {
            default:
                {
                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<ScheduledSmsEventResponse>(element, options);
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
                        var deserialized = JsonSerializer.Deserialize<ScheduledPhoneCallEventResponse>(element, options);
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
        Utf8JsonWriter writer,
        ScheduledEventResponse value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}