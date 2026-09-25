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
/// Start an AI assistant on the call.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.conversation.ended` - `call.conversation_insights.generated`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionStartAIAssistantParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// AI Assistant configuration. All fields except `id` are optional — the assistant's
    /// stored configuration will be used as fallback for any omitted fields.
    /// </summary>
    public CallAssistantRequest? Assistant {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CallAssistantRequest>(
                "assistant"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("assistant", value);
        }
    }

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
    /// Text that will be played when the assistant starts, if none then nothing will
    /// be played when the assistant starts. The greeting can be text for any voice
    /// or SSML for `AWS.Polly.&lt;voice_id&gt;` voices. There is a 3,000 character limit.
    /// </summary>
    public string? Greeting {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("greeting", value);
        }
    }

    /// <summary>
    /// Settings for handling user interruptions during assistant speech
    /// </summary>
    public InterruptionSettings? InterruptionSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InterruptionSettings>(
                "interruption_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("interruption_settings", value);
        }
    }

    /// <summary>
    /// A list of messages to seed the conversation history before the assistant
    /// starts. Follows the same message format as the `ai_assistant_add_messages` command.
    /// </summary>
    public IReadOnlyList<ActionStartAIAssistantParamsMessageHistory>? MessageHistory {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ActionStartAIAssistantParamsMessageHistory>>(
                "message_history"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ActionStartAIAssistantParamsMessageHistory>?>(
                "message_history",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A list of participants to add to the conversation when it starts.
    /// </summary>
    public IReadOnlyList<AIAssistantJoinParticipant>? Participants {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AIAssistantJoinParticipant>>(
                "participants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<AIAssistantJoinParticipant>?>(
                "participants",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When `true`, a `call.ai_gather.message_history_updated` webhook carrying
    /// the full message history is sent each time the conversation message history
    /// is updated. The assistant's own `telephony_settings.send_message_history_updates`
    /// overrides this value when it is set.
    /// </summary>
    public bool? SendMessageHistoryUpdates {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "send_message_history_updates"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("send_message_history_updates", value);
        }
    }

    /// <summary>
    /// The settings associated with speech to text for the voice assistant. This
    /// is only relevant if the assistant uses a text-to-text language model. Any
    /// assistant using a model with native audio support (e.g. `fixie-ai/ultravox-v0_4`)
    /// will ignore this field.
    /// </summary>
    public TranscriptionConfig? Transcription {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TranscriptionConfig>(
                "transcription"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("transcription", value);
        }
    }

    public ActionStartAIAssistantParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionStartAIAssistantParams (
        ActionStartAIAssistantParams actionStartAIAssistantParams
    ) : base(actionStartAIAssistantParams)
    {
        this.CallControlID = actionStartAIAssistantParams.CallControlID;

        this._rawBodyData = new(actionStartAIAssistantParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionStartAIAssistantParams (
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
    ActionStartAIAssistantParams (
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
    public static ActionStartAIAssistantParams FromRawUnchecked(
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

    public virtual bool Equals(ActionStartAIAssistantParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/ai_assistant_start",
            this.CallControlID)
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
[JsonConverter(typeof(ActionStartAIAssistantParamsMessageHistoryConverter))]
public record class ActionStartAIAssistantParamsMessageHistory : ModelBase
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
            return Match<string?>(userMessage: ( x )=>x.Content,
            assistantMessage: ( x )=>x.Content,
            toolMessage: ( x )=>x.Content,
            systemMessage: ( x )=>x.Content,
            developerMessage: ( x )=>x.Content);
        }
    }

    public ActionStartAIAssistantParamsMessageHistory (
        UserMessage value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartAIAssistantParamsMessageHistory (
        AssistantMessage value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartAIAssistantParamsMessageHistory (
        ToolMessage value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartAIAssistantParamsMessageHistory (
        SystemMessage value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartAIAssistantParamsMessageHistory (
        DeveloperMessage value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionStartAIAssistantParamsMessageHistory (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="UserMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickUserMessage(out var value)) {
///     // `value` is of type `UserMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickUserMessage([NotNullWhen(true)] out UserMessage? value)
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
/// if (instance.TryPickAssistantMessage(out var value)) {
///     // `value` is of type `AssistantMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAssistantMessage(
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
/// if (instance.TryPickToolMessage(out var value)) {
///     // `value` is of type `ToolMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickToolMessage([NotNullWhen(true)] out ToolMessage? value)
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
/// if (instance.TryPickSystemMessage(out var value)) {
///     // `value` is of type `SystemMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSystemMessage(
        [NotNullWhen(true)] out SystemMessage? value
    )
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
/// if (instance.TryPickDeveloperMessage(out var value)) {
///     // `value` is of type `DeveloperMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDeveloperMessage(
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
        System::Action<UserMessage> userMessage,
        System::Action<AssistantMessage> assistantMessage,
        System::Action<ToolMessage> toolMessage,
        System::Action<SystemMessage> systemMessage,
        System::Action<DeveloperMessage> developerMessage
    )
    {
        switch (this.Value)
        {
            case UserMessage value:
                userMessage(value);
                break;
            case AssistantMessage value:
                assistantMessage(value);
                break;
            case ToolMessage value:
                toolMessage(value);
                break;
            case SystemMessage value:
                systemMessage(value);
                break;
            case DeveloperMessage value:
                developerMessage(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ActionStartAIAssistantParamsMessageHistory");

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
        System::Func<UserMessage, T> userMessage,
        System::Func<AssistantMessage, T> assistantMessage,
        System::Func<ToolMessage, T> toolMessage,
        System::Func<SystemMessage, T> systemMessage,
        System::Func<DeveloperMessage, T> developerMessage
    )
    {
        return this.Value switch
        {
            UserMessage value=>userMessage(value),
            AssistantMessage value=>assistantMessage(value),
            ToolMessage value=>toolMessage(value),
            SystemMessage value=>systemMessage(value),
            DeveloperMessage value=>developerMessage(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ActionStartAIAssistantParamsMessageHistory")
        } ;
    }

    public static implicit operator ActionStartAIAssistantParamsMessageHistory (
        UserMessage value
    )=> new(value) ;

    public static implicit operator ActionStartAIAssistantParamsMessageHistory (
        AssistantMessage value
    )=> new(value) ;

    public static implicit operator ActionStartAIAssistantParamsMessageHistory (
        ToolMessage value
    )=> new(value) ;

    public static implicit operator ActionStartAIAssistantParamsMessageHistory (
        SystemMessage value
    )=> new(value) ;

    public static implicit operator ActionStartAIAssistantParamsMessageHistory (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ActionStartAIAssistantParamsMessageHistory");
        }
        this.Switch((userMessage) => userMessage.Validate(),
        (assistantMessage) => assistantMessage.Validate(),
        (toolMessage) => toolMessage.Validate(),
        (systemMessage) => systemMessage.Validate(),
        (developerMessage) => developerMessage.Validate());
    }

    public virtual bool Equals(
        ActionStartAIAssistantParamsMessageHistory? other
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

sealed class ActionStartAIAssistantParamsMessageHistoryConverter : JsonConverter<ActionStartAIAssistantParamsMessageHistory>
{
    public override ActionStartAIAssistantParamsMessageHistory? Read(
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
                {
                    return new ActionStartAIAssistantParamsMessageHistory(element);
                }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionStartAIAssistantParamsMessageHistory value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}