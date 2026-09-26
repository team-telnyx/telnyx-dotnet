using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Add messages to the conversation started by an AI assistant on the call.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionAddAIAssistantMessagesParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
    /// </summary>
    public string? ClientState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Use this field to avoid duplicate commands. Telnyx will ignore any command
    /// with the same `command_id` for the same `call_control_id`.
    /// </summary>
    public string? CommandID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("command_id", value);
        }
    }

    /// <summary>
    /// The messages to add to the conversation.
    /// </summary>
    public IReadOnlyList<Message>? Messages {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Message>>(
                "messages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Message>?>(
                "messages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When `true`, the injected messages immediately trigger an assistant response/turn
    /// instead of waiting for the next natural turn or idle timeout. This may interrupt
    /// a user who is still speaking.
    /// </summary>
    public bool? TriggerResponse {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "trigger_response"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("trigger_response", value);
        }
    }

    public ActionAddAIAssistantMessagesParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionAddAIAssistantMessagesParams (
        ActionAddAIAssistantMessagesParams actionAddAIAssistantMessagesParams
    ) : base(actionAddAIAssistantMessagesParams)
    {
        this.CallControlID = actionAddAIAssistantMessagesParams.CallControlID;

        this._rawBodyData = new(actionAddAIAssistantMessagesParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionAddAIAssistantMessagesParams (
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
    ActionAddAIAssistantMessagesParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CallControlID = callControlID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionAddAIAssistantMessagesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            callControlID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CallControlID"] = JsonSerializer.SerializeToElement(this.CallControlID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionAddAIAssistantMessagesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallControlID?.Equals(other.CallControlID) ?? other.CallControlID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/ai_assistant_add_messages",
            EncodePathSegment(this.CallControlID))
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

/// <summary>
/// Messages sent by an end user
/// </summary>
[JsonConverter(typeof(MessageConverter))]
public record class Message : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string? Content {
        get {
            return Match<string?>(user: ( x )=>x.Content,
            assistant: ( x )=>x.Content,
            tool: ( x )=>x.Content,
            system: ( x )=>x.Content,
            developer: ( x )=>x.Content);
        }
    }

    public Message (UserMessage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message (AssistantMessage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message (ToolMessage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message (SystemMessage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message (DeveloperMessage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Message (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="UserMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickUser(out var value)) {
///     // `value` is of type `UserMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickUser([NotNullWhen(true)] out UserMessage? value)
    {
        value =this.Value as UserMessage ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AssistantMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAssistant(out var value)) {
///     // `value` is of type `AssistantMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAssistant(
        [NotNullWhen(true)] out AssistantMessage? value
    )
    {
        value =this.Value as AssistantMessage ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ToolMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTool(out var value)) {
///     // `value` is of type `ToolMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTool([NotNullWhen(true)] out ToolMessage? value)
    {
        value =this.Value as ToolMessage ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="SystemMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSystem(out var value)) {
///     // `value` is of type `SystemMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSystem([NotNullWhen(true)] out SystemMessage? value)
    {
        value =this.Value as SystemMessage ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="DeveloperMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDeveloper(out var value)) {
///     // `value` is of type `DeveloperMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDeveloper(
        [NotNullWhen(true)] out DeveloperMessage? value
    )
    {
        value =this.Value as DeveloperMessage ;
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
///     (UserMessage value) =&gt; {...},
///     (AssistantMessage value) =&gt; {...},
///     (ToolMessage value) =&gt; {...},
///     (SystemMessage value) =&gt; {...},
///     (DeveloperMessage value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<UserMessage> user,
        System::Action<AssistantMessage> assistant,
        System::Action<ToolMessage> tool,
        System::Action<SystemMessage> system,
        System::Action<DeveloperMessage> developer
    )
    {
        switch (this.Value)
        {
            case UserMessage value:
                user(value);
                break;
            case AssistantMessage value:
                assistant(value);
                break;
            case ToolMessage value:
                tool(value);
                break;
            case SystemMessage value:
                system(value);
                break;
            case DeveloperMessage value:
                developer(value);
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
///     (UserMessage value) =&gt; {...},
///     (AssistantMessage value) =&gt; {...},
///     (ToolMessage value) =&gt; {...},
///     (SystemMessage value) =&gt; {...},
///     (DeveloperMessage value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<UserMessage, T> user,
        System::Func<AssistantMessage, T> assistant,
        System::Func<ToolMessage, T> tool,
        System::Func<SystemMessage, T> system,
        System::Func<DeveloperMessage, T> developer
    )
    {
        return this.Value switch
        {
            UserMessage value=>user(value),
            AssistantMessage value=>assistant(value),
            ToolMessage value=>tool(value),
            SystemMessage value=>system(value),
            DeveloperMessage value=>developer(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Message")
        } ;
    }

    public static implicit operator Message (UserMessage value)=> new(value) ;

    public static implicit operator Message (
        AssistantMessage value
    )=> new(value) ;

    public static implicit operator Message (ToolMessage value)=> new(value) ;

    public static implicit operator Message (SystemMessage value)=> new(value) ;

    public static implicit operator Message (
        DeveloperMessage value
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
        this.Switch((user) => user.Validate(),
        (assistant) => assistant.Validate(),
        (tool) => tool.Validate(),
        (system) => system.Validate(),
        (developer) => developer.Validate());
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
            UserMessage _=>0,
            AssistantMessage _=>1,
            ToolMessage _=>2,
            SystemMessage _=>3,
            DeveloperMessage _=>4,
            _ =>-1
        } ;
    }
}

sealed class MessageConverter : JsonConverter<Message>
{
    public override Message? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? role;
        try {
            role = element.GetProperty("role").GetString();
        } catch {
            role = null;
        }

        switch (role)
        {
            case "user":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UserMessage>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "assistant":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AssistantMessage>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "tool":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolMessage>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "system":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SystemMessage>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "developer":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DeveloperMessage>(element, options);
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
                { return new Message(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Message value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}