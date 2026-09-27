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

[JsonConverter(typeof(JsonModelConverter<ScheduledPhoneCallEventResponse, ScheduledPhoneCallEventResponseFromRaw>))]
public sealed record class ScheduledPhoneCallEventResponse : JsonModel
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

    public IReadOnlyList<CallAttempt>? CallAttempts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CallAttempt>>(
                "call_attempts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CallAttempt>?>(
                "call_attempts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Duration of the call in seconds
    /// </summary>
    public long? CallDuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "call_duration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_duration", value);
        }
    }

    /// <summary>
    /// Per-call telephony overrides applied when a scheduled phone-call event dispatches.
    /// Phone-call events only. New per-call dispatch options should be added here
    /// rather than as top-level event fields.
    /// </summary>
    public ScheduledCallSettings? CallSettings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ScheduledCallSettings>(
                "call_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_settings", value);
        }
    }

    /// <summary>
    /// Values: busy, canceled, no-answer, ringing, completed, failed, in-progress
    /// </summary>
    public string? CallStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_status", value);
        }
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

    public IReadOnlyDictionary<string, ScheduledPhoneCallEventResponseConversationMetadata>? ConversationMetadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, ScheduledPhoneCallEventResponseConversationMetadata>>(
                "conversation_metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, ScheduledPhoneCallEventResponseConversationMetadata>?>(
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
    /// Date time at which call was sent
    /// </summary>
    public System::DateTimeOffset? DispatchedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "dispatched_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dispatched_at", value);
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

    /// <summary>
    /// Configure number of retries on client errors: busy, no-answer, failed, canceled
    /// (caller hung up before the callee answered)
    /// </summary>
    public long? MaxRetriesClientErrors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_retries_client_errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_retries_client_errors", value);
        }
    }

    public long? RetryAttempts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "retry_attempts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("retry_attempts", value);
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

    public long? RetryIntervalSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "retry_interval_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("retry_interval_secs", value);
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
        foreach (var item in this.CallAttempts ?? [])
        {
            item.Validate();
        }
        _ = this.CallDuration;
        this.CallSettings?.Validate();
        _ = this.CallStatus;
        _ = this.ConversationID;
        if (this.ConversationMetadata != null)
        {
            foreach (var item in this.ConversationMetadata.Values)
            {
                item.Validate();
            }
        }
        _ = this.CreatedAt;
        _ = this.DispatchedAt;
        _ = this.DynamicVariables;
        _ = this.Errors;
        _ = this.MaxRetriesClientErrors;
        _ = this.RetryAttempts;
        _ = this.RetryCount;
        _ = this.RetryIntervalSecs;
        _ = this.ScheduledEventID;
        this.Status?.Validate();
    }

    public ScheduledPhoneCallEventResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScheduledPhoneCallEventResponse (
        ScheduledPhoneCallEventResponse scheduledPhoneCallEventResponse
    ) : base(scheduledPhoneCallEventResponse)
    {  }
    #pragma warning restore CS8618

    public ScheduledPhoneCallEventResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ScheduledPhoneCallEventResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ScheduledPhoneCallEventResponseFromRaw.FromRawUnchecked"/>
    public static ScheduledPhoneCallEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ScheduledPhoneCallEventResponseFromRaw : IFromRawJson<ScheduledPhoneCallEventResponse>
{
    /// <inheritdoc/>
    public ScheduledPhoneCallEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ScheduledPhoneCallEventResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// One row in `call_attempts` — captures the terminal outcome of a single dispatch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallAttempt, CallAttemptFromRaw>))]
public sealed record class CallAttempt : JsonModel
{
    public required long AttemptNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "attempt_number"
            );
        }
        init { this._rawData.Set("attempt_number", value); }
    }

    public required System::DateTimeOffset AttemptedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "attempted_at"
            );
        }
        init { this._rawData.Set("attempted_at", value); }
    }

    /// <summary>
    /// Values: busy, canceled, no-answer, ringing, completed, failed, in-progress
    /// </summary>
    public required string CallStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_status"
            );
        }
        init { this._rawData.Set("call_status", value); }
    }

    /// <summary>
    /// Duration of the call in seconds
    /// </summary>
    public long? CallDuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "call_duration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_duration", value);
        }
    }

    public string? TelnyxCallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "telnyx_call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("telnyx_call_control_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttemptNumber;
        _ = this.AttemptedAt;
        _ = this.CallStatus;
        _ = this.CallDuration;
        _ = this.TelnyxCallControlID;
    }

    public CallAttempt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallAttempt (CallAttempt callAttempt) : base(callAttempt)
    {  }
    #pragma warning restore CS8618

    public CallAttempt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallAttempt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallAttemptFromRaw.FromRawUnchecked"/>
    public static CallAttempt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallAttemptFromRaw : IFromRawJson<CallAttempt>
{
    /// <inheritdoc/>
    public CallAttempt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallAttempt.FromRawUnchecked(rawData);
}[JsonConverter(typeof(ScheduledPhoneCallEventResponseConversationMetadataConverter))]
public record class ScheduledPhoneCallEventResponseConversationMetadata : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ScheduledPhoneCallEventResponseConversationMetadata (
        string value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ScheduledPhoneCallEventResponseConversationMetadata (
        long value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ScheduledPhoneCallEventResponseConversationMetadata (
        bool value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ScheduledPhoneCallEventResponseConversationMetadata (
        JsonElement element
    )
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
                throw new TelnyxInvalidDataException("Data did not match any variant of ScheduledPhoneCallEventResponseConversationMetadata");

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
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ScheduledPhoneCallEventResponseConversationMetadata")
        } ;
    }

    public static implicit operator ScheduledPhoneCallEventResponseConversationMetadata (
        string value
    )=> new(value) ;

    public static implicit operator ScheduledPhoneCallEventResponseConversationMetadata (
        long value
    )=> new(value) ;

    public static implicit operator ScheduledPhoneCallEventResponseConversationMetadata (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ScheduledPhoneCallEventResponseConversationMetadata");
        }
    }

    public virtual bool Equals(
        ScheduledPhoneCallEventResponseConversationMetadata? other
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
}sealed class ScheduledPhoneCallEventResponseConversationMetadataConverter : JsonConverter<ScheduledPhoneCallEventResponseConversationMetadata>
{
    public override ScheduledPhoneCallEventResponseConversationMetadata? Read(
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
        ScheduledPhoneCallEventResponseConversationMetadata value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}