using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

/// <summary>
/// Create a scheduled event for an assistant
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ScheduledEventCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AssistantID { get; init; }

    /// <summary>
    /// The datetime at which the event should be scheduled. Formatted as ISO 8601.
    /// </summary>
    public required System::DateTimeOffset ScheduledAtFixedDatetime {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<System::DateTimeOffset>(
                "scheduled_at_fixed_datetime"
            );
        }
        init { this._rawBodyData.Set("scheduled_at_fixed_datetime", value); }
    }

    /// <summary>
    /// The phone number, SIP URI, to schedule the call or text from.
    /// </summary>
    public required string TelnyxAgentTarget {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "telnyx_agent_target"
            );
        }
        init { this._rawBodyData.Set("telnyx_agent_target", value); }
    }

    public required ApiEnum<string, ConversationChannelType> TelnyxConversationChannel {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ConversationChannelType>>(
                "telnyx_conversation_channel"
            );
        }
        init { this._rawBodyData.Set("telnyx_conversation_channel", value); }
    }

    /// <summary>
    /// The phone number, SIP URI, to schedule the call or text to.
    /// </summary>
    public required string TelnyxEndUserTarget {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "telnyx_end_user_target"
            );
        }
        init { this._rawBodyData.Set("telnyx_end_user_target", value); }
    }

    /// <summary>
    /// Per-call telephony overrides applied when a scheduled phone-call event dispatches.
    /// Phone-call events only. New per-call dispatch options should be added here
    /// rather than as top-level event fields.
    /// </summary>
    public ScheduledCallSettings? CallSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ScheduledCallSettings>(
                "call_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("call_settings", value);
        }
    }

    /// <summary>
    /// Metadata associated with the conversation. Telnyx provides several pieces
    /// of metadata, but customers can also add their own.
    /// </summary>
    public IReadOnlyDictionary<string, ConversationMetadata>? ConversationMetadata {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, ConversationMetadata>>(
                "conversation_metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, ConversationMetadata>?>(
                "conversation_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A map of dynamic variable names to values. These variables can be referenced
    /// in the assistant's instructions and messages using {{variable_name}} syntax.
    /// </summary>
    public IReadOnlyDictionary<string, string>? DynamicVariables {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>(
                "dynamic_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "dynamic_variables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Configure number of retries on client errors: busy, no-answer, failed, canceled
    /// (caller hung up before the callee answered)
    /// </summary>
    public long? MaxRetriesClientErrors {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "max_retries_client_errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_retries_client_errors", value);
        }
    }

    public long? RetryIntervalSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "retry_interval_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("retry_interval_secs", value);
        }
    }

    /// <summary>
    /// Required for sms scheduled events. The text to be sent to the end user.
    /// </summary>
    public string? Text {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("text", value);
        }
    }

    public string? IdempotencyKey {
        get {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>(
                "Idempotency-Key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public ScheduledEventCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScheduledEventCreateParams (
        ScheduledEventCreateParams scheduledEventCreateParams
    ) : base(scheduledEventCreateParams)
    {
        this.AssistantID = scheduledEventCreateParams.AssistantID;

        this._rawBodyData = new(scheduledEventCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ScheduledEventCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ScheduledEventCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string assistantID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AssistantID = assistantID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ScheduledEventCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string assistantID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            assistantID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AssistantID"] = JsonSerializer.SerializeToElement(this.AssistantID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ScheduledEventCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AssistantID?.Equals(other.AssistantID) ?? other.AssistantID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/assistants/{0}/scheduled_events",
            this.AssistantID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

[JsonConverter(typeof(ConversationMetadataConverter))]
public record class ConversationMetadata : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ConversationMetadata (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationMetadata (long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationMetadata (bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ConversationMetadata (JsonElement element)
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
                throw new TelnyxInvalidDataException("Data did not match any variant of ConversationMetadata");

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
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ConversationMetadata")
        } ;
    }

    public static implicit operator ConversationMetadata (
        string value
    )=> new(value) ;

    public static implicit operator ConversationMetadata (
        long value
    )=> new(value) ;

    public static implicit operator ConversationMetadata (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ConversationMetadata");
        }
    }

    public virtual bool Equals(ConversationMetadata? other)
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
}

sealed class ConversationMetadataConverter : JsonConverter<ConversationMetadata>
{
    public override ConversationMetadata? Read(
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
        ConversationMetadata value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}