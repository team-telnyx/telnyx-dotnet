using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// A remote agent, reachable over the A2A (Agent2Agent) protocol, that an assistant
/// can delegate to. Tools are not configured here: at the start of every conversation
/// the agent's card is fetched and one tool is derived per skill the card advertises.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AssistantA2AAgent, AssistantA2AAgentFromRaw>))]
public sealed record class AssistantA2AAgent : JsonModel
{
    /// <summary>
    /// Identifies the agent and seeds the names of the tools derived from its card
    /// (`a2a_&lt;name&gt;_&lt;skill_id&gt;`). Characters outside `[A-Za-z0-9_]`
    /// are replaced with `_` before the tool name is built, so two agents whose
    /// names differ only in punctuation collide and are rejected.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The agent's base URL, or the URL of its agent card. At most 2,048 bytes once
    /// UTF-8 encoded. `/.well-known/agent-card.json` is appended to the path unless
    /// it already ends in `.json`. Must be an `http://` or `https://` URL for an
    /// externally reachable host: internal destinations (`localhost`, private and
    /// reserved IP ranges, `.local` domains) are rejected, and the hostname may
    /// not contain a `{{...}}` placeholder. Placeholders in the path are allowed.
    /// </summary>
    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// When `true`, the assistant hands the turn straight back to the model and the
    /// agent's answer is delivered into the conversation once it arrives, instead
    /// of the caller waiting for it in silence.
    /// </summary>
    public bool? Async {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "async"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("async", value);
        }
    }

    /// <summary>
    /// Headers sent when fetching this agent's card and on every call made to it.
    /// Use them to authenticate to the agent.
    /// </summary>
    public IReadOnlyList<Header>? Headers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Header>>(
                "headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Header>?>(
                "headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filler messages spoken while a call to this agent is in progress. `request_start`
    /// messages are spoken immediately when the call begins. `request_response_delayed`
    /// messages are spoken after `timing_ms` has elapsed only if the agent has not
    /// answered yet. Filler messages are not used when `async` is `true`.
    /// </summary>
    public IReadOnlyList<Message>? Messages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Message>>(
                "messages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Message>?>(
                "messages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How often, in milliseconds, to poll an agent task that has not finished yet.
    /// Defaults to 500.
    /// </summary>
    public long? PollIntervalMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "poll_interval_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("poll_interval_ms", value);
        }
    }

    /// <summary>
    /// Total budget, in milliseconds, for one call to this agent, including any
    /// time spent polling a task that is still running. Omit to inherit the assistant's
    /// tool timeout.
    /// </summary>
    public long? TimeoutMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "timeout_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timeout_ms", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Url;
        _ = this.Async;
        foreach (var item in this.Headers ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Messages ?? [])
        {
            item.Validate();
        }
        _ = this.PollIntervalMs;
        _ = this.TimeoutMs;
    }

    public AssistantA2AAgent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantA2AAgent (AssistantA2AAgent assistantA2AAgent) : base(
        assistantA2AAgent
    )
    {  }
    #pragma warning restore CS8618

    public AssistantA2AAgent (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantA2AAgent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantA2AAgentFromRaw.FromRawUnchecked"/>
    public static AssistantA2AAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssistantA2AAgentFromRaw : IFromRawJson<AssistantA2AAgent>
{
    /// <inheritdoc/>
    public AssistantA2AAgent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssistantA2AAgent.FromRawUnchecked(rawData);
}

/// <summary>
/// A header sent when fetching an A2A agent's card and on every call made to that agent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Header, HeaderFromRaw>))]
public sealed record class Header : JsonModel
{
    /// <summary>
    /// HTTP header name. May only contain alphanumeric characters, hyphens, and
    /// underscores, or a `{{dynamic_variable}}` placeholder surrounded by those characters.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Header value, stored exactly as written. It may be a literal, a `{{dynamic_variable}}`,
    /// or an `{{#integration_secret}}identifier{{/integration_secret}}` section that
    /// resolves to a stored integration secret when the conversation starts. Control
    /// characters are not allowed. The encrypted `{{variable | encryption_secret_ref}}`
    /// form used for per-caller credentials is not resolved here and is rejected
    /// when the assistant is saved.
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public Header ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Header (Header header) : base(header)
    {  }
    #pragma warning restore CS8618

    public Header (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Header (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HeaderFromRaw.FromRawUnchecked"/>
    public static Header FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class HeaderFromRaw : IFromRawJson<Header>
{
    /// <inheritdoc/>
    public Header FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Header.FromRawUnchecked(rawData);
}[JsonConverter(typeof(MessageConverter))]
public record class Message : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string Content {
        get {
            return Match(a2AAgentRequestStart: ( x )=>x.Content,
            a2AAgentRequestResponseDelayed: ( x )=>x.Content);
        }
    }

    public JsonElement Type {
        get {
            return Match(a2AAgentRequestStart: ( x )=>x.Type,
            a2AAgentRequestResponseDelayed: ( x )=>x.Type);
        }
    }

    public long? TimingMs {
        get {
            return Match<long?>(a2AAgentRequestStart: ( x )=>x.TimingMs,
            a2AAgentRequestResponseDelayed: ( x )=>x.TimingMs);
        }
    }

    public Message (
        A2AAgentRequestStartMessage value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Message (
        A2AAgentRequestResponseDelayedMessage value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Message (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="A2AAgentRequestStartMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickA2AAgentRequestStart(out var value)) {
///     // `value` is of type `A2AAgentRequestStartMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickA2AAgentRequestStart(
        [NotNullWhen(true)] out A2AAgentRequestStartMessage? value
    )
    {
        value =this.Value as A2AAgentRequestStartMessage ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="A2AAgentRequestResponseDelayedMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickA2AAgentRequestResponseDelayed(out var value)) {
///     // `value` is of type `A2AAgentRequestResponseDelayedMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickA2AAgentRequestResponseDelayed(
        [NotNullWhen(true)] out A2AAgentRequestResponseDelayedMessage? value
    )
    {
        value =this.Value as A2AAgentRequestResponseDelayedMessage ;
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
///     (A2AAgentRequestStartMessage value) =&gt; {...},
///     (A2AAgentRequestResponseDelayedMessage value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<A2AAgentRequestStartMessage> a2AAgentRequestStart,
        System::Action<A2AAgentRequestResponseDelayedMessage> a2AAgentRequestResponseDelayed
    )
    {
        switch (this.Value)
        {
            case A2AAgentRequestStartMessage value:
                a2AAgentRequestStart(value);
                break;
            case A2AAgentRequestResponseDelayedMessage value:
                a2AAgentRequestResponseDelayed(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Message");

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
///     (A2AAgentRequestStartMessage value) =&gt; {...},
///     (A2AAgentRequestResponseDelayedMessage value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<A2AAgentRequestStartMessage, T> a2AAgentRequestStart,
        System::Func<A2AAgentRequestResponseDelayedMessage, T> a2AAgentRequestResponseDelayed
    )
    {
        return this.Value switch
        {
            A2AAgentRequestStartMessage value=>a2AAgentRequestStart(value),
            A2AAgentRequestResponseDelayedMessage value=>a2AAgentRequestResponseDelayed(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Message")
        } ;
    }

    public static implicit operator Message (
        A2AAgentRequestStartMessage value
    )=> new(value) ;

    public static implicit operator Message (
        A2AAgentRequestResponseDelayedMessage value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Message");
        }
        this.Switch((a2AAgentRequestStart) => a2AAgentRequestStart.Validate(),
        (a2AAgentRequestResponseDelayed) => a2AAgentRequestResponseDelayed.Validate());
    }

    public virtual bool Equals(Message? other)
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
            A2AAgentRequestStartMessage _=>0,
            A2AAgentRequestResponseDelayedMessage _=>1,
            _ =>-1
        } ;
    }
}sealed class MessageConverter : JsonConverter<Message>
{
    public override Message? Read(
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
            var deserialized = JsonSerializer.Deserialize<A2AAgentRequestResponseDelayedMessage>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<A2AAgentRequestStartMessage>(element, options);
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

    public override void Write(
        Utf8JsonWriter writer, Message value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<A2AAgentRequestStartMessage, A2AAgentRequestStartMessageFromRaw>))]
public sealed record class A2AAgentRequestStartMessage : JsonModel
{
    /// <summary>
    /// The text the assistant speaks.
    /// </summary>
    public required string Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Speak the filler message immediately when the call to the agent begins.
    /// </summary>
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// An optional delay value. This value is ignored for `request_start` messages.
    /// </summary>
    public long? TimingMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "timing_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timing_ms", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("request_start")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.TimingMs;
    }

    public A2AAgentRequestStartMessage ()
    { this.Type = JsonSerializer.SerializeToElement("request_start"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public A2AAgentRequestStartMessage (
        A2AAgentRequestStartMessage a2AAgentRequestStartMessage
    ) : base(a2AAgentRequestStartMessage)
    {  }
    #pragma warning restore CS8618

    public A2AAgentRequestStartMessage (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("request_start");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    A2AAgentRequestStartMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="A2AAgentRequestStartMessageFromRaw.FromRawUnchecked"/>
    public static A2AAgentRequestStartMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public A2AAgentRequestStartMessage (string content) : this()
    { this.Content = content; }
}class A2AAgentRequestStartMessageFromRaw : IFromRawJson<A2AAgentRequestStartMessage>
{
    /// <inheritdoc/>
    public A2AAgentRequestStartMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>A2AAgentRequestStartMessage.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<A2AAgentRequestResponseDelayedMessage, A2AAgentRequestResponseDelayedMessageFromRaw>))]
public sealed record class A2AAgentRequestResponseDelayedMessage : JsonModel
{
    /// <summary>
    /// The text the assistant speaks.
    /// </summary>
    public required string Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// How long to wait, in milliseconds, before speaking this message.
    /// </summary>
    public required long TimingMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "timing_ms"
            );
        }
        init { this._rawData.Set("timing_ms", value); }
    }

    /// <summary>
    /// Speak the filler message only if the agent has not answered yet after `timing_ms`.
    /// </summary>
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.TimingMs;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("request_response_delayed")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public A2AAgentRequestResponseDelayedMessage ()
    {
        this.Type = JsonSerializer.SerializeToElement("request_response_delayed");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public A2AAgentRequestResponseDelayedMessage (
        A2AAgentRequestResponseDelayedMessage a2AAgentRequestResponseDelayedMessage
    ) : base(a2AAgentRequestResponseDelayedMessage)
    {  }
    #pragma warning restore CS8618

    public A2AAgentRequestResponseDelayedMessage (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("request_response_delayed");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    A2AAgentRequestResponseDelayedMessage (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="A2AAgentRequestResponseDelayedMessageFromRaw.FromRawUnchecked"/>
    public static A2AAgentRequestResponseDelayedMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class A2AAgentRequestResponseDelayedMessageFromRaw : IFromRawJson<A2AAgentRequestResponseDelayedMessage>
{
    /// <inheritdoc/>
    public A2AAgentRequestResponseDelayedMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>A2AAgentRequestResponseDelayedMessage.FromRawUnchecked(rawData);
}