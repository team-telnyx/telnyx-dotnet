using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

[JsonConverter(typeof(JsonModelConverter<ScheduledSmsEventResponse, ScheduledSmsEventResponseFromRaw>))]
public sealed record class ScheduledSmsEventResponse : JsonModel
{
    public required string AssistantID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "assistant_id"
            );
        }
        init { this._rawData.Set("assistant_id", value); }
    }

    public required System::DateTimeOffset ScheduledAtFixedDatetime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "scheduled_at_fixed_datetime"
            );
        }
        init { this._rawData.Set("scheduled_at_fixed_datetime", value); }
    }

    public required string TelnyxAgentTarget {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "telnyx_agent_target"
            );
        }
        init { this._rawData.Set("telnyx_agent_target", value); }
    }

    public required ApiEnum<string, ConversationChannelType> TelnyxConversationChannel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ConversationChannelType>>(
                "telnyx_conversation_channel"
            );
        }
        init { this._rawData.Set("telnyx_conversation_channel", value); }
    }

    public required string TelnyxEndUserTarget {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "telnyx_end_user_target"
            );
        }
        init { this._rawData.Set("telnyx_end_user_target", value); }
    }

    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    public string? ConversationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conversation_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_id", value);
        }
    }

    public IReadOnlyDictionary<string, ScheduledSmsEventResponseConversationMetadata>? ConversationMetadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, ScheduledSmsEventResponseConversationMetadata>>(
                "conversation_metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, ScheduledSmsEventResponseConversationMetadata>?>(
                "conversation_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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
    /// A map of dynamic variable names to values. These variables can be referenced
    /// in the assistant's instructions and messages using {{variable_name}} syntax.
    /// </summary>
    public IReadOnlyDictionary<string, string>? DynamicVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "dynamic_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "dynamic_variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyList<string>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? RetryCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "retry_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("retry_count", value);
        }
    }

    public string? ScheduledEventID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "scheduled_event_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("scheduled_event_id", value);
        }
    }

    public ApiEnum<string, EventStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EventStatus>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AssistantID;
        _ = this.ScheduledAtFixedDatetime;
        _ = this.TelnyxAgentTarget;
        this.TelnyxConversationChannel.Validate();
        _ = this.TelnyxEndUserTarget;
        _ = this.Text;
        _ = this.ConversationID;
        if (this.ConversationMetadata != null)
        {
            foreach (var item in this.ConversationMetadata.Values)
            {
                item.Validate();
            }
        }
        _ = this.CreatedAt;
        _ = this.DynamicVariables;
        _ = this.Errors;
        _ = this.RetryCount;
        _ = this.ScheduledEventID;
        this.Status?.Validate();
    }

    public ScheduledSmsEventResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScheduledSmsEventResponse (
        ScheduledSmsEventResponse scheduledSmsEventResponse
    ) : base(scheduledSmsEventResponse)
    {  }
    #pragma warning restore CS8618

    public ScheduledSmsEventResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ScheduledSmsEventResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ScheduledSmsEventResponseFromRaw.FromRawUnchecked"/>
    public static ScheduledSmsEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ScheduledSmsEventResponseFromRaw : IFromRawJson<ScheduledSmsEventResponse>
{
    /// <inheritdoc/>
    public ScheduledSmsEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ScheduledSmsEventResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ScheduledSmsEventResponseConversationMetadataConverter))]
public record class ScheduledSmsEventResponseConversationMetadata : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ScheduledSmsEventResponseConversationMetadata (
        string value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ScheduledSmsEventResponseConversationMetadata (
        long value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ScheduledSmsEventResponseConversationMetadata (
        bool value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ScheduledSmsEventResponseConversationMetadata (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="long"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickLong(out var value)) {
///     // `value` is of type `long`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value =this.Value as long? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="bool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickBool(out var value)) {
///     // `value` is of type `bool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value =this.Value as bool? ;
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
///     (string value) =&gt; {...},
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<long> @long,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ScheduledSmsEventResponseConversationMetadata");

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
///     (string value) =&gt; {...},
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<long, T> @long,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            long value=>@long(value),
            bool value=>@bool(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ScheduledSmsEventResponseConversationMetadata")
        } ;
    }

    public static implicit operator ScheduledSmsEventResponseConversationMetadata (
        string value
    )=> new(value) ;

    public static implicit operator ScheduledSmsEventResponseConversationMetadata (
        long value
    )=> new(value) ;

    public static implicit operator ScheduledSmsEventResponseConversationMetadata (
        bool value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ScheduledSmsEventResponseConversationMetadata");
        }
    }

    public virtual bool Equals(
        ScheduledSmsEventResponseConversationMetadata? other
    )
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
        { string _=>0, long _=>1, bool _=>2, _ =>-1 } ;
    }
}sealed class ScheduledSmsEventResponseConversationMetadataConverter : JsonConverter<ScheduledSmsEventResponseConversationMetadata>
{
    public override ScheduledSmsEventResponseConversationMetadata? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScheduledSmsEventResponseConversationMetadata value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}