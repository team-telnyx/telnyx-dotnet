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

[JsonConverter(typeof(JsonModelConverter<InferenceEmbeddingWebhookToolParams, InferenceEmbeddingWebhookToolParamsFromRaw>))]
public sealed record class InferenceEmbeddingWebhookToolParams : JsonModel
{
    public required ApiEnum<string, InferenceEmbeddingWebhookToolParamsType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InferenceEmbeddingWebhookToolParamsType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public required Webhook Webhook {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Webhook>(
                "webhook"
            );
        }
        init { this._rawData.Set("webhook", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <summary>
    /// The maximum number of milliseconds to wait for the webhook to respond before
    /// the tool call is aborted. Set this at the tool level, as a sibling of `type`
    /// — a `timeout_ms` nested inside the `webhook` object is stored but not applied,
    /// and the tool runs at this default instead. Applies when `webhook.async` is false.
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
        this.Type.Validate();
        this.Webhook.Validate();
        _ = this.Shared;
        _ = this.TimeoutMs;
    }

    public InferenceEmbeddingWebhookToolParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InferenceEmbeddingWebhookToolParams (
        InferenceEmbeddingWebhookToolParams inferenceEmbeddingWebhookToolParams
    ) : base(inferenceEmbeddingWebhookToolParams)
    {  }
    #pragma warning restore CS8618

    public InferenceEmbeddingWebhookToolParams (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InferenceEmbeddingWebhookToolParams (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InferenceEmbeddingWebhookToolParamsFromRaw.FromRawUnchecked"/>
    public static InferenceEmbeddingWebhookToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InferenceEmbeddingWebhookToolParamsFromRaw : IFromRawJson<InferenceEmbeddingWebhookToolParams>
{
    /// <inheritdoc/>
    public InferenceEmbeddingWebhookToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InferenceEmbeddingWebhookToolParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InferenceEmbeddingWebhookToolParamsTypeConverter))]
public enum InferenceEmbeddingWebhookToolParamsType
{
    Webhook
}sealed class InferenceEmbeddingWebhookToolParamsTypeConverter : JsonConverter<InferenceEmbeddingWebhookToolParamsType>
{
    public override InferenceEmbeddingWebhookToolParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook"=>InferenceEmbeddingWebhookToolParamsType.Webhook,
            _ =>(InferenceEmbeddingWebhookToolParamsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InferenceEmbeddingWebhookToolParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InferenceEmbeddingWebhookToolParamsType.Webhook=>"webhook",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Webhook, WebhookFromRaw>))]
public sealed record class Webhook : JsonModel
{
    /// <summary>
    /// The description of the tool.
    /// </summary>
    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The name of the tool.
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
    /// The URL of the external tool to be called. This URL is going to be used by
    /// the assistant. The URL can be templated like: `https://example.com/api/v1/{id}`,
    /// where `{id}` is a placeholder for a value that will be provided by the assistant
    /// if `path_parameters` are provided with the `id` attribute.
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
    /// If async, the assistant will move forward without waiting for your server
    /// to respond.
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
    /// Maximum time in milliseconds that the conversation worker waits for an async
    /// webhook response before returning "Submitted" to the LLM. If unset, the platform
    /// default (currently 300ms) is used.
    /// </summary>
    public long? AsyncTimeoutMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "async_timeout_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("async_timeout_ms", value);
        }
    }

    /// <summary>
    /// The body parameters the webhook tool accepts, described as a JSON Schema
    /// object. These parameters will be passed to the webhook as the body of the
    /// request. See the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
    /// for documentation about the format
    /// </summary>
    public BodyParameters? BodyParameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BodyParameters>(
                "body_parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("body_parameters", value);
        }
    }

    /// <summary>
    /// The headers to be sent to the external tool.
    /// </summary>
    public IReadOnlyList<WebhookHeader>? Headers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookHeader>>(
                "headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WebhookHeader>?>(
                "headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filler messages spoken while a synchronous webhook request is in progress.
    /// `request_start` messages are spoken immediately when the request begins.
    /// `request_response_delayed` messages are spoken after `timing_ms` has elapsed
    /// only if the webhook response is still pending. Filler messages are not used
    /// for asynchronous webhooks.
    /// </summary>
    public IReadOnlyList<WebhookMessage>? Messages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookMessage>>(
                "messages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WebhookMessage>?>(
                "messages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The HTTP method to be used when calling the external tool.
    /// </summary>
    public ApiEnum<string, Method>? Method {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Method>>(
                "method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("method", value);
        }
    }

    /// <summary>
    /// The path parameters the webhook tool accepts, described as a JSON Schema
    /// object. These parameters will be passed to the webhook as the path of the
    /// request if the URL contains a placeholder for a value. See the [JSON Schema
    /// reference](https://json-schema.org/understanding-json-schema) for documentation
    /// about the format
    /// </summary>
    public PathParameters? PathParameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PathParameters>(
                "path_parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("path_parameters", value);
        }
    }

    /// <summary>
    /// Body fields supplied by the assistant configuration rather than by the model.
    /// They are never advertised in the tool definition, so the LLM can neither see
    /// nor set them, and they take precedence over a `body_parameters` value of
    /// the same name. Values support mustache templating, so they can hold dynamic
    /// variables (`{{customer_id}}`) and integration secrets (`{{#integration_secret}}my-secret{{/integration_secret}}`).
    /// Not sent on `GET` requests, which carry no body.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? PresetBodyFields {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "preset_body_fields"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "preset_body_fields",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Query string parameters supplied by the assistant configuration rather than
    /// by the model. They are never advertised in the tool definition, so the LLM
    /// can neither see nor set them, and they take precedence over a `query_parameters`
    /// value of the same name. Values support mustache templating, so they can hold
    /// dynamic variables (`{{telnyx_end_user_target}}`) and integration secrets
    /// (`{{#integration_secret}}my-secret{{/integration_secret}}`). Unlike values
    /// templated directly into the `url`, these are percent-encoded, so a value
    /// such as `+15551234567` survives the round trip.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? PresetQueryParams {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "preset_query_params"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "preset_query_params",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The query parameters the webhook tool accepts, described as a JSON Schema
    /// object. These parameters will be passed to the webhook as the query of the
    /// request. See the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
    /// for documentation about the format
    /// </summary>
    public QueryParameters? QueryParameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<QueryParameters>(
                "query_parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("query_parameters", value);
        }
    }

    /// <summary>
    /// A list of mappings that extract values from the webhook response and store
    /// them as dynamic variables. Each mapping specifies a dynamic variable name
    /// and a dot-notation path to the value in the response body.
    /// </summary>
    public IReadOnlyList<StoreFieldsAsVariable>? StoreFieldsAsVariables {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<StoreFieldsAsVariable>>(
                "store_fields_as_variables"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<StoreFieldsAsVariable>?>(
                "store_fields_as_variables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
        _ = this.Url;
        _ = this.Async;
        _ = this.AsyncTimeoutMs;
        this.BodyParameters?.Validate();
        foreach (var item in this.Headers ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Messages ?? [])
        {
            item.Validate();
        }
        this.Method?.Validate();
        this.PathParameters?.Validate();
        _ = this.PresetBodyFields;
        _ = this.PresetQueryParams;
        this.QueryParameters?.Validate();
        foreach (var item in this.StoreFieldsAsVariables ?? [])
        {
            item.Validate();
        }
    }

    public Webhook ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Webhook (Webhook webhook) : base(webhook)
    {  }
    #pragma warning restore CS8618

    public Webhook (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Webhook (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookFromRaw.FromRawUnchecked"/>
    public static Webhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookFromRaw : IFromRawJson<Webhook>
{
    /// <inheritdoc/>
    public Webhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Webhook.FromRawUnchecked(rawData);
}/// <summary>
/// The body parameters the webhook tool accepts, described as a JSON Schema object.
/// These parameters will be passed to the webhook as the body of the request. See
/// the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
/// for documentation about the format
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BodyParameters, BodyParametersFromRaw>))]
public sealed record class BodyParameters : JsonModel
{
    /// <summary>
    /// The properties of the body parameters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The required properties of the body parameters.
    /// </summary>
    public IReadOnlyList<string>? Required {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "required"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, BodyParametersType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BodyParametersType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Properties;
        _ = this.Required;
        this.Type?.Validate();
    }

    public BodyParameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BodyParameters (BodyParameters bodyParameters) : base(bodyParameters)
    {  }
    #pragma warning restore CS8618

    public BodyParameters (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BodyParameters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BodyParametersFromRaw.FromRawUnchecked"/>
    public static BodyParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class BodyParametersFromRaw : IFromRawJson<BodyParameters>
{
    /// <inheritdoc/>
    public BodyParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BodyParameters.FromRawUnchecked(rawData);
}[JsonConverter(typeof(BodyParametersTypeConverter))]
public enum BodyParametersType
{
    Object
}sealed class BodyParametersTypeConverter : JsonConverter<BodyParametersType>
{
    public override BodyParametersType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "object"=>BodyParametersType.Object, _ =>(BodyParametersType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BodyParametersType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BodyParametersType.Object=>"object",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<WebhookHeader, WebhookHeaderFromRaw>))]
public sealed record class WebhookHeader : JsonModel
{
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The value of the header. Note that we support mustache templating for the
    /// value. For example you can use `Bearer {{#integration_secret}}test-secret{{/integration_secret}}`
    /// to pass the value of the integration secret as the bearer token. [Telnyx
    /// signature headers](https://developers.telnyx.com/docs/voice/programmable-voice/voice-api-webhooks)
    /// will be automatically added to the request.
    /// </summary>
    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public WebhookHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookHeader (WebhookHeader webhookHeader) : base(webhookHeader)
    {  }
    #pragma warning restore CS8618

    public WebhookHeader (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookHeaderFromRaw.FromRawUnchecked"/>
    public static WebhookHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookHeaderFromRaw : IFromRawJson<WebhookHeader>
{
    /// <inheritdoc/>
    public WebhookHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookHeader.FromRawUnchecked(rawData);
}[JsonConverter(typeof(WebhookMessageConverter))]
public record class WebhookMessage : ModelBase
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
            return Match(webhookToolRequestStart: ( x )=>x.Content,
            webhookToolRequestResponseDelayed: ( x )=>x.Content);
        }
    }

    public JsonElement Type {
        get {
            return Match(webhookToolRequestStart: ( x )=>x.Type,
            webhookToolRequestResponseDelayed: ( x )=>x.Type);
        }
    }

    public long? TimingMs {
        get {
            return Match<long?>(webhookToolRequestStart: ( x )=>x.TimingMs,
            webhookToolRequestResponseDelayed: ( x )=>x.TimingMs);
        }
    }

    public WebhookMessage (
        WebhookToolRequestStartMessage value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookMessage (
        WebhookToolRequestResponseDelayedMessage value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public WebhookMessage (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WebhookToolRequestStartMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWebhookToolRequestStart(out var value)) {
///     // `value` is of type `WebhookToolRequestStartMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWebhookToolRequestStart(
        [NotNullWhen(true)] out WebhookToolRequestStartMessage? value
    )
    {
        value =this.Value as WebhookToolRequestStartMessage ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WebhookToolRequestResponseDelayedMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWebhookToolRequestResponseDelayed(out var value)) {
///     // `value` is of type `WebhookToolRequestResponseDelayedMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWebhookToolRequestResponseDelayed(
        [NotNullWhen(true)] out WebhookToolRequestResponseDelayedMessage? value
    )
    {
        value =this.Value as WebhookToolRequestResponseDelayedMessage ;
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
///     (WebhookToolRequestStartMessage value) =&gt; {...},
///     (WebhookToolRequestResponseDelayedMessage value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<WebhookToolRequestStartMessage> webhookToolRequestStart,
        System::Action<WebhookToolRequestResponseDelayedMessage> webhookToolRequestResponseDelayed
    )
    {
        switch (this.Value)
        {
            case WebhookToolRequestStartMessage value:
                webhookToolRequestStart(value);
                break;
            case WebhookToolRequestResponseDelayedMessage value:
                webhookToolRequestResponseDelayed(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of WebhookMessage");

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
///     (WebhookToolRequestStartMessage value) =&gt; {...},
///     (WebhookToolRequestResponseDelayedMessage value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<WebhookToolRequestStartMessage, T> webhookToolRequestStart,
        System::Func<WebhookToolRequestResponseDelayedMessage, T> webhookToolRequestResponseDelayed
    )
    {
        return this.Value switch
        {
            WebhookToolRequestStartMessage value=>webhookToolRequestStart(value),
            WebhookToolRequestResponseDelayedMessage value=>webhookToolRequestResponseDelayed(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of WebhookMessage")
        } ;
    }

    public static implicit operator WebhookMessage (
        WebhookToolRequestStartMessage value
    )=> new(value) ;

    public static implicit operator WebhookMessage (
        WebhookToolRequestResponseDelayedMessage value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of WebhookMessage");
        }
        this.Switch((webhookToolRequestStart) => webhookToolRequestStart.Validate(),
        (webhookToolRequestResponseDelayed) => webhookToolRequestResponseDelayed.Validate());
    }

    public virtual bool Equals(WebhookMessage? other)
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
            WebhookToolRequestStartMessage _=>0,
            WebhookToolRequestResponseDelayedMessage _=>1,
            _ =>-1
        } ;
    }
}sealed class WebhookMessageConverter : JsonConverter<WebhookMessage>
{
    public override WebhookMessage? Read(
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
            var deserialized = JsonSerializer.Deserialize<WebhookToolRequestResponseDelayedMessage>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<WebhookToolRequestStartMessage>(element, options);
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
        Utf8JsonWriter writer,
        WebhookMessage value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<WebhookToolRequestStartMessage, WebhookToolRequestStartMessageFromRaw>))]
public sealed record class WebhookToolRequestStartMessage : JsonModel
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
    /// Speak the filler message immediately when the webhook request begins.
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

    public WebhookToolRequestStartMessage ()
    { this.Type = JsonSerializer.SerializeToElement("request_start"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookToolRequestStartMessage (
        WebhookToolRequestStartMessage webhookToolRequestStartMessage
    ) : base(webhookToolRequestStartMessage)
    {  }
    #pragma warning restore CS8618

    public WebhookToolRequestStartMessage (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("request_start");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookToolRequestStartMessage (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookToolRequestStartMessageFromRaw.FromRawUnchecked"/>
    public static WebhookToolRequestStartMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WebhookToolRequestStartMessage (string content) : this()
    { this.Content = content; }
}class WebhookToolRequestStartMessageFromRaw : IFromRawJson<WebhookToolRequestStartMessage>
{
    /// <inheritdoc/>
    public WebhookToolRequestStartMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookToolRequestStartMessage.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<WebhookToolRequestResponseDelayedMessage, WebhookToolRequestResponseDelayedMessageFromRaw>))]
public sealed record class WebhookToolRequestResponseDelayedMessage : JsonModel
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
    /// The delay in milliseconds from the start of the webhook request.
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
    /// Speak the filler message after the configured delay if the webhook response
    /// is still pending.
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

    public WebhookToolRequestResponseDelayedMessage ()
    {
        this.Type = JsonSerializer.SerializeToElement("request_response_delayed");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookToolRequestResponseDelayedMessage (
        WebhookToolRequestResponseDelayedMessage webhookToolRequestResponseDelayedMessage
    ) : base(webhookToolRequestResponseDelayedMessage)
    {  }
    #pragma warning restore CS8618

    public WebhookToolRequestResponseDelayedMessage (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("request_response_delayed");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookToolRequestResponseDelayedMessage (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WebhookToolRequestResponseDelayedMessageFromRaw.FromRawUnchecked"/>
    public static WebhookToolRequestResponseDelayedMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WebhookToolRequestResponseDelayedMessageFromRaw : IFromRawJson<WebhookToolRequestResponseDelayedMessage>
{
    /// <inheritdoc/>
    public WebhookToolRequestResponseDelayedMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WebhookToolRequestResponseDelayedMessage.FromRawUnchecked(rawData);
}/// <summary>
/// The HTTP method to be used when calling the external tool.
/// </summary>
[JsonConverter(typeof(MethodConverter))]
public enum Method
{
    Get, Post, Put, Delete, Patch
}sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>Method.Get,
            "POST"=>Method.Post,
            "PUT"=>Method.Put,
            "DELETE"=>Method.Delete,
            "PATCH"=>Method.Patch,
            _ =>(Method)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Method value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Method.Get=>"GET",
            Method.Post=>"POST",
            Method.Put=>"PUT",
            Method.Delete=>"DELETE",
            Method.Patch=>"PATCH",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The path parameters the webhook tool accepts, described as a JSON Schema object.
/// These parameters will be passed to the webhook as the path of the request if
/// the URL contains a placeholder for a value. See the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
/// for documentation about the format
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PathParameters, PathParametersFromRaw>))]
public sealed record class PathParameters : JsonModel
{
    /// <summary>
    /// The properties of the path parameters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The required properties of the path parameters.
    /// </summary>
    public IReadOnlyList<string>? Required {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "required"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, PathParametersType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PathParametersType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Properties;
        _ = this.Required;
        this.Type?.Validate();
    }

    public PathParameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PathParameters (PathParameters pathParameters) : base(pathParameters)
    {  }
    #pragma warning restore CS8618

    public PathParameters (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PathParameters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PathParametersFromRaw.FromRawUnchecked"/>
    public static PathParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PathParametersFromRaw : IFromRawJson<PathParameters>
{
    /// <inheritdoc/>
    public PathParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PathParameters.FromRawUnchecked(rawData);
}[JsonConverter(typeof(PathParametersTypeConverter))]
public enum PathParametersType
{
    Object
}sealed class PathParametersTypeConverter : JsonConverter<PathParametersType>
{
    public override PathParametersType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "object"=>PathParametersType.Object, _ =>(PathParametersType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PathParametersType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PathParametersType.Object=>"object",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The query parameters the webhook tool accepts, described as a JSON Schema object.
/// These parameters will be passed to the webhook as the query of the request. See
/// the [JSON Schema reference](https://json-schema.org/understanding-json-schema)
/// for documentation about the format
/// </summary>
[JsonConverter(typeof(JsonModelConverter<QueryParameters, QueryParametersFromRaw>))]
public sealed record class QueryParameters : JsonModel
{
    /// <summary>
    /// The properties of the query parameters.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The required properties of the query parameters.
    /// </summary>
    public IReadOnlyList<string>? Required {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "required"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, QueryParametersType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, QueryParametersType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Properties;
        _ = this.Required;
        this.Type?.Validate();
    }

    public QueryParameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public QueryParameters (QueryParameters queryParameters) : base(
        queryParameters
    )
    {  }
    #pragma warning restore CS8618

    public QueryParameters (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    QueryParameters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="QueryParametersFromRaw.FromRawUnchecked"/>
    public static QueryParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class QueryParametersFromRaw : IFromRawJson<QueryParameters>
{
    /// <inheritdoc/>
    public QueryParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>QueryParameters.FromRawUnchecked(rawData);
}[JsonConverter(typeof(QueryParametersTypeConverter))]
public enum QueryParametersType
{
    Object
}sealed class QueryParametersTypeConverter : JsonConverter<QueryParametersType>
{
    public override QueryParametersType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "object"=>QueryParametersType.Object, _ =>(QueryParametersType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        QueryParametersType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            QueryParametersType.Object=>"object",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<StoreFieldsAsVariable, StoreFieldsAsVariableFromRaw>))]
public sealed record class StoreFieldsAsVariable : JsonModel
{
    /// <summary>
    /// The name of the dynamic variable to store the extracted value in.
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
    /// A dot-notation path to the value in the webhook response body (e.g. 'customer.name'
    /// or 'id').
    /// </summary>
    public required string ValuePath {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value_path"
            );
        }
        init { this._rawData.Set("value_path", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.ValuePath;
    }

    public StoreFieldsAsVariable ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public StoreFieldsAsVariable (
        StoreFieldsAsVariable storeFieldsAsVariable
    ) : base(storeFieldsAsVariable)
    {  }
    #pragma warning restore CS8618

    public StoreFieldsAsVariable (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    StoreFieldsAsVariable (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StoreFieldsAsVariableFromRaw.FromRawUnchecked"/>
    public static StoreFieldsAsVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class StoreFieldsAsVariableFromRaw : IFromRawJson<StoreFieldsAsVariable>
{
    /// <inheritdoc/>
    public StoreFieldsAsVariable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>StoreFieldsAsVariable.FromRawUnchecked(rawData);
}